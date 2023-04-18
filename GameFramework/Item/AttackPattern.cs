using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFramework.Extra;
using GameFramework.worldEntitys;

namespace GameFramework.Item
{
    /// <summary>
    /// Defines where a weapon deals damage
    /// </summary>
    public abstract class AttackPattern
    {
        /// <summary>
        /// The pattern an item uses to generate damage areas
        /// </summary>
        /// <param name="damage">How much damage the produced damage area does</param>
        protected AttackPattern(int damage)
        {
            Damage = damage;
        }

        private int Damage { get; set; }
        protected abstract List<Posistion> Pattern(Posistion pos, IWorldEntity.Orientation orientation);

        /// <summary>
        /// Generates the damage areas of the attack item
        /// </summary>
        /// <param name="pos">The global posistion of the items user</param>
        /// <param name="orientation">The global orientation of the items user</param>
        public void Attack(Posistion pos, IWorldEntity.Orientation orientation)
        {
            foreach (Posistion p in Pattern(pos, orientation))
            {
                GameEngine.World.WorldEntities
                    .Add(new DamgeArea(new Posistion(p.X + pos.X, p.Y + pos.Y), Damage));
            }

        }
    }
}
