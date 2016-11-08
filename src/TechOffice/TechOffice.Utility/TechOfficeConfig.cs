using System.Configuration;

namespace AnThinhPhat.Utilities
{
    public static class TechOfficeConfig
    {
        private const int _PAGESIZE = 15;

        //format file image upload
        private const string _FILE_EXTENSION = "jpg,png,jpeg,gif,bmp,tif,tiff|images/*";

        public static int PAGESIZE
        {
            get
            {
                var settingsReader = new AppSettingsReader();
                var pagesize = _PAGESIZE;
                try
                {
                    pagesize = (int) settingsReader.GetValue("PAGESIZE", typeof (int));
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
                    fileExtension = (string) settingsReader.GetValue("FILEEXTENSION", typeof (string));
                }
                catch
                {
                    fileExtension = _FILE_EXTENSION;
                }

                return fileExtension;
            }
        }
    }
}