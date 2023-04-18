using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework.Item
{
    /// <summary>
    /// An item that a creature can hold
    /// </summary>
    public interface IItem
    {
        /// <summary>
        /// The name of the item
        /// </summary>
        public string Name { get; }
    }
}
