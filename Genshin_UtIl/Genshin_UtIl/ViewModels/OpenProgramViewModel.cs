using CommunityToolkit.Mvvm.ComponentModel;

using Genshin_UtIl.UtIls;

namespace Genshin_UtIl.ViewModels
{
    public partial class OpenProgramViewModel : ObservableObject
    {
        private bool isHavingBluetoothRadioDevice;

        public bool IsHavingBluetoothRadioDevice
        {
            get => isHavingBluetoothRadioDevice;
            set
            {
                SetProperty(ref isHavingBluetoothRadioDevice, value);
            }
        }

        private bool _IsOpenNonBluetoothRadio;

        public bool IsOpenNonBluetoothRadio
        {
            get => _IsOpenNonBluetoothRadio;
            set => SetProperty(ref _IsOpenNonBluetoothRadio, value);
        }

        private bool isTurnOnbluetoothEnable;

        public bool IsTurnOnbluetoothEnable
        {
            get => isTurnOnbluetoothEnable;
            set
            {
                SetProperty(ref isTurnOnbluetoothEnable, value);
                ConfIg.Instance.BluetoothConfig.IsturnOnBluetooth = value;
            }
        }

        private bool isTurnOffbluetoothEnable;

        public bool IsTurnOffbluetoothEnable
        {
            get => isTurnOffbluetoothEnable;
            set
            {
                SetProperty(ref isTurnOffbluetoothEnable, value);
                ConfIg.Instance.BluetoothConfig.IsturnOffBluetooth = value;
            }
        }

        public OpenProgramViewModel()
        {
            BluetoothUtil.InitializeBluetoothRadioDevice();
            if (BluetoothUtil.IsHavingBluetoothRadioDevice == false)
            {
                IsHavingBluetoothRadioDevice = false;
                IsOpenNonBluetoothRadio = true;
            }
            else
            {
                IsHavingBluetoothRadioDevice = true;
                IsOpenNonBluetoothRadio = false;
            }

            IsTurnOnbluetoothEnable = ConfIg.Instance.BluetoothConfig.IsturnOnBluetooth;
            IsTurnOffbluetoothEnable = ConfIg.Instance.BluetoothConfig.IsturnOffBluetooth;
        }

    }
}
