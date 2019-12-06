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
            // testing adding a schedule to a project
            var sch = new Mock<Schedule>();
            sch.Setup(s => s.GetName()).Returns("schedulename");

            p.AddSchedule(sch.Object);
            Assert.AreEqual(p.GetSchedules()[0].GetName(), "schedulename");
            Assert.AreEqual(p.GetSchedules()[0], sch.Object);
        }
        
        // This tests adding multiple schedules to a project, and makes sure that they
        // are in the correct order
        [Test]
        public void TestAddMulipleSchedules()
        {
            var s1 = new Mock<Schedule>();
            var s2 = new Mock<Schedule>();
            var s3 = new Mock<Schedule>();

            s1.Setup(s => s.GetClient()).Returns("Trevor Collins");
            s2.Setup(s => s.GetClient()).Returns("Alfredo Diaz");
            s3.Setup(s => s.GetClient()).Returns("Fiona Nova");

            p.AddSchedule(s1.Object);
            p.AddSchedule(s2.Object);
            p.AddSchedule(s3.Object);

            Assert.AreEqual(p.GetSchedules()[0], s1.Object);
            Assert.AreEqual(p.GetSchedules()[1], s2.Object);
            Assert.AreEqual(p.GetSchedules()[2], s3.Object);
        }

        // This tests checks to see if we can remove a schedule successfully from a project
        [Test]
        public void TestRemoveSchedule()
        {
            // Testing that we can remove a schedule from a project
            var sch = new Mock<Schedule>();
            sch.Setup(s => s.GetClient()).Returns("Fiona Nova");

            p.AddSchedule(sch.Object);
            Assert.AreEqual(p.GetSchedules().Count, 1);

            p.RemoveSchedule(sch.Object);
            Assert.AreEqual(p.GetSchedules().Count, 0);
        }

        
        [Test]
        public void TestRemoveSchedulePosition()
        {
            // Test that, if we have three schedules and we move the one at index 1,
            // that the object at index 2 will move to index 1 after the removal
            // Makes sure the schedules keep their order
            var s1 = new Mock<Schedule>();
            var s2 = new Mock<Schedule>();
            var s3 = new Mock<Schedule>();

            s1.Setup(s => s.GetClient()).Returns("Trevor Collins");
            s2.Setup(s => s.GetClient()).Returns("Alfredo Diaz");
            s3.Setup(s => s.GetClient()).Returns("Fiona Nova");

            p.AddSchedule(s1.Object);
            p.AddSchedule(s2.Object);
            p.AddSchedule(s3.Object);

            List<Schedule> before = new List<Schedule>();
            before.AddRange(new List<Schedule>
            {
                s1.Object, s2.Object, s3.Object,
            });
            Assert.AreEqual(p.GetSchedules(), before);

            p.RemoveSchedule(s2.Object);

            List<Schedule> after = new List<Schedule>();
            after.AddRange(new List<Schedule>
            {
                s1.Object, s3.Object,
            });

            Assert.AreEqual(p.GetSchedules(), after);

        }
    
        // since there are two ways to remove schedules, by name and by project,
        // this tests that we can remove schedules by their names
        [Test]
        public void TestRemoveScheduleByName()
        {
            // would use mocking here as well
            var s1 = new Mock<Schedule>();
            s1.Setup(s => s.GetName()).Returns("newname");

            p.AddSchedule(s1.Object);
            Assert.AreEqual(p.GetSchedules().Count, 1);

            p.RemoveSchedule("fakename");
            Assert.AreEqual(p.GetSchedules().Count, 1);

            p.RemoveSchedule("newname");
            Assert.AreEqual(p.GetSchedules().Count, 0);

        }

        [Test]
        public void TestRemoveNonexistantSchedule()
        {
            var s1 = new Mock<Schedule>();
            var s2 = new Mock<Schedule>();
            var s3 = new Mock<Schedule>();

            s1.Setup(s => s.GetName()).Returns("first schedule");
            s2.Setup(s => s.GetName()).Returns("second schedule");
            s3.Setup(s => s.GetName()).Returns("third schedule");

            p.AddSchedule(s1.Object);


            // testing removing schedule that isn't in project doesn't crash, and that it returns false
            // this tests using a schedule as an argument
            Assert.DoesNotThrow(() => p.RemoveSchedule(s2.Object));
            Assert.IsFalse(p.RemoveSchedule(s2.Object));

            // these assertions do the same thing as above except tests the overloaded function using a schedule name as an argument
            Assert.DoesNotThrow(() => p.RemoveSchedule(s3.Object.GetName()));
            Assert.IsFalse(p.RemoveSchedule(s3.Object.GetName()));
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
