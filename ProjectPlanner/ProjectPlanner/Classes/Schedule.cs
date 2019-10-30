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

        // percentComplete = hoursWorked/totalHours
        private float hoursNeeded, hoursWorked, totalHours, percentComplete;



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

        public void SetStartDate(string value)
        {
            DateTime startDate = Convert.ToDateTime(value);
            this.startDate = startDate;
        }
        
        public DateTime GetEndDate()
        {
            return this.endDate;
        }

        public void SetEndDate(string value)
        {
            DateTime endDate = Convert.ToDateTime(value);
            this.endDate = endDate;
        }
        
        public float GetHoursNeeded()
        {
            return this.hoursNeeded;
        }

        public void SetHoursNeeded(string value)
        {
            float fHoursNeeded = float.Parse(value, CultureInfo.InvariantCulture.NumberFormat);
            this.hoursNeeded = fHoursNeeded;
        }
        
        public float GetHoursWorked()
        {
            return this.hoursWorked;
        }

        public void SetHoursWorked(string value)
        {
            float fHoursWorked = float.Parse(value, CultureInfo.InvariantCulture.NumberFormat);
            this.hoursWorked = fHoursWorked;
        }
        
        public float GetPercentComplete()
        {
            return this.percentComplete;
        }

        public float GetTotalHours()
        {
            return this.totalHours;
        }
        public void SetTotalHours(float val)
        {
            this.totalHours = val;
        }

        public void UpdateTotalHours()
        {
            float num = this.GetHoursNeeded() + this.GetHoursWorked();
            this.SetTotalHours(num);
        }

        public void UpdatePercentComplete()
        {
            this.percentComplete = this.GetHoursWorked() / this.GetTotalHours();
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
            this.SetStartDate(start);

            Console.WriteLine("Please enter the end date of the schedule MM-DD-YYYY");
            end = Console.ReadLine();
            this.SetEndDate(end);

            Console.WriteLine("Please enter hours needed, partial hours are excepted ex: 4.3");
            hoursNeeded = Console.ReadLine();
            this.SetHoursNeeded(hoursNeeded);

            Console.WriteLine("Please enter hours worked, partial hours are excepted ex: 4.3");
            hoursWorked = Console.ReadLine();
            
            this.SetHoursWorked(hoursWorked);

            float num = this.GetHoursNeeded() + this.GetHoursNeeded();
            this.SetTotalHours(num);

            this.UpdatePercentComplete();

            Console.WriteLine("Please enter the description of the schedule");
            description = Console.ReadLine();
            this.SetDescription(description);
        }
    }
}