using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Proxy_GUI
{
    /// <summary>
    /// Class for the modified combobox
    /// </summary>
    public class ComboboxModde : ComboBox
    {
        static ComboboxModde()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ComboboxModde), new FrameworkPropertyMetadata(typeof(ComboboxModde)));
        }

        /// <summary>
        /// Properties for displaying text after removal in the list
        /// </summary>
        public Visibility Lvis
        {
            get { return (Visibility)GetValue(LvisProperty); }
            set { SetValue(LvisProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Lvis.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LvisProperty =
            DependencyProperty.Register("Lvis", typeof(Visibility), typeof(ComboboxModde), new PropertyMetadata(Visibility.Hidden));


        /// <summary>
        /// Properties to set the text to be displayed
        /// </summary>
        public string Ltext
        {
            get { return (string)GetValue(LtextProperty); }
            set { SetValue(LtextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Ltext.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LtextProperty =
            DependencyProperty.Register("Ltext", typeof(string), typeof(ComboboxModde), new PropertyMetadata(""));
    }
}
