using Genshin_UtIl.UtIls;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Windowing;
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
    public sealed partial class TutorIal : Window
    {
        AppWindow appwIndow;

        List<(string PageStrIng, Type page)> _pages = new()
        {
            ("WIndow", typeof(Pages.TutorIalPage.WIndowConfIgTutorIal)),
            ("OpenGameCon", typeof(Pages.TutorIalPage.OpenFIleConfIgTutorIal))
        };

        public TutorIal(int _WIndowWIdth, int _WIndowHeIght)
        {
            this.InitializeComponent();

            appwIndow = GetAppWIndowForCurrentWIndow();

            appwIndow.Title = "원신 유틸 튜토리얼";
            appwIndow.Resize(new(_WIndowWIdth, _WIndowHeIght));

            n.SelectedItem = n.MenuItems[0];
        }

        public TutorIal(string Page, int _WIndowWIdth, int _WIndowHeIght)
        {
            this.InitializeComponent();

            appwIndow = GetAppWIndowForCurrentWIndow();

            appwIndow.Title = "원신 유틸 튜토리얼";
            appwIndow.Resize(new(_WIndowWIdth, _WIndowHeIght));

            n.SelectedItem = n.MenuItems[GetPageN(Page)];
        }

        int GetPageN(string Page)
        {
            if (Page == "WIndow")
                return 0;

            else if (Page == "ReShadeCon")
                return 1;

            else if (Page == "OpenGameCon")
                return 2;

            else
                return -1;
        }

        void NavIgateFIrstPage(string Page)
        {
            int n_ = GetPageN(Page);

            if (n_ == 0)
                N_NavIgate("WIndow", new Microsoft.UI.Xaml.Media.Animation.EntranceNavigationTransitionInfo());

            else if (n_ == 2)
                N_NavIgate("OpenGameCon", new Microsoft.UI.Xaml.Media.Animation.EntranceNavigationTransitionInfo());
        }

        AppWindow GetAppWIndowForCurrentWIndow()
        {
            IntPtr hWnd = WindowNative.GetWindowHandle(this);
            WindowId wndId = Win32Interop.GetWindowIdFromWindow(hWnd);

            return AppWindow.GetFromWindowId(wndId);
        }


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

        void N_SelectIonChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {
                N_NavIgate("sett", new Microsoft.UI.Xaml.Media.Animation.EntranceNavigationTransitionInfo());
            }

            else if (args.SelectedItemContainer == null == false)
            {
                var _Tag = args.SelectedItemContainer.Tag.ToString();

                N_NavIgate(_Tag, args.RecommendedNavigationTransitionInfo);
            }

            else
                return;
        }

        void WIndow_Closed(object sender, WindowEventArgs e)
        {
        }
    }
}
