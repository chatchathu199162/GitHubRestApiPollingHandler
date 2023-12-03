using PollingScheduler.GitHubModels;

namespace PollingScheduler.Interfaces
{
    public interface ICommitSatatService
    {
        public Task<List<WeekCommitStat>> GetCommitsPerWeekByContributor();
    }
}
