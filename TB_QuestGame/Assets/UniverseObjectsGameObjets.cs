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
            #region Weapons

            new Weapon
            {
                Id = 01,
                Name = "Ulfberht Sword",
                LocationId = 2,
                Description = "Crafted by the Nordic smith named Ulfberht, this is one of the first all steel blades.",
                Value = 25,
                CanInventory = true
            },

            new Weapon
            {
                Id = 02,
                Name = "Stiklestad Viking Sword",
                LocationId = 0,
                Description = "This is a beautiful crafted sword. The pommel and guard are decorated with copper. \n" +
                "It is a heavy sword, but it can do a lot of damage.",
                Value = 40,
                CanInventory = true
            },

            new Weapon
            {
                Id = 03,
                Name = "Maldon Sword",
                LocationId = 0,
                Description = "This is a light, agile and resilient fighting blade. It is smaller than a regular sword, which makes \n" +
                "it great for fighting armed with a shield or an axe in the other hand.",
                Value = 30,
                CanInventory = true
            },

            new Weapon
            {
                Id = 04,
                Name = "Bearded Axe",
                LocationId = 0,
                Description = "This quite capable of cleaving helms or armours. Made from though steel, great for battles.",
                Value = 30,
                CanInventory = true
            },

            new Weapon
            {
                Id = 05,
                Name = "Double-Bladed Barbarian Battle Axe",
                LocationId = 0,
                Description = "This axe is meant only for the most ferocious and stout warriours.",
                Value = 50,
                CanInventory = true
            },

            new Weapon
            {
                Id = 06,
                Name = "Short Viking Axe",
                LocationId = 0,
                Description = "Shorter than most axes, this axe is great for throwing. Don't be fooled by it's length, \n" +
                "the shaft is sharp, and with great accuracy this could be the perfect battle weapon.",
                Value = 20,
                CanInventory = true
            },

            new Weapon
            {
                Id = 07,
                Name = "Norse Viking Shield",
                LocationId = 0,
                Description = "This is a common shield among the vikings. With it's thick plywood center and steel rim, \n" +
                "it is built to withstand the sharpest of blades.",
                Value = 20,
                CanInventory = true
            },

            new Weapon
            {
                Id = 08,
                Name = "Huskarl Shield",
                LocationId = 0,
                Description = "This is a sturdy Viking Shiels made out of red oak and plywood. It is lighter than most shields, \n" +
                "which makes it easier to move around in combat.",
                Value = 30,
                CanInventory = true
            },

            new Weapon
            {
                Id = 09,
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

            #region Treasure

            new Treasure
            {
                Id = 15,
                Name = "Gold Bar",
                LocationId = 4,
                Description = "This is a test for treasure item",
                Value = 50,
                CanInventory = true
            },

            #endregion

            #region Armour and Clothing

            new Item
            {
                Id = 4,
                Name = "Helmet",
                LocationId = 0,
                Description = "Protects the head",
                Value = 10,
                CanInventory = true,
                IsConsumable = false,
                Health = 0,
            },

            #endregion

            #region Miscellaneous

            new Item
            {
                Id = 1,
                Name = "Horn",
                LocationId = 1,
                Description = "This is a must have item for all Vikings. How else are you going to consume your mead?!",
                Value = 5,
                CanInventory = true,
                IsConsumable = false,
                Health = 0
            },

            #endregion

            #region Food

            #endregion

        };
    }
}
