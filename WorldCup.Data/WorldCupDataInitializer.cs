using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldCup.Data
{
    public static class WorldCupDataInitializer
    {
        public static void InitDb()
        {
            Database.SetInitializer(new WorldCupDbInitializer());
        }
    }
}
