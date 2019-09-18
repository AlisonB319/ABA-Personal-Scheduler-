namespace ProjectPlanner.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class User
    {
        private string firstName, lastName, email, password;
        private List<Project> projects;

        private string Getemail()
        {
            return this.email;
        }

        private void SetEmail(string value)
        {
            this.email = value;
        }

        private string GetPassword()
        {
            return this.password;
        }

        private void SetPassword(string value)
        {
            this.password = value;
        }

        private List<Project> GetProjects()
        {
            return this.projects;
        }

        private void AddProject(Project project)
        {
            this.projects.Add(project);
        }

        private bool RemoveProject(string name)
        {
            Project toRemove = this.projects.Find(x => x.GetName().Contains(name));
            return this.projects.Remove(toRemove);
        }

        private bool RemoveProject(Project val)
        {
            return this.projects.Remove(val);
        }

        private void SetProjects(List<Project> value)
        {
            this.projects = value;
        }

        private string GetLastName()
        {
            return this.lastName;
        }

        private void SetLastName(string value)
        {
            this.lastName = value;
        }

        private string GetFirstName()
        {
            return this.firstName;
        }

        private void SetFirstName(string value)
        {
            this.firstName = value;
        }
    }
}
