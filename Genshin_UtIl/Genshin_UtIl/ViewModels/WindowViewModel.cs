﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using Genshin_UtIl.UtIls;
using Genshin_UtIl.UtIls.Exceptions.Registry;
using Genshin_UtIl.XamlRoot;

using Microsoft.UI.Xaml.Controls;

namespace Genshin_UtIl.ViewModels
{
    public partial class WindowViewModel : ObservableObject
    {
        private int display;

        public int Display
        {
            get => display;
            set
            {
                SetProperty(ref display, value);
                RegIstryUtIl.ApplyDisplay(value);
            }
        }

        private string width;

        public string Width
        {
            get => width;
            set
            {
                SetProperty(ref width, value);
                RegIstryUtIl.ApplyWidth(int.Parse(value));
                Resolution = value.ToString() + " x " + Height;
            }
        }

        private string height;

        public string Height
        {
            get => height;
            set
            {
                SetProperty(ref height, value);
                RegIstryUtIl.ApplyHeight(int.Parse(value));
                Resolution = Width + " x " + value.ToString();
            }
        }

        private string resolution;

        public string Resolution
        {
            get => resolution;
            set
            {
                SetProperty(ref resolution, value);
            }
        }

        private int windowmode;

        public int WindowMode
        {
            get => windowmode;
            set
            {
                SetProperty(ref windowmode, value);
                if (value == 1)
                    RegIstryUtIl.ApplyFullScreen(1);
                else
                    RegIstryUtIl.ApplyFullScreen(0);
            }
        }

        private bool isLimitWindowWidthandHeight;

        public bool IsLimitWindowWidthandHeight
        {
            get => isLimitWindowWidthandHeight;
            set
            {
                SetProperty(ref isLimitWindowWidthandHeight, value);
                ConfIg.Instance.WInConfIg.LImItWIndowSIze = value;
            }
        }

        public ICommand OpenWindowCommand { get; }

        public WindowViewModel()
        {
            try
            {
                RegIstryUtIl.InItIalIzeRegIstry();
            }

            catch (GenshinRegistryNullException ex)
            {
                AgreeOpenGameToRegistry();
            }

            Width = RegIstryUtIl.ScreenWIdth.ToString();
            Height = RegIstryUtIl.ScreenHeIght.ToString();

            Resolution = Width + " x " + Height;

            if (RegIstryUtIl.FullScreen == 0)
            {
                if (ConfIg.Instance.WInConfIg.WIndowmode == 0)
                    WindowMode = 0;
                else if (ConfIg.Instance.WInConfIg.WIndowmode == 2)
                    WindowMode = 2;
            }

            else if (RegIstryUtIl.FullScreen == 1)
                WindowMode = 1;

            OpenWindowCommand = new RelayCommand(OpenWindow);
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
                }
                catch (ExcepClass ep)
                {
                    Debug.WriteLine("Process - " + ep.Message);
                }

            }
        }

        void OpenWindow()
        {
            if (WindowMode == 2)
            {
                var SampleWIn = new SampleWIndow(int.Parse(Width), int.Parse(Height), 1);
                SampleWIn.Activate();
            }

            else
            {
                var SampleWIn = new SampleWIndow(int.Parse(Width), int.Parse(Height), 0);
                SampleWIn.Activate();
            }
        }
    }
}