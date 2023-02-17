// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Threading.Tasks;

using Genshin_UtIl.UtIls;

using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Genshin_UtIl
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class InitializeProgram : Window
    {
        public string InitializeText { get; set; }

        bool IsGenshinInstalled { get; set; }

        AppWindow thiswindow;
        Window p_window;

        public InitializeProgram()
        {
            this.InitializeComponent();
            thiswindow = UtIls.WinAppSdk.WinUIWindow.GetAppWIndowForCurrentWIndow(this);
            thiswindow.Resize(new(400, 100));
            thiswindow.TitleBar.ExtendsContentIntoTitleBar = true;

            var apppresenter = (OverlappedPresenter) thiswindow.Presenter;

            apppresenter.IsMaximizable = false;
            apppresenter.IsResizable = false;

            FindGenshinFolder();
        }

        public async void FindGenshinFolder()
        {
            InitializeText = "컴퓨터에서 원신 찾는 중";
            bool _IsGenshinInstalled = await GenshinFolderFinder.CheckGenshinFromUninstallerRegistryList();
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

            this.Close();
        }
    }
}
