using Newtonsoft.Json;
using PollingScheduler.DataBase.DBServices;
using PollingScheduler.GitHubModels;

namespace PollingScheduler.Services
{
    public class ContributorService
    {
        private readonly HttpClient client = new();
        private const string GITHUBBASEURL = "https://api.github.com";
        private const string TOKEN = "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";
        private const string USERNAME = "chatchathu199162";
        private const string REPO = "generative-ai-for-beginners";
        private readonly ContributorDataBaseService m_ContributorDataBaseService;

        public ContributorService(ContributorDataBaseService contributorDataBaseService)
        {
            m_ContributorDataBaseService = contributorDataBaseService;
        }
        public async Task<bool> SaveContributor()
        {
            try
            {
                client.BaseAddress = new Uri(GITHUBBASEURL);
                client.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue("AppName", "1.0"));
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Token", TOKEN);

                var response = await client.GetAsync($"/repos/{USERNAME}/{REPO}/contributors");
                var responseString = await response.Content.ReadAsStringAsync();
                var contributorList = JsonConvert.DeserializeObject<List<Contributor>>(responseString);
                m_ContributorDataBaseService.SaveContributor(contributorList);
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
