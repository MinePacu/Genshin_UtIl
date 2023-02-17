using System.IO;

namespace Genshin_UtIl.UtIls.ReShadeUtIl
{
    public static class ConfIgReader
    {
        static string ConfIgFIle { get; } = ConfIg.Instance.GenshInFolder.ReshadeFolder + "\\ReShade.ini";
        public static string[] ConfIgTet { get; set; }
        
        public static void ReadConfIg()
        {
            ConfIgTet = File.ReadAllLines(ConfIgFIle);
        }
    }
}
