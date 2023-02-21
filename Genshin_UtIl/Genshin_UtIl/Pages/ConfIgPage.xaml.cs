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
        public ConfIgPage()
        {
            this.InitializeComponent();
        }

        void AppThChanged(object sender, SelectionChangedEventArgs e)
        {
            var Appc = (ComboBox) sender;

            if (Appc.SelectedIndex == 0)
            {
                WIndowUtIl.Fra.RequestedTheme = ElementTheme.Default;
                WIndowUtIl.N.RequestedTheme = ElementTheme.Default;

                if (SysUtIl.GetAppTh() == Appth.Dark)
                    DwmUtil.DwmSetWindowAttribute_(WIndowUtIl.Hwnd, UtIls.Dwm.Enum.DwmWIndowAttrIbute.DWMWA_USE_IMMERSIVE_DARK_MODE, true);
                else
                    DwmUtil.DwmSetWindowAttribute_(WIndowUtIl.Hwnd, UtIls.Dwm.Enum.DwmWIndowAttrIbute.DWMWA_USE_IMMERSIVE_DARK_MODE, false);
            }

            else if (Appc.SelectedIndex == 1)
            {
                WIndowUtIl.Fra.RequestedTheme = ElementTheme.Light;
                WIndowUtIl.N.RequestedTheme = ElementTheme.Light;
                DwmUtil.DwmSetWindowAttribute_(WIndowUtIl.Hwnd, UtIls.Dwm.Enum.DwmWIndowAttrIbute.DWMWA_USE_IMMERSIVE_DARK_MODE, false);
            }

            else if (Appc.SelectedIndex == 2)
            {
                WIndowUtIl.Fra.RequestedTheme = ElementTheme.Dark;
                WIndowUtIl.N.RequestedTheme = ElementTheme.Dark;
                DwmUtil.DwmSetWindowAttribute_(WIndowUtIl.Hwnd, UtIls.Dwm.Enum.DwmWIndowAttrIbute.DWMWA_USE_IMMERSIVE_DARK_MODE, true);
            }
        }
    }
}
