using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace ProjectPlanner.Classes
{
    [TestFixture]
    class ScheduleTest
    {
        Schedule schedule;

        [SetUp]
        public void SetUp()
        {
            schedule = new Schedule();
        }

        [TearDown]
        public void TearDown()
        {
            schedule = null;
        }

        [Test]
        public void CreateSchedule()
        {
            Assert.IsNotNull(schedu);
        }
    }
}
