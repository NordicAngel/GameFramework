using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework.worldEntitys
{
    /// <summary>
    /// This is for showing and dealing damage
    /// </summary>
    public class DamgeArea : IWorldEntity
    {
        /// <summary>
        /// This is for showing and dealing damage
        /// </summary>
        /// <param name="posistion">Where the damage is delt</param>
        /// <param name="damage">How much damage the area deals</param>
        public DamgeArea(Posistion posistion, int damage)
        {
            Posistion = posistion;
            Damage = damage;
        }

        /// <summary>
        /// Where the damage is delt
        /// </summary>
        public Posistion Posistion { get; set; }

        /// <summary>
        /// Its name
        /// </summary>
        public string Name { get => "Damage"; }

        /// <summary>
        /// How much damage the area deals
        /// </summary>
        public int Damage { get; set; }
    }
}
