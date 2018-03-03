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
                Description = "The center for merchants and craftsmen.", // more description needed
                Accessable = true
            },

            new Location
            {
                LocationName = "Hamar",
                LocationId = 2,
                Description = "This place is cool.", // more description needed
                Accessable = true
            }
        };
    }
}
