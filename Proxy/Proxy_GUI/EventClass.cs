using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Proxy_GUI
{
    /// <summary>
    /// Class to handle events related to the Generic.xaml file
    /// </summary>
    partial class EventClass
    {
        /// <summary>
        /// Field for converting brush colors
        /// </summary>
        private BrushConverter BrushConverter = new BrushConverter();

        /// <summary>
        /// Method to handle the mouseover event on the combobox toggle
        /// </summary>
        private void Border_Toggle_MouseEvent(object sender, MouseEventArgs e)
        {
            Border border = (Border)sender;
            switch (border.IsMouseOver)
            {
                case true:
                    border.Background = (Brush)BrushConverter.ConvertFrom("#0061FF");
                    break;
                case false:
                    border.Background = (Brush)BrushConverter.ConvertFrom("#369FFF");
                    break;
            }
        }

        /// <summary>
        /// Method to manage the mouse click event on the combobox toggle
        /// </summary>
        private void Border_Toggle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Border border = (Border)sender;
            border.MouseEnter -= Border_Toggle_MouseEvent;
            border.MouseLeave -= Border_Toggle_MouseEvent;
            border.Background = (Brush)BrushConverter.ConvertFrom("#B20061FF");
        }

        /// <summary>
        /// Method to manage the release event click mouse on the combobox toggle
        /// </summary>
        private void Border_Toggle_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Border border = (Border)sender;
            border.MouseEnter += Border_Toggle_MouseEvent;
            border.MouseLeave += Border_Toggle_MouseEvent;
            Border_Toggle_MouseEvent(border, e);
        }

    }
}
