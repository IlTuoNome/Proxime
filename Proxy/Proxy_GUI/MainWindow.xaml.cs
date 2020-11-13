using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Leaf.xNet;
using Microsoft.Win32;
using Proxy;

namespace Proxy_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Proxy_Tool Library instance to perform operations
        /// </summary>
        private Proxy_Tool Proxy = new Proxy_Tool();

        /// <summary>
        /// IP results found field
        /// </summary>
        private IPRec iPRec;

        /// <summary>
        /// IP tested results field
        /// </summary>
        private TestRec testRec;

        /// <summary>
        /// Instance to understand if a scan or test has been performed
        /// </summary>
        private bool Scan_Test = false;

        /// <summary>
        /// Instance for retrieving the proxy file for testing
        /// </summary>
        private OpenFileDialog File_To_Test = new OpenFileDialog();

        /// <summary>
        /// Instance for save the proxy file
        /// </summary>
        private SaveFileDialog File_To_Save = new SaveFileDialog();

        public MainWindow()
        {
            InitializeComponent();
            File_To_Test.Filter = "txt files (*.txt)|*.txt";
            File_To_Save.Filter = "txt files (*.txt)|*.txt";
        }

        #region Window/Home/Bar

        #region Window

        /// <summary>
        /// Method to handle the mouseover event on the close of the custom bar
        /// </summary>
        private void Canvas_Window_Bar_Close_MouseEvent(object sender, MouseEventArgs e)
        {
            switch (Canvas_Window_Bar_Close.IsMouseOver)
            {
                case true:
                    switch (IsLight)
                    {
                        case false:
                            VisualStateManager.GoToElementState(Grid_Base, "MouseEnterCloseDark", false);
                            break;
                        case true:
                            VisualStateManager.GoToElementState(Grid_Base, "MouseEnterCloseLight", false);
                            break;
                    }
                    break;
                case false:
                    VisualStateManager.GoToElementState(Grid_Base, "ReduceCloseNormal", false);
                    break;
            }
        }

        /// <summary>
        /// Method to manage the mouse click event on the close of the custom bar
        /// </summary>
        private void Canvas_Window_Bar_Close_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            switch (IsLight)
            {
                case false:
                    VisualStateManager.GoToElementState(Grid_Base, "MouseClickCloseDark", false);
                    break;
                case true:
                    VisualStateManager.GoToElementState(Grid_Base, "MouseClickCloseLight", false);
                    break;
            }
        }

        /// <summary>
        /// Method to handle the mouse release event on the close of the custom bar
        /// </summary>
        private void Canvas_Window_Bar_Close_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Method to handle the mouseover event on the reduce of the custom bar
        /// </summary>
        private void Canvas_Window_Bar_Reduce_MouseEvent(object sender, MouseEventArgs e)
        {
            switch (Canvas_Window_Bar_Reduce.IsMouseOver)
            {
                case true:
                    switch (IsLight)
                    {
                        case false:
                            VisualStateManager.GoToElementState(Grid_Base, "MouseEnterReduceDark", false);
                            break;
                        case true:
                            VisualStateManager.GoToElementState(Grid_Base, "MouseEnterReduceLight", false);
                            break;
                    }
                    break;
                case false:
                    VisualStateManager.GoToElementState(Grid_Base, "ReduceCloseNormal", false);
                    break;
            }
        }

        /// <summary>
        /// Method to manage the mouse click event on the reduce of the custom bar
        /// </summary>
        private void Canvas_Window_Bar_Reduce_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            switch (IsLight)
            {
                case false:
                    VisualStateManager.GoToElementState(Grid_Base, "MouseClickReduceDark", false);
                    break;
                case true:
                    VisualStateManager.GoToElementState(Grid_Base, "MouseClickReduceLight", false);
                    break;
            }
        }

        /// <summary>
        /// Method to handle the mouse release event on the reduce of the custom bar
        /// </summary>
        private void Canvas_Window_Bar_Reduce_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.WindowStyle = WindowStyle.SingleBorderWindow;
            this.WindowState = WindowState.Minimized;
        }

        /// <summary>
        /// Method to reset window borders
        /// </summary>
        private void Window_Gui_Activated(object sender, EventArgs e)
        {
            switch(this.WindowState)
            {
                case WindowState.Minimized:
                    Dispatcher.BeginInvoke(DispatcherPriority.ApplicationIdle, new Action(() => WindowStyle = WindowStyle.None));
                    break;
            }
        }

        #endregion

        #region Bar

        /// <summary>
        /// Method to manage the click on UPP to return to the home in the bar
        /// </summary>
        private void Textblock_Bar_Upp_MouseClick(object sender, MouseButtonEventArgs e)
        {
            VisualStateManager.GoToElementState(Grid_Base, "MouseUPPClick", false);
        }

        /// <summary>
        /// Method to handle the mouseover event for settings on the bar
        /// </summary>
        private void Bord_Bar_Settings_MouseEvent(object sender, MouseEventArgs e)
        {
            switch (Bord_Bar_Settings.IsMouseOver)
            {
                case true:
                    VisualStateManager.GoToElementState(Grid_Base, "Path_Settings_Hover", false);
                    break;
                case false:
                    VisualStateManager.GoToElementState(Grid_Base, "Path_Settings_Normal", false);
                    break;
            }
        }

        /// <summary>
        /// Method to handle the mouse click event on settings on the bar
        /// </summary>
        private void Bord_Bar_Settings_MouseClick(object sender, MouseEventArgs e)
        {
            VisualStateManager.GoToElementState(Grid_Base, "Path_Settings_Clicked", false);
        }

        /// <summary>
        /// Method to handle the mouse release event on the settings on the bar to open the grid
        /// </summary>
        private void Bord_Bar_Settings_MouseUp(object sender, MouseButtonEventArgs e)
        {
            VisualStateManager.GoToElementState(Grid_Base, "MouseSettingsClick", false);
        }

        #endregion

        #region Scan

        /// <summary>
        /// Method to handle the mouseover event on home scan
        /// </summary>
        private void Grid_Home_Scan_MouseEvent(object sender, MouseEventArgs e)
        {
            switch (Grid_Home_Scan.IsMouseOver)
            {
                case true:
                    switch (IsLight)
                    {
                        case false:
                            VisualStateManager.GoToElementState(Grid_Base, "MouseEnterScanDark", false);
                            break;
                        case true:
                            VisualStateManager.GoToElementState(Grid_Base, "MouseEnterScanLight", false);
                            break;
                    }
                    break;
                case false:
                    VisualStateManager.GoToElementState(Grid_Base, "MouseLeaveScan", false);
                    break;
            }
        }

        /// <summary>
        /// Method to manage the click mouse on scan event of the home
        /// </summary>
        private void Grid_Home_Scan_MouseClick(object sender, MouseEventArgs e)
        {
            switch (IsLight)
            {
                case false:
                    VisualStateManager.GoToElementState(Grid_Base, "MouseClickScanDark", false);
                    break;
                case true:
                    VisualStateManager.GoToElementState(Grid_Base, "MouseClickScanLight", false);
                    break;
            }
        }

        /// <summary>
        /// Method to handle the mouse release event on home scan to start recovery
        /// </summary>
        private async void Grid_Home_Scan_MouseUp(object sender, MouseButtonEventArgs e)
        {
            VisualStateManager.GoToElementState(Grid_Base, "MouseLoadingClick", false);
            ProgressBar_Loading.Value = 30;
            TextBlock_Loading_Info.Margin = new Thickness(245, 256, 242, 268);
            TextBlock_Loading_Info.Text = "Searching for proxies...";

            try
            {
                iPRec = await Proxy.Recovery_Async((Proxy_Tool.Proxy_Type)Enum.Parse(typeof(Proxy_Tool.Proxy_Type), Combobox_Settings_Proxy.Ltext.ToLower()));
                Scan_Test = false;
                switch(Checkbox_Settings_Test.IsChecked)
                {
                    case true:
                        ProgressBar_Loading.Value = 60;
                        TextBlock_Loading_Info.Margin = new Thickness(251, 256, 237, 268);
                        TextBlock_Loading_Info.Text = "Testing the proxies...";
                        testRec = await Proxy.Test_Async((Proxy_Tool.Proxy_Type)Enum.Parse(typeof(Proxy_Tool.Proxy_Type), Combobox_Settings_Proxy.Ltext.ToLower()), iPRec.Ips_Get, NumericUpDown_Settings_Proxy.Valore);
                        Scan_Test = true;
                        break;
                }
                VisualStateManager.GoToElementState(Grid_Base, "MouseLoadingFinish", false);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                VisualStateManager.GoToElementState(Grid_Base, "MouseUPPClick", false);
            }
        }
        #endregion

        #region Test
        /// <summary>
        /// Method to handle the mouseover event on home test
        /// </summary>
        private void Grid_Home_Test_MouseEvent(object sender, MouseEventArgs e)
        {
            switch (Grid_Home_Test.IsMouseOver)
            {
                case true:
                    switch (IsLight)
                    {
                        case false:
                            VisualStateManager.GoToElementState(Grid_Base, "MouseEnterTestDark", false);
                            break;
                        case true:
                            VisualStateManager.GoToElementState(Grid_Base, "MouseEnterTestLight", false);
                            break;
                    }
                    break;
                case false:
                    VisualStateManager.GoToElementState(Grid_Base, "MouseLeaveTest", false);
                    break;
            }
        }

        /// <summary>
        /// Method to manage the click mouse on test event of the home
        /// </summary>
        private void Grid_Home_Test_MouseClick(object sender, MouseEventArgs e)
        {
            switch (IsLight)
            {
                case false:
                    VisualStateManager.GoToElementState(Grid_Base, "MouseClickTestDark", false);
                    break;
                case true:
                    VisualStateManager.GoToElementState(Grid_Base, "MouseClickTestLight", false);
                    break;
            }
        }

        /// <summary>
        /// Method to handle the drop mouseover event on home test
        /// </summary>
        private void Grid_Home_Test_PreviewDrop(object sender, DragEventArgs e)
        {
            switch (IsLight)
            {
                case false:
                    VisualStateManager.GoToElementState(Grid_Base, "MouseEnterTestDark", false);
                    break;
                case true:
                    VisualStateManager.GoToElementState(Grid_Base, "MouseEnterTestLight", false);
                    break;
            }
        }

        /// <summary>
        /// Method to handle the drop mouseleave event on home test
        /// </summary>
        private void Grid_Home_Test_PreviewDragLeave(object sender, DragEventArgs e)
        {
            VisualStateManager.GoToElementState(Grid_Base, "MouseLeaveTest", false);
        }

        /// <summary>
        /// Method to manage the release of the mouse on test in home to select the file with the ips
        /// </summary>
        private void Grid_Home_Test_MouseUp(object sender, MouseButtonEventArgs e)
        {
            switch(File_To_Test.ShowDialog())
            {
                case true:
                    Test_Start(File_To_Test.FileName);
                    break;
            }
        }

        /// <summary>
        /// Method to manage the release of the drop on test in home to select the file with the ips
        /// </summary>
        private void Grid_Home_Test_DragDrop(object sender, DragEventArgs e)
        {
            Grid_Home_Test_PreviewDragLeave(sender, e);

            string[] File_Path = (string[])e.Data.GetData(DataFormats.FileDrop);

            switch (System.IO.Path.GetExtension(File_Path[0]))
            {
                case ".txt":
                    Test_Start(File_Path[0]);
                    break;
            }
        }

        /// <summary>
        /// Method to start ip address test
        /// </summary>
        /// <param name="Path">File path</param>
        private async void Test_Start(string Path)
        {
            VisualStateManager.GoToElementState(Grid_Base, "MouseLoadingClick", false);
            string[] Ips = File.ReadAllLines(Path);
            ProgressBar_Loading.Value = 60;
            TextBlock_Loading_Info.Margin = new Thickness(251, 256, 237, 268);
            TextBlock_Loading_Info.Text = "Testing the proxies...";

            try
            {
                testRec = await Proxy.Test_Async((Proxy_Tool.Proxy_Type)Enum.Parse(typeof(Proxy_Tool.Proxy_Type), Combobox_Settings_Proxy.Ltext.ToLower()), Ips, NumericUpDown_Settings_Proxy.Valore);
                Scan_Test = true;
                VisualStateManager.GoToElementState(Grid_Base, "MouseLoadingFinish", false);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                VisualStateManager.GoToElementState(Grid_Base, "MouseUPPClick", false);
            }
        }
        #endregion

        #region Dark/Light

        /// <summary>
        /// Method to handle the mouseover event on home light/dark
        /// </summary>
        private void Canvas_Path_Theme_MouseEvent(object sender, MouseEventArgs e)
        {
            switch (IsLight)
            {
                case true:
                    switch (Canvas_Path_Light.IsMouseOver)
                    {
                        case true:
                            VisualStateManager.GoToElementState(Grid_Base, "Path_Light_Hover", false);
                            break;
                        case false:
                            VisualStateManager.GoToElementState(Grid_Base, "Path_Light_Normal", false);
                            break;
                    }
                    break;
                case false:
                    switch (Canvas_Path_Theme.IsMouseOver)
                    {
                        case true:
                            VisualStateManager.GoToElementState(Grid_Base, "Path_Dark_Hover", false);
                            break;
                        case false:
                            VisualStateManager.GoToElementState(Grid_Base, "Path_Dark_Normal", false);
                            break;
                    }
                    break;
            }
        }

        /// <summary>
        /// Method to manage the click mouse event on home light/dark
        /// </summary>
        private void Canvas_Path_Theme_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            switch (IsLight)
            {
                case true:
                    VisualStateManager.GoToElementState(Grid_Base, "Path_Light_Click", false);
                    break;
                case false:
                    VisualStateManager.GoToElementState(Grid_Base, "Path_Dark_Click", false);
                    break;
            }
        }

        /// <summary>
        /// Field for converting brush colors
        /// </summary>
        private BrushConverter BrushConverter = new BrushConverter();

        /// <summary>
        /// Field for converting general colors
        /// </summary>
        private ColorConverter ColorConverter = new ColorConverter();

        /// <summary>
        /// Field to understand if we are in light/dark theme
        /// </summary>
        private bool IsLight = false;

        /// <summary>
        /// Method to handle the mouse release event on home light/dark for changing theme
        /// </summary>
        private void Canvas_Path_Theme_MouseUp(object sender, MouseButtonEventArgs e)
        {
            switch (IsLight)
            {
                case false: //Dark to Light
                    IsLight = true;
                    Canvas_Path_Light.Visibility = Visibility.Visible;
                    Canvas_Path_Theme.Visibility = Visibility.Hidden;

                    this.Resources["Button_ShadowDepth"] = 1.9;
                    this.Resources["NonButton_ShadowDepth"] = 1.0;

                    this.Resources["Windows_Bar"] = BrushConverter.ConvertFrom("#FFFFFF");
                    this.Resources["Canvas_Window_Bar_Reduce"] = BrushConverter.ConvertFrom("#000000");
                    this.Resources["Canvas_Window_Bar_Close"] = BrushConverter.ConvertFrom("#000000");

                    this.Resources["Rectangle_Bar_Base_Shadows"] = ColorConverter.ConvertFrom("#888888");
                    this.Resources["Textblock_Bar_Upp"] = BrushConverter.ConvertFrom("#F4F4F4");
                    this.Resources["Textblock_Bar_Home"] = BrushConverter.ConvertFrom("#333333");

                    this.Resources["Grid_Home_Scan"] = BrushConverter.ConvertFrom("#F4F4F4");
                    this.Resources["Textblock_Home_Scan"] = BrushConverter.ConvertFrom("#333333");
                    this.Resources["Textblock_Home_Scan_Search"] = BrushConverter.ConvertFrom("#333333");

                    this.Resources["Grid_Home_Test"] = BrushConverter.ConvertFrom("#F4F4F4");
                    this.Resources["Textblock_Home_Test"] = BrushConverter.ConvertFrom("#333333");
                    this.Resources["Textblock_Home_Test_DropBrowse"] = BrushConverter.ConvertFrom("#333333");

                    this.Resources["Grid_Settings"] = BrushConverter.ConvertFrom("#F4F4F4");
                    this.Resources["Textblock_Settings_Test"] = BrushConverter.ConvertFrom("#333333");
                    this.Resources["CheckBoxMod_Settings_Checker_Shadow"] = ColorConverter.ConvertFrom("#999999");
                    Checkbox_Settings_Test_Checked(this, e);
                    this.Resources["Textblock_Settings_Threads"] = BrushConverter.ConvertFrom("#333333");
                    this.Resources["NumericUpDown_Settings_Background"] = BrushConverter.ConvertFrom("#999999");
                    this.Resources["NumericUpDown_Settings_Background_Shadow"] = ColorConverter.ConvertFrom("#999999");
                    this.Resources["Textblock_Settings_Proxy"] = BrushConverter.ConvertFrom("#333333");
                    this.Resources["Combobox_Settings_Proxy_List_Background"] = BrushConverter.ConvertFrom("#999999");
                    this.Resources["Combobox_Settings_Proxy_Background_Shadow"] = ColorConverter.ConvertFrom("#999999");
                    this.Resources["Combobox_Settings_Proxy_List_Selected_Background"] = BrushConverter.ConvertFrom("#666666");

                    this.Resources["Grid_Loading"] = BrushConverter.ConvertFrom("#F4F4F4");
                    this.Resources["ProgressBar_Loading_Background"] = BrushConverter.ConvertFrom("#999999");
                    this.Resources["ProgressBar_Loading_Shadow"] = ColorConverter.ConvertFrom("#999999");
                    this.Resources["TextBlock_Loading_Info"] = BrushConverter.ConvertFrom("#333333");
                    this.Resources["Button_Loading_See_Background"] = BrushConverter.ConvertFrom("#ABCCE9");
                    this.Resources["Button_Loading_Save_Background"] = BrushConverter.ConvertFrom("#CCCCCC");
                    this.Resources["Buttons_Loading_Shadow"] = ColorConverter.ConvertFrom("#999999");

                    this.Resources["Grid_Results"] = BrushConverter.ConvertFrom("#F4F4F4");
                    this.Resources["DataGrid_Results_Path_Up"] = BrushConverter.ConvertFrom("#F4F4F4");
                    this.Resources["DataGrid_Results_Lists_Background"] = BrushConverter.ConvertFrom("#999999");
                    break;
                case true: //Light to Dark
                    IsLight = false;
                    Canvas_Path_Light.Visibility = Visibility.Hidden;
                    Canvas_Path_Theme.Visibility = Visibility.Visible;

                    this.Resources["Button_ShadowDepth"] = 3.1;
                    this.Resources["NonButton_ShadowDepth"] = 1.0;

                    this.Resources["Windows_Bar"] = BrushConverter.ConvertFrom("#000000");
                    this.Resources["Canvas_Window_Bar_Reduce"] = BrushConverter.ConvertFrom("#FFFFFF");
                    this.Resources["Canvas_Window_Bar_Close"] = BrushConverter.ConvertFrom("#FFFFFF");

                    this.Resources["Rectangle_Bar_Base_Shadows"] = ColorConverter.ConvertFrom("#202020");
                    this.Resources["Textblock_Bar_Upp"] = BrushConverter.ConvertFrom("#333333");
                    this.Resources["Textblock_Bar_Home"] = BrushConverter.ConvertFrom("#FFF4F4F4");

                    this.Resources["Grid_Home_Scan"] = BrushConverter.ConvertFrom("#FF333333");
                    this.Resources["Textblock_Home_Scan"] = BrushConverter.ConvertFrom("#FFF4F4F4");
                    this.Resources["Textblock_Home_Scan_Search"] = BrushConverter.ConvertFrom("#FFCCCCCC");

                    this.Resources["Grid_Home_Test"] = BrushConverter.ConvertFrom("#FF333333");
                    this.Resources["Textblock_Home_Test"] = BrushConverter.ConvertFrom("#FFF4F4F4");
                    this.Resources["Textblock_Home_Test_DropBrowse"] = BrushConverter.ConvertFrom("#FFCCCCCC");

                    this.Resources["Grid_Settings"] = BrushConverter.ConvertFrom("#FF333333");
                    this.Resources["Textblock_Settings_Test"] = BrushConverter.ConvertFrom("#FFF4F4F4");
                    this.Resources["CheckBoxMod_Settings_Checker_Shadow"] = ColorConverter.ConvertFrom("#FF141414");
                    Checkbox_Settings_Test_Checked(this, e);
                    this.Resources["Textblock_Settings_Threads"] = BrushConverter.ConvertFrom("#FFF4F4F4");
                    this.Resources["NumericUpDown_Settings_Background"] = BrushConverter.ConvertFrom("#FF666666");
                    this.Resources["NumericUpDown_Settings_Background_Shadow"] = ColorConverter.ConvertFrom("#FF202020");
                    this.Resources["Textblock_Settings_Proxy"] = BrushConverter.ConvertFrom("#FFF4F4F4");
                    this.Resources["Combobox_Settings_Proxy_List_Background"] = BrushConverter.ConvertFrom("#666666");
                    this.Resources["Combobox_Settings_Proxy_Background_Shadow"] = ColorConverter.ConvertFrom("#FF202020");
                    this.Resources["Combobox_Settings_Proxy_List_Selected_Background"] = BrushConverter.ConvertFrom("#999999");

                    this.Resources["Grid_Loading"] = BrushConverter.ConvertFrom("#FF333333");
                    this.Resources["ProgressBar_Loading_Background"] = BrushConverter.ConvertFrom("#FF666666");
                    this.Resources["ProgressBar_Loading_Shadow"] = ColorConverter.ConvertFrom("#FF202020");
                    this.Resources["TextBlock_Loading_Info"] = BrushConverter.ConvertFrom("#FFCCCCCC");
                    this.Resources["Button_Loading_See_Background"] = BrushConverter.ConvertFrom("#3A648A");
                    this.Resources["Button_Loading_Save_Background"] = BrushConverter.ConvertFrom("#484848");
                    this.Resources["Buttons_Loading_Shadow"] = ColorConverter.ConvertFrom("#FF202020");

                    this.Resources["Grid_Results"] = BrushConverter.ConvertFrom("#FF333333");
                    this.Resources["DataGrid_Results_Path_Up"] = BrushConverter.ConvertFrom("#333333");
                    this.Resources["DataGrid_Results_Lists_Background"] = BrushConverter.ConvertFrom("#666666");
                    break;
            }
        }
        #endregion

        #endregion

        #region Settings

        /// <summary>
        /// Method for changing the theme on the checkbox
        /// </summary>
        private void Checkbox_Settings_Test_Checked(object sender, RoutedEventArgs e)
        {
            switch(Checkbox_Settings_Test.IsChecked)
            {
                case true:
                    switch(IsLight)
                    {
                        case false:
                            this.Resources["CheckBoxMod_Settings_Background"] = BrushConverter.ConvertFrom("#FF666666");
                            this.Resources["CheckBoxMod_Settings_Checker"] = BrushConverter.ConvertFrom("#369FFF");
                            break;
                        case true:
                            this.Resources["CheckBoxMod_Settings_Background"] = BrushConverter.ConvertFrom("#999999");
                            this.Resources["CheckBoxMod_Settings_Checker"] = BrushConverter.ConvertFrom("#369FFF");
                            break;
                    }
                    break;
                case false:
                    switch (IsLight)
                    {
                        case false:
                            this.Resources["CheckBoxMod_Settings_Background"] = BrushConverter.ConvertFrom("#484848");
                            this.Resources["CheckBoxMod_Settings_Checker"] = BrushConverter.ConvertFrom("#3A648A");
                            break;
                        case true:
                            this.Resources["CheckBoxMod_Settings_Background"] = BrushConverter.ConvertFrom("#CCCCCC");
                            this.Resources["CheckBoxMod_Settings_Checker"] = BrushConverter.ConvertFrom("#ABCCE9");
                            break;
                    }
                    break;
            }
        }

        /// <summary>
        /// Field to manage the combobox
        /// </summary>
        private byte first = 0;

        /// <summary>
        /// Method to manage the combobox selection behavior
        /// </summary>
        private void Combobox_Settings_Proxy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (first)
            {
                case 0:
                    first = 1;
                    Combobox_Settings_Proxy.Ltext = "Http";
                    Combobox_Settings_Proxy.Items.Remove(Combobox_Settings_Proxy.SelectedItem);
                    break;
                case 1:
                    first = 2;
                    break;
                case 2:
                    first = 1;
                    TextBlock textBlock_nuovo = new TextBlock();
                    textBlock_nuovo.Text = Combobox_Settings_Proxy.Ltext;
                    Combobox_Settings_Proxy.Items.Add(textBlock_nuovo);
                    Combobox_Settings_Proxy.Ltext = ((TextBlock)Combobox_Settings_Proxy.SelectedItem).Text;
                    Combobox_Settings_Proxy.Items.Remove(Combobox_Settings_Proxy.SelectedItem);
                    break;
            }

        }


        #endregion

        #region Loading

        /// <summary>
        /// Method to handle the mouse click event on the see button to see the results
        /// </summary>
        private void Button_Loading_See_Click(object sender, RoutedEventArgs e)
        {
            switch (Scan_Test)
            {
                case false:
                    DataGrid_Results.ItemsSource = iPRec.Ips_Get;
                    break;
                case true:
                    DataGrid_Results.ItemsSource = testRec.Ips_Val_Get;
                    break;
            }

            VisualStateManager.GoToElementState(Grid_Base, "ResultsClick", false);
        }

        /// <summary>
        /// Method to handle the mouse click event on the save button to save the results
        /// </summary>
        private void Button_Loading_Save_Click(object sender, RoutedEventArgs e)
        {
            switch(File_To_Save.ShowDialog())
            {
                case true:
                    switch(Scan_Test)
                    {
                        case false:
                            File.WriteAllLines(File_To_Save.FileName, iPRec.Ips_Get);
                            break;
                        case true:
                            File.WriteAllLines(File_To_Save.FileName, testRec.Ips_Val_Get);
                            break;
                    }
                    break;
            }
        }

        #endregion

        #region Results

        /// <summary>
        /// Method to handle the click event on the result border to copy the IP address
        /// </summary>
        private void Border_Ip_Copia(object sender, MouseEventArgs e)
        {
            Border cmd = (Border)sender;
            Clipboard.SetText(cmd.DataContext.ToString().Split(':')[0].Replace(":", ""));
        }

        /// <summary>
        /// Method to handle the click event on the result border to copy the PORT address
        /// </summary>
        private void Border_Port_Copia(object sender, MouseEventArgs e)
        {
            Border cmd = (Border)sender;
            Clipboard.SetText(cmd.DataContext.ToString().Split(':')[1].Replace(":", ""));
        }

        /// <summary>
        /// Method to handle the focus event on the edge of the result
        /// </summary>
        private void DGR_Border_GotFocus(object sender, RoutedEventArgs e)
        {
            Border border = (Border)sender;
            switch (IsLight)
            {
                case true:
                    border.Background = (Brush)BrushConverter.ConvertFrom("#666666");
                    break;
                case false:
                    border.Background = (Brush)BrushConverter.ConvertFrom("#999999");
                    break;
            }
        }

        /// <summary>
        /// Method to handle the focus leave event on the result border
        /// </summary>
        private void DGR_Border_LostFocus(object sender, RoutedEventArgs e)
        {
            Border border = (Border)sender;
            switch (IsLight)
            {
                case true:
                    border.Background = (Brush)BrushConverter.ConvertFrom("#999999");
                    break;
                case false:
                    border.Background = (Brush)BrushConverter.ConvertFrom("#666666");
                    break;
            }
        }

        /// <summary>
        /// Field to manage the display of the Grid UP of the results
        /// </summary>
        private double conto;

        /// <summary>
        /// Method to manage the display of the Grid UP of the results
        /// </summary>
        private void DataGrid_Results_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            conto += e.VerticalChange;
            switch (conto)
            {
                case 0:
                    DataGrid_Results.UpshowVisibility = Visibility.Hidden;
                    break;
                default:
                    DataGrid_Results.UpshowVisibility = Visibility.Visible;
                    break;
            }
        }

        #endregion

    }

    /// <summary>
    /// Class to convert the whole result to ip
    /// </summary>
    public class IPConverter : IValueConverter
    {
        /// <summary>
        /// Method to convert the result to ip
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string original = (string)value;
            return original.Split(':')[0].Replace(":", "");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Class to convert the whole result to port
    /// </summary>
    public class PortConverter : IValueConverter
    {
        /// <summary>
        /// Method to convert the result to port
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string original = (string)value;
            return original.Split(':')[1].Replace(":", "");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
