using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Ygo_Picture_Creator
{
    public partial class TemplateEditor : Window
    {
        private Template template;
        private Dictionary<string, Template> Templatelist = new Dictionary<string, Template>();

        private int sampleid = 84013237;

        public TemplateEditor()
        {
            InitializeComponent();

            this.Loaded += TemplateEditor_Loaded;
            tbSampleID.TextChanged += tbSampleID_TextChanged;
        }

        private void tbSampleID_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbSampleID.Text.Length < 5 || tbSampleID.Text.Length > 10) return;

            int i = 0;

            if(int.TryParse(tbSampleID.Text.Trim(), out i))
            {
                SampleId = i;
            }
        }

        private int SampleId
        {
            get 
            {
                for (int i = 0; i < Program.CardManager.Cardlist.Count; i++)
                {
                    if (Program.CardManager.Cardlist[i].CardID == sampleid)
                    {
                        return i;
                    }
                }
                
                return 84013237; 
            }
            set 
            { 
                sampleid = value;
                ShowPreview();
            }
        }

        private void TemplateEditor_Loaded(object sender, RoutedEventArgs e)
        {
            LoadTemplates();
        }

        private void MinimizeClick_Executed(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void CloseClick_Executed(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void WindowDrag(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private Template CurrentTemplate
        {
            get
            {
                return template;
            }
            set
            {
                if (value == null)
                    EditArea.IsEnabled = false;
                else
                    EditArea.IsEnabled = true;

                template = value;
                ShowPreview();
            }
        }

        private void CancelBtn_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Hide();
        }

        private void SaveBtn_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            string name = tbTempName.Text;

            if(string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Bitte gib erst einen Namen für das Template ein.");
                return;
            }

            //if (false)
            //{
            //    MessageBox.Show("Der Template-Name darf keine Sonderzeichen enthalten.");
            //    return;
            //}

            TakeCurrentTemplate(name);

            if (CurrentTemplate != null)
                if (!string.IsNullOrEmpty(CurrentTemplate.TemplateName))
                    Program.SerializeClass(DirectoryManager.FileTemplates(CurrentTemplate.TemplateName + ".xml"), CurrentTemplate, typeof(Template));

            MessageBox.Show(CurrentTemplate.TemplateName + ".xml gespeichert.");

            ShowPreview();
        }

        private void NewBtn_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            CurrentTemplate = new Template();
        }

        private void RefreshBtn_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            LoadTemplates();
        }

        private void cbxTemplates_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CurrentTemplate = GetCurrentTemplate();
            ShowTemplate(CurrentTemplate);
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

                if (!string.IsNullOrEmpty(tmp.TemplateName))
                {
                    Templatelist.Add(tmp.TemplateName, tmp);
                    cbxTemplates.Items.Add(tmp.TemplateName);
                }
            }

            if(cbxTemplates.Items.Count > 0)
            {
                cbxTemplates.SelectedIndex = 0;
            }
            else
            {
                CurrentTemplate = null;
            }
        }

        private Template GetCurrentTemplate()
        {
            if (cbxTemplates.SelectedIndex < 0) return null;

            if (string.IsNullOrEmpty(cbxTemplates.SelectedItem.ToString()))
                return null;

            string tmpName = cbxTemplates.SelectedItem.ToString();

            if (Templatelist.ContainsKey(tmpName))
                return Templatelist[tmpName];

            return null;
        }

        private void ShowPreview()
        {
            int count = SampleId;
            Card c = Program.CardManager.Cardlist[count];

            try
            {
                System.Drawing.Bitmap img = Program.CardManager.Creator.CreateBitmap(c, CurrentTemplate);
                Program.CardManager.Creator.EndInit();

                using (MemoryStream memory = new MemoryStream())
                {
                    img.Save(memory, System.Drawing.Imaging.ImageFormat.Png);
                    memory.Position = 0;
                    System.Windows.Media.Imaging.BitmapImage bitmapImage = new System.Windows.Media.Imaging.BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.StreamSource = memory;
                    bitmapImage.CacheOption = System.Windows.Media.Imaging.BitmapCacheOption.OnLoad;
                    bitmapImage.EndInit();

                    Preview.Source = bitmapImage;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
