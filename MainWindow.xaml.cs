using Microsoft.Win32;
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

namespace Ygo_Picture_Creator
{
    public partial class MainWindow : Window
    {
        #region fields
        public enum ConsoleMsgType { Normal, Error, Warning }
        #endregion

        public MainWindow()
        {
            InitializeComponent();

            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Program.DbPath = @"F:\Portable Programme\YGOPro\DevPro\cards.cdb";

            if (!string.IsNullOrEmpty(Program.DbPath))
            { 
                lbDatabaseSource.Content = "[" + Program.CardManager.Cardlist.Count + " Cards] " + Program.DbPath;
            }

            rtbConsole.Document.Blocks.Clear();
        }

        private void SetDatabasePath(string path)
        {
            if (!path.EndsWith(".cdb"))
            {
                Write("no valid file selected.", ConsoleMsgType.Error);
                return; 
            }

            Program.DbPath = path;
            lbDatabaseSource.Content = "[" + Program.CardManager.Cardlist.Count + " Cards] " + Program.DbPath;

            Write("Database with " + Program.CardManager.Cardlist.Count + " cards loaded.");
        }

        private void lbSelectDbBtn_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.DefaultExt = ".cdb";
            dlg.Filter = "Constant Database (.cdb)|*.cdb";

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                string filename = dlg.FileName;
                SetDatabasePath(filename);
            }

        }

        private void CancelBtn_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Program.CardManager.Cancel();
        }

        private void StartBtn_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Program.CardManager.CreatePictures();

            //CardPicture pic = new CardPicture(Program.CardManager.Cardlist[1]);
            //pic.Save();
        }

        public void Write(string text, ConsoleMsgType msgType = ConsoleMsgType.Normal)
        {
            if (!Dispatcher.CheckAccess())
            {
                Dispatcher.Invoke(new Action<string, ConsoleMsgType>(Write), text, msgType);
            }
            else
            {
                if (!MainWindow.IsDisposed(this))
                {
                    string timetext = string.Format(" [{0}] ", DateTime.Now.ToShortTimeString());

                    Run time = new Run(timetext) { Foreground = Brushes.DarkTurquoise };
                    Run message;

                    if (msgType == ConsoleMsgType.Error)
                        message = new Run(text) { Foreground = Brushes.Red, FontWeight = FontWeights.Bold };
                    else if (msgType == ConsoleMsgType.Warning)
                        message = new Run(text) { Foreground = Brushes.Orange };
                    else
                        message = new Run(text) { Foreground = Brushes.White };

                    Paragraph p = new Paragraph();
                    p.Inlines.Add(time);
                    p.Inlines.Add(message);
                    p.Margin = new Thickness(0);
                    p.FontSize = 13;
                    rtbConsole.Document.Blocks.Add(p);
                    rtbConsole.ScrollToEnd();
                }
            }
        }
    }
}
