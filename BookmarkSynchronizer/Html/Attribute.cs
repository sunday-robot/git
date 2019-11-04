using System;

namespace Html
{
    /// <summary>
    /// Attribute holds one attribute, as is normally stored in an
    /// HTML or XML file. This includes a name, value and delimiter.
    /// This source code may be used freely under the
    /// Limited GNU Public License(LGPL).
    ///
    /// Written by Jeff Heaton (http://www.jeffheaton.com)
    /// </summary>
    public class Attribute : ICloneable
    {
        /// <summary>
        /// The name of this attribute
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The value of this attribute
        /// </summary>
        public string Value { get; private set; }

        /// <summary>
        /// The delimiter for the value of this attribute(i.e. " or ’).
        /// </summary>
        public char Delim { get; private set; }

        /// <summary>
        /// Construct a new Attribute.  The name, delim, and value
        /// properties can be specified here.
        /// </summary>
        /// <param name="name">The name of this attribute.</param>
        /// <param name="value">The value of this attribute.</param>
        /// <param name="delim">The delimiter character for the value.
        /// </param>
        public Attribute(string name, string value, char delim = (char) 0)
        {
            Name = name.ToLower(); // HTMLでは属性名も要素名も大文字、小文字の区別はない。ただし、HTML仕様書では読みやすさのため、属性名を小文字表記しているので、これに倣って小文字にする。
            Value = value;
            Delim = delim;
        }

        #region ICloneable Members
        public virtual object Clone()
        {
            return new Attribute(Name, Value, Delim);
        }
        #endregion
    }
}