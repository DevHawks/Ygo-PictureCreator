using System;
using System.IO;
using System.Windows;
using System.Xml.Serialization;

namespace Ygo_Picture_Creator
{
    public static class Program
    {
        private static string _dbpath = "";

        public static Configurations Config;
        public static MainWindow MainWin;
        public static CardManagement CardManager;

        public static void Run(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;

            DirectoryManager.CreateDirectorys();

            for (int i = 0; i != args.Length; ++i)
            {
                if (args[i].EndsWith(".cdb"))
                {
                    FileInfo info = new FileInfo(args[i]);
                    if (info.Exists)
                    {
                        DbPath = args[i];
                    }
                }
            }

            Config = new Configurations();
            if (!File.Exists(DirectoryManager.FileData("config.xml")))
                SerializeClass(DirectoryManager.FileData("config.xml"), Config, typeof(Configurations));
            else    
            {
                Config = (Configurations)DeserializeClass(DirectoryManager.FileData("config.xml"), typeof(Configurations));
            }

            MainWin = new MainWindow();
            MainWin.Show();
        }

        public static string DbPath
        {
            get
            {
                return _dbpath;
            }
            set
            {
                _dbpath = value;
                CardManager = new CardManagement(new Database(value));
            }
        }

        private static void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {

            Exception exception = e.ExceptionObject as Exception ?? new Exception();

            System.IO.File.WriteAllText(
                DirectoryManager.FileErrors(DateTime.UtcNow.ToString("yyyy-MM-dd_HH-mm-ss") + ".txt"),
                exception.ToString());

            MessageBox.Show(exception.Message);

            Console.WriteLine(exception.ToString());
        }

        public static void SerializeClass(string filePath, Object ressource, Type type)
        {
            XmlSerializer serializer = new XmlSerializer(type);
            TextWriter textWriter = new StreamWriter(filePath);
            serializer.Serialize(textWriter, ressource);
            textWriter.Close();
        }

        public static object DeserializeClass(string filePath, Type type)
        {
            Object res;
            XmlSerializer deserializer = new XmlSerializer(type);
            TextReader textReader = new StreamReader(filePath);
            res = deserializer.Deserialize(textReader);
            textReader.Close();

            return res;
        }
    }
}
