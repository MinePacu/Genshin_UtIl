using Genshin_UtIl.UtIls;
using Genshin_UtIl.UtIls.Display.Structure;

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using System;
using static Genshin_UtIl.UtIls.DIsplayUtIl;
using static Genshin_UtIl.UtIls.WIndowUtIl;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Genshin_UtIl.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WIndowConfIg : Page
    {
        static int DIsplaySorted = 0;

        public string WindowWidthString 
        {
            get => RegIstryUtIl.ScreenWIdth.ToString();
            set { }
        }

        public string WindowHeightString 
        {
            get => RegIstryUtIl.ScreenHeIght.ToString();
            set { }
        }

        public string WindowResolutionString
        {
            get => WindowWidthString + " x " + WindowHeightString;
            set { }
        }

        public bool IsLimitGameResolution
        {
            get => ConfIg.Instance.WInConfIg.LImItWIndowSIze;
            set
            {
                ConfIg.Instance.WInConfIg.LImItWIndowSIze = value;
            }
        }

        public int Windowmode
        {
            get => ConfIg.Instance.WInConfIg.WIndowmode;
            set
            {
                ConfIg.Instance.WInConfIg.WIndowmode = value;
            }
        }

        public WIndowConfIg()
        {
            this.InitializeComponent();

            UtIl_Text.Text += "DIsplayLIstUI - " + DIsplayLIstUI.Children.Count + "\r\n";

            GC.Collect();

            if (DIsplay_strIng_LIst.Count > 1)
            {
                DIsPlaySelect.ItemsSource = DIsplay_strIng_LIst;

                int tmp = 0;
                while (tmp < DIsplay_strIng_LIst.Count)
                {
                    if (DIsplayLIst[tmp].IsPrImaryDIsplay == true)
                    {
                        AddDIsplayCard(DIsplay_strIng_LIst[tmp], "해상도 - " + DIsplayLIst[tmp].DIsplay_Resol.WIdth.ToString() + " x " + DIsplayLIst[tmp].DIsplay_Resol.HeIght.ToString()
                            + "\r\n" + "주 디스플레이 - 예" + "\r\n" + "주사율 - " + DIsplayLIst[tmp].DIsplay_Frequency + "Hz",
                            (int)DIsplayLIst[tmp].DIsplay_Resol.WIdth, (int)DIsplayLIst[tmp].DIsplay_Resol.HeIght);

                        if (RegIstryUtIl.DIsplay == 0)
                            DIsPlaySelect.SelectedIndex = tmp;
                    }

                    else
                        AddDIsplayCard(DIsplay_strIng_LIst[tmp], "해상도 - " + DIsplayLIst[tmp].DIsplay_Resol.WIdth.ToString() + " x " + DIsplayLIst[tmp].DIsplay_Resol.HeIght.ToString()
                            + "\r\n" + "주 디스플레이 - 아니요" + "\r\n" + "주사율 - " + DIsplayLIst[tmp].DIsplay_Frequency + "Hz",
                            (int) DIsplayLIst[tmp].DIsplay_Resol.WIdth, (int)DIsplayLIst[tmp].DIsplay_Resol.HeIght);
                    tmp++;
                }
            }

            else
            {
                AddDIsplayCard(DIsplay_strIng_LIst[0], "해상도 - " + DIsplayLIst[0].DIsplay_Resol.WIdth.ToString() + " x " + DIsplayLIst[0].DIsplay_Resol.HeIght.ToString()
                    + "\r\n" + "주 디스플레이 - 예" + "\r\n" + "주사율 - " + DIsplayLIst[0].DIsplay_Frequency + "Hz",
                    (int) DIsplayLIst[0].DIsplay_Resol.WIdth, (int)DIsplayLIst[0].DIsplay_Resol.HeIght);

                DIsPlaySelect.ItemsSource = DIsplay_strIng_LIst;
                DIsPlaySelect.SelectedIndex = 0;
                DIsPlaySelect.IsEnabled = false;
            }

            if (DIsplaySorted == 0)
            {
                SortDIsplayLIst();
                DIsplaySorted = 1;
            }

            if (RegIstryUtIl.DIsplay == 0 == false)
                DIsPlaySelect.SelectedIndex = GetDIsplayN_NS(DIsplay_strIng_LIst_Sorted[RegIstryUtIl.DIsplay]);


            if (RegIstryUtIl.InItIalIzed == 0)
            {
                try
                {
                    RegIstryUtIl.InItIalIzeRegIstry();
                }

                catch (ExcepClass EC)
                {
                    if (ConfIg.Instance.Dev == 1)
                        UtIl_Text.Text += EC.Exp.Source + " - " + EC.Exp.ToString() + "\r\n";
                }
            }

            WIndowWIdth = int.Parse(WindowHeightString);
            WIndowHeIght = int.Parse(WindowHeightString);

            if (RegIstryUtIl.FullScreen == 1)
                Windowmode = 1;

            else
                Windowmode = ConfIg.Instance.WInConfIg.WIndowmode;

            if (ConfIg.Instance.Dev == 0)
                UtIl_.Visibility = Visibility.Collapsed;

            else
                UtIl_.Visibility = Visibility.Visible;

            if (ConfIg.Instance.Dev == 1)
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
        }

        void WIdthTetChanged(object sender, TextChangedEventArgs e)
        {
            var WIdthTet = ((TextBox) sender).Text;

            if (int.TryParse(WIdthTet, out int WInWIdth))
            {
                if (IsLimitGameResolution == true)
                {
                    if (WInWIdth < MAXWIndowWIdth)
                        WIndowWIdth = WInWIdth;

                    else
                    {
                        WIndowWIdth = RegIstryUtIl.ScreenWIdth;
                        WindowResolutionString = WIndowWIdth + " x " + WIndowHeIght;

                        ((TextBox) sender).Text = WIndowWIdth.ToString();

                        return;
                    }

                    RefreshResolutIonTet();
                }

                else
                    WIndowWIdth = WInWIdth;
            }
        }

        void HeIghtTetChanged(object sender, TextChangedEventArgs e)
        {
            var HeIghtTet = ((TextBox) sender).Text;

            if (int.TryParse(HeIghtTet, out int WInHeIght))
            {
                if (IsLimitGameResolution == true)
                {
                    if (WInHeIght < MAXWIndowHeIght)
                        WIndowHeIght = WInHeIght;

                    else
                    {
                        WIndowHeIght = RegIstryUtIl.ScreenHeIght;
                        WindowResolutionString = WIndowWIdth + " x " + WIndowHeIght;

                        ((TextBox) sender).Text = WIndowHeIght.ToString();

                        return;
                    }

                    RefreshResolutIonTet();
                }

                else
                    WIndowHeIght = WInHeIght;
            }
        }
        
        void WIndowmodeSelectIonChanged(object sender, SelectionChangedEventArgs e)
        {
            var WInmode = (ComboBox) sender;

            if (WInmode.SelectedIndex == 0)
            {
                PreWIndow.IsEnabled = false;
                LImItWIndow.IsEnabled = false;
                LImItWIndow.IsOn = false;

                ConfIg.Instance.WInConfIg.LImItWIndowSIze = false;
            }

            else
            {
                PreWIndow.IsEnabled = true;
                LImItWIndow.IsEnabled = true;
            }

            ConfIg.Instance.WInConfIg.WIndowmode = WInmode.SelectedIndex;
        }

        void DIsplaySelectIonChanged(object sender, SelectionChangedEventArgs e)
        {
            ChangeMINMAXWIndowSIze(((ComboBox) sender).SelectedIndex);
        }

        void WIndowPrevIew(object sender, RoutedEventArgs e)
        {
            if (WIndowmode.SelectedIndex == 2)
            {
                var SampleWIn = new SampleWIndow(WIndowWIdth, WIndowHeIght, 1);
                SampleWIn.Activate();
            }

            else
            {
                var SampleWIn = new SampleWIndow(WIndowWIdth, WIndowHeIght, 0);
                SampleWIn.Activate();
            }
        }

        void LImItWIndowSIze(object sender, RoutedEventArgs e)
        {
            var Toggle = (ToggleSwitch) sender;

            if (Toggle.IsOn)
                IsLimitGameResolution = true;

            else
                IsLimitGameResolution = false;
        }

        void ApplyConfIgFunc(object sender, RoutedEventArgs e)
        {
            try
            {
                int DIsplayN = GetDIsplayN(DIsplay_strIng_LIst[DIsPlaySelect.SelectedIndex]);

                if (ConfIg.Instance.Dev == 1)
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
                if (ConfIg.Instance.Dev == 1)
                    UtIl_Text.Text += EC.Exp.Source + " - " + EC.Exp.ToString() + "\r\n";
            }
        }

        void RefreshResolutIonTet()
        {
            WindowResolutionString = WindowWidthString + " x " + WindowHeightString;
        }

        void AddDIsplayCard(string DIsplay_TItle, string DIsplay_Sub_StrIng, int DIsplayWIdth, int DIsplayHeIght)
        {
            var cardGrId = (Grid) PageStack.Children[0];

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
                Background = (SolidColorBrush) Application.Current.Resources["LayerFillColorDefaultBrush"],
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
                FontFamily = new("Segoe Fluent Icons"),
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
    }
}
