using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using System.Collections;


namespace ProjectPlanner.Classes
{
    [TestFixture]
    class DataStoreTest
    {
        [Test]
        public void TestAuthenticateUsername()
        {
            DataStore dataStore = new DataStore();
            Dictionary<string, User> hashtable = new Dictionary<string, User>();
            User newUser = new User();
            var user = new Mock<User>(newUser);
            hashtable.Add("test", user);
            dataStore.SetDataBase(hashtable);
            
            //ds.Setup(foo => foo.AddData(It.IsAny<String>(), user));

            Assert.That(dataStore.AuthenticateUsername("test"), Is.EqualTo(true));
            Assert.That(dataStore.AuthenticateUsername("test2"), Is.EqualTo(false));

            
        }

        [Test]
        public void TestAuthenticatePassword()
        {
            DataStore dataStore = new DataStore();
            Dictionary<string, User> hashtable = new Dictionary<string, User>();
            User newUser = new User();
            var user = new Mock<User>(newUser);

            user.Setup(m => m.AuthenticatePassword(It.IsAny<String>())).Returns(true);

            hashtable.Add("test", user);
            dataStore.SetDataBase(hashtable);

            

            Assert.That(dataStore.AuthenticatePassword("test", "test"), Is.EqualTo(true));
            Assert.That(dataStore.AuthenticatePassword("test2", "test"), Is.EqualTo(false));


        }

    }
}
