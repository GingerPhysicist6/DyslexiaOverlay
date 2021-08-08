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
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Overlay
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainViewModel mainViewModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            Background background = new Background();
            background.Show();

            mainViewModel = new MainViewModel(background);
            this.DataContext = mainViewModel;
        }

        public virtual void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.WindowStyle = WindowStyle.None;
            this.WindowState = WindowState.Maximized;
        }

        public void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                string message = "Do you want to close the overlay?";
                string title = "Close Window";
                MessageBoxButton buttons = MessageBoxButton.YesNo;
                MessageBoxResult result = MessageBox.Show(message, title, buttons);

                if (result == MessageBoxResult.Yes)
                {
                    this.Close();
                    Environment.Exit(0);
                }
                else
                {
                    // Nothing, message box just closes
                }
            }
        }
    }
}
