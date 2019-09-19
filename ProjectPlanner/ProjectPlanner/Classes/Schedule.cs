namespace ProjectPlanner.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Schedule
    {
        private string _name, _client, _description;
        private DateTime _startDate, _endDate;
        private float _hoursNeeded, _hoursWorked, _percentComplete;


        public string GetName()
        {
            return this._name;
        }

        private void SetName(string value)
        {
            this._name = value;
        }

        public string GetClient()
        {
            return this._client;
        }

        private void SetClient(string value)
        {
            this._client = value;
        }

        public string GetDescription()
        {
            return this._description;
        }

        private void SetDescription(string value)
        {
            this._description = value;
        }
        
        public DateTime GetStartDate()
        {
            return this._startDate;
        }

        private void SetStartDate(DateTime value)
        {
            this._startDate = value;
        }
        
        public DateTime GetEndDate()
        {
            return this._endDate;
        }

        private void SetEndDate(DateTime value)
        {
            this._endDate = value;
        }
        
        public float GetHoursNeeded()
        {
            return this._hoursNeeded;
        }

        private void SetHoursNeeded(float value)
        {
            this._hoursNeeded = value;
        }
        
        public float GetHoursWorked()
        {
            return this._hoursWorked;
        }

        private void SetHoursWorked(float value)
        {
            this._hoursWorked = value;
        }
        
        public float GetPercentComplete()
        {
            return this._percentComplete;
        }

        private void SetPercentComplete(float value)
        {
            this._percentComplete = value;
        }
    }
}