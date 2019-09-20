using ProjectPlanner.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPlanner
{
    class Program
    {
        static void Main(string[] args)
        {
            bool scheduleMakerRunning = false;
            UI newUI = new UI();
            do
            {
                bool loggedIn = newUI.LogIn();
                if (loggedIn) // the user has logged in successfully 
                {
                    newUI.ProjectOptions();
                }

                Console.WriteLine("Press 1 to Quit, or any key to continue");
                string keyInput = Console.ReadLine();
                if (keyInput == "1")
                {
                    scheduleMakerRunning = true;
                }
            } while (!scheduleMakerRunning);
        }
    }
}
