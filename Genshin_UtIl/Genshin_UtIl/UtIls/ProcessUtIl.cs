using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Genshin_UtIl.UtIls
{
    public static class ProcessUtIl
    {
        public readonly static BackgroundWork.TaskUtil GenshinProcessCheckerTask = new(new(CheckGenshinProcess));
        public readonly static BackgroundWork.TaskUtil ClientProcessCheckerTask = new(new(CheckClientProcess));
        public readonly static BackgroundWork.TaskUtil ReshadeProcessCheckerTask = new(new(CheckReshadeProcess));

        /// <summary>
        /// 지정한 프로세스를 엽니다.
        /// </summary>
        /// <returns>프로세스 리소스와 연관된 <see cref="Process"/> 클래스 또는 연 프로세스 리소스가 없으면 <see cref="null"/>
        /// <br/> 따로 같은 프로세스가 이미 열려 있는 새로운 프로세스는 이미 있는 프로세스와는 독립적입니다.</returns>
        /// <exception cref="ExcepClass"></exception>
        public async static void OpenProcess(int _Index, string _ProcessPath)
        {
            if (ConfIg.Instance.BluetoothConfig.IsturnOnBluetooth)
                await BluetoothUtil.OnOffBluetooth(true);

            if (_Index == 2)
            {
                OpenFIlterProcess(2, _ProcessPath);
                //return null;
            }

            Process proInfo = new();

            try
            {
                string Prog = _ProcessPath;

                ProcessStartInfo Proce = new(Prog)
                {
                    UseShellExecute = true,
                    Verb = "Runas"
                };

                if (ConfIg.Instance.WInConfIg.WIndowmode == 0)
                    Proce.Arguments = "-popupwindow";

                try
                {
                    proInfo = Process.Start(Proce);
                }

                catch (Exception)
                {
                }

                if (_Index == 0)
                    GenshinProcessCheckerTask.StartTask();
                else if (_Index == 1)
                    ClientProcessCheckerTask.StartTask();

                //return proInfo;
            }

            catch (Exception ep)
            {
                throw new ExcepClass(ep);
            }
        }

        public static void OpenFIlterProcess(int _Index, string _ProcessPath)
        {
            try
            {
                string Prog = _ProcessPath;

                string _Path = Environment.CurrentDirectory + "\\tep.cmd";
                string re = "cd /d " + ConfIg.Instance.GenshInFolder.ReshadeFolder + Environment.NewLine + "InJect.exe GenshinImpact.exe" + Environment.NewLine;

                FileStream fs = File.Open(_Path, FileMode.Create);
                byte[] by_Text = System.Text.Encoding.UTF8.GetBytes(re);
                fs.Write(by_Text, 0, by_Text.Length);
                fs.Close();

                ProcessStartInfo Proce = new(_Path)
                {
                    Verb = "Runas"
                };

                ProcessStartInfo tp = new(ConfIg.Instance.GenshInFolder.ReshadeFolder + "\\InJect.exe")
                {
                    Verb = "Runas",
                    Arguments = "GenshinImpact.exe"
                };

                var pro = new Process()
                {
                    StartInfo = Proce
                };

                ProcessStartInfo Proce_ = new(ConfIg.Instance.GenshInFolder.GenshInFolder + "\\GenshInImpact.exe")
                {
                    UseShellExecute = true,
                    Verb = "Runas"
                };

                if (ConfIg.Instance.WInConfIg.WIndowmode == 1)
                {
                    Proce_.WindowStyle = ProcessWindowStyle.Normal;
                    Proce_.Arguments = "-popupwindow";
                }

                try
                {
                    Process.Start(tp);

                    Thread.Sleep(1000);

                    Process.Start(Proce_);
                }

                catch (Exception)
                {
                }

                ReshadeProcessCheckerTask.StartTask();
            }

            catch (Exception ep)
            {
                throw new ExcepClass(ep);
            }
        }

        static async Task CheckGenshinProcess()
        {
            Process[] GenshinProcess = Process.GetProcessesByName("genshinimpact");
            if (GenshinProcess.Length < 1)
            {
                if (ConfIg.Instance.BluetoothConfig.IsturnOffBluetooth)
                    await BluetoothUtil.OnOffBluetooth(false);
                GenshinProcessCheckerTask.Cancel.Cancel();
            }
            else
                await Task.Delay(500);
        }

        static async Task CheckClientProcess()
        {
            Process[] ClientProcess = Process.GetProcessesByName("launcher");
            if (ClientProcess.Length < 1)
            {
                if (ConfIg.Instance.BluetoothConfig.IsturnOffBluetooth)
                    await BluetoothUtil.OnOffBluetooth(false);
                ClientProcessCheckerTask.Cancel.Cancel();
            }
            else
                await Task.Delay(500);
        }

        static async Task CheckReshadeProcess()
        {
            Process[] GenshinProcess = Process.GetProcessesByName("InJect");
            if (GenshinProcess.Length < 1)
            {
                if (ConfIg.Instance.BluetoothConfig.IsturnOffBluetooth)
                    await BluetoothUtil.OnOffBluetooth(false);
                ReshadeProcessCheckerTask.Cancel.Cancel();
            }
            else
                await Task.Delay(500);
        }
    }
}
