using Genshin_UtIl.interfaces.IView;
using Genshin_UtIl.interfaces.XamlRoot;
using Genshin_UtIl.UtIls;
using Genshin_UtIl.UtIls.Display.Structure;
using Genshin_UtIl.UtIls.Exceptions.Registry;

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.Windows.AppLifecycle;

using System;
using System.Diagnostics;
using System.Threading.Tasks;

using static Genshin_UtIl.UtIls.DIsplayUtIl;
using static Genshin_UtIl.UtIls.WIndowUtIl;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Genshin_UtIl.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WIndowConfIg : Page, IRegistryXamlRoot, IGrid
    {
        static int DIsplaySorted = 0;

        public WIndowConfIg()
        {
            this.InitializeComponent();

            IRegistryXamlRoot.WindowConfIgXamlRoot = WIndowUtIl.N.XamlRoot;

            if (RegIstryUtIl.GenshInRegIstry is null)
            {
                AgreeOpenGameToRegistry();
                return;
            }

            if (DIsplayUtIl.Sorted == false)
            {
                SortDIsplayLIst();
                Sorted = true;
            }

            if (RegIstryUtIl.DIsplay >= DIsplayLIst.Count)
            {
                RegIstryUtIl.ApplyDisplay(0);
                RegIstryUtIl.DIsplay = 0;
            }

            UtIl_Text.Text += "DIsplayLIstUI - " + DIsplayLIstUI.Children.Count + "\r\n";

            GC.Collect();

            if (DIsplay_strIng_LIst.Count > 1)
            {
                DIsPlaySelect.ItemsSource = DIsplay_strIng_LIst;

                int tmp = 0;
                while (tmp < DIsplay_strIng_LIst.Count)
                {
                    if (DisplayLIst_Sorted_lo[tmp].IsPrImaryDIsplay == true)
                    {
                        AddDIsplayCard(DIsplay_strIng_List_Sorted_lo[tmp], "해상도 - " + DisplayLIst_Sorted_lo[tmp].DIsplay_Resol.WIdth.ToString() + " x " + DisplayLIst_Sorted_lo[tmp].DIsplay_Resol.HeIght.ToString()
                            + "\r\n" + "주 디스플레이 - 예" + "\r\n" + "주사율 - " + DisplayLIst_Sorted_lo[tmp].DIsplay_Frequency + "Hz",
                            (int)DisplayLIst_Sorted_lo[tmp].DIsplay_Resol.WIdth, (int)DisplayLIst_Sorted_lo[tmp].DIsplay_Resol.HeIght);

                    }

                    else
                        AddDIsplayCard(DIsplay_strIng_List_Sorted_lo[tmp], "해상도 - " + DisplayLIst_Sorted_lo[tmp].DIsplay_Resol.WIdth.ToString() + " x " + DisplayLIst_Sorted_lo[tmp].DIsplay_Resol.HeIght.ToString()
                            + "\r\n" + "주 디스플레이 - 아니요" + "\r\n" + "주사율 - " + DisplayLIst_Sorted_lo[tmp].DIsplay_Frequency + "Hz",
                            (int)DisplayLIst_Sorted_lo[tmp].DIsplay_Resol.WIdth, (int)DisplayLIst_Sorted_lo[tmp].DIsplay_Resol.HeIght);
                    tmp++;
                }
                if (RegIstryUtIl.DIsplay == 0)
                    WindowViewmodel.Display = GetNonSortedIndexFromSortedDisplayList(0);
                else
                    WindowViewmodel.Display = GetNonSortedIndexFromSortedDisplayList(RegIstryUtIl.DIsplay);
            }

            else
            {
                AddDIsplayCard(DIsplay_strIng_List_Sorted_lo[0], "해상도 - " + DisplayLIst_Sorted_lo[0].DIsplay_Resol.WIdth.ToString() + " x " + DisplayLIst_Sorted_lo[0].DIsplay_Resol.HeIght.ToString()
                    + "\r\n" + "주 디스플레이 - 예" + "\r\n" + "주사율 - " + DisplayLIst_Sorted_lo[0].DIsplay_Frequency + "Hz",
                    (int)DisplayLIst_Sorted_lo[0].DIsplay_Resol.WIdth, (int)DisplayLIst_Sorted_lo[0].DIsplay_Resol.HeIght);

                DIsPlaySelect.ItemsSource = DIsplay_strIng_LIst;
                WindowViewmodel.Display = 0;
                DIsPlaySelect.IsEnabled = false;
            }


            if (RegIstryUtIl.DIsplay == 0 == false)
                WindowViewmodel.Display = GetNonSortedIndexFromSortedDisplayList(RegIstryUtIl.DIsplay);

            if (ConfIg.Instance.Dev == false)
                UtIl_.Visibility = Visibility.Collapsed;

            else
                UtIl_.Visibility = Visibility.Visible;

            /*
            if (ConfIg.Instance.Dev == true)
            {
                foreach (DIsplays d in DIsplayLIst)
                {
                    UtIl_Text.Text += "DIsplay[0].P.x - " + d.DIsplay_P.x + "\r\n";
                    UtIl_Text.Text += "DIsplay[0].P.y - " + d.DIsplay_P.y + "\r\n";
                }

                UtIl_Text.Text += "GetDIsplayN_NS - " + DIsplay_strIng_LIst_Sorted[RegIstryUtIl.DIsplay] + "\r\n";
                UtIl_Text.Text += "GetDIsplayN_NS - " + GetDIsplayN_NS(DIsplay_strIng_LIst_Sorted[RegIstryUtIl.DIsplay]) + "\r\n";
                UtIl_Text.Text += "RegIstryUtIl.DIsplay - " + RegIstryUtIl.DIsplay + "\r\n";
                UtIl_Text.Text += "DIsplayLIst.Length - " + DIsplayLIst.Count + "\r\n";

                foreach (string DIsplay_S in DIsplay_strIng_LIst_Sorted)
                {
                    UtIl_Text.Text += "DIsplay_strIng_LIst_Sorted - " + DIsplay_S + "\r\n";
                }
            }
            */
        }

        void DIsplaySelectIonChanged(object sender, SelectionChangedEventArgs e)
        {
            ChangeMINMAXWIndowSIze(((ComboBox) sender).SelectedIndex);
        }

        /*
        void ApplyConfIgFunc(object sender, RoutedEventArgs e)
        {
            try
            {
                int DIsplayN = GetDIsplayN(DIsplay_strIng_LIst[DIsPlaySelect.SelectedIndex]);

                if (ConfIg.Instance.Dev == true)
                {
                    UtIl_Text.Text += "DIsplayN - " + DIsplayN + "\r\n";
                    foreach (string DIsplay_S in DIsplay_strIng_LIst_Sorted)
                    {
                        UtIl_Text.Text += "DIsplay_strIng_LIst_Sorted - " + DIsplay_S + "\r\n";
                    }
                }

                if (ConfIg.Instance.WInConfIg.WIndowmode == 1 == false)
                    RegIstryUtIl.ApplyRegIstry(WIndowWIdth, WIndowHeIght, DIsplayN, ConfIg.Instance.WInConfIg.WIndowmode);

                else
                    RegIstryUtIl.ApplyRegIstry(WIndowWIdth, WIndowHeIght, DIsplayN, 0);
            }

            catch (ExcepClass EC)
            {
                if (ConfIg.Instance.Dev == true)
                    UtIl_Text.Text += EC.Exp.Source + " - " + EC.Exp.ToString() + "\r\n";
            }
        }
        */

        void AddDIsplayCard(string DIsplay_TItle, string DIsplay_Sub_StrIng, int DIsplayWIdth, int DIsplayHeIght)
        {
            var cardGrId = DIsplayLIstUI;

            ColumnDefinition col = new();
            if ((DIsplayWIdth / (float) DIsplayHeIght) == (16 / (float) 9))
            {
                col.Width = new GridLength(320);
            }
            else if ((DIsplayWIdth / (float) DIsplayHeIght) == (21 / (float) 9))
            {
                col.Width = new GridLength(420);
            }
            else if ((DIsplayWIdth / (float) DIsplayHeIght) == (32 / (float) 9))
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
                Background = (SolidColorBrush) cardGrId.Resources["CardBrush"],
                Margin = new(0, 0, 4, 9),
                CornerRadius = new(7),
                BorderThickness = new(1),
                BorderBrush = (SolidColorBrush) Application.Current.Resources["CardStrokeColorDefaultBrush"],
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
                FontFamily = new("Segoe MDL2 Assets"),
                Glyph = "\xe7f4",
                FontSize = 20,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new(0, 20, 0, 0)
            };

            TextBlock ProfIle_t = new()
            {
                Text = DIsplay_TItle,
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

        private void WindowConfig_Loaded(object sender, RoutedEventArgs e)
        {
            IRegistryXamlRoot.WindowConfIgXamlRoot = Content.XamlRoot;
        }

        async void AgreeOpenGameToRegistry()
        {
            ContentDialog contentD = new()
            {
                XamlRoot = IRegistryXamlRoot.WindowConfIgXamlRoot,
                Title = "참조",
                Content = "원신 게임 파일은 있으나 해상도와 모니터 설정 값을 불러올 수 없습니다.\r\n" +
                "설정 값을 만들기 위해서는 게임을 한 번 이상 실행해야 합니다.\r\n" +
                "게임을 실행하려면 게임 실행 버튼을 누르세요.",
                PrimaryButtonText = "게임 실행",
                CloseButtonText = "취소",
                DefaultButton = ContentDialogButton.Primary
            };

            var contentDR = await contentD.ShowAsync();

            if (contentDR == ContentDialogResult.Primary)
            {
                try
                {
                    ProcessUtIl.OpenProcess(0, ConfIg.Instance.GenshInFolder.GenshInFolder + "\\GenshinImpact.exe");
                    await Task.Delay(2000);

                    Environment.Exit(0);
                }
                catch (ExcepClass ep)
                {
                    Debug.WriteLine("Process - " + ep.Message);
                }

            }
            else
                Environment.Exit(0);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DIsplayUtIl.Sorted = false;
            DIsplayUtIl.InItIalIzed = false;

            DIsplayLIstUI.Children.Clear();
            DIsplayLIstUI.ColumnDefinitions.Clear();

            DIsplayUtIl.InitializeDisplayList();

            GC.Collect();

            if (DIsplayUtIl.Sorted == false)
            {
                SortDIsplayLIst();
                Sorted = true;
            }

            if (RegIstryUtIl.DIsplay >= DIsplayLIst.Count)
            {
                RegIstryUtIl.ApplyDisplay(0);
                RegIstryUtIl.DIsplay = 0;
            }

            UtIl_Text.Text += "DIsplayLIstUI - " + DIsplayLIstUI.Children.Count + "\r\n";

            if (DIsplay_strIng_LIst.Count > 1)
            {
                DIsPlaySelect.ItemsSource = DIsplay_strIng_LIst;

                int tmp = 0;
                while (tmp < DIsplay_strIng_LIst.Count)
                {
                    if (DisplayLIst_Sorted_lo[tmp].IsPrImaryDIsplay == true)
                    {
                        AddDIsplayCard(DIsplay_strIng_List_Sorted_lo[tmp], "해상도 - " + DisplayLIst_Sorted_lo[tmp].DIsplay_Resol.WIdth.ToString() + " x " + DisplayLIst_Sorted_lo[tmp].DIsplay_Resol.HeIght.ToString()
                            + "\r\n" + "주 디스플레이 - 예" + "\r\n" + "주사율 - " + DisplayLIst_Sorted_lo[tmp].DIsplay_Frequency + "Hz",
                            (int)DisplayLIst_Sorted_lo[tmp].DIsplay_Resol.WIdth, (int)DisplayLIst_Sorted_lo[tmp].DIsplay_Resol.HeIght);

                    }

                    else
                        AddDIsplayCard(DIsplay_strIng_List_Sorted_lo[tmp], "해상도 - " + DisplayLIst_Sorted_lo[tmp].DIsplay_Resol.WIdth.ToString() + " x " + DisplayLIst_Sorted_lo[tmp].DIsplay_Resol.HeIght.ToString()
                            + "\r\n" + "주 디스플레이 - 아니요" + "\r\n" + "주사율 - " + DisplayLIst_Sorted_lo[tmp].DIsplay_Frequency + "Hz",
                            (int)DisplayLIst_Sorted_lo[tmp].DIsplay_Resol.WIdth, (int)DisplayLIst_Sorted_lo[tmp].DIsplay_Resol.HeIght);
                    tmp++;
                }
                if (RegIstryUtIl.DIsplay == 0)
                    WindowViewmodel.Display = GetNonSortedIndexFromSortedDisplayList(0);
                else
                    WindowViewmodel.Display = GetNonSortedIndexFromSortedDisplayList(RegIstryUtIl.DIsplay);
            }

            else
            {
                AddDIsplayCard(DIsplay_strIng_List_Sorted_lo[0], "해상도 - " + DisplayLIst_Sorted_lo[0].DIsplay_Resol.WIdth.ToString() + " x " + DisplayLIst_Sorted_lo[0].DIsplay_Resol.HeIght.ToString()
                    + "\r\n" + "주 디스플레이 - 예" + "\r\n" + "주사율 - " + DisplayLIst_Sorted_lo[0].DIsplay_Frequency + "Hz",
                    (int)DisplayLIst_Sorted_lo[0].DIsplay_Resol.WIdth, (int)DisplayLIst_Sorted_lo[0].DIsplay_Resol.HeIght);

                DIsPlaySelect.ItemsSource = DIsplay_strIng_LIst;
                WindowViewmodel.Display = 0;
                DIsPlaySelect.IsEnabled = false;
            }
        }
    }
}
