using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_UtIl.UtIls.Exceptions.Registry
{
    public class GenshinRegistryNullException : Exception
    {
        public override string Message => "지정한 레지스트리를 찾을 수 없습니다.";

        public GenshinRegistryNullException() 
        { 

        }
    }
}
