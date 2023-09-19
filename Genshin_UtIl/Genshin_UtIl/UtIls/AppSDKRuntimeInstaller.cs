using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_UtIl.UtIls
{
    [Obsolete]
    public static class AppSDKRuntimeInstaller
    {
        static readonly string InstallerFile = Environment.CurrentDirectory + "\\WindowsAppRuntimeInstall.exe";

        [Obsolete]
        public async static Task InstallSDKRuntime()
        {
            ProcessStartInfo AppSdkInstaller = new ProcessStartInfo(InstallerFile)
            {
                RedirectStandardOutput = true,
            };

            Process.Start(AppSdkInstaller);

            await Task.Delay(2000);
        }
    }
}
