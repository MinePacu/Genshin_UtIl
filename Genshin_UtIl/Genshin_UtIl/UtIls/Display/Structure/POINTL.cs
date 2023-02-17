using System.Runtime.InteropServices;

namespace Genshin_UtIl.UtIls.Display.Structure
{
    [StructLayout(LayoutKind.Sequential)]
    public struct POINTL
    {
        [MarshalAs(UnmanagedType.I4)]
        public int x;
        [MarshalAs(UnmanagedType.I4)]
        public int y;
    }
}
