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

        public User()
        {
            _projects = new List<Project>();
        }


        private string Getemail()
        {
            return this._email;
        }

        private string GetPassword()
        {
            return this._password;
        }

        public List<Project> GetListProjects()
        {
            return this._projects;
        }

        public Project GetProject(string projectName)
        /*
         * This is to get a single project from the user so that a schedule can be added
         */
        {
            foreach (Project proj in this._projects)
            {
                string projName;
                projName = proj.GetName();
                if (projName == projectName)
                {
                    return proj;
                }
            }
            return null;
        }

        public void AddProject(Project project)
        {
            this._projects.Add(project);
        }

        private bool RemoveProject(string name)
        {
            Project toRemove = this._projects.Find(x => x.GetName().Contains(name));
            return this._projects.Remove(toRemove);
        }

        private void SetProjects(List<Project> value)
        {
            this._projects = value;
        }

        private string GetLastName()
        {
            return this._lastName;
        }

        private string GetFirstName()
        {
            return this._firstName;
        }

        public void CreateUser(string fname, string lname, string email, string password)
        {
            this._firstName = fname;
            this._lastName = lname;
            this._email = email;
            this._password = password;
        }
        
        public bool AuthenticatePassword(string password)
        {
            if (this._password == password)
            {
                return true;
            }
            return false;
        }
    }
}
