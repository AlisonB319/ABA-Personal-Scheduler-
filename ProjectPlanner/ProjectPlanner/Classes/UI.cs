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

        public void myLogIn()
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

                    string fName, lName, email, password;
                    Console.WriteLine("Please enter your first name");
                    fName = Console.ReadLine();
                    Console.WriteLine("Please enter your last name");
                    lName = Console.ReadLine();
                    Console.WriteLine("Please enter your email, this is also your username");
                    email = Console.ReadLine();
                    Console.WriteLine("Please enter your password");
                    password = Console.ReadLine();

                    newUser.CreateUser(fName, lName, email, password); // create the user
                    userDatabase.AddData(email, password); // add data to DataStore


                }
                else if (userDatabase.AuthenticateUser(username))
                {
                    Console.WriteLine("Please enter your password");
                    string password = Console.ReadLine();
                }
            } while (!loginComplete);
        }

        // Logs a user in to the system
        public void LogIn()
        {
            Console.Clear();
            bool loginComplete = false;
            DataStore userAuthentication = new DataStore();

            // loops while user attempts to login
            do 
            {
                Console.WriteLine("Enter your login username");
                string user = Console.ReadLine();
                if (userAuthentication.AuthenticateUser(user))
                {
                    Console.WriteLine("Enter your login password");
                    string pass = Console.ReadLine();
                    
                    // make sure our cast works, the value of the hashed username may not be a User class
                    try
                    {
                        User userClass = (User)this._dataStore.GetDataBase()[user];
                        if (pass.Equals(userClass))
                        {
                            loginComplete = true;
                        }
                        else
                        {
                            Console.WriteLine("Password entered incorrectly");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error getting user class from database, {}", e);
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Username entered incorrectly/username does not exist");
                }
                Console.WriteLine("Press 'q' to quit login or any other key to try again");
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.KeyChar.Equals('q'))
                {
                    return;
                }
                Console.Write("\n\n");
            } while (!loginComplete);
        }
    }
}
