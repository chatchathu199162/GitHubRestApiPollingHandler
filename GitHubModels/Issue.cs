namespace PollingScheduler.GitHubModels
{
    public class Issue
    {
        public int Id { get; set; }
        public string Node_Id { get; set; }
        public int Number { get; set; }
        public string Title { get; set; }
        public Contributor user { get; set; }
        public int ContributorId { get; set; }
        public string State { get; set; }
        public bool Locked { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        public string Body { get; set; }

    }
}
