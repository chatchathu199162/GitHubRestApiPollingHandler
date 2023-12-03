using Microsoft.Data.SqlClient;
using PollingScheduler.DataBase;
using PollingScheduler.GitHubModels;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PollingScheduler.DataBase.DBServices
{
    public class ContributorDataBaseService
    {
        public bool SaveContributor(List<Contributor> contributors)
        {
            try
            {
                var dbcontext = DataBaseContext.Instance;
                using (SqlConnection connection = dbcontext.GetConnection())
                {
                    connection.Close();
                    foreach (var contributor in contributors)
                    {
                        connection.Open();
                        //Check for Duplicate values
                        string checkIfExistsQuery =
                            $"SELECT COUNT(*) FROM dbo.Contributor WHERE Id = {contributor.Id}";
                        SqlCommand command11 = new SqlCommand(checkIfExistsQuery, connection);

                        int existingRecordsCount = (int)command11.ExecuteScalar();

                        if (existingRecordsCount < 1)
                        {
                            string insertQuery =
                                $"insert into dbo.Contributor values({contributor.Id},'{contributor.Login}','{contributor.Node_Id}','{contributor.Url}','{contributor.Avater_url}',{contributor.Contributions})";
                            using (SqlCommand command = new SqlCommand(insertQuery, connection))
                            {
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
