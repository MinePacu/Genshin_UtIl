using Genshin_UtIl.UtIls.Display.Structure;
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

                if (DIsplayUtIl.DIsplayLIst.Count > 1)
                    DIsplay = int.Parse(GenshInRegIstry.GetValue("UnitySelectMonitor_h17969598").ToString());                           // 처음 원신을 열었을 때 싱글 모니터인 경우 이 값은 생성되지 않음
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
            }

            catch (Exception ep)
            {
                throw new ExcepClass(ep);
            }
        }

        public static void ApplyWidth(int _ScreenWidth)
        {
            try
            {
                GenshInRegIstry.SetValue("Screenmanager Resolution Width_h182942802", _ScreenWidth);
            }

            catch (Exception ep)
            {
                throw new ExcepClass(ep);
            }
        }

        public static void ApplyHeight(int _ScreenHeight)
        {
            try
            {
                GenshInRegIstry.SetValue("Screenmanager Resolution Height_h2627697771", _ScreenHeight);
            }

            catch (Exception ep)
            {
                throw new ExcepClass(ep);
            }
        }

        public static void ApplyDisplay(int _ScreenDisplay)
        {
            try
            {
                GenshInRegIstry.SetValue("UnitySelectMonitor_h17969598", _ScreenDisplay);
            }

            catch (Exception ep)
            {
                throw new ExcepClass(ep);
            }
        }

        public static void ApplyFullScreen(int _FullScreen)
        {
            try
            {
                GenshInRegIstry.SetValue("Screenmanager Is Fullscreen mode_h3981298716", _FullScreen);
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
