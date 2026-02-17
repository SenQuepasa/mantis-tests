using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using mantis_tests;


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
        public void projectApiDelete()
        {
            // 1. Логинимся и переходим на страницу проектов
            loginHelper.Login();
            navigationHelper.GoToManagePage();
            navigationHelper.GoToProjectsPage();

            // 2. Получаем текущий список проектов через UI
            IList<IWebElement> oldProjects = projectHelper.CountOfProjects();

            // 3. Если проектов нет — создаём один через API
            if (oldProjects.Count == 0)
            {
                Console.WriteLine("Нет проектов для удаления. Создаём проект через API...");

                // Данные для авторизации
                AccountData account = new AccountData("administrator", "root");

                // Новый проект
                ProjectData newProject = new ProjectData(
                    "auto_created_" + DateTime.Now.ToString("yyyyMMdd_HHmmss")
                );

                // Создаём через API
                APIHelper apiHelper = new APIHelper(_manager); // Передаём ApplicationManager
                                                               // Создаём экземпляр APIHelper
                // Вызываем метод через экземпляр
                string projectId = apiHelper.CreateProjectViaApi(account, newProject);

                Console.WriteLine($"Проект создан через API. ID: {projectId}");

                // Обновляем список проектов после создания
                oldProjects = projectHelper.CountOfProjects();
            }

            // 4. Теперь точно есть проекты — выбираем один и удаляем
            projectHelper.SelectProject(); // Выбираем первый проект в списке
            projectHelper.InitDel();     // Начинаем удаление
            projectHelper.ConfirmDel();   // Подтверждаем удаление


            // 5. Получаем новый список проектов
            IList<IWebElement> newProjects = projectHelper.CountOfProjects();

            // 6. Проверяем, что количество уменьшилось на 1
            Assert.That(newProjects.Count, Is.EqualTo(oldProjects.Count - 1));
        }
    }
}