using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace DllCopy.View
{
    /// <summary>
    /// Interaction logic for ToolBarControl.xaml
    /// </summary>
    public partial class ToolBarControl : UserControl
    {
        public ToolBarControl()
        {
            InitializeComponent();
        }

        void PnMouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (App.Current.MainWindow.WindowState == WindowState.Maximized)
                {
                    App.Current.MainWindow.WindowState = WindowState.Normal;
                }
                App.Current.MainWindow.DragMove();
            }
        }

        private void ToolBarControl_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                switch (App.Current.MainWindow.WindowState)
                {
                    case WindowState.Normal:
                        App.Current.MainWindow.WindowState = WindowState.Maximized;
                        break;
                    case WindowState.Minimized:
                        App.Current.MainWindow.WindowState = WindowState.Maximized;
                        break;
                    case WindowState.Maximized:
                        App.Current.MainWindow.WindowState = WindowState.Normal;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                
            }
        }
    }
}
