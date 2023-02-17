using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_UtIl.UtIls.Display.Structure
{
    public struct DIsplays
    {
        public string DIsplay { get; set; }
        public struct DIsplay_ResolutIon
        {
            public uint WIdth { get; set; }
            public uint HeIght { get; set; }

            public DIsplay_ResolutIon(uint _WIdth, uint _HeIght)
            {
                WIdth = _WIdth;
                HeIght = _HeIght;
            }
        }

        public DIsplay_ResolutIon DIsplay_Resol;

        public POINTL DIsplay_P;

        public uint DIsplay_Frequency { get; set; }

        public bool IsPrImaryDIsplay { get; set; }

        /// <summary>
        /// - 기능
        /// <br/>ㅤ이 컴퓨터의 하나의 디스플레이 스펙을 저정합니다.
        /// </summary>
        /// <param name="_DIsplay">
        /// - 매개 변수
        /// <br/>ㅤ디스플레이
        /// </param>
        /// <param name="_DIsplayResolutIon">
        /// - 매개 변수
        /// <br/>ㅤ모니터 해상도</param>
        /// <param name="_DIsplay_P">
        /// - 매개 변수
        /// <br/>ㅤ윈도우 상에서 모니터의 위치</param>
        /// <param name="_DIsplay_Frequency">
        /// - 매개 변수
        /// <br/>ㅤ모니터 주파수</param>
        /// <param name="_IsPrImaryDIsplay">
        /// - 매개 변수
        /// <br/>ㅤ주 디스플레이 여부</param>
        public DIsplays(string _DIsplay, DIsplay_ResolutIon _DIsplayResolutIon, POINTL _DIsplay_P, uint _DIsplay_Frequency, bool _IsPrImaryDIsplay)
        {
            DIsplay = _DIsplay;
            DIsplay_Resol = _DIsplayResolutIon;
            DIsplay_P = _DIsplay_P;
            DIsplay_Frequency = _DIsplay_Frequency;
            IsPrImaryDIsplay = _IsPrImaryDIsplay;
        }
    }
}
