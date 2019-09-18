using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPlanner.Classes
{
    class User
    {
        private string firstName, lastName, email, password;


        private List<Project> projects;

        private string Getemail()
        {
            return email;
        }

        private void Setemail(string value)
        {
            email = value;
        }

        private string Getpassword()
        {
            return password;
        }

        private void Setpassword(string value)
        {
            password = value;
        }

        private List<Project> Getprojects()
        {
            return projects;
        }

        private void addProject(Project project)
        {
            this.projects.Add(project);
        }

        private void removeProject(string name)
        {
            //Project toRemove = this.projects.Find(x => x.Getname().Contains(name));
            //this.projects.Remove(toRemove);
        }

        private void Setprojects(List<Project> value)
        {
            projects = value;
        }

        private string GetLastName()
        {
            return lastName;
        }

        private void SetLastName(string value)
        {
            lastName = value;
        }

        private string GetFirstName()
        {
            return firstName;
        }

        private void SetFirstName(string value)
        {
            firstName = value;
        }
    }
}
