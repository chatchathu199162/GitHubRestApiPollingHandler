using PollingScheduler.DataBase.DBServices;
using PollingScheduler.GitHubModels;
using System.Transactions;
using Xunit;


namespace TestSuite
{
    public class ComitStatIntegrationTest : IDisposable
    {
        private TransactionScope _scope;
        public ComitStatIntegrationTest()
        {
            _scope = new TransactionScope();
        }
        public void Dispose()
        {
            _scope.Dispose();
        }

        [Fact]
        public void ComitStatIntegrationTest_save_success()
        {

            CommitStatDataService contributorDataBaseService = new CommitStatDataService();
            List<WeekCommitStat> commitWeekList = new List<WeekCommitStat>();
           
            List<WeekData> weekDataList = new List<WeekData>();
            WeekData w1 = new WeekData() { a = 1, c = 1, d = 12, w = 12333 };
            WeekData w2 = new WeekData() { a = 1, c = 1, d = 12, w = 12333 };
            weekDataList.Add(w1);
            weekDataList.Add(w2);

            WeekCommitStat commitWeekStat = new WeekCommitStat()
            {
                Author = new Author() { Id = 1 },
                Weeks = weekDataList

            };
            bool isSuccess = contributorDataBaseService.SaveContributorCommitHistory(commitWeekList);
            Assert.True(isSuccess);
        }
    }
}
