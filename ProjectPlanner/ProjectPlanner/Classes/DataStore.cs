
namespace ProjectPlanner.Classes
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class DataStore
    {
        private Hashtable _dataBase;

        public DataStore()
        {
            this.SetDataBase(new Hashtable());
        }
        public Hashtable GetDataBase()
        {
            return this._dataBase;
        }
        public void SetDataBase(Hashtable value)
        {
            this._dataBase = value;
        }
        public void AddData(string username, string password)
        {
            this._dataBase.Add(username, password);
        }
    }
}
