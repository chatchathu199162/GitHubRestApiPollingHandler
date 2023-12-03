using Microsoft.Data.SqlClient;
using PollingScheduler.GitHubModels;

namespace PollingScheduler.DataBase.DBServices
{
    public class IssuesDataService
    {
        public bool SaveIssueDataPerContributor(List<Issue> issueSet)
        {
            try
            {
                var dbcontext = DataBaseContext.Instance;
                using (SqlConnection connection = dbcontext.GetConnection())
                {
                    connection.Open();
                    foreach (var issue in issueSet)
                    {
                        try
                        {
                            //Check for Duplicate values
                            string checkIfExistsQuery = $"SELECT COUNT(*) FROM dbo.Issue WHERE Id = {issue.Id}";
                            SqlCommand command11 = new SqlCommand(checkIfExistsQuery, connection);

                            int existingRecordsCount = (int)command11.ExecuteScalar();

                            if (existingRecordsCount < 1)
                            {
                                int Locked = issue.Locked == true ? 1 : 0;
                                string insertQuery =
                                    $"insert into dbo.Issue values({issue.Id},{issue.user.Id},'{issue.Title}','{issue.State}',{Locked},'{issue.Created_At.ToString()}','{issue.Updated_At.ToString()}','{issue.Body}')";
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
