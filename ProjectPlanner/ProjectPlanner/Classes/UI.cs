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

        public UI()
        {
            _dataStore = this._dataStore = new DataStore();
        }

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
                        this._authenticatedUser = this._dataStore.GetAuthenticatedUser(username, password);
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
            this.Welcome();
            return true;
        }

        private void Welcome()
        {
            Console.Clear();

            Console.WriteLine("~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~\n");
            Console.WriteLine("\tWelcome {0} {1}! \n", this._authenticatedUser.GetFirstName(), this._authenticatedUser.GetLastName());
            Console.WriteLine("\tPress any key to continue \n");
            Console.WriteLine("~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~\n");
            Console.ReadKey();
        }

        public bool ProjectOptions()
        {
            bool makingSchedules = false;
            do
            {
                Console.Clear();
                string option;

                Console.WriteLine("         MAIN MENU         \n");
                Console.WriteLine("Press 1 to create a Project");
                Console.WriteLine("Press 2 to add a schedule to a project");
                Console.WriteLine("Press 3 to view your projects");
                Console.WriteLine("Press 4 to Logout");
                Console.WriteLine("Press 9 to send a test email");

                option = Console.ReadLine();
                int.TryParse(option, out int op);

                if (op == 1)
                {
                    Project newProject = new Project();
                    newProject.CreateProject();
                    this._authenticatedUser.AddProject(newProject); // add the project to the user
                }
                else if (op == 2)
                {
                    int projCount = _authenticatedUser.DisplayProjects();

                    Console.WriteLine("Select which project you want to add a schedule to?\n");
                    Console.WriteLine("Enter 0 to return to the menu");
                    string response = Console.ReadLine();
                    int.TryParse(response, out op);

                    if (op == 0)
                    {
                        continue;
                    } else
                    {

                        if (op <= projCount)
                        {
                            op--;
                            Project project = _authenticatedUser.GetListProjects()[op];

                            Schedule newSchedule = new Schedule();
                            newSchedule.CreateSchedule();
                            project.AddSchedule(newSchedule);
                        }

                    }
                }
                else if (op == 3)
                {
                    _authenticatedUser.OpenProjects();
                }
                else if (op == 4)
                {
                    makingSchedules = true;
                    _authenticatedUser = null;
                    Console.WriteLine("You have been successfully logged out");
                }
                else if (op == 9)
                {
                    Email email = new Email();
                    Console.Write("Enter the email you would like to send to: ");
                    string response = Console.ReadLine();
                    email.EmailTest(response);
                }
            } while (!makingSchedules);
            return true;
        }
    }
}