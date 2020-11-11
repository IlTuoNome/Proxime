# Proxime

![](https://github.com/IlTuoNome/Proxime/blob/master/Proxy/Proxy_GUI/Thumbnail.png)

# Table of contents
1. [Library](https://github.com/IlTuoNome/Mytest#library)
2. [How to](https://github.com/IlTuoNome/Mytest#how-to)

    1 [Start](https://github.com/IlTuoNome/Mytest#start)

    2 [Use events](https://github.com/IlTuoNome/Mytest#use-events) 

    3 [Use methods](https://github.com/IlTuoNome/Mytest#use-methods)

    4 [Use Enum](https://github.com/IlTuoNome/Mytest#use-enum)

3. [Implementation](https://github.com/IlTuoNome/Mytest/blob/main/README.md#implementation)

# Library
We can use the library to retrieve a list of http/https, socks4/5 proxies and test them.


# How to
### Start
Import Proxy.dll by adding reference to the project

Add the namespace:

```csharp
using Proxy; 
```

Instantiate the class:

```csharp
Proxy_Tool Proxy = new Proxy_Tool();
```
### Use events
- The Ip_Rec event warns you when the recovery is finished
- The Test_Rec event warns you when the ip address test is finished

```csharp
        static void Main(string[] args)
        {
            Proxy.Ip_Rec += Ip_Rec;
            Proxy.Test_Rec += Test_Rec;
        }

        static void Ip_Rec(object sender, IPRec Ips)
        {
            Console.WriteLine($"Ip recovered:" + Ips.Ips_Count);
        }

        static void Test_Rec(object sender, TestRec Ips)
        {
            Console.WriteLine($"Ip tested valid:" + Ips.Ips_Val_Count);
        }
```


### Use methods
Start a synchronous recovery:

```csharp
IPRec Ips = Proxy.Recovery(Proxy_Type Type);
``` 

Start an asynchronous recovery:

```csharp
        static async void StartRecover()
        {
            IPRec Ips = await Proxy.Recovery_Async(Proxy_Type Type);
            Console.WriteLine($"Ip recovered:" + Ips.Ips_Count);
        }
```
The return value will contain the instance with the ip addresses found.

Start the test synchronously:

```csharp
TestRec Ips_Test = Proxy.Test(Proxy_Type Type, string[] Ips, byte Threads);
```

Start the test asynchronously:

```csharp
        static async void StartTest()
        {
            TestRec Ips_Test = await Proxy.Test_Async(Proxy_Type Type, string[] Ips, byte Threads);
            Console.WriteLine($"Ip tested valid:" + Ips_Test.Ips_Val_Count);
        }
```
The return value will contain the instance with valid tested ip addresses.

Stop the test:

```csharp
Proxy.Test_Stop();
```
### Use enum

The Proxy_Type enum contains the type of proxy to retrieve/test:
- Http
- Https
- Socks4
- Socks5

Use the enum in the required methods, example: 
```csharp
Proxy.Recovery(Proxy_Tool.Proxy_Type.http);
```


# Implementation
[Behance Design Presentation]()
