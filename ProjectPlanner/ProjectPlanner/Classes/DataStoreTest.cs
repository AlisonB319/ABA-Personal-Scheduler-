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
            // mock the user object to simulate what would in the actual code
            var user = new Mock<User>();
            var dataStore = new DataStore();

            user.Setup(u => u.Getemail()).Returns("fname");
            dataStore.AddData(user.Object.Getemail(), user.Object);

            Assert.IsTrue(dataStore.AuthenticateUsername("fname"));
            Assert.IsFalse(dataStore.AuthenticateUsername("fakeout"));
        }

        [Test]
        public void TestAuthenticatePassword()
        {
            var user = new Mock<User>();
            var dataStore = new DataStore();

            user.Setup(u => u.AuthenticatePassword("passwd")).Returns(true);
            dataStore.AddData("username", user.Object);

            // make sure to authenticate the username correctly
            Assert.IsTrue(dataStore.AuthenticatePassword("username", "passwd"));
            Assert.IsFalse(dataStore.AuthenticatePassword("username", "fakepass"));
        }
    }
}