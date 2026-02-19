using mantis_tests.Mantis;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;
using SimpleBrowser.WebDriver;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Drawing;



namespace mantis_tests
{
    public class APIHelper : HelperBase
    {
        public APIHelper(ApplicationManager manager) : base(manager)
        {
        }
        public class ApiProject
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Status { get; set; } // например, "active", "closed"
            // другие поля из MantisConnect WSDL

            public ApiProject(Mantis.ProjectData project)
            {
                Id = project.id;
                Name = project.name;
                Status = project.status.name;
            }
        }
        // Метод для создания проекта через MantisConnect
        public string CreateProjectViaApi(AccountData account, ProjectData project)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();

            try
            {
                Mantis.ProjectData soapProject = ConvertToSoapProject(project);
                string projectId = client.mc_project_add(
                    account.Name,
                    account.Password,
                    soapProject
                );
                return projectId;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Не удалось создать проект через MantisConnect", ex);
            }
        }

        private static Mantis.ProjectData ConvertToSoapProject(ProjectData localProject)
        {
            return new Mantis.ProjectData
            {
                name = localProject.Name,           // Имя проекта
                                                    // Добавьте другие поля, если они есть в WSDL
                                                    // description = localProject.Description,
                                                    // access_level = localProject.AccessLevel,
            };
        }
        public void CreateNewIssue(AccountData account, ProjectData project, IssueData issueData)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.IssueData issue = new Mantis.IssueData();
            issue.summary = issueData.Summary;
            issue.description = issueData.Description;
            issue.category = issueData.Category;
            issue.project = new Mantis.ObjectRef();
            issue.project.id = project.Id;
            client.mc_issue_add(account.Name, account.Password, issue);

        }

        public static IList<ApiProject> APICountOfProjects(AccountData account)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            IList<ApiProject> projectsList = new List<ApiProject>();

            try
            {
                var soapProjects = client.mc_projects_get_user_accessible(account.Name, account.Password);

                foreach (var soapProject in soapProjects)
                {
                    projectsList.Add(new ApiProject(soapProject));
                }
                return projectsList;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Не удалось получить проекты через MantisConnect", ex);
            }
            finally
            {
                if (client.State != CommunicationState.Closed)
                    client.Close();
            }
        }

        public static void DeleteProjectViaApi(AccountData account, string projectId)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();

            try
            {
                client.mc_project_delete(account.Name, account.Password, projectId);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Не удалось удалить проект через MantisConnect", ex);
            }
        }
        public class MockWebElement : IWebElement
{
    private readonly string _text;

    public MockWebElement(string text)
    {
        _text = text;
    }

    // Свойства
    public string Text => _text;
    public bool Displayed => true;
    public bool Enabled => true;
    public string TagName => "span";
    public string Id => null;
    public bool Selected => false;
    public System.Drawing.Point Location => new System.Drawing.Point(0, 0);
    public System.Drawing.Size Size => new System.Drawing.Size(0, 0);
            
    public void Clear() { }
    public void Click() { }
    public string GetAttribute(string attributeName) => null;
    public string GetCssValue(string propertyName) => null;
    public ISearchContext Parent => null;

    public IWebElement FindElement(By by) => 
        throw new System.NotImplementedException("FindElement не поддерживается в MockWebElement");


    public ReadOnlyCollection<IWebElement> FindElements(By by) =>
        new ReadOnlyCollection<IWebElement>(new List<IWebElement>());

    public void Submit() { }
    public void SendKeys(string text) { } 
    public string GetDomAttribute(string name) => null;
    public string GetDomProperty(string name) => null;
    public ISearchContext GetShadowRoot() => null;
}

    }

}