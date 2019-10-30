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
            // Would do mocking here, although none of the mocking frameworks in C# allow you to mock concrete classes, only interfaces
            // Below is what I tried to do, but the Moq framework doesn't allow it
            /* var mocked = new Mock<Schedule>();
            mocked.Setup(schedule => schedule.GetName()).Returns("scheduleName");
            project.AddSchedule(mocked.Object);
            Assert.That(project.GetSchedules()[0].GetName(), Is.EqualTo("scheduleName"));
            */
            Schedule schedule = new Schedule();
            schedule.SetName("schedulename");
            project.AddSchedule(schedule);
            Assert.That(project.GetSchedules()[0].GetName(), Is.EqualTo("schedulename"));
            Assert.That(project.GetSchedules()[0], Is.EqualTo(schedule));
        }

        [Test]
        public void TestAddMulipleSchedules()
        {
            Project project = new Project();
            // Again, would do mocking here for multiple schedules, but we can't C# and concrete classes
            Schedule s1 = new Schedule();
            Schedule s2 = new Schedule();
            Schedule s3 = new Schedule();

            s1.SetClient("Trevor Collins");
            s2.SetClient("Alfredo Diaz");
            s3.SetClient("Fiona Nova");

            project.AddSchedule(s1);
            project.AddSchedule(s2);
            project.AddSchedule(s3);

            Assert.AreEqual(project.GetSchedules()[0], s1);
            Assert.AreEqual(project.GetSchedules()[1], s2);
            Assert.AreEqual(project.GetSchedules()[2], s3);
        }

        [Test]
        public void TestRemoveSchedule()
        {
            // Testing that we can remove a schedule from a project
            Project project = new Project();
            Schedule s = new Schedule();

            s.SetClient("Fiona Nova");

            project.AddSchedule(s);
            Assert.AreEqual(project.GetSchedules().Count, 1);

            project.RemoveSchedule(s);
            Assert.AreEqual(project.GetSchedules().Count, 0);
        }

        [Test]
        public void TestRemoveSchedulePosition()
        {
            // Test that, if we have three schedules and we move the one at index 1,
            // that the object at index 2 will move to index 1 after the removal
            Project p = new Project();
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

        [Test]
        public void TestRemoveScheduleByName()
        {
            Project p = new Project();
            // would use mocking here as well
            Schedule s = new Schedule();
            s.SetName("newname");

            p.AddSchedule(s);

            Assert.AreEqual(p.GetSchedules().Count, 1);

            p.RemoveSchedule("newname");
            Assert.AreEqual(p.GetSchedules().Count, 0);

        }

    }
}
