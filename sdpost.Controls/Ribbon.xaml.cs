using System;
using System.Collections.Generic;
using System.Linq;
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

namespace NShop.Controls
{
    public partial class Ribbon : UserControl
    {
        public Ribbon()
        {
            InitializeComponent();
        }

        public bool IsMinimized
        {
            get
            {
                return ribbon1.IsMinimized;
            }
        }

        private double rHeight=141;
        public double RHeight
        {
            get
            {
                return rHeight ;
            }
            set
            {
                rHeight = value;
            }
        }

        private void ribbon1_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            e.Handled = true;
        }

        private void ribbon1_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Source is Microsoft.Windows.Controls.Ribbon.Ribbon && (e.GetPosition(this).X > 142) || e.ClickCount > 1)
            {
                e.Handled = true;
            }
        }

        private void ribbon1_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
        }
    }
}
