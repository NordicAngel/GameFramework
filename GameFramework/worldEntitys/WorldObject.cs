using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFramework.Extra;
using GameFramework.Item;

namespace GameFramework.worldEntitys
{
    /// <summary>
    /// A non actin world enetity
    /// </summary>
    public abstract class WorldObject : IWorldEntity
    {
        /// <summary>
        /// A non actin world enetity
        /// </summary>
        /// <param name="posistion">The objects position</param>
        public WorldObject(Posistion posistion)
        {
            Posistion = posistion;
            GameEngine.World.WorldEntities.Add(this);
        }

        /// <summary>
        /// The objects opsition
        /// </summary>
        public Posistion Posistion { get; set; }

        /// <summary>
        /// The objects name
        /// </summary>
        public abstract string Name { get; }
    }
}
