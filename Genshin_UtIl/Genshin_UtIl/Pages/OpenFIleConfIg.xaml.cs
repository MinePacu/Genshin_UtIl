using Genshin_UtIl.UtIls;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Documents;
using System;
using System.ComponentModel;
using System.Diagnostics;
using WinRT.Interop;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Genshin_UtIl.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OpenFIleConfIg : Page
    {
        public OpenFIleConfIg()
        {
            this.InitializeComponent();

            Paragraph para = (Paragraph) FolderStrIng.Blocks[0];

            ((Run) para.Inlines[0]).Text = "폴더 - " + ConfIg.Instance.GenshInFolder.GenshInFolder;

            if (ConfIg.Instance.Dev == 0)
                UtIl_.Visibility = Visibility.Collapsed;

            else
                UtIl_.Visibility = Visibility.Visible;

            if (ConfIg.Instance.GenshInFolder.ReshadeFolder == null)
            {
                para = (Paragraph)ReshadeFolderStrIng.Blocks[0];
                ((Run) para.Inlines[0]).Text = "폴더 - 설정되지 않음";
            }

            else
            {
                para = (Paragraph)ReshadeFolderStrIng.Blocks[0];
                ((Run) para.Inlines[0]).Text = "폴더 - " + ConfIg.Instance.GenshInFolder.ReshadeFolder;
            }



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

            if (ConfIg.Instance.GenshInFolder.ReshadeFolder == null)
            {
                OpenFIlterFIle.IsEnabled = false;
                ReStartReShadeTg.IsEnabled = false;
            }

            else if (ConfIg.Instance.ReShadeConfIgJ.ReShade == 0)
            {
                OpenFIlterFIle.IsEnabled = false;
                ReStartReShadeTg.IsEnabled = false;
            }

        }

        void OpenFIleFunc(object sender, RoutedEventArgs e)
        {
            ProcessUtIl.InItIalIzeChecker(0, "GenshinImpact.exe");
            ProcessUtIl.OpenProcess(0, ConfIg.Instance.GenshInFolder.GenshInFolder + "\\GenshinImpact.exe");

            if (ProcessUtIl.ReCheckt(0) > 0)
                OpenFIle.Content = "다시 시작";
            else
                return;
        }

        void OpenClIentFIleFunc(object sender, RoutedEventArgs e)
        {
            try
            {
                ProcessUtIl.InItIalIzeChecker(1, "launcher.exe");
                ProcessUtIl.OpenProcess(1, ConfIg.Instance.GenshInFolder.GenshInFolder.Replace("Genshin Impact game", "") + "launcher.exe");

                if (ProcessUtIl.ReCheckt(1) > 0)
                    OpenClIentFIle.Content = "다시 시작";
                else
                    return;
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
                ProcessUtIl.InItIalIzeChecker(2, "GenshinImpact.exe");
                ProcessUtIl.OpenProcess(2, ConfIg.Instance.GenshInFolder.ReshadeFolder + "InJect.exe");
            }

            catch (ExcepClass ep)
            {
                UtIl_Text.Text += ep.Exp.ToString() + "\r\n";
            }
        }

        async void FolderConfIgFunc(object sender, RoutedEventArgs e)
        {
            try
            {
                var hwnd = WIndowUtIl.Hwnd;

                var FIlePIcker = new Windows.Storage.Pickers.FolderPicker();
                FIlePIcker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;

                InitializeWithWindow.Initialize(FIlePIcker, hwnd);

                Windows.Storage.StorageFolder folder = await FIlePIcker.PickSingleFolderAsync();

                if (folder == null == false)
                {
                    if (FolderUtIl.CheckFIle(folder.Path, "GenshinImpact.exe") == 1)
                    {
                        Paragraph para = (Paragraph) FolderStrIng.Blocks[0];

                        ((Run) para.Inlines[0]).Text = "폴더 - " + folder.Path;
                        ConfIg.Instance.GenshInFolder.GenshInFolder = folder.Path;
                    }

                    else
                    {
                        ContentDialog nofIleDIalog = new()
                        {
                            XamlRoot = this.XamlRoot,
                            Title = "게임 파일이 없음",
                            Content = "게임 파일이 있는 폴더를 다시 지정하세요.",
                            CloseButtonText = "확인",
                            DefaultButton = ContentDialogButton.Close
                        };

                        _ = await nofIleDIalog.ShowAsync();
                    }
                }
                else if (folder == null)
                    return;
            }

            catch (Exception ep)
            {
                UtIl_Text.Text += ep.ToString() + "\r\n";
            }
        }
            
        async void ReShadeFolderConfIgFunc(object sender, RoutedEventArgs e)
        {
            try
            {
                var hwnd = WIndowUtIl.Hwnd;

                var FIlePIcker = new Windows.Storage.Pickers.FolderPicker();
                FIlePIcker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;

                InitializeWithWindow.Initialize(FIlePIcker, hwnd);

                Windows.Storage.StorageFolder folder = await FIlePIcker.PickSingleFolderAsync();

                if (folder == null == false)
                {
                    if (FolderUtIl.CheckFIle(folder.Path, "ReShade64.dll") == 1)
                    {
                        Paragraph para = (Paragraph) ReshadeFolderStrIng.Blocks[0];

                        ((Run) para.Inlines[0]).Text = "폴더 - " + folder.Path;
                        ConfIg.Instance.GenshInFolder.ReshadeFolder = folder.Path;
                    }

                    else
                    {
                        ContentDialog nofIleDIalog = new()
                        {
                            XamlRoot = this.XamlRoot,
                            Title = "Reshade.dll 파일이 없음",
                            Content = "Reshade.dll 파일이 있는 폴더를 다시 지정하세요.",
                            CloseButtonText = "확인",
                            DefaultButton = ContentDialogButton.Close
                        };
                        
                        _ = await nofIleDIalog.ShowAsync();
                    }
                }

                else if (folder == null)
                    return;
            }

            catch (Exception ep)
            {
                UtIl_Text.Text += ep.ToString() + "\r\n";
            }
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

        BackgroundWorker processchecker { get; set; } = new();
        int InItIalIzed { get; set; } = new();

        int[] t { get; set; } = new int[3];

        void InItIalIzechecker()
        {
            if (InItIalIzed == 0)
            {
                processchecker.WorkerSupportsCancellation = true;
                processchecker.DoWork += ProcessChecker_Worker;
            }

            else
                processchecker.RunWorkerAsync();
        }
        
        void ProcessChecker_Worker(object sender, DoWorkEventArgs e)
        {
            t[0] = ProcessUtIl.ReCheckt(0);
            t[1] = ProcessUtIl.ReCheckt(1);
            t[2] = ProcessUtIl.ReCheckt(2);
        }
    }
}
