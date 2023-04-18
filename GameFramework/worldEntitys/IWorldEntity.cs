using GameFramework.worldEntitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    /// <summary>
    /// Some thing that exists in the world
    /// </summary>
    public interface IWorldEntity
    {
        /// <summary>
        /// A compass orientation
        /// </summary>
        enum Orientation
        {
            North,
            East,
            South,
            West,
        }
        /// <summary>
        /// The entity's position
        /// </summary>
        public Posistion Posistion { get; set; }

        /// <summary>
        /// The entity's name
        /// </summary>
        public string Name { get; }
    }
}
