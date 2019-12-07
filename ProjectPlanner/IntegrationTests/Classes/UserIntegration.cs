using System;
using System.Collections.Generic;
using System.Text;
using Moq;

namespace IntegrationTests.Classes
{
    class UserIntegration
    {
        public void RunTests()
        {
            TestGetProject();
            TestRemoveProject();
            //TestEditProject();
        }

        public void TestGetProject()
        {
            User user = new User(); // constructor is trivial so we don't test it
            var mProject1 = new Mock<Project>();
            var mProject2 = new Mock<Project>();
            var mProject3 = new Mock<Project>();
            var mProject4 = new Mock<Project>();

            mProject1.Setup(m => m.GetName()).Returns("projName1");
            mProject2.Setup(m => m.GetName()).Returns("projName2");
            mProject3.Setup(m => m.GetName()).Returns("projName3");
            mProject4.Setup(m => m.GetName()).Returns("projName4");

            user.AddProject(mProject1.Object);
            user.AddProject(mProject2.Object);
            user.AddProject(mProject3.Object);
            user.AddProject(mProject4.Object);

            var tempProject = user.GetProject("projName2");
            if (tempProject == mProject2.Object)
            {
                Console.WriteLine("GetProject Succeeded");
            } else
            {
                Console.WriteLine("GetProject Failed");
            }
            if (tempProject == mProject1.Object || tempProject == mProject3.Object || tempProject ==  mProject4.Object) // double checking moq project doesn't equate to different projects
            {
                Console.WriteLine("GetProject got wrong project");
            }

            tempProject = user.GetProject("projName4");
            if (tempProject == mProject4.Object)
            {
                Console.WriteLine("GetProject succeeded");
            }
            else
            {
                Console.WriteLine("GetProject failed");
            }

            tempProject = user.GetProject("fakename");
            if (tempProject != null)
            {
                Console.WriteLine("GetProject should have returned null since project didn't exist, but it didn't");
            }
            else
            {
                Console.WriteLine("GetProject succeeded");
            }
        }

        public void TestRemoveProject()
        {
            User user = new User();
            var mProj1 = new Mock<Project>();
            var mProj2 = new Mock<Project>();
            var mProj3 = new Mock<Project>();
            var mProj4 = new Mock<Project>();

            mProj1.Setup(m => m.GetName()).Returns("proj1name");
            mProj2.Setup(m => m.GetName()).Returns("proj2name");
            mProj3.Setup(m => m.GetName()).Returns("proj3name");
            mProj4.Setup(m => m.GetName()).Returns("proj4name");

            user.AddProject(mProj1.Object);
            user.AddProject(mProj2.Object);
            user.AddProject(mProj3.Object);
            user.AddProject(mProj4.Object);


            var removed = user.RemoveProject("proj2name");
            if (removed)
            {
                Console.WriteLine("RemoveProject succeeded");
            } else
            {
                Console.WriteLine("RemoveProject failed");
            }

            // try to remove the same project again, should fail as it's already been removed
            removed = user.RemoveProject("proj2name");
            if (!removed)
            {
                Console.WriteLine("RemoveProject succeeded. Returned false when asked to remove" +
                    "a project that has already been removed");
            }
            else
            {
                Console.WriteLine("RemoveProject failed. Should have returned false since it was attempting to " +
                    "remove a project that doesn't exist, but it returned true.");
            }

            // tests if we can remove a second project successfully
            removed = user.RemoveProject("proj4name");
            if (removed)
            {
                Console.WriteLine("RemoveProject successful");
            }
            else
            {
                Console.WriteLine("RemoveProject failed.");
            }
        }

    //    public void TestEditProject()
    //    {
    //        User user = new User();
    //        Project proj = new Project();
    //        var cons = new Mock<IConsole>();

    //        proj.SetName("old name");
    //        proj.SetDescription("old description");
    //        DateTime.TryParse("01/10/2019", out DateTime oldStart);
    //        proj.SetStartDate(oldStart);
    //        DateTime.TryParse("10/10/2019", out DateTime oldEnd);
    //        proj.SetEndDate(oldEnd);

    //        cons.Setup(c => c.WriteLine((It.IsAny<string>())));
    //        cons.Setup(c => c.ReadLine()).Returns("new stuff");

    //        var oldProj = proj;
    //        user.EditProject(proj, 1, cons.Object);
    //        user.EditProject(proj, 2, cons.Object);
    //        user.EditProject(proj, 3, cons.Object);
    //        user.EditProject(proj, 4, cons.Object);
            
    //        if (proj != oldProj)
    //        {
    //            Console.WriteLine("EditProject succeeded");
    //        }
    //        else
    //        {
    //            Console.WriteLine("EditProject failed. Should have changed values but it didn't");
    //        }
            
    //    }
    }
}
