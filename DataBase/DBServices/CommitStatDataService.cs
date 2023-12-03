using Microsoft.Data.SqlClient;
using PollingScheduler.DataBase;
using PollingScheduler.GitHubModels;

namespace PollingScheduler.DataBase.DBServices
{
    public class CommitStatDataService
    {
        public bool SaveContributorCommitHistory(List<WeekCommitStat> weekCommitbyContributorList)
        {
            try
            {
                var dbcontext = DataBaseContext.Instance;
                using (SqlConnection connection = dbcontext.GetConnection())
                {
                    connection.Open();
                    foreach (var commitStat in weekCommitbyContributorList)
                    {
                        //Check for Duplicate values

                        foreach (var weekData in commitStat.Weeks)
                        {

                            string checkIfExistsQuery =
                                $"SELECT COUNT(*) FROM dbo.CommitHistory WHERE WeekNumber = {weekData.w} and Contributor= {commitStat.Author.Id}";
                            using SqlCommand checkCommand = new SqlCommand(checkIfExistsQuery, connection);

                            int existingRecordsCount = (int)checkCommand.ExecuteScalar();
                            if (existingRecordsCount < 1)
                            {

                                string insertQuery =
                                    $"insert into dbo.CommitHistory values({weekData.w},{commitStat.Author.Id},{weekData.c},{weekData.a},{weekData.d})";
                                using SqlCommand command = new SqlCommand(insertQuery, connection);
                                command.ExecuteNonQuery();
                            }
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
