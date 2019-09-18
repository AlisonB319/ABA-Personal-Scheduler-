using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ProjectPlanner.Classes
{
    class DataStore
    {
        private Hashtable dataBase;

        public DataStore()
        {
            SetDataBase(new Hashtable());
        }
        public Hashtable GetDataBase()
        {
            return dataBase;
        }

        public void SetDataBase(Hashtable value)
        {
            dataBase = value;
        }
    }
}
