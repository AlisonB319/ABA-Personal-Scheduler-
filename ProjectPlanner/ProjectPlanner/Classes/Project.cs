using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPlanner.Classes
{
    class Project
    {
        private string name, description;
        private DateTime startDate, endDate;
        private List<Schedule> schedules;



        private List<Schedule> Getschedules()
        {
            return schedules;
        }

        private void Setschedules(List<Schedule> value)
        {
            schedules = value;
        }

        private DateTime GetendDate()
        {
            return endDate;
        }

        private void SetendDate(DateTime value)
        {
            endDate = value;
        }

        private DateTime GetstartDate()
        {
            return startDate;
        }

        private void SetstartDate(DateTime value)
        {
            startDate = value;
        }

        private string Getdescription()
        {
            return description;
        }

        private void Setdescription(string value)
        {
            description = value;
        }

        private string Getname()
        {
            return name;
        }

        private void Setname(string value)
        {
            name = value;
        }
    }
}
