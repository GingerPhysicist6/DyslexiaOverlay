using Overlay.OverlayBackground;
using System;
using System.Windows;
using System.Windows.Input;

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

            Overlay_UserControl background = new Overlay_UserControl();
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
