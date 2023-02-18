using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.UI;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;

using WinRT.Interop;

namespace Genshin_UtIl.UtIls.WinAppSdk
{
    public static class WinUIWindow
    {
        public static AppWindow GetAppWIndowForCurrentWIndow(Window window)
        {
            IntPtr hWnd = WindowNative.GetWindowHandle(window);
            WindowId wndId = Win32Interop.GetWindowIdFromWindow(hWnd);

            return AppWindow.GetFromWindowId(wndId);
        }

        public static WindowId GetWindowIdFromWindow(Window window) => Win32Interop.GetWindowIdFromWindow(WindowNative.GetWindowHandle(window));
    }
}
