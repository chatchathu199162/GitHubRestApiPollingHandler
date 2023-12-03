using PollingScheduler.Interfaces;

namespace PollingScheduler.HostedService
{
    public class GitHubRestPollingWorker : BackgroundService
    {
        private readonly IServiceProvider m_serviceProvider;

        public GitHubRestPollingWorker(IServiceProvider serviceProvider)
        {
            m_serviceProvider = serviceProvider;
        }
        //Background service will run for 2 times a day.
        private int pollingInterval = 12 * 3600 * 1000;
        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {

                while (!stoppingToken.IsCancellationRequested)
                {
                    using (var scope = m_serviceProvider.CreateScope())
                    {
                        var commitStatService = scope.ServiceProvider.GetService<ICommitSatatService>();
                        var IssueStatService = scope.ServiceProvider.GetService<IIssueStatService>();
                        var pullRequestService = scope.ServiceProvider.GetService<IPullRequestStatService>();

                        await commitStatService.GetCommitsPerWeekByContributor();
                        await IssueStatService.SaveIssueByContributor();
                        await pullRequestService.SavePullRequestByContributor();

                    }

                    await Task.Delay(pollingInterval);
                }
            }
            catch (OperationCanceledException ex)
            {
            }
            catch (Exception ex)
            {

            }
        }
    }
}
