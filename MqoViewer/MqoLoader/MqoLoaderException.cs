using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mq
{
    public class MqoLoaderException : Exception
    {
        private Exception _OriginalException;
        private int _LineNumber;

        public MqoLoaderException(Exception originalException, int lineNumber)
        {
            _OriginalException = originalException;
            _LineNumber = lineNumber;
        }

        public Exception GetOriginalException()
        {
            return _OriginalException;
        }

        public int GetLineNumber()
        {
            return _LineNumber;
        }

        public override string ToString()
        {
            return _OriginalException + base.ToString();
        }
    }
}
