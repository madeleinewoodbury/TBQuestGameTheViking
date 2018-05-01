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
                XP = 50,
                Description = "A wise and experienced warrior, he has seen a great deal on his quests.",
                Messages = new List<string>()
                {
                    "You have much to learn still, but I see a a great warrior within you.",
                    "There is great treasures beyond the sea, but you must respect the waters, if you don't\n"+
                    "it may swallow you hole.",
                },
                IsFriendly = true,
                VikingRank = Character.Rank.Radnigar,
                CanTrade = true,
                TradeObjects = new List<int>(){12, 22}
            },

            new Enemy
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
                IsViking = true,
                VikingRank = Character.Rank.Viking,
                IsArmed = true,
                CanTrade = false,
            },

            new Viking
            {
                Id = 13,
                Name ="Svala",
                LocationId = 1,
                XP = 20,
                Description = "A young shieldmaiden.",
                IsFriendly = true,
                VikingRank = Character.Rank.Viking,
                Messages = new List<string>()
                {
                    "I may have some things to trade with you"
                },
                IsArmed = false,
                CanTrade = true,
                TradeObjects = new List<int>(){20, 25, 49},
            },

            #endregion

            #region Npcs in Storhamar (2)

            new Enemy
            {
                Id = 20,
                Name ="Ubbe",
                LocationId = 2,
                XP = 15,
                Description = "Ubbe is a big string viking. He is armed with his fists.",
                BattleMessage = "I will fight you until the very last breath!",
                IsFriendly = false,
                IsViking = true,
                VikingRank = Character.Rank.Viking,
                IsArmed = false,
                CanTrade = false,
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
                TradeObjects = new List<int>(){42, 45},
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
                Description = "Sturla is the Jarl of Kunghälla.",
                Messages = new List<string>()
                {
                    "I may be a jarl, but I know a thing or two about battles.",
                    "Kunghälla will one day be the center of the world. Remember I said it first."
                },
                IsFriendly = true,
                VikingRank = Character.Rank.Jarl,
                IsArmed = false,
                CanTrade = false,
            },

            new Viking
            {
                Id = 31,
                Name ="Herfjðtur",
                LocationId = 3,
                XP = 25,
                Description = "The wife of Jarl Sturla.",
                Messages = new List<string>()
                {
                    "My husband thinks he will be the king of all vikings one day. Do you disagree?"
                },
                IsFriendly = true,
                VikingRank = Character.Rank.Viking,
                IsArmed = false,
                CanTrade = true,
                TradeObjects = new List<int>(){27, 20},
            },

            new Enemy
            {
                Id = 32,
                Name ="Alfkautr",
                LocationId = 3,
                XP = 35,
                Description = "A Hersir chosen by Jarl Sturla, but Alfkautr is a power hungry viking. You be wise not to upset him.",
                BattleMessage = "You think you can overthrow the royals of Kunghälla. But you will have to go through me first.",
                IsFriendly = false,
                PrimaryWeapon = 3,
                PrimaryShield = 8,
                IsViking = true,
                VikingRank = Character.Rank.Hersir,
                IsArmed = true,
                CanTrade = false,
            },

            #endregion

            #region NPCs in Nidaros (4)

            new Enemy
            {
                Id = 40,
                Name ="Baldr",
                LocationId = 4,
                XP = 30,
                Description = "Baldr the Beast is what he is known by the vikings of Nidaros. He doesn't like strangers very much.",
                BattleMessage = "I don't know you, therefor I don't trust you.",
                IsFriendly = false,
                PrimaryWeapon = 5,
                PrimaryShield = 0,
                IsViking = true,
                VikingRank = Character.Rank.Berserker,
                IsArmed = true,
                CanTrade = false,
            },

            new Enemy
            {
                Id = 41,
                Name ="Eyja",
                LocationId = 4,
                XP = 25,
                Description = "A fierce shieldmaiden. If you underestimate her, she will be the last thing you see before Valhalla.",
                BattleMessage = "Are you willing to fight? You are not a coward are you...",
                IsFriendly = false,
                PrimaryWeapon = 2,
                PrimaryShield = 8,
                IsViking = true,
                VikingRank = Character.Rank.Huskarl,
                IsArmed = true,
                CanTrade = false,
            },

            new Viking
            {
                Id = 42,
                Name ="Brynjar",
                LocationId = 4,
                XP = 20,
                Description = "A royal advisor to the king of Nidaros.",
                Messages = new List<string>()
                {
                    "You could be most useful on future raids. Join our ranks.",
                    "If you must know, I once stood in your shoes"
                },
                IsFriendly = true,
                VikingRank = Character.Rank.Skald,
                IsArmed = false,
                CanTrade = true,
                TradeObjects = new List<int>(){2, 10, 18, 22}
            },

            #endregion

            #region NPCs in Stavanger (5)

            new Enemy
            {
                Id = 50,
                Name ="Rolleifr",
                LocationId = 5,
                XP = 25,
                Description = "An expereienced warrior, with a lot of built up anger.",
                IsFriendly = false,
                PrimaryWeapon = 2,
                PrimaryShield = 9,
                IsViking = true,
                VikingRank = Character.Rank.Berserker,
                IsArmed = true,
                CanTrade = false,
            },

            new Viking
            {
                Id = 51,
                Name ="Ulvhildr",
                LocationId = 5,
                XP = 25,
                Description = "An old women and a healer.",
                Messages = new List<string>()
                {
                    "I see your pain...feel, don't think",
                    "What is beyond is never behind...You will be stronger than ever before."
                },
                IsFriendly = true,
                Health = 20,
                VikingRank = Character.Rank.Viking,
                IsArmed = false,
                CanTrade = false,
            },

            #endregion

            #region NPCs in Leirvik (5)

            
            new Enemy
            {
                Id = 60,
                Name ="Gunnar",
                LocationId = 6,
                XP = 50,
                Description = "Knut wants to be the Jarl of Leirvik, he sees any capable viking as anotehr threat",
                IsFriendly = false,
                PrimaryWeapon = 5,
                PrimaryShield = 8,
                IsViking = true,
                VikingRank = Character.Rank.Freyr,
                IsArmed = true,
                CanTrade = false,
            },

            new Viking
            {
                Id = 61,
                Name ="Vigdis",
                LocationId = 6,
                XP = 30,
                Description = "Wife of the Jarl Kjartan, she will gladly give you food.",
                Messages = new List<string>()
                {
                    "You must be hungry to have come all this way, let me tempt you with some food.",
                    "I will trade you food for the smalles of coin, you look like you need it more"
                },
                IsFriendly = true,
                VikingRank = Character.Rank.Jarl,
                IsArmed = false,
                CanTrade = true,
                TradeObjects = new List<int>(){40, 42, 43}
            },

            #endregion

            #region NPCs in Lindisfarne (7)

            new Viking
            {
                Id = 62,
                Name ="Sterri",
                LocationId = 7,
                XP = 30,
                Description = "Sterri overseas the Viking settlement on Lindisfarne. He might have some good thing to trade you.",
                Messages = new List<string>()
                {
                    "Glad to see you have come all the way to Lindisfarne."
                },
                IsFriendly = true,
                VikingRank = Character.Rank.Freyr,
                IsArmed = false,
                CanTrade = true,
                TradeObjects = new List<int>(){15, 16, 32, 33}
            },

            #endregion

            #region NPCs in Jorvik (8)

            new Enemy
            {
                Id = 63,
                Name ="Eanfled",
                LocationId = 8,
                XP = 40,
                Description = "An English warrior. She is skilled with a sword and eager to kill vikings.",
                IsFriendly = false,
                PrimaryWeapon = 14,
                PrimaryShield = 16,
                IsViking = false,
                EnglishRank = 8,
                VikingRank = Character.Rank.None,
                IsArmed = true,
                CanTrade = false,
            },

            #endregion

            #region NPCs in Norfolk (9)

            new Enemy
            {
                Id = 64,
                Name ="Lord Egbert",
                LocationId = 9,
                XP = 50,
                Description = "High ranking Anglo-Saxon, he has seen many battles. Not an enemy do be underestimated.",
                IsFriendly = false,
                PrimaryWeapon = 15,
                PrimaryShield = 16,
                IsViking = false,
                EnglishRank = 10,
                VikingRank = Character.Rank.None,
                IsArmed = true,
                CanTrade = false,
            },

            new Enemy
            {
                Id = 65,
                Name ="Saxon Soldier",
                LocationId = 9,
                XP = 20,
                Description = "Soldier sworn to protect Norfolk",
                IsFriendly = false,
                PrimaryWeapon = 15,
                PrimaryShield = 16,
                IsViking = false,
                EnglishRank = 7,
                VikingRank = Character.Rank.None,
                IsArmed = true,
                CanTrade = false,
            },

            #endregion


          

        };
    }
}
