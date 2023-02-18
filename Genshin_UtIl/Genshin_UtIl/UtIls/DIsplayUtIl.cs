using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

using Genshin_UtIl.UtIls.Display.Enum;
using Genshin_UtIl.UtIls.Display.Structure;

namespace Genshin_UtIl.UtIls
{
    public static class DIsplayUtIl
    {
        public static bool InItIalIzed { get; set; } = false;

        [DllImport("user32.dll")]
        static extern bool EnumDisplayDevices(string lpDevice, uint iDevNum, ref DISPLAY_DEVICE lpDisplayDevice, uint dwFlags);

        [DllImport("User32.dll")]
        internal static extern bool EnumDisplaySettings(string lpszDevice, int iModeNum, ref Devmode lpDevMode);

        public static List<DIsplays> DIsplayLIst { get; } = new();
        public static List<string> DIsplay_strIng_LIst { get; } = new();

        public static List<string> DIsplay_strIng_LIst_Sorted { get; } = new();

        public readonly static BackgroundWork.TaskUtil DisplayLoadTask = new(new(InitializeDisplayList));

        /// <summary>
        /// - 기능
        /// <br/>ㅤ디스플레이 리스트를 초기화합니다. <br/> <br/>
        /// - 예외
        /// <br/>ㅤ<see cref="ExcepClass"/>
        /// </summary> 
        public static async Task InitializeDisplayList()
        {
            DIsplayLIst.Clear();
            DIsplay_strIng_LIst.Clear();
            DIsplay_strIng_LIst_Sorted.Clear();


            DISPLAY_DEVICE d = new();
            Devmode dev = new();

            d.cb = Marshal.SizeOf(d);
            try
            {
                for (uint id = 0; EnumDisplayDevices(null, id, ref d, 0); id++)
                {
                    if (d.StateFlags.HasFlag(DisplayDeviceStateFlags.AttachedToDesktop))
                    {
                        if (EnumDisplaySettings(d.Device, -1, ref dev))
                        {
                            if (d.StateFlags.HasFlag(DisplayDeviceStateFlags.PrimaryDevice))
                            {
                                DIsplayLIst.Add(new(d.Device, new(dev.dmPelsWidth, dev.dmPelsHeight), dev.dmPosition, dev.dmDisplayFrequency, true));
                            }
                            else
                            {
                                DIsplayLIst.Add(new(d.Device, new(dev.dmPelsWidth, dev.dmPelsHeight), dev.dmPosition, dev.dmDisplayFrequency, false));
                            }

                            WIndowUtIl.WIndowLIst.Add(new(dev.dmPelsWidth, dev.dmPelsHeight));
                        }

                        d.cb = Marshal.SizeOf(d);
                        EnumDisplayDevices(d.Device, 0, ref d, 0);

                        DIsplay_strIng_LIst.Add("디스플레이 " + (DIsplay_strIng_LIst.Count - (-1)).ToString());
                        DIsplay_strIng_LIst_Sorted.Add("디스플레이 " + (DIsplay_strIng_LIst_Sorted.Count - (-1)).ToString());
                    }
                    d.cb = Marshal.SizeOf(d);
                }

                InItIalIzed = true;
            }

            catch (Exception ep)
            {
                throw new ExcepClass(ep);
            }

            await Task.Delay(10000);
        }

        public static void SortDIsplayLIst()
        {
            int tmp = 0;
            while (tmp < DIsplayLIst.Count)
            {
                if (DIsplayLIst[tmp].IsPrImaryDIsplay == true)
                {
                    var tmp_ = DIsplay_strIng_LIst_Sorted[tmp];
                    DIsplay_strIng_LIst_Sorted.RemoveAt(tmp);
                    DIsplay_strIng_LIst_Sorted.Insert(0, tmp_);

                    tmp = DIsplayLIst.Count;
                }

                tmp++;
            }
        }

        public static int GetDIsplayN(string DIsplay_StrIng)
        {
            int tmp = 0;
            int n = 0;

            while (tmp < DIsplay_strIng_LIst_Sorted.Count)
            {
                if (DIsplay_strIng_LIst_Sorted[tmp] == DIsplay_StrIng)
                {
                    n = tmp;
                    tmp = DIsplay_strIng_LIst_Sorted.Count;
                }

                else
                    tmp++;
            }

            return n;
        }

        public static int GetDIsplayN_NS(string DIsplay_StrIng)
        {
            int tmp = 0;
            int n = 0;

            while (tmp < DIsplay_strIng_LIst.Count)
            {
                if (DIsplay_strIng_LIst[tmp] == DIsplay_StrIng)
                {
                    n = tmp;
                    tmp = DIsplay_strIng_LIst_Sorted.Count;
                }

                else
                    tmp++;
            }

            return n;
        }

        static void SwapLIst<T>(this List<T> list, int _from, int _to)
        {
            T tmp = list[_from];
            list[_from] = list[_to];
            list[_to] = tmp;
        }
    }
}
