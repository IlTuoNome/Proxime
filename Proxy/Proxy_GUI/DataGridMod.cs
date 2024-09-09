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
    /// Class for the modified datagrid
    /// </summary>
    public class DataGridMod : DataGrid
    {
        static DataGridMod()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DataGridMod), new FrameworkPropertyMetadata(typeof(DataGridMod)));
        }

        /// <summary>
        /// Properties to manage the display of the up grid to get to the top of the grid
        /// </summary>
        public Visibility UpshowVisibility
        {
            get { return (Visibility)GetValue(UpshowVisibilityProperty); }
            set { SetValue(UpshowVisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UpshowVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UpshowVisibilityProperty =
            DependencyProperty.Register("UpshowVisibility", typeof(Visibility), typeof(DataGridMod), new PropertyMetadata(Visibility.Visible));

        /// <summary>
        /// Override to recover the grid up
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            grid_up = GetTemplateChild("Grid_Up") as Grid;
        }

        /// <summary>
        /// Grid up field
        /// </summary>
        private Grid Grid_Up;

        /// <summary>
        /// Property to manage the Grid_Up field
        /// </summary>
        private Grid grid_up
        {
            get { return Grid_Up; }
            set
            {
                if (Grid_Up != null)
                {
                    Grid_Up.MouseUp -= new MouseButtonEventHandler(Up_Click);
                }
                Grid_Up = value;
                if (Grid_Up != null)
                {
                    Grid_Up.MouseUp += new MouseButtonEventHandler(Up_Click);
                }
            }
        }

        /// <summary>
        /// Method to handle the click release event of the grid up
        /// </summary>
        private void Up_Click(object sender, MouseButtonEventArgs e)
        {
            this.ScrollIntoView(this.Items[0]);
        }

    }
}
