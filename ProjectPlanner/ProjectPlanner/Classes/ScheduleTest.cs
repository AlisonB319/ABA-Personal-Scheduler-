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

        [Test]
        public void UpdateTotalHoursTest()
        {
            int needed = 43, worked = 12;

            schedule.SetHoursNeeded(needed.ToString());
            schedule.SetHoursWorked(worked.ToString());
            schedule.UpdateTotalHours();

            Assert.AreEqual(schedule.GetTotalHours(), needed + worked);
        }

        [Test]
        public void UpdatePercentCompleteTest()
        {
            float worked = (float)264.3, total = 665;
            schedule.SetHoursWorked(worked.ToString());
            schedule.SetTotalHours(total.ToString());

            schedule.UpdatePercentComplete();
            Assert.AreEqual(schedule.GetPercentComplete(), worked / total);

            // Test to make sure total isn't 0 before function is called. Checks for divide by 0 error

            schedule.SetTotalHours(0.ToString());
            Console.WriteLine("{0} / {1}", schedule.GetHoursWorked(), schedule.GetTotalHours());
            schedule.UpdatePercentComplete();

            Assert.AreEqual(schedule.GetPercentComplete(), 0);
        }
    }
}
