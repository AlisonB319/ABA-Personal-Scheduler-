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

        Project p;

        [SetUp]
        public void SetUp()
        {
            p = new Project();
        }

        [TearDown]
        public void TearDown()
        {
            p = null;
        }
        [Test]
        public void TestAddSchedule() {
            // Would do mocking here, although none of the mocking frameworks in C# allow you to mock concrete classes, only interfaces
            // Below is what I tried to do, but the Moq framework doesn't allow it
            /* var mocked = new Mock<Schedule>();
            mocked.Setup(schedule => schedule.GetName()).Returns("scheduleName");
            p.AddSchedule(mocked.Object);
            Assert.That(p.GetSchedules()[0].GetName(), Is.EqualTo("scheduleName"));
            */
            Schedule schedule = new Schedule();
            schedule.SetName("schedulename");
            p.AddSchedule(schedule);

            // checks to see if the schedule was actually added to the project
            Assert.That(p.GetSchedules()[0].GetName(), Is.EqualTo("schedulename"));
            Assert.That(p.GetSchedules()[0], Is.EqualTo(schedule));
        }
        
        // This tests adding multiple schedules to a project, and makes sure that they
        // are in the correct order
        [Test]
        public void TestAddMulipleSchedules()
        {
            // Again, would do mocking here for multiple schedules, but we can't C# and concrete classes
            Schedule s1 = new Schedule();
            Schedule s2 = new Schedule();
            Schedule s3 = new Schedule();

            s1.SetClient("Trevor Collins");
            s2.SetClient("Alfredo Diaz");
            s3.SetClient("Fiona Nova");

            p.AddSchedule(s1);
            p.AddSchedule(s2);
            p.AddSchedule(s3);

            Assert.AreEqual(p.GetSchedules()[0], s1);
            Assert.AreEqual(p.GetSchedules()[1], s2);
            Assert.AreEqual(p.GetSchedules()[2], s3);
        }

        // This tests checks to see if we can remove a schedule successfully from a project
        [Test]
        public void TestRemoveSchedule()
        {
            // Testing that we can remove a schedule from a project
            Schedule s = new Schedule();

            s.SetClient("Fiona Nova");

            p.AddSchedule(s);
            Assert.AreEqual(p.GetSchedules().Count, 1);

            p.RemoveSchedule(s);
            Assert.AreEqual(p.GetSchedules().Count, 0);
        }

        
        [Test]
        public void TestRemoveSchedulePosition()
        {
            // Test that, if we have three schedules and we move the one at index 1,
            // that the object at index 2 will move to index 1 after the removal
            // Makes sure the schedules keep their order
            Schedule s1 = new Schedule();
            Schedule s2 = new Schedule();
            Schedule s3 = new Schedule();

            s1.SetClient("Gavin Free");
            s2.SetClient("Alfredo Diaz");
            s3.SetClient("Fiona Nova");

            p.AddSchedule(s1);
            p.AddSchedule(s2);
            p.AddSchedule(s3);

            List<Schedule> before = new List<Schedule>();
            before.AddRange(new List<Schedule>
            {
                s1, s2, s3,
            });
            Assert.AreEqual(p.GetSchedules(), before);

            p.RemoveSchedule(s2);

            List<Schedule> after = new List<Schedule>();
            after.AddRange(new List<Schedule>
            {
                s1, s3,
            });

            Assert.AreEqual(p.GetSchedules(), after);

        }
    
        // since there are two ways to remove schedules, by name and by project,
        // this tests that we can remove schedules by their names
        [Test]
        public void TestRemoveScheduleByName()
        {
            // would use mocking here as well
            Schedule s = new Schedule();
            s.SetName("newname");

            p.AddSchedule(s);

            Assert.AreEqual(p.GetSchedules().Count, 1);

            p.RemoveSchedule("newname");
            Assert.AreEqual(p.GetSchedules().Count, 0);

        }

        [Test]
        public void TestRemoveNonexistantSchedule()
        {
            // would use mocking here
            Schedule s1 = new Schedule();
            Schedule s2 = new Schedule();
            Schedule s3 = new Schedule();

            s1.SetName("first schedule");
            s2.SetName("second schedule");
            s3.SetName("third schedule");

            p.AddSchedule(s1);


            // testing removing schedule that isn't in project doesn't crash, and that it returns false
            // this tests using a schedule as an argument
            Assert.DoesNotThrow(() => p.RemoveSchedule(s2));
            Assert.IsFalse(p.RemoveSchedule(s2));

            // these assertions do the same thing as above except tests the overloaded function using a schedule name as an argument
            Assert.DoesNotThrow(() => p.RemoveSchedule(s3.GetName()));
            Assert.IsFalse(p.RemoveSchedule(s3.GetName()));
        }

        //[Test]
        //public void TestEndDateBeforeStart()
        //{
        //    // tests that, when setting the end date, it can't be before the start date.
        //    // WARNING must uncomment thrown exception in code for this to run
        //    DateTime.TryParse("10-10-2000", out DateTime start);
        //    p.SetStartDate(start);
        //    DateTime.TryParse("09-10-2000", out DateTime end);
        //    var ex = Assert.Throws<System.ArgumentException>(() => p.SetEndDate(end));
        //    Assert.AreEqual(ex.Message, "end date cannot be before start date");

        //}

        //[Test]
        //public void TestEndAfterStart()
        //{
        //    // tests that and end date can be set when it's after the start date
        //    // WARNING must uncomment thrown exception in code for this to run

        //    DateTime.TryParse("10-10-1000", out DateTime start);
        //    p.SetStartDate(start);
        //    DateTime.TryParse("10-10-2000", out DateTime end);

        //    Assert.DoesNotThrow(() => p.SetEndDate(end));
        //}

    }
}
