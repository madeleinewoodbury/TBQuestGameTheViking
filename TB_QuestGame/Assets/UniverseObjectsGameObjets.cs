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

            new Weapon
            {
                Id = 2,
                Name = "Sword",
                LocationId = 2,
                Description = "This is a test for weapon objects",
                Value = 25,
                CanInventory = true
            },

            new Treasure
            {
                Id = 3,
                Name = "Gold Bar",
                LocationId = 4,
                Description = "This is a test for treasure item",
                Value = 50,
                CanInventory = true
            },

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

            new Weapon
            {
                Id = 5,
                Name = "Axe",
                LocationId = 2,
                Description = "Description Needed",
                Value = 25,
                CanInventory = true
            },

            new Weapon
            {
                Id = 6,
                Name = "Shield",
                LocationId = 2,
                Description = "Description Needed",
                Value = 20,
                CanInventory = true
            },

            new Weapon
            {
                Id = 7,
                Name = "Bow",
                LocationId = 2,
                Description = "Description Needed",
                Value = 25,
                CanInventory = true
            },

            new Weapon
            {
                Id = 8,
                Name = "Knife",
                LocationId = 2,
                Description = "Description Needed",
                Value = 10,
                CanInventory = true
            },



        };
    }
}
