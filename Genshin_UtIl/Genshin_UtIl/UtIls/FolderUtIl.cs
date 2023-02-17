using System;
using System.IO;

namespace Genshin_UtIl.UtIls
{
    public static class FolderUtIl
    {
        public static string GenshInFolder { get; set; }

        public static string ReshadeFolder { get; set; }

        public static int CheckFIle(string _folderPath, string _fIle)
        {
            try
            {
                if (File.Exists(_folderPath + "\\" + _fIle))
                    return 1;
                else
                    return 0;
            }

            catch (Exception ep)
            {
                throw new ExcepClass(ep);
            }
        }
    }
}
