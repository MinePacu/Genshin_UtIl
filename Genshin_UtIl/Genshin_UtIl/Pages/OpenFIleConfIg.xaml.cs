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
    public partial class OpenFIleConfIg : Page, INotifyPropertyChanged
    {
        public string _GenshinFolderString = "폴더 - ";
        public string _ReshadeFolderString = "폴다 - ";

        public bool _IsOpenReshadeFile = false;
        public bool _IsRestartReshadeEnable = false;

        public string GenshinFolderString
        {
            get => _GenshinFolderString;
            set
            {
                _GenshinFolderString = value;
                NotifyPropertyChanged();
            }
        }
        public string ReshadeFolderString
        {
            get => _ReshadeFolderString;
            set
            {
                _ReshadeFolderString = value;
                NotifyPropertyChanged();
            }
        }

        public bool IsOpenReshadeFile
        {
            get => _IsOpenReshadeFile;
            set
            {
                _IsOpenReshadeFile = value;
                NotifyPropertyChanged("IsOpenReshadeFile");
            }
        }

        public bool IsRestartReshadeEnable
        {
            get => _IsRestartReshadeEnable;
            set
            {
                _IsRestartReshadeEnable = value;
                NotifyPropertyChanged("IsRestartReshadeEnable");
            }
        }

        public OpenFIleConfIg()
        {
            this.InitializeComponent();

            GenshinFolderTextBlock.DataContext = this;
            ReshadeFolderTextBlock.DataContext = this;

            OpenFIlterFIle.DataContext = this;
            ReStartReShadeTg.DataContext = this;

            GenshinFolderString = "폴더 - " + ConfIg.Instance.GenshInFolder.GenshInFolder;

            if (ConfIg.Instance.Dev == false)
                UtIl_.Visibility = Visibility.Collapsed;

            else
                UtIl_.Visibility = Visibility.Visible;

            if (ConfIg.Instance.GenshInFolder.ReshadeFolder == null)
                ReshadeFolderString = "폴더 - 설정되지 않음";

            else
                ReshadeFolderString = "폴더 - " + ConfIg.Instance.GenshInFolder.ReshadeFolder;



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
                IsOpenReshadeFile = false;
                IsRestartReshadeEnable = false;
            }

            else if (ConfIg.Instance.ReShadeConfIgJ.ReShade == 0)
            {
                IsOpenReshadeFile = false;
                IsRestartReshadeEnable = false;
            }

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
                        GenshinFolderString = "폴더 - " + folder.Path;
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
                        ReshadeFolderString = "폴더 - " + folder.Path;
                        ConfIg.Instance.GenshInFolder.ReshadeFolder = folder.Path;

                        IsOpenReshadeFile = true;
                        IsRestartReshadeEnable = true;
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler == null == false)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
