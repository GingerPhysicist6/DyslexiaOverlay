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
using System.Windows.Shapes;

namespace Overlay
{
    /// <summary>
    /// Interaction logic for Background.xaml
    /// </summary>
    public partial class Background : Window
    {
        public Background()
        {
            InitializeComponent();
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            var hwnd = new WindowInteropHelper(this).Handle;
            WindowsServices.SetWindowExTransparent(hwnd);
        }

        public virtual void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.WindowStyle = WindowStyle.None;
            this.WindowState = WindowState.Maximized;
        }
    }
}
