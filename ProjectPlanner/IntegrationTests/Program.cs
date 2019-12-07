using System;
using IntegrationTests.Classes;

namespace IntegrationTests
{
    class Program
    {
        static void Main(string[] args)
        {
            UIIntegration uIIntegration = new UIIntegration();
            UserIntegration userIntegration = new UserIntegration();

            uIIntegration.RunTests();
            userIntegration.RunTests();
        }
    }
}
