using System;
using System.Windows;
using System.Windows.Input;

namespace Ygo_Picture_Creator
{
    public partial class MainWindow : Window
    {
        public static Boolean IsDisposed(Window window)
        {
            return new System.Windows.Interop.WindowInteropHelper(window).Handle == IntPtr.Zero;
        }

        private void WindowDrag(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void CloseClick_Executed(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MaximizeClick_Executed(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
                this.WindowState = WindowState.Maximized;
            else
                this.WindowState = WindowState.Normal;
        }

        private void MinimizeClick_Executed(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
