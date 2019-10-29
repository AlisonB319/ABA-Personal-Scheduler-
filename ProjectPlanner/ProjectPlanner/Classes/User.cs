namespace ProjectPlanner.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class User
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

        private bool RemoveProject(Project project)
        {
            return this._projects.Remove(project);
        }

        private void SetProjects(List<Project> value)
        {
            this._projects = value;
        }

        public string GetLastName()
        {
            return this._lastName;
        }

        public string GetFirstName()
        {
            return this._firstName;
        }

        public void SetPassword(string password)
        {
            this._password = password;
        }

        public void CreateUser(string fname, string lname, string email, string password)
        {
            this._firstName = fname;
            this._lastName = lname;
            this._email = email;
            this._password = password;
        }
        
        public virtual bool AuthenticatePassword(string password)
        {
            if (this._password == password)
            {
                return true;
            }
            return false;
        }

        public int DisplayProjects()
        {
            int projectCount = 0;
            foreach (Project project in this._projects)
            {
                projectCount++;
                Console.WriteLine("\nProject {0}: {1}", projectCount, project.GetName());
                Console.WriteLine("\tDescription: {0}", project.GetDescription());
                Console.WriteLine("\tStart Date: {0}", project.GetStartDate().Date);
                Console.WriteLine("\tEnd Date: {0}", project.GetEndDate().Date);

                Console.WriteLine("\tNumber of schedules: {0}", project.GetSchedules().Count());
                Console.Write("\n");

            }
            return projectCount;
        }

        public void OpenProjects()
        {
            
            if (this.GetListProjects().Count() == 0)
            {
                Console.WriteLine("Whoops! You don't have any projects! Please create a project first.");
                return;
            }

            int projectCount = 0;

            while (true)
            {
                Console.Clear();
                projectCount = DisplayProjects();

                Console.WriteLine("Enter 1 to select a project's schedules to view");
                Console.WriteLine("Enter 2 to select a project to edit.");
                Console.WriteLine("Enter 3 to select a project to delete");
                Console.WriteLine("Enter 0 to return to the menu");

                string response = Console.ReadLine();
                int.TryParse(response, out int choice);
                Console.Clear();

                if (choice == 0)
                    return;
                else if (choice >= 1 && choice <= 3)
                {
                    projectCount = DisplayProjects();

                    if (choice == 1)
                        Console.WriteLine("Enter the number of the project whose schedule's you would like to view");
                    if (choice == 2)
                        Console.WriteLine("Enter the number of the project to edit.");
                    if (choice == 3)
                        Console.WriteLine("Enter the number of the project to delete.");

                    string input = Console.ReadLine();
                    int.TryParse(input, out int op);

                    if (op <= projectCount)
                    {
                        op--;
                        Project project = this._projects[op];
                        if (choice == 1)
                            project.ViewSchedules();
                        if (choice == 2)
                            this.EditProject(project);
                        if (choice == 3)
                            this.RemoveProject(project);
                    }
                }
            }
        } 
        private void EditProject(Project project)
        {
            bool running = true;

            while (running)
            {

                Console.Clear();

                project.DisplayAttributes();

                Console.WriteLine("\n1. Edit name");
                Console.WriteLine("2. Edit description");
                Console.WriteLine("3. Edit start date ");
                Console.WriteLine("4. Edit end date");
                Console.WriteLine("0: Exit");
                string input = Console.ReadLine();
                int.TryParse(input, out int op);

                switch (op) {
                    case 1:
                        Console.WriteLine("Editing Project Name");
                        Console.Write("New name: ");
                        input = Console.ReadLine();
                        project.SetName(input);
                        break;
                    case 2:
                        Console.WriteLine("Editing Project Description");
                        Console.Write("New Description: ");
                        input = Console.ReadLine();
                        project.SetDescription(input);
                        break;
                    case 3:
                        Console.WriteLine("Editing Start Date");
                        Console.Write("New Start Date: ");
                        input = Console.ReadLine();
                        DateTime.TryParse(input, out DateTime newDate);
                        project.SetStartDate(newDate);
                        break;
                    case 4:
                        Console.WriteLine("Editing End Date");
                        Console.Write("New End Date:");
                        input = Console.ReadLine();
                        DateTime.TryParse(input, out newDate);
                        project.SetEndDate(newDate);
                        break;
                    case 0:
                        return;
                };
            }

        }
    }
}
