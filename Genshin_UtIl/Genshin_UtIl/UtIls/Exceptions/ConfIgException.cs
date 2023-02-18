using System;

namespace Genshin_UtIl.UtIls.Exceptions
{
    public class ConfIgException : Exception
    {
        string ExceptionType;

        public override string Message
        {
            get
            {
                if (ExceptionType == "SaveConfIg")
                    return "ConfIg 파일을 저장하는데 예외가 있습니다.";
                else
                    return "ConfIg 파일을 로드하는데 예외가 있습니다.";
            }
        }

        public ConfIgException(string Type)
        {
            ExceptionType = Type;
        }
    }
}
