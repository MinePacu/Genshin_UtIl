using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ServiceProcess;
using System.Threading.Tasks;

using Windows.Devices.Radios;

namespace Genshin_UtIl.UtIls
{
    public static class BluetoothUtil
    {
        static Radio bluetoothradio { get; set; }

        public static bool IsHavingBluetoothRadioDevice { get; set; } = false;

        public async static void InitializeBluetoothRadioDevice()
        {
            IReadOnlyList<Radio> radioList = await Radio.GetRadiosAsync();

            foreach (Radio radio in radioList)
            {
                if (radio.Kind == RadioKind.Bluetooth)
                {
                    bluetoothradio = radio;
                    //Debug.WriteLine("Bluetooth Radio Device - " + radio.State);
                    IsHavingBluetoothRadioDevice = true;
                }
            }
        }

        public async static Task OnOffBluetooth(bool onoff)
        {
            await OnOffBluetoothService(onoff);

            if (onoff == true)
                await bluetoothradio.SetStateAsync(RadioState.On);
            else
                await bluetoothradio.SetStateAsync(RadioState.Off);
        }

        async static Task OnOffBluetoothService(bool onoff)
        {
            ServiceController[] scs = ServiceController.GetServices();
                
            foreach (var sc in scs) 
            {
                if (sc.DisplayName == "bthserv")
                {
                    var sctemp = new ServiceController("bthserv");
                    if (onoff == true)
                    {
                        if (sctemp.Status == ServiceControllerStatus.Stopped)
                        {
                            sc.Start();
                            while (sc.Status == ServiceControllerStatus.Stopped)
                            {
                                await Task.Delay(1000);
                                sc.Refresh();
                            }
                        }
                    }
                    else
                    {
                        if (sctemp.Status == ServiceControllerStatus.Running)
                        {
                            sc.Stop();
                            while (sc.Status == ServiceControllerStatus.Running)
                            {
                                await Task.Delay(1000);
                                sc.Refresh();
                            }
                        }
                    }
                }
            }
        }
    }
}
