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
                Name ="Egill",
                LocationId = 1,
                XP = 50,
                Description = "A wise and experienced warrior, he has seen a great deal on his quests.",
                Messages = new List<string>()
                {
                    "You have much to learn still, but I see a a great warrior within you.",
                    "There is great treasures beyond the sea, but you must respect the waters, if you don't\n"+
                    "it may swallow you hole.",
                },
                IsFriendly = true,
                PrimaryShield = 7,
                PrimaryWeapon = 1,
                VikingRank = Character.Rank.Radnigar

            },

            new Viking
            {
                Id = 2,
                Name ="Skáldi",
                LocationId = 1,
                XP = 20,
                Description = "Skáldi is always looking for a fight. He has not seen many battles, \n" +
                "but he is fearless and strong.",
                IsFriendly = false,
                PrimaryWeapon = 6,
                PrimaryShield = 7,
                VikingRank = Character.Rank.Viking,
                IsArmed = true
            },

            new Viking
            {
                Id = 3,
                Name ="Ubbe",
                LocationId = 2,
                XP = 20,
                Description = "Ubbe is a big string viking. He is armed with his fists.",
                IsFriendly = false,
                VikingRank = Character.Rank.Viking,
                IsArmed = false
            }
        };
    }
}
