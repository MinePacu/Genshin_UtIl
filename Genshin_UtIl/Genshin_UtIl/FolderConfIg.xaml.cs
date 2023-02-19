using Genshin_UtIl.UtIls;
using Genshin_UtIl.UtIls.AppColor.Enum;
using Genshin_UtIl.UtIls.Dwm;

using Microsoft.UI;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using WinRT.Interop;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Genshin_UtIl
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public partial class FolderConfIg : Window, INotifyPropertyChanged
    {
        public string _GenshinFolderString = "폴더 - ";
        public string _ReshadeFolderString = "폴다 - ";

        public bool _IsApplyEnabled = false;

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

        public bool IsApplyEnabled
        {
            get => _IsApplyEnabled;
            set
            {
                _IsApplyEnabled = value;
                NotifyPropertyChanged("IsApplyEnabled");
            }
        }

        public FolderConfIg()
        {
            this.InitializeComponent();

            GenshinFolderTextBlock.DataContext = this;
            ReshadeFolderTextBlock.DataContext = this;
            ApplyConfIg.DataContext = this;

            if (GenshinFolderString == "폴더 - ")
                IsApplyEnabled = false;

            if (ConfIg.Instance.Dev == false)
                UtIl_.Visibility = Visibility.Collapsed;

            else
                UtIl_.Visibility = Visibility.Visible;

            AppWindow appWIndow = GetAppWIndowForCurrentWIndow();

            appWIndow.Title = "초기 설정";
            appWIndow.Resize(new(ConfIg.Instance.ProgramWIndowWIdth, ConfIg.Instance.ProgramWIndowHeIght));

            WIndowUtIl.Hwnd = WindowNative.GetWindowHandle(this);

            if (SysUtIl.GetAppTh() == Appth.Dark)
                _ = DwmUtil.DwmSetWindowAttribute_(WIndowUtIl.Hwnd, UtIls.Dwm.Enum.DwmWIndowAttrIbute.DWMWA_USE_IMMERSIVE_DARK_MODE, true);
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

                        if (GenshinFolderString == "폴더 - " == false)
                            IsApplyEnabled = true;
                    }

                    else
                    {
                        ContentDialog nofIleDIalog = new()
                        {
                            XamlRoot = this.Content.XamlRoot,
                            Title = "게임 파일이 없음",
                            Content = "게임 파일이 있는 폴더를 다시 지정하세요.",
                            CloseButtonText = "확인",
                            DefaultButton = ContentDialogButton.Close
                        };

                        ContentDialogResult DIalogresult = await nofIleDIalog.ShowAsync();
                    }
                    return;
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
                        ReshadeFolderString = "폴더 - " + folder.Path;

                    else
                    {
                        ContentDialog nofIleDIalog = new()
                        {
                            XamlRoot = this.Content.XamlRoot,
                            Title = "Reshade.dll 파일이 없음",
                            Content = "Reshade.dll 파일이 있는 폴더를 다시 지정하세요.",
                            CloseButtonText = "확인",
                            DefaultButton = ContentDialogButton.Close
                        };

                        ContentDialogResult DIalogresult = await nofIleDIalog.ShowAsync();
                    }
                    return;
                }

                else if (folder == null)
                    return;
            }

            catch (Exception ep)
            {
                UtIl_Text.Text += ep.ToString() + "\r\n";
            }
        }

        void ApplyConfIgFunc(object sender, RoutedEventArgs e)
        {
            var WInPage = new WIndowPage();
            WInPage.Activate();

            FolderUtIl.GenshInFolder = GenshinFolderString.Replace("폴더 - ", "");

            ConfIg.Instance.GenshInFolder.GenshInFolder = GenshinFolderString.Replace("폴더 - ", "");
            ConfIg.Instance.FIrstOpenProgram = 0;

            this.Close();
        }

        AppWindow GetAppWIndowForCurrentWIndow()
        {
            IntPtr hWnd = WindowNative.GetWindowHandle(this);
            WindowId wndId = Win32Interop.GetWindowIdFromWindow(hWnd);

            return AppWindow.GetFromWindowId(wndId);
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
