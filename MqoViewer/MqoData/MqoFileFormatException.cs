using System;

namespace MQException
{
    public class MqoFileFormatException : Exception
    {
        public int LineNumber;

        public MqoFileFormatException(int lineNumber, string description)
            : base(description)
        {
            LineNumber = lineNumber;
        }
    }
}
