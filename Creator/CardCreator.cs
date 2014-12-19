using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Threading;

namespace Ygo_Picture_Creator
{
    public class CardCreator
    {
        public static Template Temp { get; set; }
        public static Thread FileThread;

        #region File Elements
        private Bitmap bmp;
        private Graphics g;
        #endregion

        #region Static Initializiations
        private static bool isInit = false;

        private static PrivateFontCollection pfc;
        private static Font font_Cardname, font_Desc, font_Stats, font_Typ;
        private static FontFamily fam_Cardname, fam_Desc, fam_Stats, fam_Typ;

        private static Bitmap bg_xyz, bg_normal, bg_synchro, bg_effect, bg_ritual, bg_fusion, bg_spell, bg_trap, bg_pendulum, bg_token;
        private static Bitmap aDark, aLight, aFire, aWater, aWind, aEarth, aDivine, aSpell, aTrap;
        private static Bitmap imgLevel, imgRank;
        #endregion

        public CardCreator(Template temp = null)
        {
            if (temp != null) 
                Temp = temp;


        }

        public void Start()
        {
            FileThread = new Thread(new ThreadStart(create));
            FileThread.Start();
        }

        public void Cancel()
        {
            if (FileThread == null) return;

            if (FileThread.IsAlive)
            {
                FileThread.Abort();
                Program.MainWin.Write("process been canceled.", MainWindow.ConsoleMsgType.Warning);
            }
            else
                Program.MainWin.Write("Debug: Derzeit ist kein Prozess am Arbeiten.", MainWindow.ConsoleMsgType.Warning);
        }

        private void BeginInit(Template t)
        {
            if (isInit) return;

            #region Init Backgrounds
            if (File.Exists(DirectoryManager.FileResources(DirectoryManager.CustomFolders.Cardtype, t.Cardtype_Normal)))
                bg_normal = new Bitmap(DirectoryManager.FileResources(DirectoryManager.CustomFolders.Cardtype, t.Cardtype_Normal));

            if (File.Exists(DirectoryManager.FileResources(DirectoryManager.CustomFolders.Cardtype, t.Cardtype_Xyz)))
                bg_xyz = new Bitmap(DirectoryManager.FileResources(DirectoryManager.CustomFolders.Cardtype, t.Cardtype_Xyz));

            if (File.Exists(DirectoryManager.FileResources(DirectoryManager.CustomFolders.Cardtype, t.Cardtype_Synchro)))
                bg_synchro = new Bitmap(DirectoryManager.FileResources(DirectoryManager.CustomFolders.Cardtype, t.Cardtype_Synchro));

            if (File.Exists(DirectoryManager.FileResources(DirectoryManager.CustomFolders.Cardtype, t.Cardtype_Effect)))
                bg_effect = new Bitmap(DirectoryManager.FileResources(DirectoryManager.CustomFolders.Cardtype, t.Cardtype_Effect));

            if (File.Exists(DirectoryManager.FileResources(DirectoryManager.CustomFolders.Cardtype, t.Cardtype_Ritual)))
                bg_ritual = new Bitmap(DirectoryManager.FileResources(DirectoryManager.CustomFolders.Cardtype, t.Cardtype_Ritual));

            if (File.Exists(DirectoryManager.FileResources(DirectoryManager.CustomFolders.Cardtype, t.Cardtype_Fusion)))
                bg_fusion = new Bitmap(DirectoryManager.FileResources(DirectoryManager.CustomFolders.Cardtype, t.Cardtype_Fusion));

            if (File.Exists(DirectoryManager.FileResources(DirectoryManager.CustomFolders.Cardtype, t.Cardtype_Spellcard)))
                bg_spell = new Bitmap(DirectoryManager.FileResources(DirectoryManager.CustomFolders.Cardtype, t.Cardtype_Spellcard));

            if (File.Exists(DirectoryManager.FileResources(DirectoryManager.CustomFolders.Cardtype, t.Cardtype_Trapcard)))
                bg_trap = new Bitmap(DirectoryManager.FileResources(DirectoryManager.CustomFolders.Cardtype, t.Cardtype_Trapcard));

            if (File.Exists(DirectoryManager.FileResources(DirectoryManager.CustomFolders.Cardtype, t.Cardtype_Pendulum)))
                bg_pendulum = new Bitmap(DirectoryManager.FileResources(DirectoryManager.CustomFolders.Cardtype, t.Cardtype_Pendulum));

            if (File.Exists(DirectoryManager.FileResources(DirectoryManager.CustomFolders.Cardtype, t.Cardtype_Token)))
                bg_token = new Bitmap(DirectoryManager.FileResources(DirectoryManager.CustomFolders.Cardtype, t.Cardtype_Token));
            #endregion

            #region Init Attributes
            if (File.Exists(DirectoryManager.FileResources(DirectoryManager.CustomFolders.Attribute, t.AttributeDark)))
                aDark = new Bitmap(DirectoryManager.FileResources(DirectoryManager.CustomFolders.Attribute, t.AttributeDark));

            if (File.Exists(DirectoryManager.FileResources(DirectoryManager.CustomFolders.Attribute, t.AttributeLight)))
                aLight = new Bitmap(DirectoryManager.FileResources(DirectoryManager.CustomFolders.Attribute, t.AttributeLight));

            if (File.Exists(DirectoryManager.FileResources(DirectoryManager.CustomFolders.Attribute, t.AttributeFire)))
                aFire = new Bitmap(DirectoryManager.FileResources(DirectoryManager.CustomFolders.Attribute, t.AttributeFire));

            if (File.Exists(DirectoryManager.FileResources(DirectoryManager.CustomFolders.Attribute, t.AttributeWater)))
                aWater = new Bitmap(DirectoryManager.FileResources(DirectoryManager.CustomFolders.Attribute, t.AttributeWater));

            if (File.Exists(DirectoryManager.FileResources(DirectoryManager.CustomFolders.Attribute, t.AttributeWind)))
                aWind = new Bitmap(DirectoryManager.FileResources(DirectoryManager.CustomFolders.Attribute, t.AttributeWind));

            if (File.Exists(DirectoryManager.FileResources(DirectoryManager.CustomFolders.Attribute, t.AttributeEarth)))
                aEarth = new Bitmap(DirectoryManager.FileResources(DirectoryManager.CustomFolders.Attribute, t.AttributeEarth));

            if (File.Exists(DirectoryManager.FileResources(DirectoryManager.CustomFolders.Attribute, t.AttributeDivine)))
                aDivine = new Bitmap(DirectoryManager.FileResources(DirectoryManager.CustomFolders.Attribute, t.AttributeDivine));

            if (File.Exists(DirectoryManager.FileResources(DirectoryManager.CustomFolders.Attribute, t.AttributeSpell)))
                aSpell = new Bitmap(DirectoryManager.FileResources(DirectoryManager.CustomFolders.Attribute, t.AttributeSpell));

            if (File.Exists(DirectoryManager.FileResources(DirectoryManager.CustomFolders.Attribute, t.AttributeTrap)))
                aTrap = new Bitmap(DirectoryManager.FileResources(DirectoryManager.CustomFolders.Attribute, t.AttributeTrap));
            #endregion

            #region Init Level and Rank
            if (File.Exists(DirectoryManager.FileResources(DirectoryManager.CustomFolders.Level, t.LevelPicture)))
                imgLevel = new Bitmap(DirectoryManager.FileResources(DirectoryManager.CustomFolders.Level, t.LevelPicture));

            if (File.Exists(DirectoryManager.FileResources(DirectoryManager.CustomFolders.Level, t.RankPicture)))
                imgRank = new Bitmap(DirectoryManager.FileResources(DirectoryManager.CustomFolders.Level, t.RankPicture));

            #endregion

            #region Fonts
            pfc = new PrivateFontCollection();

            font_Cardname = new Font(t.Cardname_Fontname, t.Cardname_Fontsize);
            #endregion

            isInit = true;
        }

