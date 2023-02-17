using System;

namespace Genshin_UtIl.UtIls.Display.Enum
{
    [Flags()]
    public enum DisplayDeviceStateFlags : int
    {
        /// <summary>
        /// - 열거형
        /// <br/>ㅤ이 디스플레이는 바탕화면의 일부임을 나타내는 열거형입니다.
        /// </summary>
        AttachedToDesktop = 0x1,
        MultiDriver = 0x2,
        /// <summary>
        /// - 열거형
        /// <br/>ㅤ이 디스플레이는 주 모니터임을 나타내는 열거형입니다.
        /// </summary>
        PrimaryDevice = 0x4,
        /// <summary>Represents a pseudo device used to mirror application drawing for remoting or other purposes.</summary>
        MirroringDriver = 0x8,
        /// <summary>The device is VGA compatible.</summary>
        VGACompatible = 0x10,
        /// <summary>
        /// - 열거형
        /// <br/>ㅤ이 디스플레이는 이동식 모니터임을 나타내는 열거형입니다. 이러한 모니터는 주 모니터로 설정할 수 없습니다.
        /// </summary>
        Removable = 0x20,
        /// <summary>The device has more display modes than its output devices support.</summary>
        ModesPruned = 0x8000000,
        Remote = 0x4000000,
        Disconnect = 0x2000000
    }
}
