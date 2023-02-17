using System.Runtime.InteropServices;

namespace Genshin_UtIl.UtIls.Display.Structure
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct Devmode
    {
        // You can define the following constant  
        // but OUTSIDE the structure because you know  
        // that size and layout of the structure  
        // is very important  
        // CCHDEVICE = 32 = 0x50  
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string dmDevice;
        // In addition you can define the last character array  
        // as following:  
        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]  
        //public Char[] dmDevice;  
        // After the 32-bytes array  
        [MarshalAs(UnmanagedType.U2)]
        public short dmSpecVersion;
        [MarshalAs(UnmanagedType.U2)]
        public short dmDriverVersion;
        [MarshalAs(UnmanagedType.U2)]
        public short dmSize;
        [MarshalAs(UnmanagedType.U2)]
        public short dmDriverExtra;
        [MarshalAs(UnmanagedType.U4)]
        public uint dmFields;
        public POINTL dmPosition;
        [MarshalAs(UnmanagedType.U4)]
        public uint dmDisplayOrientation;
        [MarshalAs(UnmanagedType.U4)]
        public uint dmDisplayFixedOutput;
        [MarshalAs(UnmanagedType.I2)]
        public short dmColor;
        [MarshalAs(UnmanagedType.I2)]
        public short dmDuplex;
        [MarshalAs(UnmanagedType.I2)]
        public short dmYResolution;
        [MarshalAs(UnmanagedType.I2)]
        public short dmTTOption;
        [MarshalAs(UnmanagedType.I2)]
        public short dmCollate;
        // CCHDEVICENAME = 32 = 0x50  
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string dmForm;
        // Also can be defined as  
        //[MarshalAs(UnmanagedType.ByValArray,  
        // SizeConst = 32, ArraySubType = UnmanagedType.U1)]  
        //public Byte[] dmFormName;  
        [MarshalAs(UnmanagedType.U2)]
        public short dmLogPixels;
        [MarshalAs(UnmanagedType.U4)]
        public uint dmBitsPerPel;
        [MarshalAs(UnmanagedType.U4)]
        public uint dmPelsWidth;
        [MarshalAs(UnmanagedType.U4)]
        public uint dmPelsHeight;
        [MarshalAs(UnmanagedType.U4)]
        public uint dmDisplayFlags;
        [MarshalAs(UnmanagedType.U4)]
        public uint dmDisplayFrequency;
        [MarshalAs(UnmanagedType.U4)]
        public uint dmICMFunctIon;
        [MarshalAs(UnmanagedType.U4)]
        public uint dmICMIntent;
        [MarshalAs(UnmanagedType.U4)]
        public uint dmMediaType;
        [MarshalAs(UnmanagedType.U4)]
        public uint dmDitherType;
        [MarshalAs(UnmanagedType.U4)]
        public uint dmReserved1;
        [MarshalAs(UnmanagedType.U4)]
        public uint dmReserved2;
        [MarshalAs(UnmanagedType.U4)]
        public uint dmPanningWidth;
        [MarshalAs(UnmanagedType.U4)]
        public uint dmPanningHeight;
    }
}
