using Microsoft.Data.SqlClient;
using PollingScheduler.DataBase;
using PollingScheduler.GitHubModels;

namespace PollingScheduler.DataBase.DBServices
{
    public class PullRequestDataService
    {
        public bool SavePullRequestsByContributor(List<PullRequest> pullRequests)
        {
            try
            {
                var dbcontext = DataBaseContext.Instance;
                using (SqlConnection connection = dbcontext.GetConnection())
                {
                    connection.Open();
                    foreach (var pullRequest in pullRequests)
                    {
                        try
                        {
                            //Check for Duplicate values
                            string checkIfExistsQuery =
                                $"SELECT COUNT(*) FROM dbo.PullRequestStat WHERE Id = {pullRequest.Id}";
                            SqlCommand command11 = new SqlCommand(checkIfExistsQuery, connection);

                            int existingRecordsCount = (int)command11.ExecuteScalar();

                            if (existingRecordsCount < 1)
                            {
                                string insertQuery =
                                    $"insert  into dbo.PullRequestStat values({pullRequest.Id},{pullRequest.User.Id},'{pullRequest.Created_At.ToString()}','{pullRequest.Updated_At.ToString()}','{pullRequest.Url}')";

                                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                                {
                                    command.ExecuteNonQuery();
                                }
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                    connection.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
