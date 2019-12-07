using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using System.Collections;

namespace IntegrationTests.Classes
{
    class DataStoreIntegration
    {
        public void RunTests()
        {
            TestAuthenticatePassword1();
        }

        public void TestAuthenticatePassword1()
        {
            DataStore dataStore = new DataStore();
            var mDataStore = new Mock<DataStore>(dataStore);

            var user = new Mock<User>();

            user.Object.CreateUser("test", "test", "test@email.com", "pass");

            Hashtable hashtable = new Hashtable();

            hashtable.Add("test@email.com", user.Object);
            dataStore.SetDataBase(hashtable);

            user.Setup(m => m.AuthenticatePassword("pass")).Returns(true);

            if(dataStore.AuthenticatePassword("test@email.com", "pass"))
            {
                Console.WriteLine("AuthenticatePassword1 Passed");
            }
            else
            {
                Console.WriteLine("AuthenticatePassword1 Failed: unable to authenticate");
            }

        }

    }
}
