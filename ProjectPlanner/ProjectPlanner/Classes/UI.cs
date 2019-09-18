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

        // Logs a user in to the system
        public void LogIn()
        {
            Console.Clear();
            bool loginComplete = false;
            
            // loops while user attempts to login
            do 
            {
                
                Console.WriteLine("Enter your login username");
                string user = Console.ReadLine();
                if (this._dataStore.GetDataBase().ContainsKey(user))
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
