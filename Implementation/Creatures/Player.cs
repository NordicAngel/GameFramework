using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFramework;
using GameFramework.Extra;
using GameFramework.Item;
using GameFramework.worldEntitys;

namespace Implementation.Creatures
{   
    public class Player : Creature
    {
        public Player(Posistion posistion) : base(posistion)
        {
            HP = 10;
        }

        public override int HP { get; set; }

        public override string Name => "Hero";

        public override void Act()
        {
            ConsoleKeyInfo input = Console.ReadKey();
            switch (input.Key)
            {
                case ConsoleKey.UpArrow:
                    Move(IWorldEntity.Orientation.North);
                    break;
                case ConsoleKey.RightArrow:
                    Move(IWorldEntity.Orientation.East);
                    break;
                case ConsoleKey.LeftArrow:
                    Move(IWorldEntity.Orientation.West);
                    break;
                case ConsoleKey.DownArrow:
                    Move(IWorldEntity.Orientation.South);
                    break;
                case ConsoleKey.Spacebar:
                    Attack();
                    break;
                case ConsoleKey.A:
                    ActiveAttackItemIndex -= ActiveAttackItemIndex <= 0 ? 0 : 1;
                    break;
                case ConsoleKey.D:
                    ActiveAttackItemIndex += ActiveAttackItemIndex >= AttackInventory.Count - 1 ? 0 : 1;
                    break;
            }
            IEnumerable<IWorldEntity> entities = GameEngine.World.WorldEntities.Where(e => e.Posistion == Posistion);
            IEnumerable<ILootable> lootContainers = entities.Where(e => e is ILootable).Select(e => (ILootable)e);
            IEnumerable<IItem> loot = lootContainers.SelectMany(e => e.Inventory);

            if (loot.Count() != 0)
            {
                AttackInventory.AddRange(loot.Where(e => e is AttackItem && !AttackInventory.Any(i => i.Name == e.Name)).Select(e => (AttackItem)e));
                DefenceInventory.AddRange(loot.Where(e => e is DefenceItem && !DefenceInventory.Any(i => i.Name == e.Name)).Select(e => (DefenceItem)e));
            }

            lootContainers.ToList().ForEach(lc => lc.Inventory.RemoveAll(i => true));
        }
    }
}
