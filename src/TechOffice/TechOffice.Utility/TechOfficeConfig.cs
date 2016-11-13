using System.Configuration;

namespace AnThinhPhat.Utilities
{
    public static class TechOfficeConfig
    {
        private const int _PAGESIZE = 15;

        //format file image upload
        private const string _FILE_EXTENSION = "jpg,png,jpeg,gif,bmp,tif,tiff|images/*";

        private const string _PASS_DEFAULT = "phu@rieng";

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

        public static int LENGTHFOLDER = 10;
    }
}