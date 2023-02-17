using Genshin_UtIl.UtIls;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

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

            AppTh_.SelectedIndex = ConfIg.Instance.AppTh;

            if (ConfIg.Instance.Dev == 1)
                UtIlToggle.IsOn = true;

            else
                UtIlToggle.IsOn = false;

            if (ConfIg.Instance.FIrstPage == "WIndow")
                PageCon_.SelectedIndex = 0;

            else if (ConfIg.Instance.FIrstPage == "ReShadeCon")
                PageCon_.SelectedIndex = 1;

            else if(ConfIg.Instance.FIrstPage == "OpenGameCon")
                PageCon_.SelectedIndex = 2;
        }

        void AppThChanged(object sender, SelectionChangedEventArgs e)
        {
            var Appc = (ComboBox) sender;

            if (Appc.SelectedIndex == 0)
            {
                WIndowUtIl.Fra.RequestedTheme = ElementTheme.Default;
                WIndowUtIl.N.RequestedTheme = ElementTheme.Default;
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
                ConfIg.Instance.Dev = 0;

            else if (tmp.IsOn == true)
                ConfIg.Instance.Dev = 1;
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
