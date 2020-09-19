using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;
using VideoGameOrderingSystem.Data.Models;

namespace VideoGameOrderingSystem.Data.Database
{
    class DatabaseContext
    {
        public LiteDatabase database = new LiteDatabase(@"D:\Developer\C#\VideoGameOrderingSystem\VideoGameOrderingSystem\VideoGameOrderingSystem.Data\Database\Main.db");
    }
}
