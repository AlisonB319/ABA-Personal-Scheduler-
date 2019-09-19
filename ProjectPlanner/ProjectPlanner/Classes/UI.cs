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

        public void ListUsers()
        {
            foreach (object k in this._dataStore.GetDataBase().Values)
            {
                Console.WriteLine(k.ToString());
            }
        }

        public void LogIn()
        {
            Console.Clear();
            DataStore userDatabase = new DataStore();
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
                    Console.WriteLine("Please enter your email,k this is also your username");
                    email = Console.ReadLine();
                    Console.WriteLine("Please enter your password");
                    create_password = Console.ReadLine();

                    newUser.CreateUser(fName, lName, email, create_password); // create the user
                    userDatabase.AddData(email, newUser); // add user data to DataStore
                }
                else if (userDatabase.AuthenticateUsername(username))
                {
                    Console.WriteLine("Please enter your password");
                    string password = Console.ReadLine();
                    if (userDatabase.AuthenticatePassword(username, password))
                    {
                        Console.WriteLine("User is authenticated");
                    }
                    else
                    {
                        Console.WriteLine("Authentication failed please try again");
                    }
                }
                else
                {
                    Console.WriteLine("Authentication failed please try again");
                }
            } while (!loginComplete);
        }
    }
}
