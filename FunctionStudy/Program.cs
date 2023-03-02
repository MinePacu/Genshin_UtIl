﻿using System.Management;

Console.WriteLine("Windows 11 Contains - " + GetOSFriendlyName().Contains("Windows 11"));

string GetOSFriendlyName()
{
    string result = string.Empty;
    ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem");
    foreach (ManagementObject os in searcher.Get())
    {
        result = os["Caption"].ToString();
        break;
    }
    return result;
}