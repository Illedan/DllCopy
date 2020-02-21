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

        public static readonly DependencyProperty BackgroundProperty = DependencyProperty.Register("Background", typeof(Brush), typeof(ToolBarControl), new PropertyMetadata(Brushes.LightGray));

        public new Brush Background
        {
            get { return (Brush)GetValue(BackgroundProperty); }
            set { SetValue(BackgroundProperty, value); }
        }

        public static readonly DependencyProperty TextColorProperty = DependencyProperty.Register("TextColor", typeof(Brush), typeof(ToolBarControl), new PropertyMetadata(Brushes.White));

        public Brush TextColor
        {
            get { return (Brush)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        public static readonly DependencyProperty ButtonColorProperty = DependencyProperty.Register("ButtonColor", typeof(Brush), typeof(ToolBarControl), new PropertyMetadata(default(Brush)));

        public Brush ButtonColor
        {
            get { return (Brush)GetValue(ButtonColorProperty); }
            set { SetValue(ButtonColorProperty, value); }
        }

        public static readonly DependencyProperty ButtonMouseOverColorProperty = DependencyProperty.Register("ButtonMouseOverColor", typeof(Brush), typeof(ToolBarControl), new PropertyMetadata(default(Brush)));

        public Brush ButtonMouseOverColor
        {
            get { return (Brush)GetValue(ButtonMouseOverColorProperty); }
            set { SetValue(ButtonMouseOverColorProperty, value); }
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

        private void ToggleWindowSize(object sender, RoutedEventArgs e)
        {
            switch (App.Current.MainWindow.WindowState)
            {
                case WindowState.Normal:
                    App.Current.MainWindow.WindowState = WindowState.Maximized;
                    break;
                case WindowState.Maximized:
                    App.Current.MainWindow.WindowState = WindowState.Normal;
                    break;
            }
        }

        private void MinimizeWindow(object sender, RoutedEventArgs e)
        {
            App.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void CloseApp(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
