using Newtonsoft.Json;
using PollingScheduler.DataBase.DBServices;
using PollingScheduler.GitHubModels;
using PollingScheduler.Interfaces;
using System.Net;

namespace PollingScheduler.Services
{
    public class PullRequestStatService : IPullRequestStatService
    {
        private readonly HttpClient client = new();
        private const string GITHUBBASEURL = "https://api.github.com";
        private const string TOKEN = "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";
        private const string ForkedRepo = "microsoft/generative-ai-for-beginners";
        private PullRequestDataService m_DataService;
        public PullRequestStatService(PullRequestDataService dataService)
        {
            m_DataService = dataService;
        }
        public async Task SavePullRequestByContributor()
        {
            client.BaseAddress = new Uri(GITHUBBASEURL);
            client.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue("AppName", "1.0"));
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Token", TOKEN);

            var response = await client.GetAsync($"repos/{ForkedRepo}/pulls");
            while (response.StatusCode != HttpStatusCode.OK)
            {
                Thread.Sleep(30);
            }

            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<PullRequest>>(responseString);
            m_DataService.SavePullRequestsByContributor(result);
        }

    }

}
