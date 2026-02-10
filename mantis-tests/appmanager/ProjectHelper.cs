using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace mantis_tests
{
    public class ProjectHelper : HelperBase
    {
        public ProjectHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void SubmitCreation()
        {
            driver.FindElement(By.XPath("//input[@value='Добавить проект']")).Click();
        }

        public void FillProjectForm()
        {
            string uniqueProjectName = "test_project_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
            driver.FindElement(By.Id("project-name")).Click();
            driver.FindElement(By.Id("project-name")).Clear();
            driver.FindElement(By.Id("project-name")).SendKeys(uniqueProjectName);
        }

        public void InitCreation()
        {
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
        }

    }
}
