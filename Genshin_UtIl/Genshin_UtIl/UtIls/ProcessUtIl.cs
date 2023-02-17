using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace Genshin_UtIl.UtIls
{
    public static class ProcessUtIl
    {
        static ProcessClass[] ProcessCheckers { get; set; } = new ProcessClass[3];

        public static void InItIalIzeChecker(int _Index, string _Process)
        {
            try
            {
                ProcessCheckers[_Index] = new(_Process);
            }

            catch (Exception ep)
            {
                throw new ExcepClass(ep);
            }
        }

        /// <summary>
        /// 지정한 프로세스를 엽니다.
        /// </summary>
        /// <returns>프로세스 리소스와 연관된 <see cref="Process"/> 클래스 또는 연 프로세스 리소스가 없으면 <see cref="null"/>
        /// <br/> 따로 같은 프로세스가 이미 열려 있는 새로운 프로세스는 이미 있는 프로세스와는 독립적입니다.</returns>
        /// <exception cref="ExcepClass"></exception>
        public static Process? OpenProcess(int _Index, string _ProcessPath)
        {
            if (_Index == 2)
            {
                OpenFIlterProcess(2, _ProcessPath);
                return null;
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

                if (ConfIg.Instance.WInConfIg.WIndowmode == 1)
                    Proce.Arguments = "-popupwindow";

                try
                {
                    proInfo = Process.Start(Proce);
                }

                catch (Exception)
                {
                }

                ProcessCheckers[_Index].InItIalIzeWorker();

                return proInfo;
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

                ProcessCheckers[_Index].InItIalIzeWorker();
            }

            catch (Exception ep)
            {
                throw new ExcepClass(ep);
            }
        }

        public static int ReCheckt(int _Index)
        {
            return ProcessCheckers[_Index].t;
        }
    }

    class ProcessClass
    {
        public BackgroundWorker ProcessCheck { get; set; }
        public string ProcessFIle { get; set; }

        public int t { get; set; } = 0;
        int InItIalIzed { get; set; } = 0;
        int DIsposed { get; set; } = 0;

        public void InItIalIzeWorker()
        {
            if (InItIalIzed == 0)
            {
                ProcessCheck.WorkerSupportsCancellation = true;
                ProcessCheck.DoWork += CheckProcess;
                ProcessCheck.RunWorkerCompleted += AfterCheckProcess;
                InItIalIzed = 1;
            }

            else
                ProcessCheck.RunWorkerAsync();
        }

        void CheckProcess(object sender, DoWorkEventArgs e)
        {
            if (e.Cancel == false)
            {
                Process[] profIle_process = Process.GetProcesses();

                int tmp = 0;
                t = 0;
                while (tmp < profIle_process.Length)
                {
                    try
                    {
                        if (profIle_process[tmp].ProcessName == ProcessFIle)
                            t++;
                        tmp++;
                    }

                    catch (Exception ep)
                    {
                        e.Cancel = true;
                        throw new ExcepClass(ep);
                    }
                }

                if (t == 0)
                    e.Cancel = true;

                else
                {
                    try
                    {
                        Thread.Sleep(1240);
                    }

                    catch (Exception ep_)
                    {
                        e.Cancel = true;
                        throw new ExcepClass(ep_);
                    }

                }
            }
        }

        void AfterCheckProcess(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                ProcessCheck.Dispose();
                InItIalIzed = 0;
                DIsposed = 1;
                return;
            }

            else
                InItIalIzeWorker();
        }

        public void ReInItIalWorker()
        {
            if (DIsposed == 1)
                ProcessCheck = new();
        }

        public ProcessClass(string _ProcessFIle)
        {
            ProcessCheck = new();
            ProcessFIle = _ProcessFIle;
        }
    }
}
