using System;
using System.Collections;
using System.Collections.Generic;

namespace Html
{
    /// <summary>
    /// The AttributeList class is used to store list of
    /// Attribute classes.
    /// This source code may be used freely under the
    /// Limited GNU Public License(LGPL).
    ///
    /// Written by Jeff Heaton (http://www.jeffheaton.com)
    /// </summary>
    ///
    public class AttributeList : ICloneable
    {
        /// <summary>
        /// A list of the attributes in this AttributeList
        /// </summary>
        private List<Attribute> _List = new List<Attribute>();

        /// <summary>
        /// Make an exact copy of this object using the cloneable
        /// interface.
        /// </summary>
        /// <returns>A new object that is a clone of the specified
        /// object.</returns>
        public Object Clone()
        {
            AttributeList rtn = new AttributeList();

            for (int i = 0; i < _List.Count; i++)
                rtn.Add((Attribute)this[i].Clone());

            return rtn;
        }

        /// <summary>
        /// Add the specified attribute to the list of attributes.
        /// </summary>
        /// <param name="a">An attribute to add to this
        /// AttributeList.</paramv
        public void Add(Attribute a)
        {
            _List.Add(a);
        }

        /// <summary>
        /// Clear all attributes from this AttributeList and return
        /// it to a empty state.
        /// </summary>
        public void Clear()
        {
            _List.Clear();
        }

        /// <summary>
        /// Access the individual attributes
        /// </summary>
        public Attribute this[int index]
        {
            get
            {
                if (index < _List.Count)
                    return (Attribute)_List[index];
                else
                    return null;
            }
        }

        /// <summary>
        /// Access the individual attributes by name.
        /// </summary>
        public Attribute this[string index]
        {
            get
            {
                var canonIndex = index.ToLower();
                foreach (var a in _List)
                {
                    if (a.Name == canonIndex)
                        return a;
                }
                return null;
            }
        }
    }
}