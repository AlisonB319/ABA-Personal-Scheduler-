using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using System.Collections;
using System.Xml.Linq;


namespace ProjectPlanner.Classes
{
    [TestFixture]
    class DataStoreTest
    {
        [Test]
        public void TestAuthenticateUsername()
        {
            DataStore dataStore = new DataStore();
            Hashtable hashtable = new Hashtable();
            
            dataStore.SetDataBase(hashtable);

            //check that our database is in fact empty to start
            Assert.That(dataStore.AuthenticateUsername("test2"), Is.EqualTo(false));

            User user = new User();
            hashtable.Add("test", user);

            //check that we can successfully see a user in the hashtable
            Assert.That(dataStore.AuthenticateUsername("test"), Is.EqualTo(true));

            //check that we cannot see users not in the hashtable
            Assert.That(dataStore.AuthenticateUsername("test2"), Is.EqualTo(false));


        }

        [Test]
        public void TestAuthenticatePassword()
        {
            DataStore NewDataStore = new DataStore();
            Hashtable hashtable = new Hashtable();
            var user = new Mock<User>();
            var dataStore = new Mock<DataStore>(NewDataStore);

            dataStore.Setup(foo => foo.getUserFromDatabase(It.IsAny<String>())).Returns(user);
            user.Setup(foo => foo.AuthenticatePassword(It.IsAny<String>())).Returns(true);

            hashtable.Add("test", user);
            NewDataStore.SetDataBase(hashtable);

            

            Assert.That(NewDataStore.AuthenticatePassword("test", "test"), Is.EqualTo(true));
            Assert.That(NewDataStore.AuthenticatePassword("test2", "test"), Is.EqualTo(false));


        }

    }
}
