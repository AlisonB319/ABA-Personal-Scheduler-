
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
        public void AddData(string username, User account)
        {
            this._dataBase.Add(username, account);
        }
        public bool AuthenticateUsername(string username)
        {
            if (this._dataBase.ContainsKey(username))
            {
                return true;
            }
            return false;
        }
        public bool AuthenticatePassword(string username, string password)
        {
            User userClass = (User)this._dataBase[username];
            return userClass.authenticatePassword(password);
        }
    }
}
