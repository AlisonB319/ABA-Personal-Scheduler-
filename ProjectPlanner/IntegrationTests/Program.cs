using System;
using IntegrationTests.Classes;

namespace IntegrationTests
{
    class Program
    {
        static void Main(string[] args)
        {
            UIIntegration uIIntegration = new UIIntegration();

            uIIntegration.RunTests();
        }
    }
}
