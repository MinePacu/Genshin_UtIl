using Genshin_UtIl.interfaces.XamlRoot;
using Genshin_UtIl.UtIls;

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Documents;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

using WinRT.Interop;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Genshin_UtIl.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public partial class OpenFIleConfIg : Page, IXamlRoot
    {

        public OpenFIleConfIg()
        {
            this.InitializeComponent();

            //GenshinFolderTextBlock.DataContext = this;
            //ReshadeFolderTextBlock.DataContext = this;

            //OpenFIlterFIle.DataContext = this;
            //ReStartReShadeTg.DataContext = this;

            BluetoothPanel.DataContext = new ViewModels.OpenProgramViewModel();

            if (ConfIg.Instance.Dev == false)
                UtIl_.Visibility = Visibility.Collapsed;

            else
                UtIl_.Visibility = Visibility.Visible;


            if (ConfIg.Instance.ReStartConf.ReStartFunc == 0 == false)
            {
                if (ConfIg.Instance.ReStartConf.ReStartFunc == 1)
                {
                }

                else if (ConfIg.Instance.ReStartConf.ReStartFunc == 2)
                {
                }
            }

            if (ConfIg.Instance.ReStartConf.ReStartPage == "WIndow" == false)
                ConfIg.Instance.ReStartConf.ReStartPage = "WIndow";
        }

        void OpenFIleFunc(object sender, RoutedEventArgs e)
        {
            ProcessUtIl.OpenProcess(0, ConfIg.Instance.GenshInFolder.GenshInFolder + "\\GenshinImpact.exe");

            //if (ProcessUtIl.ReCheckt(0) > 0)
                OpenFIle.Content = "다시 시작";
        }

        void OpenClIentFIleFunc(object sender, RoutedEventArgs e)
        {
            try
            {
                ProcessUtIl.OpenProcess(1, ConfIg.Instance.GenshInFolder.GenshInFolder.Replace("Genshin Impact game", "") + "launcher.exe");
            }

            catch (ExcepClass ep)
            {
                UtIl_Text.Text += ep.Exp.ToString() + "\r\n";
            }
        }

        void OpenFIlterFIleFunc(object sender, RoutedEventArgs e)
        {
            try
            {
                ProcessUtIl.OpenProcess(2, ConfIg.Instance.GenshInFolder.ReshadeFolder + "InJect.exe");
            }

            catch (ExcepClass ep)
            {
                UtIl_Text.Text += ep.Exp.ToString() + "\r\n";
            }
        }

        void FolderConfIgFunc(object sender, RoutedEventArgs e)
        {
            IXamlRoot.FolderConfigWindowXamlRoot = XamlRoot;
        }
            
        void ReShadeFolderConfIgFunc(object sender, RoutedEventArgs e)
        {
            IXamlRoot.FolderConfigWindowXamlRoot = XamlRoot;
        }

        void ReStartReShade(object sender, RoutedEventArgs e)
        {
            var Toggle = (ToggleSwitch) sender;

            if (Toggle.IsOn)
                ConfIg.Instance.ReShadeConfIgJ.AutoReStartReShade = 1;

            else
                ConfIg.Instance.ReShadeConfIgJ.AutoReStartReShade = 0;
        }

        void ReStartReShadeTuFunc(object sender, RoutedEventArgs e)
        {
            var TutoWIndow = new TutorIal("OpenGameCon", WIndowUtIl.appwIndow.Size.Width, WIndowUtIl.appwIndow.Size.Height);
            TutoWIndow.Activate();

            GC.Collect();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler == null == false)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
