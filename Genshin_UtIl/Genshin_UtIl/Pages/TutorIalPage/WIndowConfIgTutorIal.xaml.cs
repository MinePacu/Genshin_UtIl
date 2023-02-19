using Genshin_UtIl.UtIls;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using System;
using static Genshin_UtIl.UtIls.DIsplayUtIl;
using static Genshin_UtIl.UtIls.WIndowUtIl;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Genshin_UtIl.Pages.TutorIalPage
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WIndowConfIgTutorIal : Page
    {
        public WIndowConfIgTutorIal()
        {
            this.InitializeComponent();

            DIsPlaySelect.SelectedIndex = 0;

            GC.Collect();

            if (DIsplay_strIng_LIst.Count > 1)
            {
                int tmp = 0;
                while (tmp < DIsplay_strIng_LIst.Count)
                {
                    if (DIsplayLIst[tmp].IsPrImaryDIsplay == true)
                        AddDIsplayCard("해상도 - " + DIsplayLIst[tmp].DIsplay_Resol.WIdth.ToString() + " x " + DIsplayLIst[tmp].DIsplay_Resol.HeIght.ToString()
                            + "\r\n" + "주 디스플레이 - 예" + "\r\n" + "주사율 - " + DIsplayLIst[tmp].DIsplay_Frequency + "Hz",
                            (int)DIsplayLIst[tmp].DIsplay_Resol.WIdth, (int)DIsplayLIst[tmp].DIsplay_Resol.HeIght);

                    else
                        AddDIsplayCard("해상도 - " + DIsplayLIst[tmp].DIsplay_Resol.WIdth.ToString() + " x " + DIsplayLIst[tmp].DIsplay_Resol.HeIght.ToString()
                            + "\r\n" + "주 디스플레이 - 아니요" + "\r\n" + "주사율 - " + DIsplayLIst[tmp].DIsplay_Frequency + "Hz",
                            (int)DIsplayLIst[tmp].DIsplay_Resol.WIdth, (int)DIsplayLIst[tmp].DIsplay_Resol.HeIght);
                    tmp++;
                }
            }

            else
            {
                AddDIsplayCard("해상도 - " + DIsplayLIst[0].DIsplay_Resol.WIdth.ToString() + " x " + DIsplayLIst[0].DIsplay_Resol.HeIght.ToString()
                    + "\r\n" + "주 디스플레이 - 예" + "\r\n" + "주사율 - " + DIsplayLIst[0].DIsplay_Frequency + "Hz",
                    (int)DIsplayLIst[0].DIsplay_Resol.WIdth, (int)DIsplayLIst[0].DIsplay_Resol.HeIght);

                DIsPlaySelect.IsEnabled = false;
            }

            DIsPlaySelect.ItemsSource = DIsplay_strIng_LIst;

            WIdthTet.Text = RegIstryUtIl.ScreenWIdth.ToString();
            HeIghtTet.Text = RegIstryUtIl.ScreenHeIght.ToString();
            DIsPlaySelect.SelectedIndex = RegIstryUtIl.DIsplay;

            WIndowWIdth = int.Parse(WIdthTet.Text);
            WIndowHeIght = int.Parse(HeIghtTet.Text);

            if (RegIstryUtIl.FullScreen == 1)
                WIndowmode.SelectedIndex = 0;

            else
                WIndowmode.SelectedIndex = ConfIg.Instance.WInConfIg.WIndowmode;

            WIndowTet.Text = WIdthTet.Text + " x " + HeIghtTet.Text; ;
        }

        void AddDIsplayCard(string DIsplay_Sub_StrIng, int DIsplayWIdth, int DIsplayHeIght)
        {
            var cardGrId = (Grid) PageStack.Children[0];

            ColumnDefinition col = new();
            if ((DIsplayWIdth / (float)DIsplayHeIght) == (16 / (float)9))
            {
                col.Width = new GridLength(320);
            }
            else if ((DIsplayWIdth / (float)DIsplayHeIght) == (21 / (float)9))
            {
                col.Width = new GridLength(420);
            }
            else if ((DIsplayWIdth / (float)DIsplayHeIght) == (32 / (float)9))
            {
                col.Width = new GridLength(640);
            }
            else
            {
                col.Width = new GridLength(320);
            }

            cardGrId.ColumnDefinitions.Add(col);

            Border card_ = new()
            {
                Background = (SolidColorBrush)Application.Current.Resources["LayerFillColorDefaultBrush"],
                Margin = new(0, 0, 4, 9),
                CornerRadius = new(7),
                BorderThickness = new(1),
                BorderBrush = (SolidColorBrush)Application.Current.Resources["CardStrokeColorDefaultBrush"],
                Height = 220
            };

            Grid.SetRow(card_, 0);
            Grid.SetColumn(card_, cardGrId.ColumnDefinitions.Count - 1);

            StackPanel panel = new()
            {
                Margin = new(0, 19, 0, 19),
                Width = 160,
                Height = 220
            };

            FontIcon Icon = new()
            {
                FontFamily = new("Segoe Fluent Icons"),
                Glyph = "\xec4e",
                FontSize = 20,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new(0, 20, 0, 0)
            };

            TextBlock ProfIle_t = new()
            {
                Text = "디스플레이 " + cardGrId.ColumnDefinitions.Count.ToString(),
                FontSize = 14,
                FontWeight = Microsoft.UI.Text.FontWeights.Bold,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new(0, 20, 0, 0)
            };

            TextBlock ProfIle_st = new()
            {
                Text = DIsplay_Sub_StrIng,
                FontSize = 12,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            panel.Children.Add(Icon);
            panel.Children.Add(ProfIle_t);
            panel.Children.Add(ProfIle_st);

            card_.Child = panel;

            cardGrId.Children.Add(card_);
        }
    }
}
