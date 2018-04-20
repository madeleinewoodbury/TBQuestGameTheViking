using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    public class Viking : NPC, ITalk, IBattle
    {
        public override int Id { get; set; }
        public override string Description { get; set; }
        public List<string> Messages { get; set; }
        public int PrimaryWeapon { get; set; }
        public int PrimaryShield { get; set; }
        public string BattleMessage { get; set; }

        /// <summary>
        /// Generate a message or use the default message
        /// </summary>
        /// <returns></returns>
        public string Talk()
        {
            if (this.Messages != null)
            {
                return GetMessage();
            }
            else
            {
                return "I have nothing to say to you.";
            }
        }

        /// <summary>
        /// randomly select a message from the list of messages
        /// </summary>
        /// <returns></returns>
        private string GetMessage()
        {
            Random r = new Random();
            int messageIndex = r.Next(0, Messages.Count());
            return Messages[messageIndex];
        }

        public string Battle()
        {
            if (this.BattleMessage == null)
            {
                return "I will kill you!";
            }
            else
            {
                return this.BattleMessage
            }
        }

    }
}
