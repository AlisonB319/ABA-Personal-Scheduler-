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
            //Ideally the project class would be mocked so that its implementations do not affect our test
            Project NewProject = new Project();
            string name = "test";
            string name2 = "test2";
            //example of mocking implementation
            //var project = new Mock<NewProject>();
            //project.Setup(m => m.GetName()).Returns(<A concrete string or matchers>);

            NewProject.SetName(name2);

            //Check that an empty project list acts appropriately
            Assert.That(TestUser.RemoveProject(name), Is.EqualTo(false));

            TestUser.AddProject(NewProject);

            //Check that and improper remove call will not remove the wrong item
            Assert.That(TestUser.RemoveProject(name), Is.EqualTo(false));

            //check that we can remove the item that we added to the datastore
            Assert.That(TestUser.RemoveProject(name2), Is.EqualTo(true));

        }

        [Test]
        public void TestGetProject()
        {
            //Ideally the project class would be mocked so that its implementations do not affect our test
            Project NewProject = new Project();
            string name = "test";
            string name2 = "test2";
            //example of mocking implementation
            //var project = new Mock<NewProject>();
            //project.Setup(m => m.GetName()).Returns(Project);

            NewProject.SetName(name2);

            //Check that an empty project list acts appropriately
            Assert.That(TestUser.GetProject(name), Is.EqualTo(null));

            TestUser.AddProject(NewProject);

            //Check that and improper remove call will not remove the wrong item
            Assert.That(TestUser.GetProject(name), Is.EqualTo(null));

            //check that we can remove the item that we added to the datastore
            Assert.That(TestUser.GetProject(name2), Is.EqualTo(NewProject));
        }

        [Test]
        public void TestEditProject()
        {
            /*
             * This test can only be run with the ability to properly mock objects.
             * Edit project is a switch statement so we want to make sure that we can successfully
             * touch all code  paths in the switch statement and execute all of the respective functions 
             * in the switch statements
             * 
             * To do this we can mock the project that is input to the user and keep track of the calls
             * on each of the set functions that are used in the edit function. All of these functions
             * are mocked so that they do not do anything other than receive a function call.
             * 
             * 
             * 
            Project NewProject = new Project();
            string name = "test";
            string name2 = "test2";

            var project = new Mock<Project>(NewProject);

            project.Setup(mock => mock.SetName());
            project.Setup(mock => mock.SetDescription());
            project.Setup(mock => mock.SetStartDate());
            project.Setup(mock => mock.SetEndDate());

            TestUser.EditProject(project, 1);
            TestUser.EditProject(project, 2);
            TestUser.EditProject(project, 3);
            TestUser.EditProject(project, 4);

            project.Verify(mock => mock.SetName(It.IsAny(string), Times.Once());
            project.Verify(mock => mock.SetDescription(It.IsAny(string), Times.Once());
            project.Verify(mock => mock.SetStartDate(It.IsAny(string), Times.Once());
            project.Verify(mock => mock.SetEndDate(It.IsAny(string), Times.Once());


            */
        }
    }
}
