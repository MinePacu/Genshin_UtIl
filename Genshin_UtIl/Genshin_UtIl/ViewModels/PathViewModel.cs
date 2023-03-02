using System;
using System.Windows.Input;

using CommunityToolkit.Mvvm.ComponentModel;

using Genshin_UtIl.UtIls;
using Microsoft.UI.Xaml.Controls;
using WinRT.Interop;
using CommunityToolkit.Mvvm.Input;
using Genshin_UtIl.interfaces.XamlRoot;
using Genshin_UtIl.interfaces.Window;
using System.Threading.Tasks;

namespace Genshin_UtIl.ViewModels
{
    public partial class PathViewModel : ObservableObject
    {

        private string genshinFolderPath;

        public string GenshinFolderPath
        {
            get => genshinFolderPath;
            set => SetProperty(ref genshinFolderPath, value);
        }

        private string reshadeFolderPath;

        public string ReshadeFolderPath
        {
            get => reshadeFolderPath;
            set => SetProperty(ref reshadeFolderPath, value);
        }

        private bool isApplyEnabled;

        public bool IsApplyEnabled
        {
            get => isApplyEnabled;
            set => SetProperty(ref isApplyEnabled, value);
        }

        public ICommand ChangeGenshinPathDesCommand { get; }
        public ICommand ApplyConfIgCommand { get; }

        public ICommand OpenGenshinCommand { get; }
        public ICommand OpenClientCommand { get; }

        public ICommand OpenNonLoadGenshinCommand { get; }

        public PathViewModel()
        {
            ChangeGenshinPathDesCommand = new AsyncRelayCommand(FolderConfIgFunc);

            ApplyConfIgCommand = new RelayCommand(ApplyConfig);

            OpenGenshinCommand = new RelayCommand(OpenGenshin);
            OpenClientCommand = new RelayCommand(OpenClient);

            OpenNonLoadGenshinCommand = new RelayCommand(OpenNonLoadGenshinPath);

            if (ConfIg.Instance.GenshInFolder.GenshInFolder == null == false)
                GenshinFolderPath = "폴더 - " + ConfIg.Instance.GenshInFolder.GenshInFolder;
            else
                GenshinFolderPath = "폴더 - 설정되지 않음";

            if (ConfIg.Instance.GenshInFolder.ReshadeFolder == null == false)
                ReshadeFolderPath = "폴더 - " + ConfIg.Instance.GenshInFolder.ReshadeFolder;
            else
                ReshadeFolderPath = "폴더 - 설정되지 않음";

        }


        async Task FolderConfIgFunc()
        {
            try
            {
                var hwnd = WIndowUtIl.Hwnd;

                var FIlePIcker = new Windows.Storage.Pickers.FolderPicker();
                FIlePIcker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;

                FIlePIcker.FileTypeFilter.Add("*");

                InitializeWithWindow.Initialize(FIlePIcker, hwnd);

                Windows.Storage.StorageFolder folder = await FIlePIcker.PickSingleFolderAsync();

                if (folder == null == false)
                {
                    if (FolderUtIl.CheckFIle(folder.Path, "GenshinImpact.exe") == 1)
                    {
                        GenshinFolderPath = "폴더 - " + folder.Path;
                        ConfIg.Instance.GenshInFolder.GenshInFolder = folder.Path;

                        if (GenshinFolderPath == "폴더 - " == false)
                            IsApplyEnabled = true;
                    }

                    else
                    {
                        ContentDialog nofIleDIalog = new()
                        {
                            XamlRoot = IXamlRoot.FolderConfigWindowXamlRoot,
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

            catch (Exception) 
            {
            }
        }

        async void OpenNonLoadGenshinPath()
        {
            /*
            if (SysUtIl.GetOSFriendlyVersion().Contains("Windows 11"))
            {
                MicaAcrylicHelper.window = IFolderWindow.FolderWindow;
                MicaAcrylicHelper.TrySetMicaBackdrop(false);
            }
            */

            ContentDialog nonLoadGenshinFolder = new()
            {
                XamlRoot = IXamlRoot.FolderConfigWindowXamlRoot,
                Title = "참조",
                Content = "프로그램에서 원신 폴더를 찾지 못했습니다.\r\n수동으로 원신이 설치된 폴더를 지정해주세요.\r\n원신이 설치된 폴더는 GenshinImpact.exe 파일이 있어야 합니다.",
                CloseButtonText = "확인",
                DefaultButton = ContentDialogButton.Close
            };

            _ = await nonLoadGenshinFolder.ShowAsync();

            return;
        }

        async void ApplyConfig()
        {
            ConfIg.Instance.GenshInFolder.GenshInFolder = GenshinFolderPath;
            ConfIg.Instance.GenshInFolder.ReshadeFolder = ReshadeFolderPath;

            WIndowPage window = new();
            window.Activate();

            IFolderWindow.FolderWindow.Close();
        }

        void OpenGenshin()
        {
            ProcessUtIl.OpenProcess(0, ConfIg.Instance.GenshInFolder.GenshInFolder + "\\GenshinImpact.exe");
        }

        void OpenClient()
        {
            ProcessUtIl.OpenProcess(1, ConfIg.Instance.GenshInFolder.GenshInFolder.Replace("Genshin Impact game", "") + "launcher.exe");
        }
    }
}
