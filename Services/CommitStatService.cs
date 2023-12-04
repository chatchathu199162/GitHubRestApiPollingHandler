using System.Net;
using Newtonsoft.Json;
using PollingScheduler.DataBase.DBServices;
using PollingScheduler.GitHubModels;
using PollingScheduler.Interfaces;

namespace PollingScheduler.Services
{
    public class CommitStatService : ICommitSatatService
    {
        private readonly HttpClient client = new();
        private const string GITHUBBASEURL = "https://api.github.com";
        private const string TOKEN = "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";
        private const string USERNAME = "chatchathu199162";
        private const string REPO = "generative-ai-for-beginners";
        private readonly CommitStatDataService m_CommitStatDataService;

        public CommitStatService(CommitStatDataService commitStatDataService)
        {
            m_CommitStatDataService = commitStatDataService;
        }
        public async Task<List<WeekCommitStat>> GetCommitsPerWeekByContributor()
        {
            try
            {
                client.BaseAddress = new Uri(GITHUBBASEURL);
                client.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue("AppName", "1.0"));
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Token", TOKEN);

                var response = await client.GetAsync($"/repos/{USERNAME}/{REPO}/stats/contributors");
                while (response.StatusCode == HttpStatusCode.Accepted)
                {
                    while (response.StatusCode != HttpStatusCode.OK)
                    {
                        Thread.Sleep(30);
                        response = await client.GetAsync($"/repos/{USERNAME}/{REPO}/stats/contributors");

                    }

                }

                var responseString = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<WeekCommitStat>>(responseString);
                m_CommitStatDataService.SaveContributorCommitHistory(result);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
