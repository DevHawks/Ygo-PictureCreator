using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace Ygo_Picture_Creator
{
    public partial class MainWindow : Window
    {
        #region fields
        public enum ConsoleMsgType { Normal, Error, Warning }
        public Dictionary<string, Template> Templatelist = new Dictionary<string, Template>();
        #endregion

        public MainWindow()
        {
            InitializeComponent();

            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            lbHeadline.Content = "YGOPro Card Picture Creator - v" + Program.APP_VERSION;

            rtbConsole.Document.Blocks.Clear();

            if (!string.IsNullOrEmpty(Program.Config.DefaultDatabasePath))
                SetDatabasePath(Program.Config.DefaultDatabasePath);
            else
                SetDatabasePath("");

            LoadTemplates();
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
            Program.CardManager.Creator.Cancel();
        }

        private void StartBtn_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Program.CardManager.Creator.Start();
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

        private void LoadTemplates()
        {
            string path = DirectoryManager.DirTemplate;
            Templatelist = new Dictionary<string, Template>();
            cbxTemplates.Items.Clear();

            string[] files = Directory.GetFiles(DirectoryManager.DirTemplate, "*.xml", SearchOption.TopDirectoryOnly);

            for (int i = 0; i < files.Length; i++)
            {
                FileInfo info = new FileInfo(files[i]);

                Template tmp = (Template)Program.DeserializeClass(info.FullName, typeof(Template));

                if(!string.IsNullOrEmpty(tmp.TemplateName))
                {
                    Templatelist.Add(tmp.TemplateName, tmp);
                    cbxTemplates.Items.Add(tmp.TemplateName);
                }
            }

            if (cbxTemplates.Items.Count > 0)
                cbxTemplates.SelectedIndex = 0;
        }

        public Template GetCurrentTemplate()
        {
            if (cbxTemplates.SelectedIndex < 0) return null;

            if (string.IsNullOrEmpty(cbxTemplates.SelectedItem.ToString()))
                return null;

            string tmpName = cbxTemplates.SelectedItem.ToString();

            if (Templatelist.ContainsKey(tmpName))
                return Templatelist[tmpName];

            return null;
        }

        private void cbxTemplates_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            CardCreator.Temp = GetCurrentTemplate();
        }

        private void OpenTEBtn_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if(Program.TempEditor == null)
                Program.TempEditor = new TemplateEditor();

            Program.TempEditor.Show();
        }

        private void Refresh_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            LoadTemplates();
        }
    }
}
