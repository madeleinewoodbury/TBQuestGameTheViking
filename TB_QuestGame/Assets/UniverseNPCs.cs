using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    public static partial class UniverseObjects
    {
        public static List<NPC> NPCs = new List<NPC>()
        {
            new Viking
            {
                Id = 1,
                Name ="Name",
                GameCharacter = Character.CharacterType.Farmer,
                LocationId = 1,
                Description = "Description",
                Messages = new List<string>()
                {
                    "Message 1",
                    "Message 2",
                    "Message 3"
                }

            },

            new Viking
            {
                Id = 2,
                Name ="Name",
                GameCharacter = Character.CharacterType.Viking,
                LocationId = 1,
                Description = "Description"
            }
        };
    }
}
