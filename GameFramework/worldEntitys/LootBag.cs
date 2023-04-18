using GameFramework.Extra;
using GameFramework.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework.worldEntitys
{
    /// <summary>
    /// An entity from killed creatures containing their loot
    /// </summary>
    public class LootBag : WorldObject, ILootable
    {
        public override string Name => "LootBag";

        public List<IItem> Inventory { get; set; }

        public LootBag(Posistion posistion, List<IItem> inventory) : base(posistion)
        {
            Inventory = inventory;
            GameEngine.GameTickTakeDamage += RemoveIfEmpty;
        }

        private void RemoveIfEmpty()
        {
            if (Inventory.Count == 0)
            {
                GameEngine.World.WorldEntities.Remove(this);
                GameEngine.GameTickTakeDamage -= RemoveIfEmpty;
            }
        }
    }
}
