namespace PollingScheduler.GitHubModels
{
    public class PullRequest
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int pull_request_review_id { get; set; }
        public Contributor User { get; set; }
        public DateTime? Created_At { get; set; }
        public DateTime? Updated_At { get; set; }
        public string pull_request_url { get; set; }
        public string Body { get; set; }
    }

}
