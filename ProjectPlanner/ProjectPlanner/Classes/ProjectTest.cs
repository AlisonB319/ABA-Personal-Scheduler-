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
    class ProjectTest
    {
        [Test]
        public void TestAddSchedule() {
            Project project = new Project();
            var mocked = new Mock<Schedule>();
        }

    }
}
