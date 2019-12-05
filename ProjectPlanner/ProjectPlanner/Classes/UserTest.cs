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
        User TestUser;

        [SetUp]
        public void SetUp()
        {
            TestUser = new User();
        }

        [TearDown]
        public void TearDown()
        {
            TestUser = null;
        }

        [Test]
        public void TestAuthenticatePassword()
        {
            //check against an unset password
            Assert.That(TestUser.AuthenticatePassword("test"), Is.EqualTo(false));

            TestUser.SetPassword("test");

            //check against a set password but wrongly
            Assert.That(TestUser.AuthenticatePassword("test2"), Is.EqualTo(false));
            //check with an empty string
            Assert.That(TestUser.AuthenticatePassword(""), Is.EqualTo(false));
            //check with correct password
            Assert.That(TestUser.AuthenticatePassword("test"), Is.EqualTo(true));
        }

        [Test]
        public void TestRemoveProject()
        {
            string name = "test";
            string name2 = "test2";
            
            // mock the project class so that we don't have to worry about implementation 
            var proj = new Mock<Project>();
            proj.Setup(p => p.GetName()).Returns(name2);

            //Check that an empty project list acts appropriately
            Assert.That(TestUser.RemoveProject(name), Is.EqualTo(false));
            TestUser.AddProject(proj.Object);
            //Check that and improper remove call will not remove the wrong item
            Assert.That(TestUser.RemoveProject(name), Is.EqualTo(false));
            //check that we can remove the item that we added to the datastore
            Assert.That(TestUser.RemoveProject(name2), Is.EqualTo(true));
        }

        [Test]
        public void TestGetProject()
        {
            string name = "test";
            string name2 = "test2";

            // Mocking the Project object
            var proj = new Mock<Project>();
            proj.Setup(p => p.GetName()).Returns(name2);

            //Check that an empty project list acts appropriately
            Assert.That(TestUser.GetProject(name), Is.EqualTo(null));
            TestUser.AddProject(proj.Object);
            //Check that and improper remove call will not remove the wrong item
            Assert.That(TestUser.GetProject(name), Is.EqualTo(null));
            //check that we can remove the item that we added to the datastore
            Assert.That(TestUser.GetProject(name2), Is.EqualTo(proj.Object));
        }

        [Test]
        public void TestEditProject()
        {
            // Mocking the Project object
            /*
             * This mocks the process of creating a project and then mocking the 
             * the entire project once
             */
            var project = new Mock<Project>();
            var cons = new Mock<IConsole>();

            cons.Setup(c => c.WriteLine((It.IsAny<string>())));

            project.Setup(pro => pro.SetName(It.IsAny<string>())); 
            project.Setup(pro => pro.SetDescription(It.IsAny<string>()));
            project.Setup(pro => pro.SetStartDate(It.IsAny<DateTime>()));
            project.Setup(pro => pro.SetEndDate(It.IsAny<DateTime>()));

            TestUser.EditProject(project.Object, 1, cons.Object);
            TestUser.EditProject(project.Object, 2, cons.Object);
            TestUser.EditProject(project.Object, 3, cons.Object);
            TestUser.EditProject(project.Object, 4, cons.Object);

            project.Verify(mock => mock.SetName(It.IsAny<string>()), Times.Once());
            project.Verify(mock => mock.SetDescription(It.IsAny<string>()), Times.Once());
            project.Verify(mock => mock.SetStartDate(It.IsAny<DateTime>()), Times.Once());
            project.Verify(mock => mock.SetEndDate(It.IsAny<DateTime>()), Times.Once());

            TestUser.EditProject(project.Object, 1, cons.Object);
            TestUser.EditProject(project.Object, 2, cons.Object);
            TestUser.EditProject(project.Object, 3, cons.Object);
            TestUser.EditProject(project.Object, 4, cons.Object);
        }
    }
}
