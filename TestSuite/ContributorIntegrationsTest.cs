using System.Transactions;
using PollingScheduler.DataBase.DBServices;
using PollingScheduler.GitHubModels;
using Xunit;

namespace TestSuite
{
    public class ContributorIntegrationsTest : IDisposable
    {
        private TransactionScope _scope;
        public ContributorIntegrationsTest()
        {
            _scope = new TransactionScope();
        }
        public void Dispose()
        {
            _scope.Dispose();
        }

        [Fact]
        public void ContributorIntegrationTest_save_success()
        {
            ContributorDataBaseService contributorDataBaseService = new ContributorDataBaseService();
            bool isSuccess = contributorDataBaseService.SaveContributor(new List<Contributor>
            {
                new Contributor { Id =787, Login = "Test User", Contributions = 0, Node_Id = "jjj" },
            });
            Assert.True(isSuccess);
        }

        [Fact]
        public void ContributorIntegrationTest_No_contributions_success()
        {
            ContributorDataBaseService contributorDataBaseService = new ContributorDataBaseService();
            bool isSuccess = contributorDataBaseService.SaveContributor(new List<Contributor>
            {
                new Contributor { Id =1111, Login = "Test User2" },
            });
            Assert.False(isSuccess);
        }
        [Fact]
        public void ContributorIntegrationTest_No_Login_success()
        {
            ContributorDataBaseService contributorDataBaseService = new ContributorDataBaseService();
            bool isSuccess = contributorDataBaseService.SaveContributor(new List<Contributor>
            {
                new Contributor { Id =1111 },
            });
            Assert.True(isSuccess);
        }
    }
}