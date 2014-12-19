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
        private static Brush bNormal, bEffect, bToken, bRitual, bFusion, bSynchro, bXyz, bPendulum, bSpell, bTrap;
        private static Brush bStats, bDesc, bTyp;

        private static Bitmap bg_xyz, bg_normal, bg_synchro, bg_effect, bg_ritual, bg_fusion, bg_spell, bg_trap, bg_pendulum, bg_token;
        private static Bitmap aDark, aLight, aFire, aWater, aWind, aEarth, aDivine, aSpell, aTrap;
        private static Bitmap imgLevel, imgRank;
        #endregion

        public static ThreadData TData;

        public CardCreator(Template temp = null)
        {
            if (temp != null) 
                Temp = temp;

            TData = new ThreadData();
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

            #region
            bNormal = new SolidBrush(Color.FromArgb(t.Cardname_Color_Normal[0], t.Cardname_Color_Normal[1], t.Cardname_Color_Normal[2]));
            bEffect = new SolidBrush(Color.FromArgb(t.Cardname_Color_NormalEffect[0], t.Cardname_Color_NormalEffect[1], t.Cardname_Color_NormalEffect[2]));
            bToken = new SolidBrush(Color.FromArgb(t.Cardname_Color_Token[0], t.Cardname_Color_Token[1], t.Cardname_Color_Token[2]));
            bRitual = new SolidBrush(Color.FromArgb(t.Cardname_Color_Ritual[0], t.Cardname_Color_Ritual[1], t.Cardname_Color_Ritual[2]));
            bFusion = new SolidBrush(Color.FromArgb(t.Cardname_Color_Fusion[0], t.Cardname_Color_Fusion[1], t.Cardname_Color_Fusion[2]));
            bSynchro = new SolidBrush(Color.FromArgb(t.Cardname_Color_Synchro[0], t.Cardname_Color_Synchro[1], t.Cardname_Color_Synchro[2]));
            bXyz = new SolidBrush(Color.FromArgb(t.Cardname_Color_Xyz[0], t.Cardname_Color_Xyz[1], t.Cardname_Color_Xyz[2]));
            bPendulum = new SolidBrush(Color.FromArgb(t.Cardname_Color_Pendulum[0], t.Cardname_Color_Pendulum[1], t.Cardname_Color_Pendulum[2]));
            bSpell = new SolidBrush(Color.FromArgb(t.Cardname_Color_Spell[0], t.Cardname_Color_Spell[1], t.Cardname_Color_Spell[2]));
            bTrap = new SolidBrush(Color.FromArgb(t.Cardname_Color_Trap[0], t.Cardname_Color_Trap[1], t.Cardname_Color_Trap[2]));
            #endregion

            #region Fonts
            pfc = new PrivateFontCollection();

            fam_Cardname = LoadFontFamily(GetFontPath(t.Cardname_Fontname));
            font_Cardname = new Font(fam_Cardname, t.Cardname_Fontsize);

            fam_Typ = LoadFontFamily(GetFontPath(t.Monstertype_Fontname));
            font_Typ = new Font(fam_Typ, t.Monstertype_Fontsize);

            fam_Desc = LoadFontFamily(GetFontPath(t.Desc_Fontname));
            font_Desc = new Font(fam_Desc, t.Desc_Fontsize);

            fam_Stats = LoadFontFamily(GetFontPath(t.Stats_Fontname));
            font_Stats = new Font(fam_Stats, t.Stats_Fontsize);
            #endregion

            isInit = true;
        }

        public void EndInit()
        {
            try
            {
                font_Cardname.Dispose();
                font_Desc.Dispose();
                font_Stats.Dispose();
                font_Typ.Dispose();
                fam_Cardname.Dispose();
                fam_Desc.Dispose();
                fam_Stats.Dispose();
                fam_Typ.Dispose();
                pfc.Dispose();
            }
            catch (Exception ex)
            {
                Program.MainWin.Write(ex.Message, MainWindow.ConsoleMsgType.Error);
            }

            isInit = false;
        }

        private string GetFontPath(string font)
        {
            return DirectoryManager.FileResources(DirectoryManager.CustomFolders.Fonts, font);
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

            TemplateEditor.CheckTemplate(Temp);

            for (int i = 0; i < Program.CardManager.Cardlist.Count; i++)
            {
                CreateFile(Program.CardManager.Cardlist[i], i);

                Thread.Sleep(TData.ThreadSleepTime);
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
            DrawTyp(data, t);
            DrawDescription(data, t);
            DrawStats(data, t);

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
            if (!t.DrawCardname) return;

            char[] chars = data.Cardname.Trim().ToCharArray();

            PointF p = new PointF(t.CardnameAreaX, t.CardnameAreaY);

            foreach (char c in chars)
            {
                if (p.X > (t.CardnameWidth - t.CardnameAreaX))
                    break;

                float f = GetCharWidth(c);
                g.DrawString(c.ToString(), font_Cardname, SelectBrush(data), p);
                p.X += f;
            }
        }

        private void DrawTyp(Card data, Template t)
        {
            if (!t.DrawMonstertype) return;
            if (!data.IsMonster) return;

            if (bTyp == null)
                bTyp = new SolidBrush(Color.FromArgb(t.Monstertype_Color[0], t.Monstertype_Color[1], t.Monstertype_Color[2]));

            string MtypeString = data.GetCardType;
            // TODO Need a better way to get Cardtypes :-(

            RectangleF r = new RectangleF(t.MonstertypeAreaX, t.MonstertypeAreaY, t.MonstertypeWidth, t.MonstertypeHeight);

            g.DrawString(MtypeString, font_Typ, bTyp, r);
            
        }

        private void DrawDescription(Card data, Template t)
        {
            if (!t.DrawDescription) return;

            if (bDesc == null)
                bDesc = new SolidBrush(Color.FromArgb(t.Desc_Color[0], t.Desc_Color[1], t.Desc_Color[2]));

            //char[] chars = data.CardDescription.Trim().ToCharArray();

            RectangleF r = new RectangleF(t.DescAreaX, t.DescAreaY, t.DescWidth, t.DescHeight);

            g.DrawString(data.CardDescription.Trim(), font_Desc, bDesc, r);
            //for (int i = 0; i < chars.Length; i++)
            //{
                
            //}
        }

        private void DrawStats(Card data, Template t)
        {
            if (!data.IsMonster) return;

            if (bStats == null)
                bStats = new SolidBrush(Color.FromArgb(t.Stats_Color[0], t.Stats_Color[1], t.Stats_Color[2]));

            if(t.DrawATK)
            {
                string text = string.Format(t.ATK_Format, data.ATK);
                RectangleF r = new RectangleF(t.ATK_AreaX, t.ATK_AreaY, t.ATK_Width, t.ATK_Height);
                g.DrawString(text, font_Stats, bStats, r);
            }
            if(t.DrawDEF)
            {
                string text = string.Format(t.DEF_Format, data.DEF);
                RectangleF r = new RectangleF(t.DEF_AreaX, t.DEF_AreaY, t.DEF_Width, t.DEF_Height);
                g.DrawString(text, font_Stats, bStats, r);
            }
        }

        private Brush SelectBrush(Card data)
        {
            if (data.IsSpell) return bSpell;
            else if (data.IsTrap) return bTrap;
            else if (data.IsNormalMonster) return bNormal;
            else if (data.IsNormalEffectMonster) return bEffect;
            else if (data.IsPendulum) return bPendulum;
            else if (data.IsRitualType) return bRitual;
            else if (data.IsFusionType) return bFusion;
            else if (data.IsSynchroType) return bSynchro;
            else if (data.IsXyzType) return bXyz;
            else return bToken;
        }

        private float GetCharWidth(char c)
        {
            SizeF size = g.MeasureString(c.ToString(), font_Cardname);

            // To much white space -.-
            size.Width = (float)(size.Width * 0.52f);

            return size.Width;
        }

        public static FontFamily LoadFontFamily(string fileName)
        {
            if (pfc == null)
                pfc = new PrivateFontCollection();
            pfc.AddFontFile(fileName);

            return pfc.Families[pfc.Families.Length - 1];
        }
    }
}
