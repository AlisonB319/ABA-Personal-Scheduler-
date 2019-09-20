namespace ProjectPlanner.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Schedule
    {
        private string name, client, description;
        private DateTime startDate, endDate;
        private float hoursNeeded, hoursWorked, percentComplete;

        public string GetName()
        {
            return this.name;
        }
        public void SetName(string value)
        {
            this.name = value;
        }

        public string GetClient()
        {
            return this.client;
        }

        public void SetClient(string value)
        {
            this.client = value;
        }

        public string GetDescription()
        {
            return this.description;
        }

        public void SetDescription(string value)
        {
            this.description = value;
        }
        
        public DateTime GetStartDate()
        {
            return this.startDate;
        }

        public void SetStartDate(DateTime value)
        {
            this.startDate = value;
        }
        
        public DateTime GetEndDate()
        {
            return this.endDate;
        }

        public void SetEndDate(DateTime value)
        {
            this.endDate = value;
        }
        
        public float GetHoursNeeded()
        {
            return this.hoursNeeded;
        }

        public void SetHoursNeeded(float value)
        {
            this.hoursNeeded = value;
        }
        
        public float GetHoursWorked()
        {
            return this.hoursWorked;
        }

        public void SetHoursWorked(float value)
        {
            this.hoursWorked = value;
        }
        
        public float GetPercentComplete()
        {
            return this.percentComplete;
        }

        public void SetPercentComplete(float value)
        {
            this.percentComplete = value;
        }

        public void CreateSchedule()
        {
            string name, client, start, end, hoursNeeded, hoursWorked, description;

            Console.WriteLine("Please enter the name of the schedule");
            name = Console.ReadLine();
            this.SetName(name);

            Console.WriteLine("Please enter the client of the schedule");
            client = Console.ReadLine();
            this.SetClient(client);

            Console.WriteLine("Please enter the start date of the schedule MM-DD-YYYY");
            start = Console.ReadLine();
            DateTime startDate = Convert.ToDateTime(start);
            this.SetStartDate(startDate);

            Console.WriteLine("Please enter the end date of the schedule MM-DD-YYYY");
            end = Console.ReadLine();
            DateTime endDate = Convert.ToDateTime(end);
            this.SetStartDate(endDate);

            Console.WriteLine("Please enter hours needed, partial hours are excepted ex: 4.3");
            hoursNeeded = Console.ReadLine();
            float fHoursNeeded = float.Parse(hoursNeeded, CultureInfo.InvariantCulture.NumberFormat);
            this.SetHoursNeeded(fHoursNeeded);

            Console.WriteLine("Please enter hours worked, partial hours are excepted ex: 4.3");
            hoursWorked = Console.ReadLine();
            float fHoursWorked = float.Parse(hoursWorked, CultureInfo.InvariantCulture.NumberFormat);
            this.SetHoursWorked(fHoursWorked);

            Console.WriteLine("Please enter the description of the schedule");
            description = Console.ReadLine();
            this.SetDescription(description);
        }
    }
}