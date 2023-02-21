using Microsoft.UI;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using System;
using WinRT.Interop;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Genshin_UtIl
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SampleWIndow : Window
    {
        AppWindow appWIndow;

        public SampleWIndow()
        {
            this.InitializeComponent();
        }

        public SampleWIndow(int _WIdth, int _HeIght, int _TItlebar)
        {
            this.InitializeComponent();

            appWIndow = GetAppWIndowForCurrentWIndow();
            appWIndow.Resize(new(_WIdth, _HeIght));

            if (_TItlebar == 1)
                appWIndow.Title = "원신";

            else if (AppWindowTitleBar.IsCustomizationSupported() == false)
                appWIndow.Title = "원신";

            else
            {
                appWIndow.TitleBar.ExtendsContentIntoTitleBar = true;
                appWIndow.Title = "원신";

                var defaultPresenter = (OverlappedPresenter) appWIndow.Presenter;

                defaultPresenter.IsMinimizable = false;
                defaultPresenter.IsMaximizable = false;
            }

            DisplayArea displayAr = DisplayArea.GetFromWindowId(UtIls.WinAppSdk.WinUIWindow.GetWindowIdFromWindow(this), DisplayAreaFallback.Nearest);
            var Center = appWIndow.Position;
            Center.X = (displayAr.WorkArea.Width - appWIndow.Size.Width) / 2;
            Center.Y = (displayAr.WorkArea.Height - appWIndow.Size.Height) / 2;
            appWIndow.Move(Center);
        }
        AppWindow GetAppWIndowForCurrentWIndow()
        {
            IntPtr hWnd = WindowNative.GetWindowHandle(this);
            WindowId wndId = Win32Interop.GetWindowIdFromWindow(hWnd);

            return AppWindow.GetFromWindowId(wndId);
        }
    }
}
