using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using NSubstitute;
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


            /*
             * This is how mocking should work if the mocking of concrete classes was supported by 
             * The mocking frameworks for C#
            */
            //var user = new Mock<User>();
            //var dataStore = new Mock<DataStore>(NewDataStore);

            //user.Setup(m => m.AuthenticatePassword("test")).Returns(true);
            //dataStore.Setup(foo => foo.getUserFromDatabase(It.IsAny<String>())).Returns(user);
            User NewUser = new User();
            NewUser.CreateUser("test", "user", "thisisnotanemail@email.com", "test");


            hashtable.Add("test", NewUser);
            NewDataStore.SetDataBase(hashtable);

            //Check that a user that is in the database connot be incorrectly authenticated
            Assert.That(NewDataStore.AuthenticatePassword("test", "test"), Is.EqualTo(true));
            //check that a user in the database can be successfully authenticated
            Assert.That(NewDataStore.AuthenticatePassword("test", "test"), Is.EqualTo(true));
            //Check that a user not in the database will not be authenticated
            Assert.That(NewDataStore.AuthenticatePassword("test2", "test"), Is.EqualTo(false));

            //In mocking we could use this to verify that the user classes AuthenticatePassword was calle dthe appropriate amount of times.
            //user.Verify(mock => mock.AuthenticatePassword("test"), Times.Tree());
        }

    }
}
