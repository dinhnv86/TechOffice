using System.Configuration;

namespace AnThinhPhat.Utilities
{
    public static class TechOfficeConfig
    {
        private const int _PAGESIZE = 15;

        //format file image upload
        private const string _FILE_EXTENSION = "jpg,png,jpeg,gif,bmp,tif,tiff|images/*";

        private const string _PASS_DEFAULT = "phu@rieng";

        private const int _IDENTITY_PHONGNOIVU = 9;

        private const int _IDENTITY_LANHDAO = 1;

        public static int PAGESIZE
        {
            get
            {
                var settingsReader = new AppSettingsReader();
                var pagesize = _PAGESIZE;
                try
                {
                    pagesize = (int)settingsReader.GetValue("PAGESIZE", typeof(int));
                }
                catch
                {
                    pagesize = _PAGESIZE;
                }

                return pagesize;
            }
        }

        public static string FILEEXTENSION
        {
            get
            {
                var settingsReader = new AppSettingsReader();
                var fileExtension = _FILE_EXTENSION;
                try
                {
                    fileExtension = (string)settingsReader.GetValue("FILEEXTENSION", typeof(string));
                }
                catch
                {
                    fileExtension = _FILE_EXTENSION;
                }

                return fileExtension;
            }
        }

        public static string PASSDEFAULT
        {
            get
            {
                var settingsReader = new AppSettingsReader();
                var passDefault = _PASS_DEFAULT;
                try
                {
                    passDefault = (string)settingsReader.GetValue("PASSDEFAULT", typeof(string));
                }
                catch
                {
                    passDefault = _PASS_DEFAULT;
                }

                return passDefault;
            }
        }

        public static int IDENTITY_PHONGNOIVU
        {
            get
            {
                var settingsReader = new AppSettingsReader();
                var identity = _IDENTITY_PHONGNOIVU;
                try
                {
                    identity = (int)settingsReader.GetValue("IDENTITY_PHONGNOIVU", typeof(int));
                }
                catch
                {
                    identity = _IDENTITY_PHONGNOIVU;
                }

                return identity;
            }
        }

        public static int IDENTITY_LANHDAO
        {
            get
            {
                var settingsReader = new AppSettingsReader();
                var identity = _IDENTITY_LANHDAO;
                try
                {
                    identity = (int)settingsReader.GetValue("IDENTITY_LANHDAO", typeof(int));
                }
                catch
                {
                    identity = _IDENTITY_LANHDAO;
                }

                return identity;
            }
        }

        public static int LENGTHFOLDER = 10;
        public static char PADDING_CHAR = '0';
        public const string SEPARATE_CHAR = ", ";

        public static string FOLDER_UPLOAD = "~/Uploads";//folder upload;
        public static string FOLDER_UPLOAD_TACNGHIEP = FOLDER_UPLOAD + "/TN";//tac nghiep
        public static string FOLDER_UPLOAD_TT = FOLDER_UPLOAD + "/TT";//thu tuc
        public static string FOLDER_UPLOAD_CV = FOLDER_UPLOAD + "/ CV";//cong viec
        public static string FOLDER_UPLOAD_VB = FOLDER_UPLOAD + "/ VB";//van ban
    }
}