using Genshin_UtIl.UtIls;
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using WinRT.Interop;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Genshin_UtIl
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FolderConfIg : Window
    {
        public FolderConfIg()
        {
            this.InitializeComponent();

            if (FolderStrIng.Text == "폴더 - ")
                ApplyConfIg.IsEnabled = false;

            if (ConfIg.Instance.Dev == false)
                UtIl_.Visibility = Visibility.Collapsed;

            else
                UtIl_.Visibility = Visibility.Visible;

            AppWindow appWIndow = GetAppWIndowForCurrentWIndow();

            appWIndow.Title = "초기 설정";
            appWIndow.Resize(new(ConfIg.Instance.ProgramWIndowWIdth, ConfIg.Instance.ProgramWIndowHeIght));

            WIndowUtIl.Hwnd = WindowNative.GetWindowHandle(this);
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
                        FolderStrIng.Text = "폴더 - " + folder.Path;

                        if (FolderStrIng.Text == "폴더 - " == false)
                            ApplyConfIg.IsEnabled = true;
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
                        ReshadeFolderStrIng.Text = "폴더 - " + folder.Path;

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

            FolderUtIl.GenshInFolder = FolderStrIng.Text.Replace("폴더 - ", "");

            ConfIg.Instance.GenshInFolder.GenshInFolder = FolderStrIng.Text.Replace("폴더 - ", "");
            ConfIg.Instance.FIrstOpenProgram = 0;

            this.Close();
        }

        AppWindow GetAppWIndowForCurrentWIndow()
        {
            IntPtr hWnd = WindowNative.GetWindowHandle(this);
            WindowId wndId = Win32Interop.GetWindowIdFromWindow(hWnd);

            return AppWindow.GetFromWindowId(wndId);
        }
    }
}
