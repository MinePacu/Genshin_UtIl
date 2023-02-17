using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Threading;

using Microsoft.Win32;
using System;

namespace Genshin_UtIl.UtIls
{
    public static class GenshinFolderFinder
    {
        public static string GenshinPath { get; set; }

        /// <summary>
        /// - 기능
        /// <br/>ㅤ이 프로그램이 실행된 컴퓨터에서 레지스트리의 Uninstaller 목록을 로드하여 원신이 설치되어 있는지를 확인합니다. <br/><br/> 
        /// - 반환
        /// <br/>ㅤ이 프로그램이 설치된 컴퓨터의 레지스트리의 Uninstaller 목록 서브 키에서 원신이 설치되어 있으면 true, 아니면 false를 반환합니다.
        /// </summary>
#pragma warning disable CS1998 // 이 비동기 메서드에는 'await' 연산자가 없으며 메서드가 동시에 실행됩니다.
        public static async Task<bool> CheckGenshinFromUninstallerRegistryList()
#pragma warning restore CS1998 // 이 비동기 메서드에는 'await' 연산자가 없으며 메서드가 동시에 실행됩니다.
        {
            string registry_key = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            using (Microsoft.Win32.RegistryKey key = Registry.LocalMachine.OpenSubKey(registry_key))
            {
                foreach (string subkey_name in key.GetSubKeyNames())
                {
                    using (RegistryKey subkey = key.OpenSubKey(subkey_name))
                    {
                        try
                        {
                            if (subkey.ValueCount > 1 && subkey.GetValue("DisplayName").ToString().Contains("Genshin Impact"))
                            {
                                GenshinPath = subkey.GetValue("InstallLocation").ToString() + "\\Genshin Impact game";
                                return true;
                            }
                        }

                        catch (NullReferenceException)
                        {
                            
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// - 기능
        /// <br/>ㅤ이 프로그램이 실행된 컴퓨터에서 각 파티션의 Program Files 폴더를 찾아 Genshin Impact 폴더가 있는지 확안합니다. <br/> <br/>
        /// - 반환
        /// <br/>ㅤ이 프로그램이 실행된 컴퓨터에서 각 파티션의 Program Files 폴더가 있고 Genshin Impact 폴더가 있으면 true, 없으면 false를 반환합니다.
        /// </summary>
#pragma warning disable CS1998 // 이 비동기 메서드에는 'await' 연산자가 없으며 메서드가 동시에 실행됩니다.
        public static async Task<bool> CheckGenshinFromProgramFilesFolder()
#pragma warning restore CS1998 // 이 비동기 메서드에는 'await' 연산자가 없으며 메서드가 동시에 실행됩니다.
        {
            DriveInfo[] Drives = DriveInfo.GetDrives();

            foreach (DriveInfo Drive in Drives)
            {
                if (Path.Exists(Drive.Name + "Program Files\\Genshin Impact"))
                {
                    GenshinPath = Drive.Name + "Program Files\\Genshin Impact\\Genshin Impact game";
                    return true;
                }
            }

            return false;
        }
    }
}
