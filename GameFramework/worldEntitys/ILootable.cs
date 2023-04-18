using GameFramework.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework.worldEntitys
{
    public interface ILootable
    {
        public List<IItem> Inventory { get; set; }
    }
}
