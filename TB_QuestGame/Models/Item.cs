using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    public class Item : GameObject
    {
        public override int Id { get; set; }
        public override string Name { get; set; }
        public override string Description { get; set; }
        public override int LocationId { get; set; }
        public override bool CanInventory { get; set; }

        public bool IsConsumable { get; set; }
        public int Value { get; set; }
        public int Health { get; set; }
    }
}
