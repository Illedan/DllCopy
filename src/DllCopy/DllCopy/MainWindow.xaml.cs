using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using DllCopy.Models;
using DllCopy.Services;

namespace DllCopy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel m_viewModel;
        public MainWindow()
        {
            InitializeComponent();
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            Init();
        }

        private async void Init()
        {
            var config = await ConfigService.ReadConfig();
            DataContext = m_viewModel = new MainViewModel(config);
        }


        protected override void OnClosing(CancelEventArgs e)
        {
            m_viewModel.OnClosing();
            base.OnClosing(e);
        }

        private void DropExe(object sender, DragEventArgs e)
        {
            try
            {
                if(!e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    return;
                }

                var files = (string []) e.Data.GetData(DataFormats.FileDrop);
                foreach(var file in files)
                {
                    m_viewModel.AddTargetCommand.Execute(file);
                }
            }
            catch(Exception exception)
            {

            }
        }

        private void DropFile(object sender, DragEventArgs e)
        {
            try
            {
                var frameworkElement = sender as FrameworkElement;
                var folder = frameworkElement?.DataContext as Folder;
                var files = (string []) e.Data.GetData(DataFormats.FileDrop);
                folder?.AddFiles(files);
                m_viewModel.SaveConfigCommand.Execute(null);
            }
            catch(Exception exception)
            {
            }
        }
        private void OnDragOver(object sender, DragEventArgs e)
        {
            e.Handled = true;
        }
    }
}
