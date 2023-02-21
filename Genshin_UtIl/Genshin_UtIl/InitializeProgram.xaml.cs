// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using Genshin_UtIl.interfaces.Window;

using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;


// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Genshin_UtIl
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class InitializeProgram : Window, IinitializeWindow
    {
        AppWindow thiswindow;

        public InitializeProgram()
        {
            this.InitializeComponent();
            thiswindow = UtIls.WinAppSdk.WinUIWindow.GetAppWIndowForCurrentWIndow(this);
            thiswindow.Resize(new(600, 100));
            thiswindow.TitleBar.ExtendsContentIntoTitleBar = true;

            var apppresenter = (OverlappedPresenter) thiswindow.Presenter;

            apppresenter.IsMaximizable = false;
            apppresenter.IsMinimizable = false;
            apppresenter.IsResizable = false;

            apppresenter.SetBorderAndTitleBar(true, false);

            DisplayArea displayAr = DisplayArea.GetFromWindowId(UtIls.WinAppSdk.WinUIWindow.GetWindowIdFromWindow(this), DisplayAreaFallback.Nearest);
            var Center = thiswindow.Position;
            Center.X = (displayAr.WorkArea.Width - thiswindow.Size.Width) / 2;
            Center.Y = (displayAr.WorkArea.Height - thiswindow.Size.Height) / 2;
            thiswindow.Move(Center);

            IinitializeWindow.InitializeWindow = this;
        }
    }
}
