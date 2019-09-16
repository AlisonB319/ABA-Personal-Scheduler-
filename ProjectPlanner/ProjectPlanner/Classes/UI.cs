using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPlanner.Classes
{
    class UI
    {
        private DataStore dataStore;


        public void ListUsers()
        {
            foreach(object k in dataStore.GetDataBase().Values)
            {
                Console.WriteLine(k.ToString());
            }
        }

        //Logs a user in to the system
        public void LogIn()
        {
            Console.Clear();
            bool loginComplete = false;
            do //loops while user attempts to login
            {
                
                Console.WriteLine("Enter your login username");
                string user = Console.ReadLine();
                if (dataStore.GetDataBase().ContainsKey(user))
                {
                    Console.WriteLine("Enter your login password");
                    string pass = Console.ReadLine();
                    try //make sure our cast works, the value of the hashed username may not be a User class
                    {
                        User userClass = (User)dataStore.GetDataBase()[user];
                        if (pass.Equals(userClass))
                        {
                            loginComplete = true;
                        }
                        else
                        {
                            Console.WriteLine("Password entered incorrectly");
                        }
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine("Error getting user class from database");
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
