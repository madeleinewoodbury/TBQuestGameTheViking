using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    public class Enemy : NPC, IBattle
    {
        public override int Id { get; set; }
        public override string Description { get; set; }
        public int PrimaryWeapon { get; set; }
        public int PrimaryShield { get; set; }
        public string BattleMessage { get; set; }

        public string Battle()
        {
            if (this.BattleMessage == null)
            {
                return "I will kill you!";
            }
            else
            {
                return this.BattleMessage;
            }
        }
    }
}
