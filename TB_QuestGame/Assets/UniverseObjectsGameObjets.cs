﻿using System;
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
            #region Weapons (1-16)

            new Weapon
            {
                Id = 1,
                Name = "Ulfberht Sword",
                LocationId = 0,
                XP = 10,
                Description = "Crafted by the Nordic smith named Ulfberht, this is one of the first all steel blades.",
                Value = 25,
                Weight = 10,
                DamagePoints = 25,
                CanInventory = true,
                Shield = false
            },

            new Weapon
            {
                Id = 2,
                Name = "Stiklestad Viking Sword",
                LocationId = 0,
                XP = 15,
                Description = "This is a beautiful crafted sword. The pommel and guard are decorated with copper. \n" +
                "It is a heavy sword, but it can do a lot of damage.",
                Value = 40,
                Weight = 15,
                DamagePoints = 45,
                CanInventory = true
            },

            new Weapon
            {
                Id = 3,
                Name = "Maldon Sword",
                LocationId = 4,
                XP = 15,
                Description = "This is a light, agile and resilient fighting blade. It is smaller than a regular sword, which makes \n" +
                "it great for fighting armed with a shield or an axe in the other hand.",
                Value = 30,
                Weight = 8,
                DamagePoints = 30,
                CanInventory = true,
                Shield = false
            },

            new Weapon
            {
                Id = 4,
                Name = "Bearded Axe",
                LocationId = 0,
                XP = 12,
                Description = "This quite capable of cleaving helms or armours. Made from though steel, great for battles.",
                Value = 30,
                Weight = 15,
                DamagePoints = 25,
                CanInventory = true,
                Shield = false
            },

            new Weapon
            {
                Id = 5,
                Name = "Double-Bladed Barbarian Battle Axe",
                LocationId = 0,
                XP = 15,
                Description = "This axe is meant only for the most ferocious and stout warriours.",
                Value = 50,
                Weight = 20,
                DamagePoints = 50,
                CanInventory = true,
                Shield = false
            },

            new Weapon
            {
                Id = 6,
                Name = "Short Viking Axe",
                LocationId = 3,
                XP = 10,
                Description = "Shorter than most axes, this axe is great for throwing. Don't be fooled by it's length, \n" +
                "the shaft is sharp, and with great accuracy this could be the perfect battle weapon.",
                Value = 20,
                Weight = 10,
                DamagePoints = 30,
                CanInventory = true,
                Shield = false
            },

            new Weapon
            {
                Id = 7,
                Name = "Norse Viking Shield",
                LocationId = 0,
                XP = 10,
                Description = "This is a common shield among the vikings. With it's thick plywood center and steel rim, \n" +
                "it is built to withstand the sharpest of blades.",
                Value = 20,
                Weight = 15,
                DamagePoints = 10,
                CanInventory = true,
                Shield = true
            },

            new Weapon
            {
                Id = 8,
                Name = "Huskarl Shield",
                LocationId = 0,
                XP = 10,
                Description = "This is a sturdy Viking Shiels made out of red oak and plywood. It is lighter than most shields, \n" +
                "which makes it easier to move around in combat.",
                Value = 30,
                Weight = 10,
                DamagePoints = 10,
                CanInventory = true,
                Shield = true
            },

            new Weapon
            {
                Id = 9,
                Name = "Berserker Shield",
                LocationId = 0,
                XP = 15,
                Description = "This is one of the stringest shields, made from thick wood and steel. It is heavy, but not much can go through it.",
                Value = 40,
                Weight = 20,
                DamagePoints = 15,
                CanInventory = true,
                Shield = true
            },

            new Weapon
            {
                Id = 10,
                Name = "Holmegard Bow",
                LocationId = 5,
                XP = 10,
                Description = "This is a wide flatbow with narrow ends. Made to shoot far and with great force.",
                Value = 35,
                Weight = 15,
                DamagePoints = 25,
                CanInventory = true,
                Shield = false
            },

             new Weapon
            {
                Id = 11,
                Name = "Meare Heat Bow",
                LocationId = 0,
                XP = 12,
                Description = "A traditional bow, small and light. Great for hunting and shorter distances.",
                Value = 20,
                Weight = 10,
                DamagePoints = 20,
                CanInventory = true,
                Shield = false
            },

            new Weapon
            {
                Id = 12,
                Name = "Einar Viking Dagger",
                LocationId = 8,
                XP = 10,
                Description = "A small but incredibilry sharp knife. Great for upclose combats.",
                Value = 15,
                Weight = 5,
                DamagePoints = 10,
                CanInventory = true
            },

            new Weapon
            {
                Id = 13,
                Name = "Warrior Dagger",
                LocationId = 0,
                XP = 15,
                Description = "If it were any longer you could mistake this for a sword. This is a knife best suited for a warrior.",
                Value = 30,
                Weight = 15,
                DamagePoints = 20,
                CanInventory = true,
                Shield = false
            },

            new Weapon
            {
                Id = 14,
                Name = "Anglo-Saxon Seax",
                LocationId = 9,
                XP = 15,
                Description = "A multifunctional weapon, worn to show prestige and power, but it's sharp \n" +
                "blade was made to kill.",
                Value = 45,
                Weight = 10,
                DamagePoints = 30,
                CanInventory = true,
                Shield = false
            },

            new Weapon
            {
                Id = 15,
                Name = "Anglo-Saxon Sword",
                LocationId = 0,
                XP = 15,
                Description = "Sharp saxon blade. Not as heavy as viking swords.",
                Value = 35,
                Weight = 10,
                DamagePoints = 40,
                CanInventory = true,
                Shield = false
            },

            new Weapon
            {
                Id = 16,
                Name = "Anglo-Saxon Shield",
                LocationId = 0,
                XP = 15,
                Description = "Shield carried by the English soldiers",
                Value = 25,
                Weight = 15,
                DamagePoints = 10,
                CanInventory = true,
                Shield = true
            },

            #endregion

            #region Treasure (17-33)

            new Treasure
            {
                Id = 17,
                Name = "Amber Dragon Hammer",
                LocationId = 6,
                XP = 15,
                Description = "This is a highly intricate amulet of power and protection, fit for a high ranking Saxon or Viking leader. \n" +
                "The head of a Celtic dragon has been sculpted to bite the chain that it hangs from.",
                Value = 50,
                Weight = 5,
                CanInventory = true
            },

            new Treasure
            {
                Id = 18,
                Name = "Bear Claw Pendant",
                LocationId = 1,
                XP = 10,
                Description = "This is a well decorated and unique bear claw pendant. Made from steel and will look great on a berserker.",
                Value = 20,
                Weight = 5,
                CanInventory = true
            },

            new Treasure
            {
                Id = 19,
                Name = "Kattegat Brooch",
                LocationId = 3,
                XP = 5,
                Description = "A nice brooch cast from bronze. Only made in Kattegat.",
                Value = 15,
                Weight = 7,
                CanInventory = true
            },

            new Treasure
            {
                Id = 20,
                Name = "Bronze Wolf Hammer",
                LocationId = 5,
                XP = 5,
                Description = "Bronze hammer pendant with a wolf's heas on it.",
                Value = 10,
                Weight = 10,
                CanInventory = true
            },

            new Treasure
            {
                Id = 21,
                Name = "Eagle Ring",
                LocationId = 4,
                XP = 10,
                Description = "The ring has two eagles on it, made out of brass. Represent strength and resilience.",
                Value = 20,
                Weight = 5,
                CanInventory = true
            },

            new Treasure
            {
                Id = 23,
                Name = "Gold Necklace",
                LocationId = 9,
                XP = 15,
                Description = "A beautful necklace made from gold. Wore by the reach Anglo-Saxons.",
                Value = 40,
                Weight = 5,
                CanInventory = true
            },

            new Treasure
            {
                Id = 24,
                Name = "Tortoise Brooches",
                LocationId = 3,
                XP = 10,
                Description = "The name comes from their resmblance to the tortoise. Made from brass and bronze.",
                Value = 20,
                Weight = 8,
                CanInventory = true
            },

            new Treasure
            {
                Id = 25,
                Name = "Odin Pendant",
                LocationId = 8,
                XP = 25,
                Description = "Odin, known as the Norse All-Father. He sist astride his horse, Sleipnerm who carries souls to the \n" +
                "unseen realms. This gold pendant has an eye in the middle, it is the eye of Odin.",
                Value = 100,
                Weight = 10,
                CanInventory = true
            },

            new Treasure
            {
                Id = 26,
                Name = "Oseberg Earrings",
                LocationId = 2,
                XP = 10,
                Description = "A Viking doesn't wear any earrings, but earrings made out of silver made to represent the sea.",
                Value = 20,
                Weight = 5,
                CanInventory = true
            },

            new Treasure
            {
                Id = 27,
                Name = "Thor's Hammer Bronze",
                LocationId = 3,
                XP = 15,
                Description = "A unique and beautiful pendant representing the Hammer of Thor.",
                Value = 50,
                Weight = 10,
                CanInventory = true
            },

            new Treasure
            {
                Id = 28,
                Name = "Fylkirfold ring",
                LocationId = 1,
                XP = 10,
                Description = "Made out pewter and silver. With the name Fylkirfold carved into it.",
                Value = 20,
                Weight = 5,
                CanInventory = true
            },

            new Treasure
            {
                Id = 29,
                Name = "Valhalla Necklace",
                LocationId = 5,
                XP = 15,
                Description = "A heavy necklace made from gold, the name implies that you must be worthy of wearing it.",
                Value = 50,
                Weight = 10,
                CanInventory = true
            },
            
            new Treasure
            {
                Id = 30,
                Name = "Heart stone",
                LocationId = 2,
                XP = 10,
                Description = "A beautiful stone shaped like a heart.",
                Weight = 10,
                Value = 25,
                CanInventory = true
            },
            
            new Treasure
            {
                Id = 31,
                Name = "Silver plate",
                LocationId = 4,
                XP = 15,
                Description = "A large plate made of silver, it must be worth a pretty penny.",
                Weight = 15,
                Value = 80,
                CanInventory = true
            },

            new Treasure
            {
                Id = 32,
                Name = "Saxon gold ring",
                LocationId = 8,
                XP = 20,
                Description = "A beautiful fairly large gold ring made by Saxons.",
                Value = 25,
                Weight = 8,
                CanInventory = true
            },

            new Treasure
            {
                Id = 33,
                Name = "Ocean Pendant",
                LocationId = 6,
                XP = 10,
                Description = "This pendant i shaped like a wave, it is said that it brings you luck out on the open seas.",
                Value = 15,
                Weight = 10,
                CanInventory = true
            },
            
            #endregion

            #region Armour and Clothing (34-39)

            new Item
            {
                Id = 34,
                Name = "Leather Helmet",
                LocationId = 1,
                XP = 5,
                Description = "Made from sturdy leather, this helmet is lighter than steel, but not the most protective in battle.",
                Value = 10,
                Weight = 10,
                CanInventory = true,
                IsConsumable = false,
                Health = 0,
            },

            new Item
            {
                Id = 35,
                Name = "Coppergate Helmet",
                LocationId = 9,
                XP = 10,
                Description = "Also known as the York Helmet. This is an Anglo-Saxon crested helmet, richly decorated with brass ornamentation.",
                Value = 25,
                Weight = 15,
                CanInventory = true,
                IsConsumable = false,
                Health = 0,
            },

            new Item
            {
                Id = 36,
                Name = "Steel Helmet",
                LocationId = 0,
                XP = 10,
                Description = "Nicely decorated helmet made from steel. Great for battles, protects the nose and chin as well.",
                Value = 30,
                Weight = 15,
                CanInventory = true,
                IsConsumable = false,
                Health = 0,
            },


            new Item
            {
                Id = 37,
                Name = "Chainmill",
                LocationId = 7,
                XP = 5,
                Description = "Covers the upperbody, it's heavy, but it could save your life in battle.",
                Value = 15,
                Weight = 25,
                CanInventory = true,
                IsConsumable = false,
                Health = 0,
            },

            new Item
            {
                Id = 38,
                Name = "Battle Arm Braces",
                LocationId = 3,
                XP = 5,
                Description = "Worn in battles, these braces will make you look more fearsome.",
                Value = 5,
                Weight = 10,
                CanInventory = true,
                IsConsumable = false,
                Health = 0,
            },

            new Item
            {
                Id = 39,
                Name = "Leather Armour",
                XP = 15,
                LocationId = 1,
                Description = "Light armour made of leather.",
                Value = 10,
                Weight = 10,
                CanInventory = true,
                IsConsumable = false,
                Health = 0,
            },

            #endregion

            #region Food (40-47)
            
            new Item
            {
                Id = 40,
                Name = "Cod",
                LocationId = 5,
                XP = 5,
                Description = "A gift from the sea. Consume and iyt will give your strength and energy",
                Value = 10,
                Weight = 5,
                CanInventory = true,
                IsConsumable = true,
                Health = 10,
                Energy = 20
            },

            new Item
            {
                Id = 41,
                Name = "Mead",
                LocationId = 2,
                XP = 5,
                Description = "Drink to the gods.",
                Value = 0,
                Weight = 1,
                CanInventory = true,
                IsConsumable = true,
                Health = 5,
                Energy = 10,
            },

            new Item
            {
                Id = 42,
                Name = "Meat",
                XP = 5,
                LocationId = 5,
                Description = "",
                Value = 0,
                Weight = 2,
                CanInventory = true,
                IsConsumable = true,
                Health = 15,
                Energy = 20,
            },

            new Item
            {
                Id = 43,
                Name = "Fish",
                XP = 5,
                LocationId = 6,
                Description = "",
                Value = 0,
                Weight = 3,
                CanInventory = true,
                IsConsumable = true,
                Health = 10,
                Energy = 10,
            },

            new Item
            {
                Id = 44,
                Name = "Apple",
                XP = 5,
                LocationId = 8,
                Description = "",
                Value = 0,
                Weight = 1,
                CanInventory = true,
                IsConsumable = true,
                Health = 5,
                Energy = 10
            },

            new Item
            {
                Id = 45,
                Name = "Skyr",
                XP = 5,
                LocationId = 4,
                Description = "A soft, yoghurt-like cheese.",
                Value = 0,
                Weight = 1,
                CanInventory = true,
                IsConsumable = true,
                Health = 5
            },
            
            new Item
            {
                Id = 46,
                Name = "Mushroom mixture",
                LocationId = 2,
                XP = 20,
                Description = "A medicinal mixture crafted to heal",
                Value = 20,
                CanInventory = true,
                IsConsumable = true,
                Health = 80
            },

            new Item
            {
                Id = 47,
                Name = "Wonder of the earth",
                XP = 30,
                LocationId = 4,
                Description = "A liquid medicine, not quite sure who made it and out of what. But it's healing powers are real.",
                Value = 20,
                CanInventory = true,
                IsConsumable = true,
                Health = 75
            },
            
            #endregion

            #region Miscellaneous (48-50)

            new Item
            {
                Id = 48,
                Name = "Horn",
                LocationId = 2,
                XP = 0,
                Description = "This is a must have item for all Vikings. How else are you going to consume your mead?!",
                Value = 5,
                Weight = 5,
                CanInventory = true,
                IsConsumable = false,
                Health = 0
            },

            new Item
            {
                Id = 49,
                Name = "Dragon Tankard",
                LocationId = 3,
                XP = 10,
                Description = "Hold about 1 pint, this tankard has a sculpted dragon as a handle. Made fron pewter.",
                Value = 15,
                Weight = 5,
                CanInventory = true,
                IsConsumable = false,
                Health = 0
            },

            new Item
            {
                Id = 50,
                Name = "Comb",
                LocationId = 2,
                XP = 0,
                Description = "Comb made from animal bones.",
                Value = 5,
                Weight = 2,
                CanInventory = true,
                IsConsumable = false,
                Health = 0
            },

            #endregion

            #region Places (51-)

            //
            // Places in Kapuang
            //
            new Place
            {
                Id = 51,
                Name = "The Mead and Shield Tavern",
                LocationId = 1,
                Description = "Here you can eat and gain some strength",
                EntryMessage ="Welcome to The Mead and Shield Tavern. \n" +
                "Our mead is warm, the fish is fresh, and the people are in a festive mood. \n",
                CanInventory = false,
                Health = 10,
                XP = 0,
                EntryPoints = 0,
                CanRest = false,
                CanEeat = true,
                CanTrain = false
            },

            new Place
            {
                Id = 52,
                Name = "Magda's Inn",
                LocationId = 1,
                Description = "Magda's door is always open. Here you'll find the rest you need to continue your journey",
                EntryMessage = "Welcome to Magda's Inn \n" +
                "The bed is ready for you, lay down and get some rest before you continue your quest.",
                CanInventory = false,
                Health = 10,
                XP = 0,
                EntryPoints = 0,
                CanRest = true,
                CanEeat = false,
                CanTrain = false
            },

            //
            // Places in Storhamar
            //
            new Place
            {
                Id = 53,
                Name = "The Wood Hut",
                LocationId = 2,
                Description = "Come in to the Wood Hut and rest you weary bones.",
                EntryMessage ="Welcome to The Wood Hut \n" +
                "We don't get a lot of visitors here, but we started a fire for you. \n" +
                "You look like a warrior, go head, sleep wherever you like. \n" +
                "\n",
                CanInventory = false,
                Health = 0,
                XP = 0,
                EntryPoints = 0,
                CanRest = true,
                CanEeat = false,
                CanTrain = false
            },

            //
            // Places in Kungahälla
            //
            new Place
            {
                Id = 54,
                Name = "Bohus Fästning",
                LocationId = 3,
                Description = "Imporant Viking leaders gather at this fortress, you'll need to be experienced to enter here.",
                EntryMessage = "Welcome into Bohus Fästning \n" +
                "You must be important to have been granted entry to this strong fortress. \n" +
                "Please, help yourself to one of our rooms, and don't be shy, dine with us if you wish. \n" +
                "\n",
                CanInventory = false,
                Health = 50,
                XP = 50,
                EntryPoints = 300,
                CanRest = true,
                CanEeat = true,
                CanTrain = false
            },

            //
            // Places in Nidaros
            //
            new Place
            {
                Id = 55,
                Name = "The Oxe Cave",
                LocationId = 4,
                Description = "The Oxe Cave have the best meats in town. \n" +
                "But here you will also find some of the most feared vikings in the land.",
                EntryMessage = "Welcome in to the Oxe Cave \n +" +
                "Please, enjoy our meats. But be aware, not everyone in here is a friend. \n",
                CanInventory = false,
                Health = 30,
                XP = 15,
                EntryPoints = 20,
                CanRest = false,
                CanEeat = true,
                CanTrain = false
            },

            new Place
            {
                Id = 56,
                Name = "The Willow",
                LocationId = 4,
                Description = "Need some rest. The Willow can help with that",
                EntryMessage = "Welcome to the Willow \n" +
                "You look tired, why don't you get some rest in one of pur rooms. \n",
                CanInventory = false,
                Health = 0,
                XP = 0,
                EntryPoints = 0,
                CanRest = true,
                CanEeat = false,
                CanTrain = false
            },

            //
            // Places in Stavanger
            //
            new Place
            {
                Id = 57,
                Name = "The Seamonster Training Center",
                LocationId = 5,
                Description = "Come in a work on your seafaring skills. They may come in handy.",
                EntryMessage = "Welcome to the Seamonster Training Center \n " +
                "We will teach you all you need to know to travel the open seas. \n",
                CanInventory = false,
                Health = 0,
                XP = 30,
                EntryPoints = 0,
                CanRest = false,
                CanEeat = false,
                CanTrain = true
            },

            new Place
            {
                Id = 58,
                Name = "Fishy Tavern",
                LocationId = 5,
                Description = "Hungry? We serve fish and well...more fish",
                EntryMessage = "Welcome to the Fishy Tavern \n " +
                "Eat and be merry, hop you like fish. \n",
                CanInventory = false,
                Health = 25,
                XP = 0,
                EntryPoints = 0,
                CanRest = false,
                CanEeat = true,
                CanTrain = false
            },

            //
            // Places in Leirvik
            //
            
            new Place
            {
                Id = 59,
                Name = "Jarl Knut's hall",
                LocationId = 6,
                Description = "The Jarl of Leircik welcomes you to dine in his hall and get some rest",
                EntryMessage = "Welcome to Knut's Hall\n" +
                "Have some ale, it is freshly brewed. If you need rest, you are welcome to stay the night.",
                CanInventory = false,
                Health = 45,
                XP = 25,
                EntryPoints = 0,
                CanRest = true,
                CanEeat = true,
                CanTrain = true
            },

            //
            // Places in Lindisfarne
            //
            new Place
            {
                Id = 60,
                Name = "The Monk's monastery",
                LocationId = 7,
                Description = "A peacful place it once was, but now it is plagued by raids from the northmen.",
                EntryMessage = "Take a look a round, learn from the place. There are beds if you need rest.",
                CanInventory = false,
                Health = 0,
                XP = 45,
                EntryPoints = 0,
                CanRest = false,
                CanEeat = false,
                CanTrain = true
            },

            //
            // Places in Jorvik
            //
            new Place
            {
                Id = 61,
                Name = "Fortress of York",
                LocationId = 8,
                Description = "Captured by the Vikings, this magnificent fortress provides rest and a chance to work on your skills.",
                EntryMessage = "Welcome to the Fortress of York\n" +
                "Make yourself at home, there are lots to see here.",
                CanInventory = false,
                Health = 25,
                XP = 50,
                EntryPoints = 900,
                CanRest = true,
                CanEeat = true,
                CanTrain = true
            },

            //
            // Places in Norfolk
            //
            new Place
            {
                Id = 62,
                Name = "The Traveling Inn",
                LocationId = 9,
                Description = "Located at the edge of the village. A place to rest and eat.",
                EntryMessage = "Welcome to the Traveling Inn\n" +
                "We wish you no harm, please eat and drink. You are welcome to stay the night.",
                CanInventory = false,
                Health = 30,
                XP = 0,
                EntryPoints = 0,
                CanRest = true,
                CanEeat = true,
                CanTrain = false
            },

            #endregion

        };
    }
}
