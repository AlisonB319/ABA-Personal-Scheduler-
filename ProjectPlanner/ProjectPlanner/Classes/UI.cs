namespace ProjectPlanner.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class UI
    {
        private DataStore _dataStore;
        private User _authenticatedUser;

        public void ListUsers()
        {
            foreach (object k in this._dataStore.GetDataBase().Values)
            {
                Console.WriteLine(k.ToString());
            }
        }

        public bool LogIn()
        {
            Console.Clear();
            bool loginComplete = false;
            this._dataStore = new DataStore();
            do
            {
                Console.WriteLine("Please enter your username, or press 1 to create an account");
                string username = Console.ReadLine();


                if (username == "1")
                {
                    // Creating the User account
                    // Assuming that email is the username
                    User newUser = new User();

                    string fName, lName, email, create_password;
                    Console.WriteLine("Please enter your first name");
                    fName = Console.ReadLine();
                    Console.WriteLine("Please enter your last name");
                    lName = Console.ReadLine();
                    Console.WriteLine("Please enter your email, this is also your username");
                    email = Console.ReadLine();
                    Console.WriteLine("Please enter your password");
                    create_password = Console.ReadLine();

                    newUser.CreateUser(fName, lName, email, create_password); // create the user
                    this._dataStore.AddData(email, newUser); // add user data to DataStore
                }
                else if (_dataStore.AuthenticateUsername(username))
                {
                    Console.WriteLine("Please enter your password");
                    string password = Console.ReadLine();
                    if (this._dataStore.AuthenticatePassword(username, password))
                    {
                        Console.WriteLine("User is authenticated");
                        this._authenticatedUser = this._dataStore.getAuthenticatedUser(username, password);
                        loginComplete = true;
                    }
                    else
                    {
                        Console.WriteLine("Authentication failed please try again");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Authentication failed please try again");
                    continue;
                }
            } while (!loginComplete);
            return true;
        }

        public void ProjectOptions()
        {
            bool makingSchedules = false;
            do
            {
                Console.Clear();
                string option;
                Console.WriteLine("Press 1 to create a Project");
                Console.WriteLine("Press 2 to add a schedule to a project");
                Console.WriteLine("Press 3 to view your projects");
                option = Console.ReadLine();
                if (option == "1")
                {
                    Project newProject = new Project();
                    newProject.CreateProject();
                    this._authenticatedUser.AddProject(newProject); // add the project to the user
                }
                else if (option == "2")
                {
                    Schedule newSchedule = new Schedule();
                    string projectName;
                    newSchedule.CreateSchedule();
                    // We probably want some kind of menu option to determine which project to choose
                    Console.WriteLine("Please enter the name of the Project this schedule belongs to");
                    projectName = Console.ReadLine();
                    Project userProject = this._authenticatedUser.GetProject(projectName);
                    userProject.AddSchedule(newSchedule);
                    // *******************************************************************************
                }
                else if (option == "3")
                {
                    _authenticatedUser.OpenProjects();
                }
            } while (!makingSchedules);
        }
    }
}