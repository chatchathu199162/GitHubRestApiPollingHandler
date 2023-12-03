using Microsoft.Data.SqlClient;
using PollingScheduler.GitHubModels;
using System.Data;


namespace PollingScheduler.DataBase.DBServices
{
    public class DeveloperIqDataService
    {
        SqlConnection conn;

        public DeveloperIqDataService()
        {
            string UserId = "admin";
            string hostName = "database-1.c42lxbt48cts.us-east-1.rds.amazonaws.com,1433";
            string Database = "ProductivityTracker";
            string password = "19901231";
            string connectionString = $"Data Source={hostName};Initial Catalog={Database};User ID={UserId};Password={password}";

            conn = new SqlConnection(connectionString);
        }

        public List<PullRequest> GetPullRequestByContributor(Contributor contributor)
        {
            List<PullRequest> prList = new List<PullRequest>();
            PullRequest pr = new PullRequest
            {
                User = new Contributor()
            };

            conn.Open();
            string sql = $"select * from PullRequestStat where ContributorId = {contributor.Id}";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                pr.Id = reader.GetInt32("Id");
                pr.Url = reader.GetString("PullRequestUrl");
                pr.Created_At = DateTime.Parse(reader.GetString("CreatedAt"));
                pr.Updated_At = DateTime.Parse(reader.GetString("UpdatedAt"));
                pr.User.Id = contributor.Id;
                prList.Add(pr);
            }
            conn.Close();
            return prList;
        }

        public List<Issue> GetIssueByContributor(Contributor contributor)
        {
            List<Issue> prList = new List<Issue>();
            Issue issue = new Issue();

            conn.Open();
            string sql = $"select * from dbo.Issue where ContributorId ={contributor.Id}";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                issue.Id = reader.GetInt32("Id");
                issue.Title = reader.GetString("Title");
                issue.Created_At = DateTime.Parse(reader.GetString("Created_At"));
                issue.Updated_At = DateTime.Parse(reader.GetString("Updated_At"));
                issue.ContributorId = reader.GetInt32("ContributorId");
                issue.Body = reader.GetString("Body");
                prList.Add(issue);
            }
            conn.Close();
            return prList;
        }

        public List<WeekData> GetCommitsByContributor(Contributor contributor)
        {
            List<WeekData> prList = new List<WeekData>();
            WeekData weekCommits = new WeekData();

            conn.Open();
            string sql = $"select * from dbo.CommitHistory where Contributor ={contributor.Id}";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                // weekCommits.w = reader.GetInt64("WeekNumber");
                weekCommits.a = reader.GetInt32("Addition");
                weekCommits.d = reader.GetInt32("Deletion");
                weekCommits.c = reader.GetInt32("NumberOfCommits");
                prList.Add(weekCommits);
            }
            conn.Close();
            return prList;
        }

    }
}
