﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    public abstract class GameObject
    {
        public abstract int Id { get; set; }
        public abstract string Name { get; set; }
        public abstract string Description { get; set; }
        public abstract int LocationId { get; set; }
        public abstract bool CanInventory { get; set; }
        public abstract int Value { get; set; }
        public abstract int Weight { get; set; }
    }
}
