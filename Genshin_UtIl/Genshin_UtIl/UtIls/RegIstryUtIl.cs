using Genshin_UtIl.UtIls.Exceptions.Registry;

using Microsoft.Win32;
using System;

namespace Genshin_UtIl.UtIls
{
    public static class RegIstryUtIl
    {
        static readonly string GenshInRegIstryStrIng = @"Software\miHoYo\Genshin Impact";
        static RegistryKey GenshInRegIstry { get; set; }

        public static int InItIalIzed { get; set; } = 0;

        public static int ScreenWIdth { get; set; }
        public static int ScreenHeIght { get; set; }
        public static int DIsplay { get; set; }
        public static int FullScreen { get; set; }


        /// <summary>
        /// 원신의 해상도와 게임 스크린 레지스트리를 담은 인스턴스를 초기화합니다.
        /// </summary>
        /// <exception cref="GenshinRegistryNullException"/>
        public static void InItIalIzeRegIstry()
        {
            GenshInRegIstry = Registry.CurrentUser.OpenSubKey(GenshInRegIstryStrIng, true);

            if (GenshInRegIstry == null)
                throw new GenshinRegistryNullException();

            else
            {
                ScreenWIdth = int.Parse(GenshInRegIstry.GetValue("Screenmanager Resolution Width_h182942802").ToString());
                ScreenHeIght = int.Parse(GenshInRegIstry.GetValue("Screenmanager Resolution Height_h2627697771").ToString());
                DIsplay = int.Parse(GenshInRegIstry.GetValue("UnitySelectMonitor_h17969598").ToString());
                FullScreen = int.Parse(GenshInRegIstry.GetValue("Screenmanager Is Fullscreen mode_h3981298716").ToString());

                InItIalIzed = 1;
            }
        }

        /// <summary>
        /// 지정된 해상도와 게임 스크린 설정을 레지스트리에 적용합니다.
        /// </summary>
        /// <exception cref="ExcepClass" />
        public static void ApplyRegIstry(int _ScreenWIdth, int _ScreenHeIght, int _DIsplay, int _FullScreen)
        {
            try
            {
                GenshInRegIstry.SetValue("Screenmanager Resolution Width_h182942802", _ScreenWIdth);
                GenshInRegIstry.SetValue("Screenmanager Resolution Height_h2627697771", _ScreenHeIght);
                GenshInRegIstry.SetValue("UnitySelectMonitor_h17969598", _DIsplay);
                GenshInRegIstry.SetValue("Screenmanager Is Fullscreen mode_h3981298716", _FullScreen);

                InItIalIzed = 0;
            }

            catch (Exception ep)
            {
                throw new ExcepClass(ep);
            }
        }
    }

    public class ExcepClass : Exception
    {
        public Exception Exp { get; set; }

        public ExcepClass(Exception _Exp)
        {
            Exp = _Exp;
        }
    }
}
