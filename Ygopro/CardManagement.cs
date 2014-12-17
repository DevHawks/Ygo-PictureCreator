using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ygo_Picture_Creator
{
    public class CardManagement
    {
        public Database CurrentDatabase;
        public IReadOnlyList<Card> Cardlist;

        private Thread creationThread;
        private bool isRunning = false;

        public CardManagement(Database db)
        {
            CurrentDatabase = db;
            ReadDatabase();
        }

        private void ReadDatabase()
        {
            try
            {
                Cardlist = CurrentDatabase.GetCardSearch();

                Console.WriteLine(Cardlist.Count + " Cards loaded.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void CreatePictures()
        {
            if (Cardlist.Count < 1)
            {
                Program.MainWin.Write("No Database selected.", MainWindow.ConsoleMsgType.Error);
                return;
            }

            creationThread = new Thread(new ThreadStart(DoIt));
            creationThread.Start();
        }

        // yes i know, the name ^^
        private void DoIt()
        {
            if (isRunning)
            {
                Program.MainWin.Write("process is already running.", MainWindow.ConsoleMsgType.Warning);
                return;
            }

            isRunning = true;
            for (int i = 0; i < Cardlist.Count; i++)
            {
                CardPicture pic = new CardPicture(Cardlist[i]);
                pic.Save();

                Thread.Sleep(5);
            }
            isRunning = false;
            Program.MainWin.Write("process completed.", MainWindow.ConsoleMsgType.Warning);
        }

        public void Cancel()
        {
            creationThread.Abort();
            Program.MainWin.Write("process been canceled.", MainWindow.ConsoleMsgType.Warning);
        }
    }
}
