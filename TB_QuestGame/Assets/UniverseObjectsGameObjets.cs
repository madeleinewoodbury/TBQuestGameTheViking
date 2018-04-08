using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    public static partial class UniverseObjects
    {
        public static List<GameObject> GameObjetcs = new List<GameObject>()
        {
            #region Weapons (1-14)

            new Weapon
            {
                Id = 1,
                Name = "Ulfberht Sword",
                LocationId = 0,
                Description = "Crafted by the Nordic smith named Ulfberht, this is one of the first all steel blades.",
                Value = 25,
                CanInventory = true
            },

            new Weapon
            {
                Id = 2,
                Name = "Stiklestad Viking Sword",
                LocationId = 0,
                Description = "This is a beautiful crafted sword. The pommel and guard are decorated with copper. \n" +
                "It is a heavy sword, but it can do a lot of damage.",
                Value = 40,
                CanInventory = true
            },

            new Weapon
            {
                Id = 3,
                Name = "Maldon Sword",
                LocationId = 0,
                Description = "This is a light, agile and resilient fighting blade. It is smaller than a regular sword, which makes \n" +
                "it great for fighting armed with a shield or an axe in the other hand.",
                Value = 30,
                CanInventory = true
            },

            new Weapon
            {
                Id = 4,
                Name = "Bearded Axe",
                LocationId = 0,
                Description = "This quite capable of cleaving helms or armours. Made from though steel, great for battles.",
                Value = 30,
                CanInventory = true
            },

            new Weapon
            {
                Id = 5,
                Name = "Double-Bladed Barbarian Battle Axe",
                LocationId = 0,
                Description = "This axe is meant only for the most ferocious and stout warriours.",
                Value = 50,
                CanInventory = true
            },

            new Weapon
            {
                Id = 6,
                Name = "Short Viking Axe",
                LocationId = 0,
                Description = "Shorter than most axes, this axe is great for throwing. Don't be fooled by it's length, \n" +
                "the shaft is sharp, and with great accuracy this could be the perfect battle weapon.",
                Value = 20,
                CanInventory = true
            },

            new Weapon
            {
                Id = 7,
                Name = "Norse Viking Shield",
                LocationId = 0,
                Description = "This is a common shield among the vikings. With it's thick plywood center and steel rim, \n" +
                "it is built to withstand the sharpest of blades.",
                Value = 20,
                CanInventory = true
            },

            new Weapon
            {
                Id = 8,
                Name = "Huskarl Shield",
                LocationId = 0,
                Description = "This is a sturdy Viking Shiels made out of red oak and plywood. It is lighter than most shields, \n" +
                "which makes it easier to move around in combat.",
                Value = 30,
                CanInventory = true
            },

            new Weapon
            {
                Id = 9,
                Name = "Berserker Shield",
                LocationId = 0,
                Description = "This is one of the stringest shields, made from thick wood and steel. It is heavy, but not much can go through it.",
                Value = 40,
                CanInventory = true
            },

            new Weapon
            {
                Id = 10,
                Name = "Holmegard Bow",
                LocationId = 0,
                Description = "This is a wide flatbow with narrow ends. Made to shoot far and with great force.",
                Value = 35,
                CanInventory = true
            },

             new Weapon
            {
                Id = 11,
                Name = "Meare Heat Bow",
                LocationId = 0,
                Description = "A traditional bow, small and light. Great for hunting and shorter distances.",
                Value = 20,
                CanInventory = true
            },

            new Weapon
            {
                Id = 12,
                Name = "Einar Viking Dagger",
                LocationId = 0,
                Description = "A small but incredibilry sharp knife. Great for upclose combats.",
                Value = 15,
                CanInventory = true
            },

            new Weapon
            {
                Id = 13,
                Name = "Warrior Dagger",
                LocationId = 0,
                Description = "If it were any longer you could mistake this for a sword. This is a knife best suited for a warrior.",
                Value = 30,
                CanInventory = true
            },

            new Weapon
            {
                Id = 14,
                Name = "Anglo-Saxon Seax",
                LocationId = 0,
                Description = "A multifunctional weapon, worn to show prestige and power, but it's sharp \n" +
                "blade was made to kill.",
                Value = 45,
                CanInventory = true
            },

            #endregion

            #region Treasure (15-30)

            new Treasure
            {
                Id = 15,
                Name = "Amber Dragon Hammer",
                LocationId = 6,
                Description = "This is a highly intricate amulet of power and protection, fit for a high ranking Saxon or Viking leader. \n" +
                "The head of a Celtic dragon has been sculpted to bite the chain that it hangs from.",
                Value = 50,
                CanInventory = true
            },

            new Treasure
            {
                Id = 16,
                Name = "Bear Claw Pendant",
                LocationId = 1,
                Description = "This is a well decorated and unique bear claw pendant. Made from steel and will look great on a berserker.",
                Value = 20,
                CanInventory = true
            },

            new Treasure
            {
                Id = 17,
                Name = "Kattegat Brooch",
                LocationId = 3,
                Description = "A nice brooch cast from bronze. Only made in Kattegat.",
                Value = 15,
                CanInventory = true
            },

            new Treasure
            {
                Id = 18,
                Name = "Bronze Wolf Hammer",
                LocationId = 5,
                Description = "Bronze hammer pendant with a wolf's heas on it.",
                Value = 10,
                CanInventory = true
            },

            new Treasure
            {
                Id = 19,
                Name = "Eagle Ring",
                LocationId = 4,
                Description = "The ring has two eagles on it, made out of brass. Represent strength and resilience.",
                Value = 20,
                CanInventory = true
            },

            new Treasure
            {
                Id = 20,
                Name = "Gold Necklace",
                LocationId = 9,
                Description = "A beautful necklace made from gold. Wore by the reach Anglo-Saxons.",
                Value = 40,
                CanInventory = true
            },

            new Treasure
            {
                Id =21,
                Name = "Tortoise Brooches",
                LocationId = 3,
                Description = "The name comes from their resmblance to the tortoise. Made from brass and bronze.",
                Value = 20,
                CanInventory = true
            },

            new Treasure
            {
                Id = 22,
                Name = "Odin Pendant",
                LocationId = 8,
                Description = "Odin, known as the Norse All-Father. He sist astride his horse, Sleipnerm who carries souls to the \n" +
                "unseen realms. This gold pendant has an eye in the middle, it is the eye of Odin.",
                Value = 100,
                CanInventory = true
            },

            new Treasure
            {
                Id = 23,
                Name = "Oseberg Earrings",
                LocationId = 2,
                Description = "A Viking doesn't wear any earrings, but earrings made out of silver made to represent the sea.",
                Value = 20,
                CanInventory = true
            },

            new Treasure
            {
                Id = 24,
                Name = "Thor's Hammer Bronze",
                LocationId = 3,
                Description = "A unique and beautiful pendant representing the Hammer of Thor.",
                Value = 50,
                CanInventory = true
            },

            new Treasure
            {
                Id = 25,
                Name = "Fylkirfold ring",
                LocationId = 1,
                Description = "Made out pewter and silver. With the name Fylkirfold carved into it.",
                Value = 20,
                CanInventory = true
            },

            new Treasure
            {
                Id = 26,
                Name = "Valhalla Necklace",
                LocationId = 5,
                Description = "A heavy necklace made from gold, the name implies that you must be worthy of wearing it.",
                Value = 50,
                CanInventory = true
            },
            /*
            new Treasure
            {
                Id = 27,
                Name = "",
                LocationId = 0,
                Description = "",
                Value = 50,
                CanInventory = true
            },
            
            new Treasure
            {
                Id = 28,
                Name = "",
                LocationId = 0,
                Description = "",
                Value = 0,
                CanInventory = true
            },

            new Treasure
            {
                Id = 29,
                Name = "",
                LocationId = 0,
                Description = "",
                Value = 0,
                CanInventory = true
            },

            new Treasure
            {
                Id = 30,
                Name = "",
                LocationId = 0,
                Description = "",
                Value = 0,
                CanInventory = true
            },
            */
            #endregion

            #region Armour and Clothing (31-38)

            new Item
            {
                Id = 31,
                Name = "Leather Helmet",
                LocationId = 1,
                Description = "Made from sturdy leather, this helmet is lighter than steel, but not the most protective in battle.",
                Value = 10,
                CanInventory = true,
                IsConsumable = false,
                Health = 0,
            },

            new Item
            {
                Id = 32,
                Name = "Coppergate Helmet",
                LocationId = 9,
                Description = "Also known as the York Helmet. This is an Anglo-Saxon crested helmet, richly decorated with brass ornamentation.",
                Value = 25,
                CanInventory = true,
                IsConsumable = false,
                Health = 0,
            },

            new Item
            {
                Id = 33,
                Name = "Steel Helmet",
                LocationId = 0,
                Description = "Nicely decorated helmet made from steel. Great for battles, protects the nose and chin as well.",
                Value = 30,
                CanInventory = true,
                IsConsumable = false,
                Health = 0,
            },


            new Item
            {
                Id = 34,
                Name = "Chainmill",
                LocationId = 7,
                Description = "Covers the upperbody, it's heavy, but it could save your life in battle.",
                Value = 15,
                CanInventory = true,
                IsConsumable = false,
                Health = 0,
            },

            new Item
            {
                Id = 35,
                Name = "Battle Arm Braces",
                LocationId = 3,
                Description = "",
                Value = 5,
                CanInventory = true,
                IsConsumable = false,
                Health = 0,
            },

            new Item
            {
                Id = 36,
                Name = "Leather Armour",
                LocationId = 1,
                Description = "",
                Value = 10,
                CanInventory = true,
                IsConsumable = false,
                Health = 0,
            },
            /*
            new Item
            {
                Id = 37,
                Name = "",
                LocationId = 0,
                Description = "",
                Value = 0,
                CanInventory = true,
                IsConsumable = false,
                Health = 0,
            },

            new Item
            {
                Id = 38,
                Name = "",
                LocationId = 0,
                Description = "",
                Value = 0,
                CanInventory = true,
                IsConsumable = false,
                Health = 0,
            },
            */

            #endregion

            #region Food (39-46)
            /*
            new Item
            {
                Id = 39,
                Name = "",
                LocationId = 0,
                Description = "",
                Value = 0,
                CanInventory = true,
                IsConsumable = true,
                Health = 0
            },*/

            new Item
            {
                Id = 40,
                Name = "Mead",
                LocationId = 2,
                Description = "Drink to the gods.",
                Value = 0,
                CanInventory = true,
                IsConsumable = true,
                Health = 5
            },

            new Item
            {
                Id = 41,
                Name = "Meat",
                LocationId = 5,
                Description = "",
                Value = 0,
                CanInventory = true,
                IsConsumable = true,
                Health = 15
            },

            new Item
            {
                Id = 42,
                Name = "Fish",
                LocationId = 6,
                Description = "",
                Value = 0,
                CanInventory = true,
                IsConsumable = true,
                Health = 10
            },

            new Item
            {
                Id = 43,
                Name = "Apple",
                LocationId = 8,
                Description = "",
                Value = 0,
                CanInventory = true,
                IsConsumable = true,
                Health = 5
            },

            new Item
            {
                Id = 44,
                Name = "Skyr",
                LocationId = 4,
                Description = "A soft, yoghurt-like cheese.",
                Value = 0,
                CanInventory = true,
                IsConsumable = true,
                Health = 5
            },
            /*
            new Item
            {
                Id = 45,
                Name = "",
                LocationId = 0,
                Description = "",
                Value = 0,
                CanInventory = true,
                IsConsumable = true,
                Health = 5
            },

            new Item
            {
                Id = 46,
                Name = "",
                LocationId = 0,
                Description = "",
                Value = 0,
                CanInventory = true,
                IsConsumable = true,
                Health = 5
            },
            */
            #endregion

            #region Miscellaneous (47-)

            new Item
            {
                Id = 47,
                Name = "Horn",
                LocationId = 2,
                Description = "This is a must have item for all Vikings. How else are you going to consume your mead?!",
                Value = 5,
                CanInventory = true,
                IsConsumable = false,
                Health = 0
            },

            new Item
            {
                Id = 48,
                Name = "Dragon Tankard",
                LocationId = 3,
                Description = "Hold about 1 pint, this tankard has a sculpted dragon as a handle. Made fron pewter.",
                Value = 15,
                CanInventory = true,
                IsConsumable = false,
                Health = 0
            },

            new Item
            {
                Id = 49,
                Name = "Comb",
                LocationId = 2,
                Description = "Comb made from animal bones.",
                Value = 5,
                CanInventory = true,
                IsConsumable = false,
                Health = 0
            },

            #endregion

            #region Places (50-)

            //
            // Places in Kapuang
            //
            new Place
            {
                Id = 50,
                Name = "The Mead and Shield Tavern",
                LocationId = 1,
                Description = "Here you can eat and gain some strength",
                EntryMessage ="Welcome to The Mead and Shield Tavern. \n" +
                "Our mead is warm, the fish is fresh, and the people are in a festive mood. \n",
                CanInventory = false,
                Health = 10,
                ExperiencePoints = 0,
                EnytryPoints = 0,
                CanRest = false,
                CanEeat = true,
                CanTrain = false
            },

            new Place
            {
                Id = 51,
                Name = "Magda's Inn",
                LocationId = 1,
                Description = "Magda's door is always open. Here you'll find the rest you need to continue your journey",
                EntryMessage = "Welcome to Magda's Inn \n" +
                "The bed is ready for you, lay down and get some rest before you continue your quest.",
                CanInventory = false,
                Health = 10,
                ExperiencePoints = 0,
                EnytryPoints = 0,
                CanRest = true,
                CanEeat = false,
                CanTrain = false
            },

            //
            // Places in Storhamar
            //
            new Place
            {
                Id = 52,
                Name = "The Wood Hut",
                LocationId = 2,
                Description = "Come in to the Wood Hut and rest you weary bones.",
                EntryMessage ="Welcome to The Wood Hut \n" +
                "We don't get a lot of visitors here, but we started a fire for you. \n" +
                "You look like a warrior, go head, sleep wherever you like. \n" +
                "\n",
                CanInventory = false,
                Health = 0,
                ExperiencePoints = 0,
                EnytryPoints = 0,
                CanRest = true,
                CanEeat = false,
                CanTrain = false
            },

            //
            // Places in Kungahälla
            //
            new Place
            {
                Id = 53,
                Name = "Bohus Fästning",
                LocationId = 3,
                Description = "Imporant Viking leaders gather at this fortress, you'll need to be experienced to enter here.",
                EntryMessage = "Welcome into Bohus Fästning \n" +
                "You must be important to have been granted entry to this strong fortress. \n" +
                "Please, help yourself to one of our rooms, and don't be shy, dine with us if you wish. \n" +
                "\n",
                CanInventory = false,
                Health = 0,
                ExperiencePoints = 10,
                EnytryPoints = 50,
                CanRest = true,
                CanEeat = true,
                CanTrain = false
            },

            //
            // Places in Nidaros
            //
            new Place
            {
                Id = 54,
                Name = "The Oxe Cave",
                LocationId = 4,
                Description = "The Oxe Cave have the best meats in town. \n +" +
                "But here you will also find some of the most feared vikings in the land.",
                EntryMessage = "Welcome in to the Oxe Cave \n +" +
                "Please, enjoy our meats. But be aware, not everyone in here is a friend. \n",
                CanInventory = false,
                Health = 20,
                ExperiencePoints = 5,
                EnytryPoints = 20,
                CanRest = false,
                CanEeat = true,
                CanTrain = false
            },

            new Place
            {
                Id = 55,
                Name = "The Willow",
                LocationId = 4,
                Description = "Need some rest. The Willow can help with that",
                EntryMessage = "Welcome to the Willow \n +" +
                "You look tired, why don't you get some rest in one of pur rooms. \n",
                CanInventory = false,
                Health = 0,
                ExperiencePoints = 0,
                EnytryPoints = 0,
                CanRest = true,
                CanEeat = false,
                CanTrain = false
            },

            //
            // Places in Stavanger
            //
            new Place
            {
                Id = 56,
                Name = "The Seamonster Training Center",
                LocationId = 5,
                Description = "Come in a work on your seafaring skills. They may come in handy.",
                EntryMessage = "Welcome to the Seamonster Training Center \n " +
                "We will teach you all you need to know to travel the open seas. \n",
                CanInventory = false,
                Health = 0,
                ExperiencePoints = 25,
                EnytryPoints = 0,
                CanRest = false,
                CanEeat = false,
                CanTrain = true
            },

            //
            // Places in Leirvik
            //
            /*
            new Place
            {
                Id = 00,
                Name = "",
                LocationId = 6,
                Description = "",
                EntryMessage = "",
                CanInventory = false,
                Health = 0,
                ExperiencePoints = 0,
                EnytryPoints = 0,
                CanRest = true,
                CanEeat = true,
                CanTrain = false
            },

            //
            // Places in Lindisfarner
            //
            new Place
            {
                Id = 00,
                Name = "",
                LocationId = 7,
                Description = "",
                EntryMessage = "",
                CanInventory = false,
                Health = 0,
                ExperiencePoints = 0,
                EnytryPoints = 0,
                CanRest = true,
                CanEeat = true,
                CanTrain = false
            },

            //
            // Places in Jorvik
            //
            new Place
            {
                Id = 00,
                Name = "",
                LocationId = 8,
                Description = "",
                EntryMessage = "",
                CanInventory = false,
                Health = 0,
                ExperiencePoints = 0,
                EnytryPoints = 0,
                CanRest = true,
                CanEeat = true,
                CanTrain = false
            },

            //
            // Places in Norfolk
            //
            new Place
            {
                Id = 00,
                Name = "",
                LocationId = 9,
                Description = "",
                EntryMessage = "",
                CanInventory = false,
                Health = 0,
                ExperiencePoints = 0,
                EnytryPoints = 0,
                CanRest = true,
                CanEeat = true,
                CanTrain = false
            },*/

            #endregion

        };
    }
}
