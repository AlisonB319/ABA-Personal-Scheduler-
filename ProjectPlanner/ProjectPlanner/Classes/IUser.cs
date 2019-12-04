using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPlanner.Classes
{
    public interface IUser
    {

        List<Project> GetListProjects();

        Project GetProject(string projectName);
        

        void AddProject(Project project);
        

        bool RemoveProject(string name);
        

        string GetLastName();
        

        string GetFirstName();
        

        void SetPassword(string password);
        

        void CreateUser(string fname, string lname, string email, string password);
        

        bool AuthenticatePassword(string password);
        

        int DisplayProjects();
        

        void OpenProjects();
        


        void EditProject(Project project, int choice);
        
    }
}
