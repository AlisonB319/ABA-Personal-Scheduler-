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
                    Console.WriteLine("Please enter your email,k this is also your username");
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

        public void ScheduleOptions()
        {
            bool makingSchedules = false;
            do
            {
                string option;
                Console.WriteLine("Press 1 to create a schedule");
                option = Console.ReadLine();
                if (option == "1")
                {
                    Schedule newSchedule = new Schedule();
                    newSchedule.CreateSchedule();
                }
            } while (!makingSchedules);
        }
    }
}