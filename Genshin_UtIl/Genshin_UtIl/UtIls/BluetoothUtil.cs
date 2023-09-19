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

        /// <summary>
        /// 블루투스 디바이스가 기기에 있는지 여부입니다.
        /// </summary>
        public static bool IsHavingBluetoothRadioDevice { get; set; } = false;

        /// <summary>
        /// 블루투스 디바이스 목록을 로드하며 인스턴스를 초기화합니다.
        /// </summary>
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

        /// <summary>
        /// 블루투스를 켜거나 끕니다.
        /// </summary>
        /// <param name="onoff">이 매개 변수가 <c>true</c>이면 블루투스를 켭니다. <c>false</c>이면 블루투스를 끕니다.</param>
        /// <returns>완료된 작업(<see cref="Task"/>)</returns>
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