        public void EndInit()
        {


            isInit = false;
        }

        private void create()
        {
            if (Program.CardManager.Cardlist.Count < 1)
            {
                Program.MainWin.Write("No Database selected.", MainWindow.ConsoleMsgType.Error);
                return;
            }

            if (Temp == null)
            {
                Program.MainWin.Write("No Template selected.", MainWindow.ConsoleMsgType.Error);
                return;
            }

            // TODO Check Template !!!

            for (int i = 0; i < Program.CardManager.Cardlist.Count; i++)
            {
                CreateFile(Program.CardManager.Cardlist[i], i);

                Thread.Sleep(5);
            }

            EndInit();
        }

        public Bitmap CreateBitmap(Card data, Template t)
        {
            BeginInit(t);

            bmp = new Bitmap(t.FullPictureWidth, t.FullPictureHeight);
            g = Graphics.FromImage(bmp);

            DrawBackground(data, t);
            DrawRank(data, t);
            DrawAttribute(data, t);
            DrawCardpicture(data, t);
            DrawCardname(data, t);

            return bmp;
        }

        private void CreateFile(Card data, int count)
        {
            if (Temp == null) return;

            Template t = Temp;

            bmp = CreateBitmap(data, t);

            try
            {
                bmp.Save(DirectoryManager.FileResults(data.CardID + ".jpg"), ImageFormat.Jpeg);
                Program.MainWin.Write(count + "/" + Program.CardManager.Cardlist.Count + " || " +
                    data.CardID + ".jpg was created.");
            }
            catch (Exception ex)
            {
                Program.MainWin.Write(ex.Message);
            }
        }

