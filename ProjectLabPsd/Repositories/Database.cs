using ProjectLabPsd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectLabPsd.Repositories
{
    public class Database
    {
        private static KpopZtationEntities6 db = null;

        private Database() { }

        public static KpopZtationEntities6 getDb()
        {
            if(db == null)
            {
                db = new KpopZtationEntities6 ();
            }
            return db;
        }
    }
}