
namespace ProjectPlanner.Classes
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class DataStore : IDataStore
    {
        private Hashtable _dataBase;

        public DataStore()
        {
            _dataBase = new Hashtable();
        }

        public Hashtable GetDataBase()
        {
            return this._dataBase;
        }

        public virtual void SetDataBase(Hashtable value)
        {
            this._dataBase = value;
        }

        public virtual User getUserFromDatabase(string username)
        {          
            return (User)this._dataBase[username];
        }

        public virtual void AddData(string username, User account)
        {
            this._dataBase.Add(username, account);
        }

        public virtual bool AuthenticateUsername(string username)
        {
            if (this._dataBase.ContainsKey(username))
            {
                return true;
            }
            return false;
        }

        public virtual bool AuthenticatePassword(string username, string password)
        {
            //test was not passing due to a lack of null check from the getUserFromDatabase return value
            bool result = false;
            User user;
            if((user = getUserFromDatabase(username)) == null)
            {
                return result;
            }
            else
                return user.AuthenticatePassword(password);
        }

        public User GetAuthenticatedUser(string username, string password)
        {
            return (User)this._dataBase[username];
        }


    }
}
