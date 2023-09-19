using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using Genshin_UtIl.interfaces.Window;
using Genshin_UtIl.UtIls;

using Microsoft.UI.Xaml;

namespace Genshin_UtIl.ViewModels
{
    public partial class InitializeWindowViewModel : ObservableObject
    {
        Window p_window;

        private string initializeText;

        public string InitializeText
        {
            get => initializeText;
            set
            {
                SetProperty(ref initializeText, value);
            }
        }

        private bool isGenshinInstalled;

        public bool IsGenshinInstalled
        {
            get => isGenshinInstalled;
            set
            {
                SetProperty(ref isGenshinInstalled, value);
            }
        }

        public ICommand FIndGenshinFolderTaskCommand { get; }

        public InitializeWindowViewModel()
        {
            FIndGenshinFolderTaskCommand = new AsyncRelayCommand(FindGenshinFolder);
        }

        async Task FindGenshinFolder()
        {
            //InitializeText = "프로그램 실행에 필요한 Windows App SDK Rumtime 설치 중";
            //await InstallSDKRumtime();

            InitializeText = "컴퓨터에서 원신 찾는 중";
            bool _IsGenshinInstalled = await GenshinFolderFinder.CheckGenshinFromMuiCacheRegistryList();
            Debug.WriteLine("Debug(UninstallerList) - _IsGenshinInstalled == " + _IsGenshinInstalled.ToString());
            await Task.Delay(2000);

            if (_IsGenshinInstalled)
                ConfIg.Instance.GenshInFolder.GenshInFolder = GenshinFolderFinder.GenshinPath;

            else
            {
                _IsGenshinInstalled = await GenshinFolderFinder.CheckGenshinFromProgramFilesFolder();
                Debug.WriteLine("Debug(ProgramFilesFolder) - _IsGenshinInstalled == " + _IsGenshinInstalled.ToString());
                await Task.Delay(2000);

                if (_IsGenshinInstalled)
                    ConfIg.Instance.GenshInFolder.GenshInFolder = GenshinFolderFinder.GenshinPath;

                else
                {
                    _IsGenshinInstalled = GenshinFolderFinder.CheckGetGenshinPathFromLogFile(System.Environment.ExpandEnvironmentVariables(@"%userprofile%\AppData\LocalLow\miHoYo\Genshin Impact\output_log.txt"), out string GenshinPath);
                    if (_IsGenshinInstalled)
                        ConfIg.Instance.GenshInFolder.GenshInFolder = GenshinPath;
                }
            }

            IsGenshinInstalled = _IsGenshinInstalled;

            if (IsGenshinInstalled)
            {
                ConfIg.Instance.FIrstOpenProgram = 0;
                p_window = new WIndowPage();
            }
            else
                p_window = new FolderConfIg();

            p_window.Activate();

            IinitializeWindow.InitializeWindow.Close();
        }

        [Obsolete]
        async Task InstallSDKRumtime()
        {
            await AppSDKRuntimeInstaller.InstallSDKRuntime();
        }
    }
}
