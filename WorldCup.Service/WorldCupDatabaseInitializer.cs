using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCup.Data;

namespace WorldCup.Service
{
    public class WorldCupDatabaseInitializer
    {
        public static void InitDb()
        {
            WorldCupDataInitializer.InitDb();
        }
    }
}
