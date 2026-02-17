using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace mantis_tests
{
    public class ProjectCreationTests : TestBase
    {
        [Test]
        //public void projectCreate()
        //{
        //    loginHelper.Login();
        //    navigationHelper.GoToManagePage();
        //    navigationHelper.GoToProjectsPage();
        //    ProjectData project = new ProjectData("test_project_" + DateTime.Now.ToString("yyyyMMdd_HHmmss"));
        //    AccountData account = new AccountData("administrator", "root");

        //    IList<IWebElement> oldProjects = APIHelper.APICountOfProjects(account, project);
        //    projectHelper.InitCreation();

        //    projectHelper.FillProjectForm(project);
        //    projectHelper.SubmitCreation();
        //    IList<IWebElement> newProjects = projectHelper.CountOfProjects();
        //    Assert.That(newProjects.Count, Is.EqualTo(oldProjects.Count + 1));
        //}

        public void projectApiCreate()
        {
            loginHelper.Login();
            navigationHelper.GoToManagePage();
            navigationHelper.GoToProjectsPage();
            ProjectData project = new ProjectData("test_project_" + DateTime.Now.ToString("yyyyMMdd_HHmmss"));
            AccountData account = new AccountData("administrator", "root");

            IList<IWebElement> oldProjects = APIHelper.APICountOfProjects(account, project);
            projectHelper.InitCreation();

            projectHelper.FillProjectForm(project);
            projectHelper.SubmitCreation();
            IList<IWebElement> newProjects = APIHelper.APICountOfProjects(account, project);
            Assert.That(newProjects.Count, Is.EqualTo(oldProjects.Count + 1));
        }
    }
}
