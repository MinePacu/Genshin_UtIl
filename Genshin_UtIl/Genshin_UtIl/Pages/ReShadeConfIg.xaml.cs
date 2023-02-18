using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Genshin_UtIl.UtIls;
using System;
using Genshin_UtIl.UtIls.ReShadeUtIl;
using Microsoft.UI.Xaml.Documents;
using WinRT.Interop;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Genshin_UtIl.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ReShadeConfIg : Page
    {
        public ReShadeConfIg()
        {
            this.InitializeComponent();

            if (ConfIg.Instance.Dev == false)
                UtIl_.Visibility = Visibility.Collapsed;

            else
                UtIl_.Visibility = Visibility.Visible;
        }

        void ReShadeFunc(object sender, RoutedEventArgs e)
        {
            var Toggle = (ToggleSwitch) sender;

            if (Toggle.IsOn)
            {
                if (ConfIg.Instance.ReShadeConfIgJ.AgreeUsIngReShade == 0)
                {
                    AgreeUsIngReShade();
                    if (ConfIg.Instance.ReShadeConfIgJ.AgreeUsIngReShade == 0)
                        Toggle.IsOn = false;

                    else
                        Toggle.IsOn = true;
                }

                else
                    ConfIg.Instance.ReShadeConfIgJ.ReShade = 1;
            }

            else
                ConfIg.Instance.ReShadeConfIgJ.ReShade = 0;
        }

        async void AgreeUsIngReShade()
        {
            ContentDialog contentD = new()
            {
                XamlRoot = this.XamlRoot,
                Title = "참조",
                Content = "ReShade 필터 프로그램은 그래픽 필터 프로그램이므로 게임을 변조시키지 않지만,\r\n" +
                "ReShade 프로그램을 이용함으로서 생기는 모든 불이익은 이 프로그램(원신 유틸)의 개발자가 전적으로 책임지지 않습니다.\r\n" +
                "이를 동의하고 ReShade 기능을 계속 이용하려면 동의 버튼을, 이용하지 않으려면 취소 버튼을 누르세요.",
                PrimaryButtonText = "동의",
                CloseButtonText = "취소",
                DefaultButton = ContentDialogButton.Close
            };

            var contentDR = await contentD.ShowAsync();

            if (contentDR == ContentDialogResult.Primary)
            {
                if (ConfIg.Instance.GenshInFolder.ReshadeFolder == null)
                {
                    ContentDialog contentD_ = new()
                    {
                        XamlRoot = this.XamlRoot,
                        Title = "참조",
                        Content = "ReShade.ini 파일이 없습니다.\r\n" +
                        "ReShade 폴더를 게임 실행 페이지에서 설정했는지 확인하세요.",
                        CloseButtonText = "확인",
                        DefaultButton = ContentDialogButton.Close
                    };

                    _ = await contentD_.ShowAsync();
                }

                else
                {
                    ConfIg.Instance.ReShadeConfIgJ.AgreeUsIngReShade = 1;
                    ConfIg.Instance.ReShadeConfIgJ.ReShade = 1;
                }
            }

            else
            {
                ConfIg.Instance.ReShadeConfIgJ.AgreeUsIngReShade = 0;
                ConfIg.Instance.ReShadeConfIgJ.ReShade = 0;
            }
        }

        void ReShadeTuFunc(object sender, RoutedEventArgs e)
        {
            var TuToPage = new TutorIal("ReShadeCon", WIndowUtIl.appwIndow.Size.Width, WIndowUtIl.appwIndow.Size.Height);
            TuToPage.Activate();
        }

    }
}
