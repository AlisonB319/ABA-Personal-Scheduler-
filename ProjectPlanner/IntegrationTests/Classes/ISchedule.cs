using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTests.Classes
{
    public interface ISchedule
    {
        void SetProject(Project val);

        Project GetProject();

        string GetName();

        void SetName(string value);

        string GetClient();

        void SetClient(string value);

        string GetDescription();

        void SetDescription(string value);

        DateTime GetStartDate();

        void SetStartDate(string value);

        DateTime GetEndDate();

        void SetEndDate(string value);

        float GetHoursNeeded();

        void SetHoursNeeded(string value);

        float GetHoursWorked();

        void SetHoursWorked(string value);

        float GetPercentComplete();

        float GetTotalHours();

        void SetTotalHours(string val);

        void UpdateTotalHours();

        void UpdatePercentComplete();

        bool CheckDates(DateTime projTime, string scheduleString, bool startEnd);

        void CreateSchedule(Project proj);
       
    }
}
