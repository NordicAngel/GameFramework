using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFramework.Item;
using GameFramework.worldEntitys;

namespace GameFramework
{
    /// <summary>
    /// A weapon used by a creature
    /// </summary>
    public abstract class AttackItem : IItem
    {
        /// <summary>
        /// How much damage the item does
        /// </summary>
        public abstract int Damage { get; }

        /// <summary>
        /// The items name
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Witch pattern the item uses to genarate damage areas
        /// </summary>
        public abstract AttackPattern AttackPattern { get; }

        /// <summary>
        /// Used to trigger the attack of the item
        /// </summary>
        /// <param name="pos">The global posistion of the items user</param>
        /// <param name="orientation">The global orientation of the items user</param>
        public void Attack(Posistion pos, IWorldEntity.Orientation orientation) 
            => AttackPattern.Attack(pos, orientation);

    }
}
