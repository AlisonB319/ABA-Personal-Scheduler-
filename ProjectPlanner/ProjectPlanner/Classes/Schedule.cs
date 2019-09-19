namespace ProjectPlanner.Classes
{
    using System;
    using System.Collections.Generic;
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
    }
}