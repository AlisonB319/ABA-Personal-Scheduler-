using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;

namespace ProjectPlanner.Classes
{
    [TestFixture]
    class UserTest
    {
        [Test]
        public void TestAuthenticatePassword()
        {

            User user = new User();

            //check against an unset password
            Assert.That(user.AuthenticatePassword("test"), Is.EqualTo(false));

            user.SetPassword("test");

            //check against a set password but wrongly
            Assert.That(user.AuthenticatePassword("test2"), Is.EqualTo(false));

            //check with an empty string
            Assert.That(user.AuthenticatePassword(""), Is.EqualTo(false));

            //check with correct password
            Assert.That(user.AuthenticatePassword("test"), Is.EqualTo(true));




        }
    }
}
