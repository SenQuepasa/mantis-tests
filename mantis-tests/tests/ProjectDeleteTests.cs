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
    public class ProjectDeleteTests : TestBase
    {
        [Test]
        public void projectDelete()
        {
            loginHelper.Login();
            navigationHelper.GoToManagePage();
            navigationHelper.GoToProjectsPage();
            IList<IWebElement> oldProjects = projectHelper.CountOfProjects();
            projectHelper.SelectProject();
            projectHelper.InitDel();
            projectHelper.ConfirmDel();
            IList<IWebElement> newProjects = projectHelper.CountOfProjects();
            Assert.That(newProjects.Count, Is.EqualTo(oldProjects.Count - 1));
        }
    }
}