using Microsoft.Win32;

string registry_key = @"SOFTWARE\Classes\Local Settings\Software\Microsoft\Windows\Shell\MuiCache";
using (Microsoft.Win32.RegistryKey key = Registry.CurrentUser.OpenSubKey(registry_key))
{
    foreach (string subvalue_name in key.GetValueNames())
    {
        Console.WriteLine(subvalue_name);
    }
}