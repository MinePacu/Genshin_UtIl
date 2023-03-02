using System.Management;
using System.Security.Principal;

using Genshin_UtIl.UtIls.AppColor.Enum;
using Microsoft.Win32;

namespace Genshin_UtIl.UtIls
{
    public static class SysUtIl
    {
        public static int IsPro()
        {
            WindowsIdentity IdentIty = WindowsIdentity.GetCurrent();
            WindowsPrincipal prIncIpal = new(IdentIty);

            if (prIncIpal.IsInRole(WindowsBuiltInRole.Administrator) == false)
            {
                return 0;
            }

            else
            {
                return 1;
            }
        }


        internal const string HKeyWIndowsAppTh = @"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Themes\Personalize";

        /// <summary>
        /// - 기능
        /// <br/>ㅤ시스템 앱 테마를 로드합니다.
        /// </summary>
        /// <returns>시스템 앱 테마 (다크 또는 라이트)</returns>
        public static Appth GetAppTh()
        {
            int res = (int)Registry.GetValue(HKeyWIndowsAppTh, "AppsUseLightTheme", -1);
            //Debug.WriteLine("res - " + res);

            if (res == 0)
                return Appth.Dark;
            else
                return Appth.Light;
        }

        public static string GetOSFriendlyVersion()
        {
            string result = string.Empty;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem");
            foreach (ManagementObject os in searcher.Get())
            {
                result = os["Caption"].ToString();
                break;
            }
            return result;
        }
    }
}
