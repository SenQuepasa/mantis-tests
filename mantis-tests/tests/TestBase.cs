using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{

    public class TestBase
    {
        public static bool PERFORM_LONG_UI_CHECK = false;
        protected ApplicationManager app;
        protected LoginHelper loginHelper;
        protected NavigationHelper navigationHelper;
        protected ProjectHelper projectHelper;
        protected ApplicationManager _manager;




        [OneTimeSetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
            loginHelper = new LoginHelper(app);
            navigationHelper = new NavigationHelper(app);
            projectHelper = new ProjectHelper(app);
            _manager = new ApplicationManager();

        }

        public static Random rnd = new Random();

        public static string GenerateRandomString(int max)
        {
            int l = Convert.ToInt32(rnd.NextDouble() * max);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < l; i++)
            {
                builder.Append(Convert.ToChar(32 + Convert.ToInt32(rnd.NextDouble() * 65)));
            }
            return builder.ToString();
        }
    }
}
