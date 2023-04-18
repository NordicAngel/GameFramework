using GameFramework.worldEntitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework.Item.Patterns
{
    public class SwordPattern : AttackPattern
    {
        public SwordPattern(int damage) : base(damage)
        {
        }

        protected override List<Posistion> Pattern(Posistion pos, IWorldEntity.Orientation orientation)
        {
            switch (orientation)
            {
                case IWorldEntity.Orientation.North:
                    return new List<Posistion>() { 
                        new Posistion(1,1),
                        new Posistion(0,1),
                        new Posistion(-1,1),
                    };
                case IWorldEntity.Orientation.East:
                    return new List<Posistion>() {
                        new Posistion(1,1),
                        new Posistion(1, 0),
                        new Posistion(1,-1),
                    }; 
                case IWorldEntity.Orientation.South:
                    return new List<Posistion>() {
                        new Posistion(1,-1),
                        new Posistion(0,-1),
                        new Posistion(-1,-1),
                    };
                case IWorldEntity.Orientation.West:
                    return new List<Posistion>() {
                        new Posistion(-1,1),
                        new Posistion(-1,0),
                        new Posistion(-1,-1),
                    };
                default:
                    return new List<Posistion>();
            }
        }
    }
}
