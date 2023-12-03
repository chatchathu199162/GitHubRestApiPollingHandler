namespace PollingScheduler.GitHubModels
{
    public class WeekCommitStat
    {
        public int Total { get; set; }
        public List<WeekData> Weeks { get; set; }
        /// <summary>
        /// This is the contributor of the code.
        /// </summary>
        public Author Author { get; set; }

    }

    public class WeekData
    {
        /// <summary>
        /// Start of the week, given as a Unix timestamp.
        /// </summary>
        public int w { get; set; }
        /// <summary>
        /// Number of Addition
        /// </summary>
        public int a { get; set; }
        /// <summary>
        /// Number of Deletion
        /// </summary>
        public int d { get; set; }
        /// <summary>
        /// Number of Commits
        /// </summary>
        public int c { get; set; }

    }
    public class Author
    {
        public string Login { get; set; }
        public int Id { get; set; }
        public string Url { get; set; }

    }
}
