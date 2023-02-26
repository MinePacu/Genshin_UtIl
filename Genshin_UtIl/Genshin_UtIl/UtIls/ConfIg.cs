using System;
using System.Text.Json;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using Genshin_UtIl.UtIls.Exceptions;

namespace Genshin_UtIl.UtIls
{
    public class ConfIg
    {
        public static string FIleStrIng = "confIg";

        public class ConfIgEle
        {
            public int FIrstOpenProgram { get; set; } = 1;
            public int ProgramWIndowWIdth { get; set; } = 1290;
            public int ProgramWIndowHeIght { get; set; } = 540;

            public string FIrstPage { get; set; } = "WIndow";

            public WIndowConfIg WInConfIg { get; set; } = new();
            public GenshInFolderClass GenshInFolder { get; set; } = new();
            public ReShadeConfIgJson ReShadeConfIgJ { get; set; } = new();

            public ReStartConfIg ReStartConf { get; set; } = new();

            public ProgramConfig Programconfig { get; set; } = new();

            public BluetoothConfig BluetoothConfig { get; set; } = new();

            public int AppTh { get; set; } = 0;
            public bool Dev { get; set; } = false;

            public string Args { get; set; } = null;

        }

        public static ConfIgEle Instance { get; set; } = new();

        public class WIndowConfIg
        {
            public bool LImItWIndowSIze { get; set; } = false;
            public int WIndowmode { get; set; } = 0;
        }

        public class GenshInFolderClass
        {
            public string GenshInFolder { get; set; }

            public string ReshadeFolder { get; set; }
        }

        public class ReShadeConfIgJson
        {
            public int ReShade { get; set; } = 0;
            public int AutoReStartReShade { get; set; } = 0;
            public int AgreeUsIngReShade { get; set; } = 0;
        }

        public class ReStartConfIg
        {
            public int RequestRestartProgramWIthPro { get; set; } = 0;
            public int ReStartFunc { get; set; } = 0;

            public string ReStartPage { get; set; } = "WIndow";
        }

        public class ProgramConfig
        {
            public int x { get; set; } = 0;
            public int y { get; set; } = 0;
        }

        public class BluetoothConfig
        {
            public bool IsturnOnBluetooth { get; set; } = false;
            public bool IsturnOffBluetooth { get; set; } = false;
        }
        public static void Load()
        {
            try
            {
                if (File.Exists($@"{Directory.GetCurrentDirectory()}\{FIleStrIng}.json") == false)
                {
                    File.WriteAllText($@"{Directory.GetCurrentDirectory()}\{FIleStrIng}.json", "{ }");
                }
                string JsonStrIng = File.ReadAllText($@"{Directory.GetCurrentDirectory()}\{FIleStrIng}.json");

                var optIons = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };

                Instance = JsonSerializer.Deserialize<ConfIgEle>(JsonStrIng);
            }

            catch (Exception)
            {
                throw new ConfIgException("LoadConfig");
            }
        }

        public static void Save()
        {
            try
            {
                JsonSerializerOptions optIons = new()
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                    PropertyNameCaseInsensitive = true,
                    WriteIndented = true
                };

                string Json = JsonSerializer.Serialize(Instance, optIons);
                File.WriteAllText($@"{Directory.GetCurrentDirectory()}\{FIleStrIng}.json", Json);
            }

            catch (Exception)
            {
                throw new ConfIgException("SaveConfig");
            }
        }
    }
}
