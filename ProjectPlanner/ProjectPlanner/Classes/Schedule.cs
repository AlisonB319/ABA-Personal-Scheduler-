namespace ProjectPlanner.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Schedule : ISchedule
    {
        private string name, client, description;
        private DateTime startDate, endDate;


        // percentComplete = hoursWorked/totalHours
        private float hoursNeeded, hoursWorked, totalHours, percentComplete;
        private Project proj;

        public void SetProject(Project val)
        {
            this.proj = val;
        }
        public Project GetProject()
        {
            return this.proj;
        }

        public virtual string GetName()
        {
            return this.name;
        }
        public void SetName(string value)
        {
            this.name = value;
        }

        public virtual string GetClient()
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
            DateTime.TryParse(value, out DateTime startDate);
            this.startDate = startDate;
        }

        public DateTime GetEndDate()
        {
            return this.endDate;
        }

        public void SetEndDate(string value)
        {
            DateTime.TryParse(value, out DateTime endDate);
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
        public void SetTotalHours(string value)
        {
            float hours = float.Parse(value, CultureInfo.InvariantCulture.NumberFormat);
            this.totalHours = hours;
        }

        public void UpdateTotalHours()
        {
            float num = this.GetHoursNeeded() + this.GetHoursWorked();
            this.SetTotalHours(num.ToString());
        }

        public void UpdatePercentComplete()
        {
            if (this.GetTotalHours() != 0)
            {
                this.percentComplete = this.GetHoursWorked() / this.GetTotalHours();
            }
            else
            {
                this.percentComplete = 0;
            }
        }

        // Function to make sure that schedule times are within project times
        public bool CheckDates(DateTime projTime, string scheduleString, bool startEnd)
        {
            DateTime.TryParse(scheduleString, out DateTime scheduleTime);
            int result = DateTime.Compare(projTime, scheduleTime);

            // start = startend = true 
            if (result > 0 && startEnd is true) // project start is later than schedule start
            {
                return false;
            }
            // end = startend = false
            else if (result < 0 && startEnd is false)
            {
                return false;
            }
            return true;
        }

        public void CreateSchedule(Project proj)
        {
            string name, client, start, end, hoursNeeded, hoursWorked, description;

            Console.WriteLine("Please enter the name of the schedule");
            name = Console.ReadLine();
            this.SetName(name);

            Console.WriteLine("Please enter the client of the schedule");
            client = Console.ReadLine();
            this.SetClient(client);

            // ******************************
            // make sure that schedule is within the time frame of the project
            Console.WriteLine("Please enter the start date of the schedule MM-DD-YYYY");
            DateTime ProjStart = proj.GetStartDate();
            bool correctStartDate = false;
            while (!correctStartDate)
            {
                start = Console.ReadLine();


                bool result = this.CheckDates(ProjStart, start, true);
                if (result == true)
                {
                    this.SetStartDate(start);
                    correctStartDate = true;
                }
                else
                {
                    Console.WriteLine("Invalid Start Time");
                    DateTime projStart = proj.GetStartDate();
                    string startStr = projStart.ToString();

                    string str = "Please enter a date after " + startStr;
                    Console.WriteLine(str);
                }
            }

            Console.WriteLine("Please enter the end date of the schedule MM-DD-YYYY");
            DateTime ProjEnd = proj.GetEndDate();
            DateTime scheduleStartDate = this.GetStartDate();
            bool correctEndDate = false;
            while (!correctEndDate)
            {
                end = Console.ReadLine();

                bool resultP = this.CheckDates(ProjEnd, end, false);

                bool resultStart = this.CheckDates(scheduleStartDate, end, true);

                if (resultP == true && resultStart == true)
                {
                    this.SetEndDate(end);
                    correctEndDate = true;
                }
                else
                {
                    Console.WriteLine("Invalid End Time");
                    DateTime projEnd = proj.GetEndDate();
                    string endStr, str;
                    str = "";
                    if (resultP == false)
                    {
                        endStr = projEnd.ToString();
                        str = "Please enter a date after " + endStr;
                    }
                    if (resultStart == false)
                    {
                        endStr = scheduleStartDate.ToString();
                        str = "Please enter a date before " + endStr;
                    }
                    Console.WriteLine(str);
                }
            }

            Console.WriteLine("Please enter hours needed, partial hours are excepted ex: 4.3");
            hoursNeeded = Console.ReadLine();
            this.SetHoursNeeded(hoursNeeded);

            Console.WriteLine("Please enter hours worked, partial hours are excepted ex: 4.3");
            hoursWorked = Console.ReadLine();

            this.SetHoursWorked(hoursWorked);

            float num = this.GetHoursNeeded() + this.GetHoursNeeded();
            this.SetTotalHours(num.ToString());

            this.UpdatePercentComplete();

            Console.WriteLine("Please enter the description of the schedule");
            description = Console.ReadLine();
            this.SetDescription(description);
        }
    }
}