using GameFramework;
using GameFramework.worldEntitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.WorldObjects
{
    public class Rock : WorldObject
    {
        public Rock(Posistion posistion) : base(posistion)
        {
        }

        public override string Name => "Rock";
    }
}
