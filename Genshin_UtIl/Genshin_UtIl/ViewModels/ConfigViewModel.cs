using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommunityToolkit.Mvvm.ComponentModel;

using Genshin_UtIl.UtIls;

namespace Genshin_UtIl.ViewModels
{
    public partial class ConfigViewModel : ObservableObject
    {
        private int appColor;

        public int AppColor
        {
            get => appColor;
            set
            {
                SetProperty(ref appColor, value);
                ConfIg.Instance.AppTh = value;
            }
        }

        private bool isUseDeveloperUtil;

        public bool IsUseDeveloperUtil
        {
            get => isUseDeveloperUtil;
            set
            {
                SetProperty(ref isUseDeveloperUtil, value);
                ConfIg.Instance.Dev = value;
            }
        }

        private int firstPage;

        public int FirstPage
        {
            get => firstPage;
            set
            {
                SetProperty(ref firstPage, value);
                if (value == 0)
                    ConfIg.Instance.FIrstPage = "WIndow";

                else if (value == 1)
                    ConfIg.Instance.FIrstPage = "ReShadeCon";

                else if (value == 2)
                    ConfIg.Instance.FIrstPage = "OpenGameCon";
            }
        }

        public ConfigViewModel()
        {
            AppColor = ConfIg.Instance.AppTh;
            IsUseDeveloperUtil = ConfIg.Instance.Dev;

            if (ConfIg.Instance.FIrstPage == "WIndow")
                FirstPage = 0;

            else if (ConfIg.Instance.FIrstPage == "ReShadeCon")
                FirstPage = 1;

            else if (ConfIg.Instance.FIrstPage == "OpenGameCon")
                FirstPage = 2;
        }
    }
}
