using System.Transactions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PollingScheduler.DataBase;
using PollingScheduler.DataBase.DBServices;
using PollingScheduler.GitHubModels;
using Xunit;

namespace GitHubEventPolling.Test
{
    public class ContributorIntegrationTest :IDisposable
    {
        private TransactionScope _scope;

        public ContributorIntegrationTest()
        {
            _scope =   new TransactionScope(); 
        }

        public void Dispose()
        {
            _scope.Dispose();
        }

        [Fact]
        public void ContributorIntegrationTest_save_success()
        {
           
            string UserId = "admin";
            string hostName = "database-1.c42lxbt48cts.us-east-1.rds.amazonaws.com,1433";
            string Database = "ProductivityTracker";
            string password = "19901231";

            string connectionString =
                $"Data Source={hostName};Initial Catalog={Database};User ID={UserId};Password={password}";
            ContributorDataBaseService contributorDataBaseService = new ContributorDataBaseService();
            bool isSuccess = contributorDataBaseService.SaveContributor(new List<Contributor>
                    {
                        new Contributor { Id =787, Login = "Test User", Contributions = 0, Node_Id = "jjj" },
                    });
            Assert.True(isSuccess);
        }
    }
}