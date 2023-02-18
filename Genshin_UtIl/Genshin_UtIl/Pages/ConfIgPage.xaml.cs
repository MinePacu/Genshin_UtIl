using Genshin_UtIl.UtIls;
using Genshin_UtIl.UtIls.AppColor.Enum;
using Genshin_UtIl.UtIls.Dwm;

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

using WinRT.Interop;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Genshin_UtIl.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ConfIgPage : Page
    {
        public int AppColor { get; set; }

        public bool IsUseDeveloperUtil { get; set; }

        public int FirstPage { get; set; }

        public ConfIgPage()
        {
            this.InitializeComponent();

            AppColor = ConfIg.Instance.AppTh;

            IsUseDeveloperUtil = ConfIg.Instance.Dev;

            if (ConfIg.Instance.FIrstPage == "WIndow")
                FirstPage = 0;

            else if (ConfIg.Instance.FIrstPage == "ReShadeCon")
                FirstPage = 1;

            else if(ConfIg.Instance.FIrstPage == "OpenGameCon")
                FirstPage = 2;
        }

        void AppThChanged(object sender, SelectionChangedEventArgs e)
        {
            var Appc = (ComboBox) sender;

            if (Appc.SelectedIndex == 0)
            {
                WIndowUtIl.Fra.RequestedTheme = ElementTheme.Default;
                WIndowUtIl.N.RequestedTheme = ElementTheme.Default;

                if (SysUtIl.GetAppTh() == Appth.Dark)
                {
                    DwmUtil.DwmSetWindowAttribute_(WIndowUtIl.Hwnd, UtIls.Dwm.Enum.DwmWIndowAttrIbute.DWMWA_USE_IMMERSIVE_DARK_MODE, true);
                }
            }

            else if (Appc.SelectedIndex == 1)
            {
                WIndowUtIl.Fra.RequestedTheme = ElementTheme.Light;
                WIndowUtIl.N.RequestedTheme = ElementTheme.Light;
            }

            else if (Appc.SelectedIndex == 2)
            {
                WIndowUtIl.Fra.RequestedTheme = ElementTheme.Dark;
                WIndowUtIl.N.RequestedTheme = ElementTheme.Dark;
            }

            ConfIg.Instance.AppTh = Appc.SelectedIndex;
        }

        void UtIlChanged(object sender, RoutedEventArgs e)
        {
            var tmp = (ToggleSwitch) sender;

            if (tmp.IsOn == false)
                ConfIg.Instance.Dev = false;

            else if (tmp.IsOn == true)
                ConfIg.Instance.Dev = true;
        }

        void PageConChanged(object sender, SelectionChangedEventArgs e)
        {
            var PageCon = (ComboBox)sender;

            if (PageCon.SelectedIndex == 0)
                ConfIg.Instance.FIrstPage = "WIndow";

            else if (PageCon.SelectedIndex == 1)
                ConfIg.Instance.FIrstPage = "ReShadeCon";

            else if (PageCon.SelectedIndex == 2)
                ConfIg.Instance.FIrstPage = "OpenGameCon";
        }
    }
}
