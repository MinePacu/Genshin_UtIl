using Genshin_UtIl.UtIls;
using Microsoft.UI.Xaml;
using System.Diagnostics;
using System;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Genshin_UtIl
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            ConfIg.Load();

            string Prog = Environment.CurrentDirectory + "\\" + "GenshIn_UtIl.exe";

            try
            {
                DIsplayUtIl.InitializeDisplayList();
            }

            catch (ExcepClass)
            {
            }

            /*
            try
            {
                RegIstryUtIl.InItIalIzeRegIstry();
            }

            catch (ExcepClass)
            {
            }
            */

            if (ConfIg.Instance.ReStartConf.RequestRestartProgramWIthPro == 1)
            {
                if (SysUtIl.IsPro() == 0)
                {
                    ProcessStartInfo Proce = new(Prog)
                    {
                        UseShellExecute = true,
                        Verb = "Runas",
                        Arguments = "restart"
                    };

                    try
                    {
                        Process.Start(Proce);
                        Environment.Exit(0);
                    }

                    catch (Exception)
                    {
                    }
                }
            }

            if (ConfIg.Instance.FIrstOpenProgram == 1)
                m_window = new InitializeProgram();

            else
                m_window = new WIndowPage();

            m_window.Activate();
        }

        Window m_window;
    }
}
