using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTests.Classes
{
    public interface IProject
    {

        List<ISchedule> GetSchedules();

        void SetSchedules(List<ISchedule> value);


        void DisplayAttributes();

        void AddSchedule(ISchedule val);

        bool RemoveSchedule(String val);

        bool RemoveSchedule(ISchedule val);


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
