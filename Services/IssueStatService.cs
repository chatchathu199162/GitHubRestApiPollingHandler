using Newtonsoft.Json;
using System.Net;
using PollingScheduler.DataBase.DBServices;
using PollingScheduler.Interfaces;
using PollingScheduler.GitHubModels;

namespace PollingScheduler.Services
{
    public class IssueStatService : IIssueStatService
    {
        private readonly HttpClient client = new();
        private const string GITHUBBASEURL = "https://api.github.com";
        private const string TOKEN = "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";
        private const string ForkedRepo = "microsoft/generative-ai-for-beginners";
        private IssuesDataService m_issuesDataService;

        public IssueStatService(IssuesDataService dataService)
        {
            m_issuesDataService = dataService;
        }
        public async Task SaveIssueByContributor()
        {
            client.BaseAddress = new Uri(GITHUBBASEURL);
            client.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue("AppName", "1.0"));
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Token", TOKEN);

            var response = await client.GetAsync($"/repos/{ForkedRepo}/issues");
            while (response.StatusCode != HttpStatusCode.OK)
            {
                Thread.Sleep(30);
            }

            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<Issue>>(responseString);
            m_issuesDataService.SaveIssueDataPerContributor(result);
        }
    }
}
