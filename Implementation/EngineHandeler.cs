using GameFramework;
using GameFramework.Extra;
using GameFramework.Item.Items;
using GameFramework.worldEntitys;
using Implementation.Creatures;
using Implementation.Items;
using Implementation.WorldObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation
{
    public class EngineHandeler
    {
        public static void DrawWorld()
        {
            World world = GameEngine.World;
            StringBuilder sb = new StringBuilder();
            for (int i = world.MaxY; i > -1; i--)
            {
                for (int j = 0; j < world.MaxX + 1; j++)
                {
                    IEnumerable<IWorldEntity> ents = world.WorldEntities
                        .Where(e => e.Posistion == new Posistion(j, i));

                    char c = EntitySprite(ents.FirstOrDefault());
                    
                    sb.Append(c + " ");
                }
                sb.AppendLine();
            }
            sb.AppendLine(InventoryString());
            Console.Clear();
            Console.WriteLine(sb);
        }

        private static string? InventoryString()
        {
            Player? p = (Player?)GameEngine.World.WorldEntities.Where(e => e is Player).FirstOrDefault();
            if (p == null)
                return null;

            StringBuilder sb = new();
            for (int i = 0; i < p.AttackInventory.Count; i++)
            {
                AttackItem item = p.AttackInventory[i];
                sb.Append(item.Name + " " + 
                    (i == p.ActiveAttackItemIndex ? "< |" :"  |"));
            }
            return sb.ToString();
        }

        private static char EntitySprite(IWorldEntity? ent)
        {
            if (ent == null)
                return ' ';

            switch (ent.Name)
            {
                case "Damage":
                    return '#';
                case "Rock":
                    return '@';
                case "Goblin":
                    return 'G';
                case "Hero":
                    return '!';
                case "LootBag":
                    return 'L';
                default:
                    return ' ';
            }
        }

        public static void InitWorld()
        {
            World world = GameEngine.World;
            for (int x = 0; x < world.MaxX + 1; x++)
            {
                world.WorldEntities.Add(new Rock(new Posistion(x, 0)));
                world.WorldEntities.Add(new Rock(new Posistion(x, world.MaxY)));
            }
            for (int y = 1; y < world.MaxY; y++)
            {
                world.WorldEntities.Add(new Rock(new Posistion(0, y)));
                world.WorldEntities.Add(new Rock(new Posistion(world.MaxX, y)));
            }

            Player p = new Player(new Posistion(25, 10));
            p.AttackInventory.Add(new ArmingSword());


            Random rand = new Random();
            for (int c = 0; c < 20; c++)
            {
                Posistion pos = new Posistion(rand.Next(1, GameEngine.World.MaxX - 1), rand.Next(1, GameEngine.World.MaxY - 1));
                if (!GameEngine.World.WorldEntities.Any(e => e.Posistion == pos))
                {
                    Goblin g = new Goblin(pos);
                    g.AttackInventory.Add(new ShortBow());
                }
            }
        }
    }
}
