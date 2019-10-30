﻿
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
        private Hashtable _dataBase;

        public DataStore()
        {
            _dataBase = new Hashtable();
        }

        public Hashtable GetDataBase()
        {
            return this._dataBase;
        }

        public void SetDataBase(Hashtable value)
        {
            this._dataBase = value;
        }

        public User getUserFromDatabase(string username)
        {          
            return (User)this._dataBase[username];
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
