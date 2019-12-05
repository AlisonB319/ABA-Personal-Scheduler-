using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTests.Classes
{
    interface IProject
    {

        List<Schedule> GetSchedules();

        void SetSchedules(List<Schedule> value);


        void DisplayAttributes();

        void AddSchedule(Schedule val);

        bool RemoveSchedule(String val);

        bool RemoveSchedule(Schedule val);


        DateTime GetEndDate();


        void SetEndDate(DateTime value);


        DateTime GetStartDate();


        void SetStartDate(DateTime value);


        string GetDescription();


        void SetDescription(string value);


        string GetName();


        void SetName(string value);

        void CreateProject();


        int DisplaySchedules();
        

        void ViewSchedules();
          
    }
}
