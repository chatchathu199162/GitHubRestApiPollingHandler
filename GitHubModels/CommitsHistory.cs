namespace PollingScheduler.GitHubModels
{
    public class CommitsHistory
    {
        public int CommitsHistoryId { get; set; }
        public string WeekNumber { get; set; }
        public int ContributorId { get; set; }
        public string Addition { get; set; }
        public string Deletion { get; set; }


    }
}
