using GameFramework;
using GameFramework.Item;
using Implementation.Items.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Items
{
    public class ShortBow : AttackItem
    {
        public override int Damage => 3;

        public override string Name => "ShortBow";

        public override AttackPattern AttackPattern => new BowPattern(3);
    }
}
