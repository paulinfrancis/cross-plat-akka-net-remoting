using System.Collections.Generic;

namespace Common
{
    public class HiMessage
    {
        public HiMessage(string message, int num, IEnumerable<string> aCollection)
        {
            Message = message;
            Num = num;
            ACollection = aCollection;
        }

        public string Message { get; }
        public int Num { get; }
        public IEnumerable<string> ACollection { get; }
    }
}
