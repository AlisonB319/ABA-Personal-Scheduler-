﻿
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
        private Dictionary<string, User> _dataBase;

        public DataStore()
        {
            _dataBase = new Dictionary<string, User>();
        }

        public Dictionary<string, User> GetDataBase()
        {
            return this._dataBase;
        }

        public void SetDataBase(Dictionary<string, User> value)
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
            User userClass = this._dataBase[username];
            return userClass.AuthenticatePassword(password);
        }

        public User getAuthenticatedUser(string username, string password)
        {
            return (User)this._dataBase[username];
        }


    }
}
