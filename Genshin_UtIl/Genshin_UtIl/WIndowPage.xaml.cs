using Genshin_UtIl.UtIls;
using Genshin_UtIl.UtIls.AppColor.Enum;
using Genshin_UtIl.UtIls.Dwm;

using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using WinRT.Interop;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Genshin_UtIl
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WIndowPage : Window
    {
        AppWindow appwIndow;

        public WIndowPage()
        {
            this.InitializeComponent();

            appwIndow = UtIls.WinAppSdk.WinUIWindow.GetAppWIndowForCurrentWIndow(this);
            WIndowUtIl.Fra = (FrameworkElement) Content;
            WIndowUtIl.N = n;
            WIndowUtIl.appwIndow = appwIndow;

            appwIndow.Title = "원신 유틸";
            appwIndow.Resize(new(ConfIg.Instance.ProgramWIndowWIdth, ConfIg.Instance.ProgramWIndowHeIght));

            //appwIndow.TitleBar.ExtendsContentIntoTitleBar = true;

            WIndowUtIl.Hwnd = WindowNative.GetWindowHandle(this);

            n.SelectedItem = n.MenuItems[GetPageN()];

            // NavIgateFIrstPage();

            if (ConfIg.Instance.Programconfig.x == 0 && ConfIg.Instance.Programconfig.y == 0)
            {
                DisplayArea displayAr = DisplayArea.GetFromWindowId(UtIls.WinAppSdk.WinUIWindow.GetWindowIdFromWindow(this), DisplayAreaFallback.Nearest);
                var Center = appwIndow.Position;
                Center.X = (displayAr.WorkArea.Width - appwIndow.Size.Width) / 2;
                Center.Y = (displayAr.WorkArea.Height - appwIndow.Size.Height) / 2;
                appwIndow.Move(Center);
            }

            else
                appwIndow.Move(new(ConfIg.Instance.Programconfig.x, ConfIg.Instance.Programconfig.y));

            if (ConfIg.Instance.AppTh == 0)
            {
                WIndowUtIl.Fra.RequestedTheme = ElementTheme.Default;
                WIndowUtIl.N.RequestedTheme = ElementTheme.Default;

                if (SysUtIl.GetAppTh() == Appth.Dark)
                    DwmUtil.DwmSetWindowAttribute_(WIndowUtIl.Hwnd, UtIls.Dwm.Enum.DwmWIndowAttrIbute.DWMWA_USE_IMMERSIVE_DARK_MODE, true);
                else
                    DwmUtil.DwmSetWindowAttribute_(WIndowUtIl.Hwnd, UtIls.Dwm.Enum.DwmWIndowAttrIbute.DWMWA_USE_IMMERSIVE_DARK_MODE, false);
            }

            else if (ConfIg.Instance.AppTh == 1)
            {
                WIndowUtIl.Fra.RequestedTheme = ElementTheme.Light;
                WIndowUtIl.N.RequestedTheme = ElementTheme.Light;
                DwmUtil.DwmSetWindowAttribute_(WIndowUtIl.Hwnd, UtIls.Dwm.Enum.DwmWIndowAttrIbute.DWMWA_USE_IMMERSIVE_DARK_MODE, false);
            }

            else if (ConfIg.Instance.AppTh == 2)
            {
                WIndowUtIl.Fra.RequestedTheme = ElementTheme.Dark;
                WIndowUtIl.N.RequestedTheme = ElementTheme.Dark;
                DwmUtil.DwmSetWindowAttribute_(WIndowUtIl.Hwnd, UtIls.Dwm.Enum.DwmWIndowAttrIbute.DWMWA_USE_IMMERSIVE_DARK_MODE, true);
            }

            DIsplayUtIl.DisplayLoadTask.StartTask();
        }

        List<(string PageStrIng, Type page)> _pages = new()
        {
            ("WIndow", typeof(Pages.WIndowConfIg)),
            ("ReShadeCon", typeof(Pages.ReShadeConfIg)),
            ("OpenGameCon", typeof(Pages.OpenFIleConfIg)),
            ("TutorIal", typeof(TutorIal))
        };

        void N_NavIgate(string PagestrIng, Microsoft.UI.Xaml.Media.Animation.NavigationTransitionInfo tran)
        {
            Type _page = null;

            if (PagestrIng == "sett")
            {
                _page = typeof(Pages.ConfIgPage);
            }

            else
            {
                var lte = _pages.FirstOrDefault(p => p.PageStrIng.Equals(PagestrIng));
                _page = lte.page;
            }

            var PageType = contentFra.CurrentSourcePageType;

            if (_page == null == false)
            {
                if (Type.Equals(PageType, _page) == false)
                {
                    contentFra.Navigate(_page, null, tran);
                }
            }
        }

        int GetPageN()
        {
            if (ConfIg.Instance.FIrstPage == "WIndow")
                return 0;

            else if (ConfIg.Instance.FIrstPage == "ReShadeCon")
                return 1;

            else if (ConfIg.Instance.FIrstPage == "OpenGameCon")
                return 2;

            else
                return -1;
        }

        void N_SelectIonChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {
                N_NavIgate("sett", new Microsoft.UI.Xaml.Media.Animation.EntranceNavigationTransitionInfo());
            }

            else if (args.SelectedItemContainer == null == false)
            {
                var _Tag = args.SelectedItemContainer.Tag.ToString();

                if (_Tag == "TutorIal")
                {
                    TutorIal wIndow = new(appwIndow.Size.Width, appwIndow.Size.Height);
                    wIndow.Activate();
                }    

                else
                    N_NavIgate(_Tag, args.RecommendedNavigationTransitionInfo);
            }

            else
                return;
        }

        void NavIgateFIrstPage()
        {
            int n_ = GetPageN();

            if (n_ == 0)
                N_NavIgate("WIndow", new Microsoft.UI.Xaml.Media.Animation.EntranceNavigationTransitionInfo());

            else if (n_ == 1)
                N_NavIgate("ReShadeCon", new Microsoft.UI.Xaml.Media.Animation.EntranceNavigationTransitionInfo());

            else if (n_ == 2)
                N_NavIgate("OpenGameCon", new Microsoft.UI.Xaml.Media.Animation.EntranceNavigationTransitionInfo());
        }

        void WIndow_Closed(object sender, WindowEventArgs e)
        {
            var wIndow = (OverlappedPresenter) appwIndow.Presenter;

            if (wIndow.State == OverlappedPresenterState.Minimized == false)
            {
                ConfIg.Instance.ProgramWIndowWIdth = appwIndow.Size.Width;
                ConfIg.Instance.ProgramWIndowHeIght = appwIndow.Size.Height;

                ConfIg.Instance.Programconfig.x = appwIndow.Position.X;
                ConfIg.Instance.Programconfig.y = appwIndow.Position.Y;
            }

            ConfIg.Save();
        }
    }
}
