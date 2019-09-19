namespace ProjectPlanner.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Project
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

        public void AddSchedule(Schedule val)
        {
            this.schedules.Add(val);
        }

        // this method accepts a string which is the name of a schedule,
        // searches through the list of schedules, and removes the first schedule it finds with that
        // name and removes it
        public bool RemoveSchedule(String val)
        {
            Schedule toRemove = this.schedules.Find(x => x.GetName().Contains(this.name));
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
            this.endDate = value;
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
            DateTime startDate = Convert.ToDateTime(start);
            this.SetStartDate(startDate);

            Console.WriteLine("Please enter the end date of the project MM-DD-YYYY");
            end = Console.ReadLine();
            DateTime endDate = Convert.ToDateTime(end);
            this.SetStartDate(endDate);

            Console.WriteLine("Please enter the description of the schedule");
            description = Console.ReadLine();
            this.SetDescription(description);
        }
    }
}