        private void DrawBackground(Card data, Template t)
        {
            Rectangle bounce = new Rectangle(0, 0, t.FullPictureWidth, t.FullPictureHeight);

            if (data.IsMonster)
            {
                if (data.IsNormalMonster)
                {
                    if (bg_normal != null)
                        g.DrawImage(bg_normal, bounce);
                }
                else if (data.IsNormalEffectMonster)
                {
                    if (bg_effect != null)
                        g.DrawImage(bg_effect, bounce);
                }
                else if (data.IsFusionType)
                {
                    if (bg_fusion != null)
                        g.DrawImage(bg_fusion, bounce);
                }
                else if (data.IsRitualType)
                {
                    if (bg_ritual != null)
                        g.DrawImage(bg_ritual, bounce);
                }

                else if (data.IsSynchroType)
                {
                    if (bg_synchro != null)
                        g.DrawImage(bg_synchro, bounce);
                }
                else if (data.IsXyzType)
                {
                    if (bg_xyz != null)
                        g.DrawImage(bg_xyz, bounce);
                }
                else if (data.IsPendulum)
                {
                    if (bg_pendulum != null)
                        g.DrawImage(bg_pendulum, bounce);
                }

                else // Hope all other are Tokens but i'm not shure
                {
                    if (bg_token != null)
                        g.DrawImage(bg_token, bounce);
                }
            }
            else if (data.IsSpell)
            {
                g.DrawImage(bg_spell, bounce);
            }
            else if (data.IsTrap)
            {
                g.DrawImage(bg_trap, bounce);
            }
        }

        private void DrawAttribute(Card data, Template t)
        {
            if (!t.DrawAttribute) return;

            RectangleF bounce = new RectangleF(t.AttributePositionX, t.AttributePositionY, t.AttributeWidth, t.AttributeHeight);

            if (data.IsSpell)
            {
                if(aSpell != null)
                    g.DrawImage(aSpell, bounce);
            }
            else if (data.IsTrap)
            {
                if (aSpell != null)
                    g.DrawImage(aTrap, bounce);
            }
            else
            {
                if (data.GetAttribute == CardStrings.Attribute1_Earth)
                {
                    if (aSpell != null)
                        g.DrawImage(aEarth, bounce);
                }
                else if (data.GetAttribute == CardStrings.Attribute2_Water)
                {
                    if (aSpell != null)
                        g.DrawImage(aWater, bounce);
                }
                else if (data.GetAttribute == CardStrings.Attribute3_Fire)
                {
                    if (aSpell != null)
                        g.DrawImage(aFire, bounce);
                }
                else if (data.GetAttribute == CardStrings.Attribute4_Wind)
                {
                    if (aSpell != null)
                        g.DrawImage(aWind, bounce);
                }
                else if (data.GetAttribute == CardStrings.Attribute5_Light)
                {
                    if (aSpell != null)
                        g.DrawImage(aLight, bounce);
                }
                else if (data.GetAttribute == CardStrings.Attribute6_Dark)
                {
                    if (aSpell != null)
                        g.DrawImage(aDark, bounce);
                }
                else if (data.GetAttribute == CardStrings.Attribute7_Divine)
                {
                    if (aSpell != null)
                        g.DrawImage(aDivine, bounce);
                }
                else
                    Program.MainWin.Write("Unknown Attribute on CardCreator");
            }
        }

        private void DrawRank(Card data, Template t)
        {
            if (!t.DrawRank || !data.IsMonster) return;

            if (data.IsPendulum) return;

            if (data.IsXyzType && imgRank == null) return;

            if (!data.IsXyzType && imgLevel == null) return;

            int rank = data.CardLevel;

            RectangleF b = new RectangleF(t.RankAreaX, t.RankAreaY, t.RankWidth, t.RankHeight);

            if(t.DrawRankHorizontal && !t.DrawRankLeftToRight)
            {
                for (int i = 1; i < rank; i++)
                    g.DrawImage(data.IsXyzType ? imgRank : imgLevel, new RectangleF(b.X - (i * b.Width), b.Y, b.Width, b.Height));
            }
            else if(t.DrawRankHorizontal && t.DrawRankLeftToRight)
            {
                for (int i = 0; i < rank - 1; i++)
                    g.DrawImage(data.IsXyzType ? imgRank : imgLevel, new RectangleF(b.X + (i * b.Width), b.Y, b.Width, b.Height));
            }
            
        }

        private void DrawCardpicture(Card data, Template t)
        {
            RectangleF bounce = new RectangleF(t.CardPicAreaX, t.CardPicAreaY, t.CardPicAreaWidth, t.CardPicAreaHeight);

            Bitmap b;
            string path = "";

            if (File.Exists(DirectoryManager.FileResources(DirectoryManager.CustomFolders.Pics, data.CardID + ".jpg")))
                path = DirectoryManager.FileResources(DirectoryManager.CustomFolders.Pics, data.CardID + ".jpg");
            else if (File.Exists(DirectoryManager.FileResources(DirectoryManager.CustomFolders.Pics, data.CardID + ".png")))
                path = DirectoryManager.FileResources(DirectoryManager.CustomFolders.Pics, data.CardID + ".png");

            if(path != "")
            {
                b = new Bitmap(path);
                if(b != null)
                    g.DrawImage(b, bounce);
            }
        }

        private void DrawCardname(Card data, Template t)
        {

        }
    }
}
