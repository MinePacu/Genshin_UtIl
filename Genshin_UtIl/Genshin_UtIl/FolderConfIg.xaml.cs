using Genshin_UtIl.interfaces.Window;
using Genshin_UtIl.interfaces.XamlRoot;
using Genshin_UtIl.UtIls;
using Genshin_UtIl.UtIls.AppColor.Enum;
using Genshin_UtIl.UtIls.Dwm;
using Genshin_UtIl.UtIls.WinAppSdk;

using Microsoft.UI;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WinRT;
using WinRT.Interop;
using Windows.Storage;
using Windows.Foundation;
using Microsoft.UI.Composition.SystemBackdrops;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Genshin_UtIl
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public partial class FolderConfIg : Window, IXamlRoot, IFolderWindow
    {
        public FolderConfIg()
        {
            this.InitializeComponent();

            WIndowUtIl.Hwnd = WindowNative.GetWindowHandle(this);

            AppWindow appWIndow = WinUIWindow.GetAppWIndowForCurrentWIndow(this);

            appWIndow.Title = "초기 설정";
            appWIndow.Resize(new(ConfIg.Instance.ProgramWIndowWIdth, ConfIg.Instance.ProgramWIndowHeIght));

            if (SysUtIl.GetAppTh() == Appth.Dark)
                _ = DwmUtil.DwmSetWindowAttribute_(WIndowUtIl.Hwnd, UtIls.Dwm.Enum.DwmWIndowAttrIbute.DWMWA_USE_IMMERSIVE_DARK_MODE, true);

            IFolderWindow.FolderWindow = this;

            //UtIl_Text.Text += WIndowUtIl.Hwnd;

        }

        async void FolderConfIgFunc(object sender, RoutedEventArgs e)
        {
            IXamlRoot.FolderConfigWindowXamlRoot = this.Content.XamlRoot;
        }

        private void StackPanel_Loaded(object sender, RoutedEventArgs e)
        {
            IXamlRoot.FolderConfigWindowXamlRoot = this.Content.XamlRoot;
        }
    }
}
