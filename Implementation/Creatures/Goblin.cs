using GameFramework;
using GameFramework.worldEntitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Creatures
{
    public class Goblin : Creature
    {
        public Goblin(Posistion posistion) : base(posistion)
        {
            HP = 5;
        }

        public override int HP { get; set; }
        public override string Name => "Goblin";

        public override void Act()
        {
            //Attack();
        }
    }
}
