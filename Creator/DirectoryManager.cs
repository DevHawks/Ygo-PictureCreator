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
        private const string TEMPLATE_DIR_NAME = "Templates";

        private const string RESOURCES_DIR_ATTRIBUTE = "Attributes";
        private const string RESOURCES_DIR_LEVEL = "Level";
        private const string RESOURCES_DIR_CARDTYPE = "Cardtype";
        private const string RESOURCES_DIR_FONTS = "Fonts";
        private const string RESOURCES_DIR_PICS = "Pics";
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

        public static string DirTemplate
        {
            get
            {
                return Path.Combine(ApplicationPath, TEMPLATE_DIR_NAME);
            }
        }
        #endregion

        #region methods
        public static void CreateDirectorys()
        {
            if (!Directory.Exists(DirData)) Directory.CreateDirectory(DirData);
            if (!Directory.Exists(DirResults)) Directory.CreateDirectory(DirResults);
            if (!Directory.Exists(DirErrors)) Directory.CreateDirectory(DirErrors);
            if (!Directory.Exists(DirTemplate)) Directory.CreateDirectory(DirTemplate);

            if (!Directory.Exists(DirResources))
                Directory.CreateDirectory(DirResources);

            if (!Directory.Exists(Path.Combine(DirResources, RESOURCES_DIR_ATTRIBUTE)))
                Directory.CreateDirectory(Path.Combine(DirResources, RESOURCES_DIR_ATTRIBUTE));
            if (!Directory.Exists(Path.Combine(DirResources, RESOURCES_DIR_LEVEL)))
                Directory.CreateDirectory(Path.Combine(DirResources, RESOURCES_DIR_LEVEL));
            if (!Directory.Exists(Path.Combine(DirResources, RESOURCES_DIR_CARDTYPE)))
                Directory.CreateDirectory(Path.Combine(DirResources, RESOURCES_DIR_CARDTYPE));
            if (!Directory.Exists(Path.Combine(DirResources, RESOURCES_DIR_FONTS)))
                Directory.CreateDirectory(Path.Combine(DirResources, RESOURCES_DIR_FONTS));
            if (!Directory.Exists(Path.Combine(DirResources, RESOURCES_DIR_PICS)))
                Directory.CreateDirectory(Path.Combine(DirResources, RESOURCES_DIR_PICS));
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

        public static string FileTemplates(string filename)
        {
            return Path.Combine(ApplicationPath, TEMPLATE_DIR_NAME, filename);
        }

        public enum CustomFolders { Attribute, Level, Cardtype, Fonts, Pics };

        public static string FileResources(CustomFolders custom, string filename)
        {
            if (custom == CustomFolders.Pics)
                return Path.Combine(DirResources, RESOURCES_DIR_PICS, filename);
            else if (custom == CustomFolders.Attribute)
                return Path.Combine(DirResources, RESOURCES_DIR_ATTRIBUTE, filename);
            else if (custom == CustomFolders.Cardtype)
                return Path.Combine(DirResources, RESOURCES_DIR_CARDTYPE, filename);
            else if (custom == CustomFolders.Fonts)
                return Path.Combine(DirResources, RESOURCES_DIR_FONTS, filename);
            else if (custom == CustomFolders.Level)
                return Path.Combine(DirResources, RESOURCES_DIR_LEVEL, filename);
            else
                return FileResources(filename);
        }
        #endregion
    }
}
