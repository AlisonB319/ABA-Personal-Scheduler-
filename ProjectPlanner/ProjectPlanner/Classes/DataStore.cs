namespace ProjectPlanner.Classes
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DataStore
    {
        private Hashtable dataBase;

        public DataStore()
        {
            this.SetDataBase(new Hashtable());
        }

        public Hashtable GetDataBase()
        {
            return this.dataBase;
        }

        public void SetDataBase(Hashtable value)
        {
            this.dataBase = value;
        }
    }
}
