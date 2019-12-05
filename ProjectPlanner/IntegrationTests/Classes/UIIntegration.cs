using System;
using System.Collections.Generic;
using System.Text;
using Moq;

namespace IntegrationTests.Classes
{
    public class UIIntegration
    {
        public void RunTests()
        {
            TestLogIn1();
            TestLogIn2();
            TestLogIn3();
        }


        //integrating user.createuser given the user is new
        public void TestLogIn1()
        {
            //The user would provide information for their account here
            User user = new User(); //constructor is trivial so we skip an integration step
            IDataStore dataStore = new DataStore();
            var mDataStore = new Mock<DataStore>();

            mDataStore.Setup(m => m.AddData(It.IsAny<string>(), It.IsAny<User>())).Verifiable();

            string FirstName = "FirstName";
            string LastName = "LastName";
            string Email = "Email@email.com";
            string Password = "Password";

            user.CreateUser(FirstName, LastName, Email, Password);
            mDataStore.Object.AddData(Email, user);

            if (user.GetFirstName() == FirstName && user.GetLastName() == LastName)//these gets are trivial so we don't worry about their implementation
            {
                try
                {
                    mDataStore.Verify(m => m.AddData(It.IsAny<string>(), It.IsAny<User>()), Times.Once());

                }
                catch (MockException)
                {
                    Console.WriteLine("Login1: Failed, mDataStore.AddData not called");
                }
                Console.WriteLine("Login1: Passed");
            }
            else
            {
                Console.WriteLine("Login1: Failed, User not successfully created");
            }
        }

        //integrating _datastore.addData given the user is new
        public void TestLogIn2()
        {
            //The user would provide information for their account here
            User user = new User(); //constructor is trivial so we skip an integration step
            IDataStore dataStore = new DataStore();


            string FirstName = "FirstName";
            string LastName = "LastName";
            string Email = "Email@email.com";
            string Password = "Password";

            user.CreateUser(FirstName, LastName, Email, Password);
            dataStore.AddData(Email, user);

            if (dataStore.GetDataBase().Count == 1)//get database is trivial so we don't worry about a mock here
            {
                Console.WriteLine("Login2: Passed");
            }
            else
            {
                Console.WriteLine("Login2: Failed, database count does not match expected count");
            }
        }

        //integrating _datastore.AuthenticateUsername given the user is new
        public void TestLogIn3()
        {
            //The user would provide information for their account here
            User user = new User(); //constructor is trivial so we skip an integration step
            IDataStore dataStore = new DataStore();
            User _authenticatedUser;

            var mDataStore = new Mock<DataStore>();

            string FirstName = "FirstName";
            string LastName = "LastName";
            string Email = "Email@email.com";
            string Password = "Password";

            mDataStore.Setup(m => m.AuthenticatePassword(Email, Password)).Returns(true);
            mDataStore.Setup(m => m.GetAuthenticatedUser(Email, Password)).Returns(user);



            user.CreateUser(FirstName, LastName, Email, Password);
            dataStore.AddData(Email, user);


            if (dataStore.AuthenticateUsername(Email))
            {
                if (mDataStore.Object.AuthenticatePassword(Email, Password))
                {
                    _authenticatedUser = mDataStore.Object.GetAuthenticatedUser(Email, Password);
                    Console.WriteLine("Login3: Passed");
                }
                else
                {
                    Console.WriteLine("Login3: Failed, Authentication failed");

                }
            }
            else
            {
                Console.WriteLine("Login3: Failed, Authentication failed");

            }
        }
    }
}
