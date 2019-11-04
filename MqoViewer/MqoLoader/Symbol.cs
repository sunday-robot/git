using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mq
{
    public class Symbol
    {
        private String _Value;

        public String Value
        {
            get
            {
                return _Value;
            }
        }

        public Symbol(String value)
        {
            _Value = value;
        }

        public override bool Equals(object obj)
        {
            return (obj is Symbol) && ((Symbol)obj)._Value.Equals(_Value);
        }

        public override int GetHashCode()
        {
            return _Value.GetHashCode();
        }

        public override string ToString()
        {
            return _Value;
        }
    }
}
