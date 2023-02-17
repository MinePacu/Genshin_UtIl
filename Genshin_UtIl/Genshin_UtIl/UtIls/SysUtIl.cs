using System.Security.Principal;

namespace Genshin_UtIl.UtIls
{
    public static class SysUtIl
    {
        public static int IsPro()
        {
            WindowsIdentity IdentIty = WindowsIdentity.GetCurrent();
            WindowsPrincipal prIncIpal = new(IdentIty);

            if (prIncIpal.IsInRole(WindowsBuiltInRole.Administrator) == false)
            {
                return 0;
            }

            else
            {
                return 1;
            }
        }
    }
}
