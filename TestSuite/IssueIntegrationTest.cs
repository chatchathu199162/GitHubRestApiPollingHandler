using System.Transactions;
using PollingScheduler.DataBase.DBServices;
using PollingScheduler.GitHubModels;

namespace TestSuite
{
    public class IssueIntegrationTest : IDisposable
    {
        private TransactionScope _scope;
        public IssueIntegrationTest()
        {
            _scope = new TransactionScope();
        }
        public void Dispose()
        {
            _scope.Dispose();
        }

        [Fact]
        public void IssueIntegrationTeston_save_success()
        {
           IssuesDataService dataDataService = new IssuesDataService();
           List<Issue> issues = new List<Issue>();
           Issue issue = new Issue()
           {
               Body = "Not competing request",
               ContributorId = 12,
               Created_At = DateTime.Now
           };
           issues.Add(issue);
           var  isSuccess =dataDataService.SaveIssueDataPerContributor(issues);
           
            Assert.True(isSuccess);
        }

    }
}