using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

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
            projectHelper.InitCreation();
            projectHelper.FillProjectForm();
            projectHelper.SubmitCreation();
        }

      
    }
}
