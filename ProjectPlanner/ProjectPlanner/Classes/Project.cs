namespace ProjectPlanner.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Project:IProject
    {
        private string name, description;
        private DateTime startDate, endDate;
        private List<Schedule> schedules;

        public Project()
        {
            schedules = new List<Schedule>();
        }

        public List<Schedule> GetSchedules()
        {
            return this.schedules;
        }

        public void SetSchedules(List<Schedule> value)
        {
            this.schedules = value;
        }

        public void DisplayAttributes()
        {
            Console.WriteLine("Project Name: {0}", this.name);
            Console.WriteLine("\tDescription: {0}", this.description);
            Console.WriteLine("\tStart Date: {0}", this.startDate.Date);
            Console.WriteLine("\tEnd Date: {0}", this.endDate.Date);
        }
        public void AddSchedule(Schedule val)
        {
            val.SetProject(this);
            this.schedules.Add(val);
        }

        // this method accepts a string which is the name of a schedule,
        // searches through the list of schedules, and removes the first schedule it finds with that
        // name and removes it
        public bool RemoveSchedule(String val)
        {
            Schedule toRemove = this.schedules.Find(x => x.GetName().Contains(val));
            return this.schedules.Remove(toRemove);
        }

        // this method accepts a schedule as parameter and removes that schedule from the list
        // returns true if successful and false if not.
        public bool RemoveSchedule(Schedule val)
        {
            return this.schedules.Remove(val);
        }

        public DateTime GetEndDate()
        {
            return this.endDate;
        }

        public void SetEndDate(DateTime value)
        {
            bool valid = false;
            while (valid == false)
            {
                if (this.GetStartDate() <= value)
                {
                    this.endDate = value;
                    valid = true;
                }
                else
                {
                    // throw new System.ArgumentException("end date cannot be before start date");
                    Console.WriteLine("Invalid End Date.");
                    Console.WriteLine("A project's end date cannot take place before it's start date");
                    Console.WriteLine("This projects start date is {0}. Enter another end date", this.GetStartDate().ToShortDateString());
                    string end = Console.ReadLine();
                    DateTime.TryParse(end, out value);
                }
            }
        }

        public DateTime GetStartDate()
        {
            return this.startDate;
        }

        public void SetStartDate(DateTime value)
        {
            this.startDate = value;
        }

        public string GetDescription()
        {
            return this.description;
        }

        public void SetDescription(string value)
        {
            this.description = value;
        }

        public string GetName()
        {
            return this.name;
        }

        public void SetName(string value)
        {
            this.name = value;
        }


        public void CreateProject()
        {
            string name, start, end, description;
            Console.WriteLine("Please enter the name of the project");
            name = Console.ReadLine();
            this.SetName(name);

            Console.WriteLine("Please enter the start date of the project MM-DD-YYYY");
            start = Console.ReadLine();
            DateTime.TryParse(start, out DateTime startDate);
            this.SetStartDate(startDate);

            Console.WriteLine("Please enter the end date of the project MM-DD-YYYY");
            end = Console.ReadLine();
            DateTime.TryParse(end, out DateTime endDate);
            this.SetEndDate(endDate);

            Console.WriteLine("Please enter the description of the project");
            description = Console.ReadLine();
            this.SetDescription(description);
        }

        public int DisplaySchedules()
        {
            int scheduleCount = 0;
            foreach (Schedule schedule in this.schedules)
            {
                scheduleCount++;
                Console.WriteLine("\nSchedule {0}: {1}", scheduleCount, schedule.GetName());
                Console.WriteLine("Description: {0}", schedule.GetDescription());
                Console.WriteLine("\tStart Date: {0}", schedule.GetStartDate().ToShortDateString());
                Console.WriteLine("\tEnd Date: {0}", schedule.GetEndDate().Date.ToShortDateString());
                Console.WriteLine("\tHours Needed: {0}", schedule.GetHoursNeeded());
                Console.WriteLine("\tHours Worked: {0}", schedule.GetHoursWorked());
                Console.WriteLine("\tPercentComplete: {0}", schedule.GetPercentComplete());
                Console.Write("\n");
            }
            return scheduleCount;
        }

        public void ViewSchedules()
        {
            while (true)
            {
                Console.Clear();
                if (this.GetSchedules().Count() == 0)
                {
                    Console.WriteLine("There are no schedules for this project.");
                    Console.WriteLine("If you would like to add a schedule, press 'c'\nElse, press any other key");
                    string key = Console.ReadLine();
                    if (key == "c") {
                        Schedule newSchedule = new Schedule();
                        newSchedule.CreateSchedule(this);
                        this.AddSchedule(newSchedule);
                    }
                    return;
                }

                int scheduleCount = this.DisplaySchedules();
                Console.WriteLine("Enter 1 if you would like to edit a schedule.");
                Console.WriteLine("Enter 2 if you would like to delete a schedule.");

                Console.WriteLine("Enter 0 to return to the menu");
                string response = Console.ReadLine();
                int choice = int.Parse(response);

                if (choice == 0)
                    return;
                else if (choice == 1 || choice == 2)
                {
                    Console.Clear();
                    scheduleCount = this.DisplaySchedules();
                    if (choice == 1) Console.WriteLine("Enter the number of the project to edit.");
                    if (choice == 2) Console.WriteLine("Enter the number of the project to delete.");

                    response = Console.ReadLine();
                    int.TryParse(response, out int op);


                    if (op <= scheduleCount)
                    {
                        op--;
                        Schedule schedule = this.schedules[op];

                        if (choice == 2) this.RemoveSchedule(schedule);
                        else
                        {
                            int choice2 = 0;
                            do
                            {
                                Console.Clear();
                                Console.WriteLine("Editing Schedule: {0}", schedule.GetName());
                                Console.WriteLine("\n\n1. Edit Name");
                                Console.WriteLine("2. Edit Description");
                                Console.WriteLine("3. Edit Start Date");
                                Console.WriteLine("4. Edit End Date");
                                Console.WriteLine("5. Edit Hours Needed");
                                Console.WriteLine("9. Exit");

                                response = Console.ReadLine();
                                choice2 = int.Parse(response);

                                switch (choice2)
                                {
                                    case 1:
                                        Console.WriteLine("Editing Schedule name");
                                        Console.WriteLine("Current Name: {0}", schedule.GetName());
                                        Console.Write("New Name: ");
                                        string newName = Console.ReadLine();
                                        schedule.SetName(newName);
                                        Console.WriteLine("Done.");
                                        break;

                                    case 2:
                                        Console.WriteLine("Editing Schedule Description.");
                                        Console.WriteLine("Current Description: {0}", schedule.GetDescription());
                                        Console.Write("New Description: ");
                                        string newDescription = Console.ReadLine();
                                        schedule.SetDescription(newDescription);
                                        Console.WriteLine("Done.");
                                        break;

                                    case 3:
                                        Console.WriteLine("Editing Start Date");
                                        Console.WriteLine("Current Start Date: {0}", schedule.GetStartDate().Date);
                                        Console.Write("New Start Date (MM-DD-YYYY): ");
                                        string input = Console.ReadLine();
                                        schedule.SetStartDate(input);
                                        Console.WriteLine("Done.");
                                        break;
                                    case 4:
                                        Console.WriteLine("Editing End Date");
                                        Console.WriteLine("Current End Date: {0}", schedule.GetEndDate().Date);
                                        Console.Write("New End Date (MM-DD-YYYY): ");
                                        input = Console.ReadLine();
                                        schedule.SetEndDate(input);
                                        Console.WriteLine("Done.");
                                        break;
                                    case 5:
                                        Console.WriteLine("Editing Hours Needed");
                                        Console.WriteLine("Current Hours Needed: {0}", schedule.GetHoursNeeded());
                                        Console.Write("New Hours Needed: ");
                                        input = Console.ReadLine();
                                        schedule.SetHoursNeeded(input);

                                        // updating total hours and percent complete too
                                        schedule.UpdateTotalHours();
                                        schedule.UpdatePercentComplete();

                                        Console.WriteLine("Done.");
                                        break;
                                    case 9:
                                        break;
                                    default:
                                        Console.WriteLine("Invalid selection, try again.");
                                        choice2 = 0;
                                        break;
                                }
                            } while (choice2 != 9);
                        }
                        
                    }
                }
            }
        }
    }
}
