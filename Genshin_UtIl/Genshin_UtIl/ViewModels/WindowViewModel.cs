using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Genshin_UtIl.interfaces.XamlRoot;
using Genshin_UtIl.UtIls;
using Genshin_UtIl.UtIls.Exceptions.Registry;

using Microsoft.UI.Xaml.Controls;

namespace Genshin_UtIl.ViewModels
{
    public partial class WindowViewModel : ObservableObject, IRegistryXamlRoot
    {
        private int display;

        public int Display
        {
            get => display;
            set
            {
                SetProperty(ref display, value);
                int DIsplayN = 0;
                if (DIsplayUtIl.Sorted)
                {
                    DIsplayN = DIsplayUtIl.GetIndexFromSortedDisplayList(DIsplayUtIl.DIsplayLIst[value].DIsplay);
                    RegIstryUtIl.ApplyDisplay(DIsplayN);
                }
                else
                    DIsplayN = value;
                Debug.WriteLine("DisplayN - " + DIsplayN);
            }
        }

        private bool _IsEnableOptionDisableInfoBar = true;

        public bool IsEnableOptionDisableInfoBar
        {
            get => _IsEnableOptionDisableInfoBar;
            set => SetProperty(ref _IsEnableOptionDisableInfoBar, value);
        }

        private bool _IsOpenResolutionLimitedInfoBar;

        public bool IsOpenResolutionLimitedInfoBar
        {
            get => _IsOpenResolutionLimitedInfoBar;
            set => SetProperty(ref _IsOpenResolutionLimitedInfoBar, value);
        }

        private string width;

        public string Width
        {
            get => width;
            set
            {
                if (ConfIg.Instance.WInConfIg.LImItWIndowSIze && uint.Parse(value) > DIsplayUtIl.DIsplayLIst[Display].DIsplay_Resol.WIdth)
                {
                    SetProperty(ref width, DIsplayUtIl.DIsplayLIst[Display].DIsplay_Resol.WIdth.ToString());
                    RegIstryUtIl.ApplyWidth((int) DIsplayUtIl.DIsplayLIst[Display].DIsplay_Resol.WIdth);
                    Resolution = DIsplayUtIl.DIsplayLIst[Display].DIsplay_Resol.WIdth.ToString() + " x " + Height;
                    IsOpenResolutionLimitedInfoBar = true;
                }
                else
                {
                    SetProperty(ref width, value);
                    RegIstryUtIl.ApplyWidth(int.Parse(value));
                    Resolution = value.ToString() + " x " + Height;
                    IsOpenResolutionLimitedInfoBar = false;
                }
            }
        }

        private string height;

        public string Height
        {
            get => height;
            set
            {
                if (ConfIg.Instance.WInConfIg.LImItWIndowSIze && uint.Parse(value) > DIsplayUtIl.DIsplayLIst[Display].DIsplay_Resol.HeIght)
                {
                    SetProperty(ref width, DIsplayUtIl.DIsplayLIst[Display].DIsplay_Resol.HeIght.ToString());
                    RegIstryUtIl.ApplyHeight((int)DIsplayUtIl.DIsplayLIst[Display].DIsplay_Resol.HeIght);
                    Resolution = Width + " x " + DIsplayUtIl.DIsplayLIst[Display].DIsplay_Resol.HeIght.ToString();
                    IsOpenResolutionLimitedInfoBar = true;
                }
                else
                {
                    SetProperty(ref height, value);
                    RegIstryUtIl.ApplyHeight(int.Parse(value));
                    Resolution = Width + " x " + value.ToString();
                    IsOpenResolutionLimitedInfoBar = false;
                }
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
                IsOpenResolutionLimitedInfoBar = false;
            }
        }

        private bool isOpenLoadingGenshinRegistry = false;

        public bool IsOpenLoadingGenshinRegistry
        {
            get => isOpenLoadingGenshinRegistry;
            set => SetProperty(ref isOpenLoadingGenshinRegistry, value);
        }

        private bool isEnableChangeoption = true;

        public bool IsEnableChagneoption
        {
            get => isEnableChangeoption;
            set => SetProperty(ref isEnableChangeoption, value);
        }

        public ICommand OpenWindowCommand { get; }

        public WindowViewModel()
        {
            IsOpenResolutionLimitedInfoBar = false;

            if (DIsplayUtIl.DIsplayLIst.Count < 2)
                IsEnableOptionDisableInfoBar = true;
            else
                IsEnableOptionDisableInfoBar = false;
            
            if (RegIstryUtIl.GenshInRegIstry is null == false)
            {
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
            }

            OpenWindowCommand = new RelayCommand(OpenWindow);
        }
        
        public void RefreshViewmodel()
        {

            if (RegIstryUtIl.GenshInRegIstry is null == false)
            {
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
