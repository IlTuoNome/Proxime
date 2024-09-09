using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Class for the modified NumericUpDown
    /// </summary>
    public class NumericUpDown : Control
    {
        static NumericUpDown()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NumericUpDown), new FrameworkPropertyMetadata(typeof(NumericUpDown)));
        }

        // Using a DependencyProperty as the backing store for Valore.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValoreProperty =
            DependencyProperty.Register("Valore", typeof(byte), typeof(NumericUpDown), new PropertyMetadata(Convert.ToByte(0)));

        /// <summary>
        /// Property to manage the value
        /// </summary>
        public byte Valore
        {
            get { return (byte)GetValue(ValoreProperty); }
            set 
            {
                if (value != 0)
                {
                    SetValue(ValoreProperty, value);
                }
            }
        }

        /// <summary>
        /// Fields of up/down buttons
        /// </summary>
        private RepeatButton Repeat_Up, Repeat_Down;

        /// <summary>
        /// Field for displaying the value
        /// </summary>
        private TextBlock TextBlock_Num;

        /// <summary>
        /// Properties to manage the display of the value
        /// </summary>
        private TextBlock TextBlock_NUM
        {
            get { return TextBlock_Num; }

            set { TextBlock_Num = value; }
        }

        /// <summary>
        /// Properties to manage the up button
        /// </summary>
        private RepeatButton Repeat_UP
        {
            get { return Repeat_Up; }
            set
            {
                if (Repeat_Up != null)
                {
                    Repeat_Up.Click -= new RoutedEventHandler(Repeat_Up_Click);
                }
                Repeat_Up = value;
                if (Repeat_Up != null)
                {
                    Repeat_Up.Click += new RoutedEventHandler(Repeat_Up_Click);
                }
            }
        }

        /// <summary>
        /// Properties to manage the down button
        /// </summary>
        private RepeatButton Repeat_DOWN
        {
            get { return Repeat_Down; }
            set
            {
                if (Repeat_Down != null)
                {
                    Repeat_Down.Click -= new RoutedEventHandler(Repeat_Down_Click);
                }
                Repeat_Down = value;
                if (Repeat_Down != null)
                {
                    Repeat_Down.Click += new RoutedEventHandler(Repeat_Down_Click);
                }
            }
        }

        /// <summary>
        /// Override to retrieve items
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            Repeat_UP = GetTemplateChild("RepeatUp") as RepeatButton;
            Repeat_DOWN = GetTemplateChild("RepeatDown") as RepeatButton;
            TextBlock_NUM = GetTemplateChild("TextblockNumUpDown") as TextBlock;
        }

        /// <summary>
        /// Method to manage the click event on the up button
        /// </summary>
        private void Repeat_Up_Click(object sender, RoutedEventArgs e)
        {
            Valore++;
            TextBlock_Num.Text = Valore.ToString();
        }

        /// <summary>
        /// Method to manage the click event on the down button
        /// </summary>
        private void Repeat_Down_Click(object sender, RoutedEventArgs e)
        {
            Valore--;
            TextBlock_Num.Text = Valore.ToString();
        }
    }
}
