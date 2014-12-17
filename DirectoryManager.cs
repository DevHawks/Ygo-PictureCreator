using System.IO;
using System.Reflection;

namespace Ygo_Picture_Creator
{
    public static class DirectoryManager
    {
        #region fields
        public static string ApplicationPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

        private const string DATA_DIR_NAME = "Data";
        private const string PICTURE_DIR_NAME = "Resources";
        private const string RESULT_DIR_NAME = "Result";
        private const string ERROR_DIR_NAME = "Errors";
        #endregion

        #region properties
        public static string DirData
        {
            get
            {
                return Path.Combine(ApplicationPath, DATA_DIR_NAME);
            }
        }

        public static string DirResources
        {
            get
            {
                return Path.Combine(ApplicationPath, PICTURE_DIR_NAME);
            }
        }

        public static string DirResults
        {
            get
            {
                return Path.Combine(ApplicationPath, RESULT_DIR_NAME);
            }
        }

        public static string DirErrors
        {
            get
            {
                return Path.Combine(ApplicationPath, ERROR_DIR_NAME);
            }
        }
        #endregion

        #region methods
        public static void CreateDirectorys()
        {
            if (!Directory.Exists(DirData)) Directory.CreateDirectory(DirData);
            if (!Directory.Exists(DirResources)) Directory.CreateDirectory(DirResources);
            if (!Directory.Exists(DirResults)) Directory.CreateDirectory(DirResults);
            if (!Directory.Exists(DirErrors)) Directory.CreateDirectory(DirErrors);
        }

        public static string FileData(string filename)
        {
            return Path.Combine(ApplicationPath, DATA_DIR_NAME, filename);
        }

        public static string FileResources(string filename)
        {
            return Path.Combine(ApplicationPath, PICTURE_DIR_NAME, filename);
        }

        public static string FileResults(string filename)
        {
            return Path.Combine(ApplicationPath, RESULT_DIR_NAME, filename);
        }

        public static string FileErrors(string filename)
        {
            return Path.Combine(ApplicationPath, ERROR_DIR_NAME, filename);
        }
        #endregion
    }
}
