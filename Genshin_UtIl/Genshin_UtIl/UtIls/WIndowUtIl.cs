using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using Microsoft.UI.Windowing;
using System.Runtime.InteropServices;

namespace Genshin_UtIl.UtIls
{
    public class WIndowUtIl
    {
        [DllImport("dwmapi.dll")]
        static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attr_ref, int attrSIze);

        public static int WIndowWIdth { get; set; }
        public static int WIndowHeIght { get; set; }
        public static int MINWIndowWIdth { get; set; }
        public static uint MAXWIndowWIdth { get; set; }

        public static int MINWIndowHeIght { get; set; }
        public static uint MAXWIndowHeIght { get; set; }

        public static void ChangeMINMAXWIndowSIze(int DIsplay_number)
        {
            MAXWIndowWIdth = DIsplayUtIl.DIsplayLIst[DIsplay_number].DIsplay_Resol.WIdth;
            MAXWIndowHeIght = DIsplayUtIl.DIsplayLIst[DIsplay_number].DIsplay_Resol.HeIght;
        }

        public static IntPtr Hwnd { get; set; }
        public static FrameworkElement Fra { get; set; }
        public static NavigationView N { get; set; }

        public static AppWindow appwIndow { get; set; }

        public struct MIN_MAX_WIndow
        {
            public int MINWIndowWIdth { get; set; }
            public uint MAXWIndowWIdth { get; set; }

            public int MINWIndowHeIght { get; set; }
            public uint MAXWIndowHeIght { get; set; }

            public MIN_MAX_WIndow(uint _MAXWIndowWIdth, uint _MAXWIndowHeIght)
            {
                MINWIndowWIdth = 0;
                MAXWIndowWIdth = _MAXWIndowWIdth;
                MINWIndowHeIght = 0;
                MAXWIndowHeIght = _MAXWIndowHeIght;
            }
        }

        public static List<MIN_MAX_WIndow> WIndowLIst { get; } = new();

        public static void SetTItleDark(IntPtr hwnd, int enable)
        {
            if (enable <= 1)
            {
                if (enable >= 0)
                    _ = DwmSetWindowAttribute(hwnd, 20, ref enable, sizeof(int));
            }
        }
    }
}
