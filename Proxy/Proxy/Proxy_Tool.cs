using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Leaf.xNet;


namespace Proxy
{
    /// <summary>
    /// Proxy recovery and testing class
    /// </summary>
    public class Proxy_Tool
    {
        /// <summary>
        /// Event to warn that the retrieval of the ip addresses is finished
        /// </summary>
        public EventHandler<IPRec> Ip_Rec;

        /// <summary>
        /// Event to warn that the ip address test is finished
        /// </summary>
        public EventHandler<TestRec> Test_Rec;

        /// <summary>
        /// Field to end the tests
        /// </summary>
        private CancellationTokenSource Task_Token;

        /// <summary>
        /// Field to check if the test has been started
        /// </summary>
        private bool Test_Start = false;

        /// <summary>
        /// Method to retrieve ip addresses from sources synchronously
        /// </summary>
        /// <param name="Type">Type of proxy to retrieve</param>
        /// <returns>Returns the IPRec instance containing the retrieved ip addresses</returns>
        public IPRec Recovery(Proxy_Type Type)
        {
            IPRec Ips = new IPRec();
            using (HttpRequest Richiesta = new HttpRequest())
            {
                string Risposta;

                Richiesta.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:80.0) Gecko/20100101 Firefox/80.0";

                try
                {
                    string Link;
                    switch (Type)
                    {
                        case Proxy_Type.http:
                            Link = "https://api.proxyscrape.com/v2/?request=getproxies&protocol=http&timeout=10000&country=all&ssl=no&anonymity=all&simplified=true";
                            break;
                        case Proxy_Type.https:
                            Link = "https://api.proxyscrape.com/v2/?request=getproxies&protocol=http&timeout=10000&country=all&ssl=yes&anonymity=all&simplified=true";
                            break;
                        default:
                            Link = $"https://api.proxyscrape.com/v2/?request=getproxies&protocol={Type}&timeout=10000&country=all";
                            break;
                    }
                    Risposta = Richiesta.Get(Link).ToString();
                }
                catch (HttpException)
                {
                    try
                    {
                        Risposta = Richiesta.Get($"https://www.proxy-list.download/api/v1/get?type={Type}").ToString();
                    }
                    catch (HttpException Errore)
                    {
                        throw new Exception($"Problem with connection or sources.\n{Errore.Message}");
                    }
                }

                foreach (Match Ip in Regex.Matches(Risposta, @"\d{1,3}.\d{1,3}.\d{1,3}.\d{1,3}:\d{1,5}"))
                {
                    Ips.Ip_Set = Ip.Value;
                }

                Ip_Rec?.Invoke(this, Ips);
            }
            return Ips;
        }

        /// <summary>
        /// Method to retrieve ip addresses from sources asynchronously
        /// </summary>
        /// <param name="Type">Type of proxy to retrieve</param>
        /// <returns>Returns the IPRec instance containing the retrieved ip addresses</returns>
        public Task<IPRec> Recovery_Async(Proxy_Type Type)
        {
            return Task.Run(() => Recovery(Type));
        }

        /// <summary>
        /// Method for testing IP addresses synchronously
        /// </summary>
        /// <param name="Type">Type of proxy to test</param>
        /// <param name="Ips">IP addresses to be tested</param>
        /// <param name="Threads">Parallel threads</param>
        /// <returns>Returns the TestRec instance containing the tested ip addresses</returns>
        public TestRec Test(Proxy_Type Type, string[] Ips, byte Threads)
        {
            switch (Ips.Length)
            {
                case 0:
                    throw new ArgumentException("There are no ip addresses.", "Ips");
            }

            switch (Threads)
            {
                case 0:
                    Threads = 1;
                    break;
            }

            TestRec Ips_Val = new TestRec();
            using (Task_Token = new CancellationTokenSource())
            {

                ParallelOptions OPT = new ParallelOptions();
                OPT.MaxDegreeOfParallelism = Threads;
                OPT.CancellationToken = Task_Token.Token;
                Test_Start = true;

                try
                {
                    Parallel.ForEach(Ips, OPT, Ip =>
                    {
                        using (HttpRequest Richiesta = new HttpRequest())
                        {
                            Richiesta.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:80.0) Gecko/20100101 Firefox/80.0";

                            switch (Type)
                            {
                                case Proxy_Type.http:
                                case Proxy_Type.https:
                                    Richiesta.Proxy = HttpProxyClient.Parse(Ip);
                                    break;
                                case Proxy_Type.socks4:
                                    Richiesta.Proxy = Socks4ProxyClient.Parse(Ip);
                                    break;
                                case Proxy_Type.socks5:
                                    Richiesta.Proxy = Socks5ProxyClient.Parse(Ip);
                                    break;
                            }

                            try
                            {
                                Richiesta.Get($"https://google.com");
                                Ips_Val.Ip_Val_Set = Ip;
                            }
                            catch (HttpException) 
                            {
                                //Null
                            };
                        }
                    });
                }
                catch (OperationCanceledException)
                {
                    //NULL
                }

                Test_Start = false;
                Test_Rec?.Invoke(this, Ips_Val);
            }
            return Ips_Val;
        }

        /// <summary>
        /// Method for testing IP addresses asynchronously
        /// </summary>
        /// <param name="Type">Type of proxy to test</param>
        /// <param name="Ips">IP addresses to be tested</param>
        /// <param name="Threads">Parallel threads</param>
        /// <returns>Returns the TestRec instance containing the tested ip addresses</returns>
        public Task<TestRec> Test_Async(Proxy_Type Type, string[] Ips, byte Threads)
        {
            return Task.Run(() => Test(Type, Ips, Threads));
        }

        /// <summary>
        /// Enum of proxy types to retrieve / test
        /// </summary>
        public enum Proxy_Type
        {
            http,
            https,
            socks4,
            socks5
        }

        /// <summary>
        /// Method to stop the ip address test
        /// </summary>
        public void Test_Stop()
        {
            switch(Test_Start)
            {
                case true:
                    Task_Token.Cancel();
                    break;
                case false:
                    throw new Exception("Test non avviato o già stoppato.");
            }
        }
    }

    /// <summary>
    /// Class to hold the retrieved ip addresses
    /// </summary>
    public class IPRec : EventArgs
    {
        /// <summary>
        /// List with the ip addresses found
        /// </summary>
        private List<string> Ips = new List<string>();

        /// <summary>
        /// Properties to set the ip address found
        /// </summary>
        internal string Ip_Set 
        {
            set { Ips.Add(value); }
        }

        /// <summary>
        /// Property to retrieve the ip addresses found in array format
        /// </summary>
        public string[] Ips_Get
        {
            get { return Ips.ToArray(); }
        }

        /// <summary>
        /// Properties to retrieve the number of ip found
        /// </summary>
        public int Ips_Count
        {
            get { return Ips.Count; }
        }
    }

    /// <summary>
    /// Class to hold tested IP addresses
    /// </summary>
    public class TestRec : EventArgs
    {
        /// <summary>
        /// List with valid ip addresses found
        /// </summary>
        private List<string> Ips_Val = new List<string>();

        /// <summary>
        /// Properties to set the valid ip address found
        /// </summary>
        internal string Ip_Val_Set
        {
            set { Ips_Val.Add(value); }
        }

        /// <summary>
        /// Property to retrieve valid ip addresses in array format
        /// </summary>
        public string[] Ips_Val_Get
        {
            get { return Ips_Val.ToArray(); }
        }

        /// <summary>
        /// Properties to retrieve the number of ip found
        /// </summary>
        public int Ips_Val_Count
        {
            get { return Ips_Val.Count; }
        }
    }
}
