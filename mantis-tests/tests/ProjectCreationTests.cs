using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static mantis_tests.APIHelper;

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

            IList<ApiProject> oldProjects = APIHelper.APICountOfProjects(account);
            projectHelper.InitCreation();

            projectHelper.FillProjectForm(project);
            projectHelper.SubmitCreation();
            IList<ApiProject> newProjects = APIHelper.APICountOfProjects(account);
            Assert.That(newProjects.Count, Is.EqualTo(oldProjects.Count + 1));
        }
    }
}
