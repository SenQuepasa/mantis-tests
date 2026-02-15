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
        public void projectCreate()
        {
            loginHelper.Login();
            navigationHelper.GoToManagePage();
            navigationHelper.GoToProjectsPage();
            IList<IWebElement> oldProjects = projectHelper.CountOfProjects();
            projectHelper.InitCreation();

            ProjectData project = new ProjectData("test_project_" + DateTime.Now.ToString("yyyyMMdd_HHmmss"));
            projectHelper.FillProjectForm(project);
            projectHelper.SubmitCreation();
            IList<IWebElement> newProjects = projectHelper.CountOfProjects();
            Assert.That(newProjects.Count, Is.EqualTo(oldProjects.Count + 1));
        }
    }
}
