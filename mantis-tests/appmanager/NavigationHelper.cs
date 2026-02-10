using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class NavigationHelper : HelperBase
    {
        public NavigationHelper(ApplicationManager manager) : base(manager) { }

        public void GoToManagePage()
        {
            driver.Navigate().GoToUrl("http://localhost/mantisbt/manage_overview_page.php");
        }
        public void GoToProjectsPage()
        {
            driver.Navigate().GoToUrl("http://localhost/mantisbt/manage_proj_page.php");
        }
    }
}