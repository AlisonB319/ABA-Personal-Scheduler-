using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ProjectPlanner.Classes
{
    interface IDataStore
    {
        Hashtable GetDataBase();


        void SetDataBase(Hashtable value);


        User getUserFromDatabase(string username);


        void AddData(string username, User account);


        bool AuthenticateUsername(string username);


        bool AuthenticatePassword(string username, string password);


        User GetAuthenticatedUser(string username, string password);
        

    }
}
