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
        public void SelectProject()
        {
            driver.FindElement(By.XPath("//div[@id='main-container']/div[2]/div[2]/div/div/div[2]/div[2]/div/div[2]/table/tbody/tr/td/a")).Click();
        }
        


        public void FillProjectForm(ProjectData project)
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
        public IList<IWebElement> CountOfProjects()
        {
            driver.Navigate().GoToUrl("http://localhost/mantisbt/manage_overview_page.php");
            driver.Navigate().GoToUrl("http://localhost/mantisbt/manage_proj_page.php");
            string projects = "//div[@id='main-container']/div[2]/div[2]/div/div/div[2]/div[2]/div/div[2]/table/tbody/tr/td/a";
            IList<IWebElement> elements = driver.FindElements(By.XPath(projects));
            return elements;
        }

        public void InitDel()
        {
            driver.FindElement(By.XPath("//form[@id='manage-proj-update-form']/div/div[3]/button[2]")).Click();
        }
        public void ConfirmDel()
        {
            driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
        }
    }
}