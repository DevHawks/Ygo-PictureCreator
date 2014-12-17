using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace Ygo_Picture_Creator
{
    public class CardPicture
    {
        public Card CardData { get; private set; }
        public Bitmap FullBitmap;

        private static Bitmap border_xyz = new Bitmap(DirectoryManager.FileData("xyz.png"));

        #region Bitmaps Attribute 
        private static Bitmap attribute_dark = new Bitmap(DirectoryManager.FileData("dark.png"));
        private static Bitmap attribute_light = new Bitmap(DirectoryManager.FileData("light.png"));
        private static Bitmap attribute_fire = new Bitmap(DirectoryManager.FileData("fire.png"));
        private static Bitmap attribute_water = new Bitmap(DirectoryManager.FileData("water.png"));
        private static Bitmap attribute_wind = new Bitmap(DirectoryManager.FileData("wind.png"));
        private static Bitmap attribute_earth = new Bitmap(DirectoryManager.FileData("earth.png"));
        private static Bitmap attribute_divine = new Bitmap(DirectoryManager.FileData("divine.png"));
        private static Bitmap attribute_spell = new Bitmap(DirectoryManager.FileData("magic.png"));
        private static Bitmap attribute_trap = new Bitmap(DirectoryManager.FileData("trap.png"));
        #endregion

        public CardPicture(Card card)
        {
            CardData = card;
        }

        public void Save()
        {
            if (!CardData.IsXyzType) return;

            FullBitmap = new Bitmap(177, 256);

            Graphics g = Graphics.FromImage(FullBitmap);

            if(CardData.IsMonster)
            {
                if(CardData.IsXyzType)
                    g.DrawImage(border_xyz, new Rectangle(0, 0, 177, 256));
            }

            g.DrawString(CardData.Cardname, new Font("Segoe UI", 12), Brushes.Gold, new PointF(20, 20));

            CreateFile();
        }

        private void CreateFile()
        {
            try
            {
                FullBitmap.Save(DirectoryManager.FileResults(CardData.CardID + ".jpg"), ImageFormat.Jpeg);
                Program.MainWin.Write(CardData.CardID + ".jpg wurde erstellt.");
            }
            catch (Exception ex)
            {
                Program.MainWin.Write(ex.Message);
            }
        }
    }
}
