using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework.Item
{
    /// <summary>
    /// An item that reduces damage to a creature
    /// </summary>
    public abstract class DefenceItem : IItem
    {
        /// <summary>
        /// Name of the defence item
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// How many points of damage teh item reduces 
        /// </summary>
        public abstract int Defence { get; }
    }
}
