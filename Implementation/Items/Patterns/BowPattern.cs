using GameFramework;
using GameFramework.Item;
using GameFramework.worldEntitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Items.Patterns
{
    public class BowPattern : AttackPattern
    {
        public BowPattern(int damage) : base(damage)
        {
        }

        protected override List<Posistion> Pattern(Posistion pos, IWorldEntity.Orientation orientation)
        {
            switch (orientation)
            {
                case IWorldEntity.Orientation.North:
                    return new List<Posistion>() {
                        new Posistion(0,1),
                        new Posistion(0,2),
                        new Posistion(0,3),
                        new Posistion(0,4),
                    };
                case IWorldEntity.Orientation.East:
                    return new List<Posistion>() {
                        new Posistion(1,0),
                        new Posistion(2,0),
                        new Posistion(3,0),
                        new Posistion(4,0),
                    };
                case IWorldEntity.Orientation.South:
                    return new List<Posistion>() {
                        new Posistion(0,-1),
                        new Posistion(0,-2),
                        new Posistion(0,-3),
                        new Posistion(0,-4),
                    };
                case IWorldEntity.Orientation.West:
                    return new List<Posistion>() {
                        new Posistion(-1,0),
                        new Posistion(-2,0),
                        new Posistion(-3,0),
                        new Posistion(-4,0),
                    };
                default:
                    return new List<Posistion>();
            }
        }
    }
}
