using GameFramework.Item.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework.Item.Items
{
    public class ArmingSword : AttackItem
    {
        public override int Damage => 2;

        public override string Name => "ArmingSword";

        public override AttackPattern AttackPattern => new SwordPattern(2);
    }
}
