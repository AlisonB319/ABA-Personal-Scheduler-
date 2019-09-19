namespace ProjectPlanner.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    class User
    {
        private string _firstName, _lastName, _email, _password;


        private List<Project> _projects;

        private string Getemail()
        {
            return this._email;
        }

        private void SetEmail(string value)
        {
            this._email = value;
        }

        private string GetPassword()
        {
            return this._password;
        }

        private void SetPassword(string value)
        {
            this._password = value;
        }

        private List<Project> GetProjects()
        {
            return this._projects;
        }

        private void AddProject(Project project)
        {
            this._projects.Add(project);
        }

        private bool RemoveProject(string name)
        {
            Project toRemove = this._projects.Find(x => x.GetName().Contains(name));
            return this._projects.Remove(toRemove);
        }

        private bool RemoveProject(Project val)
        {
            return this._projects.Remove(val);
        }

        private void SetProjects(List<Project> value)
        {
            this._projects = value;
        }

        private string GetLastName()
        {
            return this._lastName;
        }

        private void SetLastName(string value)
        {
            this._lastName = value;
        }

        private string GetFirstName()
        {
            return this._firstName;
        }

        private void SetFirstName(string value)
        {
            this._firstName = value;
        }
    }
}
