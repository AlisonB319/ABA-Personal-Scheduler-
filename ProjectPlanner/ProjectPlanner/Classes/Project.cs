namespace ProjectPlanner.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Project
    {
        private string _name, _description;
        private DateTime _startDate, _endDate;
        private List<Schedule> _schedules;



        public List<Schedule> GetSchedules()
        {
            return this._schedules;
        }

        private void SetSchedules(List<Schedule> value)
        {
            this._schedules = value;
        }

        private void AddSchedule(Schedule val)
        {
            this._schedules.Add(val);
        }

        // this method accepts a string which is the name of a schedule,
        // searches through the list of schedules, and removes the first schedule it finds with that
        // name and removes it
        private bool RemoveSchedule(String val)
        {
            Schedule toRemove = this._schedules.Find(x => x.GetName().Contains(this._name));
            return this._schedules.Remove(toRemove);
        }
        // this method accepts a schedule as parameter and removes that schedule from the list
        // returns true if successful and false if not.
        private bool RemoveSchedule(Schedule val)
        {
            return this._schedules.Remove(val);
        }

        public DateTime GetEndDate()
        {
            return this._endDate;
        }

        private void SetEndDate(DateTime value)
        {
            this._endDate = value;
        }

        public DateTime GetStartDate()
        {
            return this._startDate;
        }

        private void SetStartDate(DateTime value)
        {
            this._startDate = value;
        }

        public string GetDescription()
        {
            return this._description;
        }

        private void SetDescription(string value)
        {
            this._description = value;
        }

        public string GetName()
        {
            return this._name;
        }

        private void SetName(string value)
        {
            this._name = value;
        }
    }
}
