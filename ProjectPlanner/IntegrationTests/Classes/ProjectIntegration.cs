using System;
using System.Collections.Generic;
using System.Text;
using Moq;

namespace IntegrationTests.Classes
{
    class ProjectIntegration
    {
        public void RunTests()
        {
            IntegrateViewSchedule();
            IntegrateRemoveSchedule();
            IntegrateRemoveSchedule2();
            IntegrateAddSchedule();
            IntegrateAddSchedule2();
        }

        public void IntegrateViewSchedule()
        {
            Project project = new Project();

            if (project.ViewScheduleInt())
            {
                Console.WriteLine("ViewSchedule Passed");

            }
            else
            {
                Console.WriteLine("ViewSchedule Failed");

            }
        }

        public void IntegrateRemoveSchedule()
        {
            Project project = new Project();

            var mSchedule = new Mock<ISchedule>();

            mSchedule.Object.SetName("test");

            project.AddSchedule(mSchedule.Object);

            mSchedule.Setup(m => m.GetName()).Returns("test");

            if (project.RemoveSchedule("test"))
            {
                Console.WriteLine("RemoveSchedule1: Passed");
            }
            else
            {
                Console.WriteLine("RemoveSchedule1: Failed");
            }

        }

        public void IntegrateRemoveSchedule2()
        {
            Project project = new Project();

            ISchedule schedule = new Schedule();

            schedule.SetName("test");

            project.AddSchedule(schedule);

            if (project.RemoveSchedule("test"))
            {
                Console.WriteLine("RemoveSchedule2: Passed");
            }
            else
            {
                Console.WriteLine("RemoveSchedule2: Failed");
            }

        }

        public void IntegrateAddSchedule()
        {
            Project project = new Project();

            var mSchedule = new Mock<ISchedule>();

            project.AddSchedule(mSchedule.Object);

            if (project.GetSchedules().Count == 1)
            {
                Console.WriteLine("AddSchedule1: Pass");
            }
            else
            {
                Console.WriteLine("AddSchedule1: Fail");
            }


        }

        public void IntegrateAddSchedule2() 
        {
            Project project = new Project();

            ISchedule schedule = new Schedule();

            project.AddSchedule(schedule);

            if (project.GetSchedules().Count == 1 && schedule.GetProject() == project)
            {
                Console.WriteLine("AddSchedule1: Pass");
            }
            else
            {
                Console.WriteLine("AddSchedule1: Fail");
            }
        }


    }
}
