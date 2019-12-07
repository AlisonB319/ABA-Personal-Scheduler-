using System;
using IntegrationTests.Classes;

namespace IntegrationTests
{
    class Program
    {
        static void Main(string[] args)
        {
            UIIntegration uIIntegration = new UIIntegration();
            DataStoreIntegration dsIntegration = new DataStoreIntegration();
            ProjectIntegration prIntegration = new ProjectIntegration();

            uIIntegration.RunTests();
            dsIntegration.RunTests();
            prIntegration.RunTests();
        }
    }
}
