using mantis_tests;
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


        [Test]
        public void ProjectApiDelete()
        {
            // Данные для авторизации
            AccountData account = new AccountData("administrator", "root");

            // 1. Получаем текущий список проектов через API
            IList<ApiProject> oldProjects = APIHelper.APICountOfProjects(account);

            // 2. Если проектов нет — создаём один через API
            if (oldProjects.Count == 0)
            {
                Console.WriteLine("Нет проектов для удаления. Создаём проект через API...");

                ProjectData newProject = new ProjectData(
                    "auto_created_" + DateTime.Now.ToString("yyyyMMdd_HHmmss")
                );

                APIHelper apiHelper = new APIHelper(_manager);
                string projectId = apiHelper.CreateProjectViaApi(account, newProject);

                Console.WriteLine($"Проект создан через API. ID: {projectId}");

                // Обновляем список проектов после создания
                oldProjects = APIHelper.APICountOfProjects(account);
            }

            // 3. Выбираем проект для удаления (например, первый в списке)
            ApiProject projectToDelete = oldProjects.First();

            // 4. Удаляем проект через API
            APIHelper.DeleteProjectViaApi(account, projectToDelete.Id);
            // 5. Получаем новый список проектов через API
            IList<ApiProject> newProjects = APIHelper.APICountOfProjects(account);

            // 6. Проверяем, что количество уменьшилось на 1
            Assert.That(newProjects.Count, Is.EqualTo(oldProjects.Count - 1));

            // Дополнительно: проверяем, что удалённый проект отсутствует в списке
            Assert.That(newProjects, Is.Not.Contains(projectToDelete));
        }
    }
}