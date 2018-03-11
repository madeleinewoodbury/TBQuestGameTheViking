using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// static class to hold all objects in the game universe
    /// </summary>
    public static class UniverseObjects
    {
        public static List<Location> Locations = new List<Location>()
        {
            new Location
            {
                LocationName = "Kaupang",
                LocationId = 1,
                Region = "Norge",
                Description = "Located in Sikringssal, this is the center for merchants and craftsmen. \n" +
                "An important trading post, here you can find anything from weapons to clothing. \n" +
                "Kaupang is located by the sea Norgeshav, from here you can venture out on the open sea \n" +
                "and explore new places.",
                ExperiencePoints = 0,
                AccessableLocations = new List<int>(){2,3,5,6,7,9}
            },


            new Location
            {
                LocationName = "Storhamar",
                LocationId = 2,
                Region = "Norge",
                Description = "Located in Hedmark, which mean the 'Heden Forest'. This place is surrounded by forest \n" +
                "and it is a great place for Viking settlements.",
                ExperiencePoints = 0,
                AccessableLocations = new List<int>(){1,3,4}
            },

            new Location
            {
                LocationName = "Kungahälla",
                LocationId = 3,
                Region = "Norge",
                Description = "Located in southern Bohuslän. This is a center for royal authority. \n" +
                "A good place to make connections. Located by the river Nordre älv, with access to Kattageat. \n" +
                "From here you can access the sea Norgeshav.",
                ExperiencePoints = 5,
                AccessableLocations = new List<int>(){1,2,5,6,7,9}
            },
            
            new Location
            {
                LocationName = "Nidaros",
                LocationId = 4,
                Region = "Norge",
                Description = "Located in Trøndelag, north in Norge. Formerly known as Kapuangen, this is an \n" +
                "important market place for vikings. There are also talks of this town to become the capital of \n" +
                "Norge.",
                ExperiencePoints = 5,
                AccessableLocations = new List<int>(){2,5}
            },

            new Location
            {
                LocationName = "Stavanger",
                LocationId = 5,
                Region = "Norge",
                Description = "Located on the West coast of Norge, with great access to the Atlantic oceans. \n" +
                "The Vikings that lives here are great seafarers and may a good resource to navigate the open seas.",
                ExperiencePoints = 10,
                AccessableLocations = new List<int>(){1,3,4,6,7,9}
            },

            new Location
            {
                LocationName = "Leirvik",
                LocationId = 6,
                Region = "Shetland",
                Description = "The main port of the Shetland Islands, located West of Norge and North-east of\n" +
                "England. The rugged and beautiful island is a great place to rest before venturing out on the \n" +
                "dangerous seas.",
                ExperiencePoints = 10,
                AccessableLocations = new List<int>(){1,3,5,7,9}
            },

            new Location
            {
                LocationName = "Lindisfarne",
                LocationId = 7,
                Region = "England",
                Description = "The Holy Island of Lindisfarne is located in the Kingdom called Northumbria in England. \n" +
                "This is said to be one of the first places that the Vikings raided in Anglo-Saxon England.",
                ExperiencePoints = 15,
                AccessableLocations = new List<int>(){1,3,5,6,8,9}
            },

            new Location
            {
                LocationName = "Jorvik",
                LocationId = 8,
                Region = "England",
                Description = "Also known as York, is the capital of Northumbria. The Great Heathen Army captured York\n" +
                "and currently hold the city. Many Vikings are settling in Jorvik, but the Anglo-Saxons could try to take it" +
                "back.",
                ExperiencePoints = 20,
                AccessableLocations = new List<int>(){7,9}
            },

            new Location
            {
                LocationName = "Norfolk",
                LocationId = 9,
                Region = "England",
                Description = "Located in East Anglia, which is under the rule of King Edumund. The English army is \n" +
                "prepared for battle as the Vikings have their eye on the Kingdom.",
                ExperiencePoints = 15,
                AccessableLocations = new List<int>(){1,3,5,6,7,8}
            }

        };
    }
}
