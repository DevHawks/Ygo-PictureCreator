using System;
using System.Collections.Generic;

namespace Ygo_Picture_Creator
{
    public class CardManagement
    {
        public Database CurrentDatabase;
        public IReadOnlyList<Card> Cardlist;
        public CardCreator Creator;

        public CardManagement(Database db)
        {
            CurrentDatabase = db;
            ReadDatabase();

            Creator = new CardCreator(Program.MainWin.GetCurrentTemplate());
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
    }
}
