using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPlanner.Classes
{
    class Schedule
    {
        private string name, client, description;
        private DateTime startDate, endDate;
        private float hoursNeeded, hoursWorked, percentComplete;












        private string GetName()
        {
            return name;
        }

        private void SetName(string value)
        {
            name = value;
        }

        private string GetClient()
        {
            return client;
        }

        private void SetClient(string value)
        {
            client = value;
        }

        private string GetDescription()
        {
            return description;
        }

        private void SetDescription(string value)
        {
            description = value;
        }
        
        private DateTime GetStartDate()
        {
            return startDate;
        }

        private void SetStartDate(DateTime value)
        {
            startDate = value;
        }
        
        private DateTime GetEndDate()
        {
            return endDate;
        }

        private void SetEndDate(DateTime value)
        {
            endDate = value;
        }
        
        private float GetHoursNeeded()
        {
            return hoursNeeded;
        }

        private void SetHoursNeeded(float value)
        {
            hoursNeeded = value;
        }
        
        private float GetHoursWorked()
        {
            return hoursWorked;
        }

        private void SetHoursWorked(float value)
        {
            hoursWorked = value;
        }
        
        private float GetPercentComplete()
        {
            return percentComplete;
        }

        private void SetPercentComplete(float value)
        {
            percentComplete = value;
        }
    }
}