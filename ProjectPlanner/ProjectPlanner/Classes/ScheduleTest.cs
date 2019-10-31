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
            string sprojStart, scheduleStart, sprojEnd, scheduleEnd;

            sprojStart = "01/01/2000";
            sprojEnd = "12/31/2020";

            DateTime.TryParse(sprojStart, out DateTime projStart);
            DateTime.TryParse(sprojEnd, out DateTime projEnd);

            scheduleStart = "05/05/2010";
            scheduleEnd = "10/10/2012";

            bool start = schedule.CheckDates(projStart, scheduleStart, true);
            bool end = schedule.CheckDates(projEnd, scheduleEnd, false);

            Assert.IsTrue(start);
            Assert.IsTrue(end);

            scheduleStart = "12/31/1999";
            scheduleEnd = "01/01/2021";

            start = schedule.CheckDates(projStart, scheduleStart, true);
            end = schedule.CheckDates(projEnd, scheduleEnd, false);

            Assert.IsFalse(start);
            Assert.IsFalse(end);

        }
    }
}
