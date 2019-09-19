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
            UI newUI = new UI();
            bool loggedIn;
            loggedIn = newUI.LogIn();

            if (loggedIn) // the user has logged in successfully 
            {
                newUI.ScheduleOptions();
            }
            
        }
    }
}
