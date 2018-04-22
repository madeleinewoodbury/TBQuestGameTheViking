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
            #region NPCs in Kaupang (1)

            new Viking
            {
                Id = 10,
                Name ="Egill",
                LocationId = 1,
                XP = 110,
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
                VikingRank = Character.Rank.Radnigar,
                CanTrade = true,
                TradeObjects = new List<int>(){12, 21}
            },

            new Viking
            {
                Id = 12,
                Name ="Skáldi",
                LocationId = 1,
                XP = 20,
                Description = "Skáldi is always looking for a fight. He has not seen many battles, \n" +
                "but he is fearless and strong.",
                BattleMessage = "Better pray to your gods, because you will soon meet them.",
                IsFriendly = false,
                PrimaryWeapon = 6,
                PrimaryShield = 7,
                VikingRank = Character.Rank.Viking,
                IsArmed = true,
                CanTrade = false
            },

            new Viking
            {
                Id = 13,
                Name ="Svala",
                LocationId = 1,
                XP = 10,
                Description = "A young shieldmaiden.",
                IsFriendly = true,
                VikingRank = Character.Rank.Viking,
                Messages = new List<string>()
                {
                    "I may have some things to trade with you"
                },
                IsArmed = false,
                CanTrade = true,
                TradeObjects = new List<int>(){20, 49}
            },

            #endregion

            #region Npcs in Storhamar (2)

            new Viking
            {
                Id = 20,
                Name ="Ubbe",
                LocationId = 2,
                XP = 15,
                Description = "Ubbe is a big string viking. He is armed with his fists.",
                BattleMessage = "I will fight you until the very last breath!",
                IsFriendly = false,
                VikingRank = Character.Rank.Viking,
                IsArmed = false,
                CanTrade = false
            },

            new Viking
            {
                Id = 21,
                Name ="Vilborg",
                LocationId = 2,
                XP = 10,
                Description = "An old widow, her husband Ilmr, went missing in the woods on a hunting trip.",
                Messages = new List<string>()
                {
                    "Have you seen my husband?",
                    "They say he will never return, but I know he is out there."
                },
                IsFriendly = true,
                VikingRank = Character.Rank.Viking,
                IsArmed = false,
                CanTrade = true,
                TradeObjects = new List<int>(){44}
            },

            new Viking
            {
                Id = 22,
                Name ="Melkolfr",
                LocationId = 2,
                XP = 30,
                Description = "Some call him 'Melkolfr the Map' because he knows his ways around.",
                Messages = new List<string>()
                {
                    "Follow the path that leads west and you will find the treasures you are looking for.",
                },
                IsFriendly = true,
                VikingRank = Character.Rank.Viking,
                IsArmed = false,
                CanTrade = false
            },

            #endregion

            #region NPCs in Kungahälla (3)

            new Viking
            {
                Id = 30,
                Name ="Sturla",
                LocationId = 3,
                XP = 25,
                Description = "Sturla is the Jarl of Kungälla.",
                IsFriendly = true,
                VikingRank = Character.Rank.Jarl,
                IsArmed = false,
                CanTrade = false
            },

            new Viking
            {
                Id = 31,
                Name ="Herfjðtur",
                LocationId = 3,
                XP = 25,
                Description = "The wife of Jarl Sturla.",
                IsFriendly = true,
                VikingRank = Character.Rank.Viking,
                IsArmed = false,
                CanTrade = false
            },

            #endregion

            #region NPCs in Nidaros (4)

            #endregion

            #region NPCs in Stavanger (5)

            #endregion

            #region NPCs in Leirvik (5)

            #endregion

            #region NPCs in Lindisfarne (7)

            #endregion

            #region NPCs in Jorvuj (8)

            #endregion

            #region NPCs in Norfolk (9)

            #endregion


          

        };
    }
}
