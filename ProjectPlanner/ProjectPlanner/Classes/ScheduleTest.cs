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
            // would mock a project, but I cannot since C# does not have mocking

            Assert.IsNotNull(schedule);
        }

        [Test]
        public void CheckTime()
        {
            DateTime.TryParse("01/01/2000", out DateTime projStart);
            DateTime.TryParse("12/31/2020", out DateTime projEnd);

            bool start = schedule.CheckDates(projStart, "10/10/2012", true);
            bool end = schedule.CheckDates(projEnd, "10/10/2012", false);

            Assert.IsTrue(start);
            Assert.IsTrue(end);

            start = schedule.CheckDates(projStart, "12/31/1999", true);
            end = schedule.CheckDates(projEnd, "01/01/2021", false);

            Assert.IsFalse(start);
            Assert.IsFalse(end);
        }
    }
}
