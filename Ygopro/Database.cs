using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace Ygo_Picture_Creator
{
    public class Database
    {
        private String dbConnection;
        private string sqlQuery = "SELECT datas.[id], datas.[ot], datas.[alias], datas.[setcode], datas.[type], " +
            "datas.[atk], datas.[def], datas.[level], datas.[race], datas.[attribute], datas.[category], " +
            "texts.[name],texts.[desc] FROM datas, texts WHERE texts.[id] = datas.[id] ORDER BY datas.[level] " +
            "DESC, datas.[atk] DESC;";

        public Database(string path)
        {
            dbConnection = String.Format("Data Source={0}", path);
        }

        public List<Card> GetCardSearch()
        {
            List<Card> rowStringArrayList = new List<Card>();

            try
            {
                SQLiteConnection sqConnection = new SQLiteConnection(dbConnection);
                sqConnection.Open();
                SQLiteCommand mycommand = new SQLiteCommand(sqlQuery, sqConnection);
                SQLiteDataReader reader = mycommand.ExecuteReader();

                try
                {
                    while (reader.Read())
                    {
                        Card card = new Card();

                        int column = 0;

                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            switch (column)
                            {
                                case 0: card.CardID = reader.GetInt32(i); break;
                                case 1: card.CardOT = reader.GetInt32(i); break;
                                case 2: card.CardAlias = reader.GetInt32(i); break;
                                case 3: card.CardSetcode = reader.GetInt32(i); break;
                                case 4: card.CardType = reader.GetInt32(i); break;
                                case 5: card.CardAtk = reader.GetInt32(i); break;
                                case 6: card.CardDef = reader.GetInt32(i); break;
                                case 7: card.CardLevel = reader.GetInt32(i); break;
                                case 8: card.CardRace = reader.GetInt32(i); break;
                                case 9: card.CardAttribute = reader.GetInt32(i); break;
                                case 10: card.CardCategory = reader.GetInt32(i); break;
                                case 11: card.Cardname = reader.GetString(i); break;
                                case 12: card.CardDescription = reader.GetString(i); break;
                            }

                            column++;
                        }
                        rowStringArrayList.Add(card);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    reader.Close();
                    sqConnection.Close();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return rowStringArrayList;
        }
    }
}
