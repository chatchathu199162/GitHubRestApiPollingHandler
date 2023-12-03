using Microsoft.Data.SqlClient;

namespace PollingScheduler.DataBase
{
    public sealed class DataBaseContext
    {

        private static DataBaseContext instance;
        private static readonly object lockObject = new object();
        private SqlConnection dbConnection; // Replace with your actual database connection type

        private DataBaseContext()
        {
            string UserId = "admin";
            string hostName = "database-1.c42lxbt48cts.us-east-1.rds.amazonaws.com,1433";
            string Database = "ProductivityTracker";
            string password = "19901231";
            string connectionString = $"Data Source={hostName};Initial Catalog={Database};User ID={UserId};Password={password}";
            // Initialize the database connection here
            dbConnection = new SqlConnection(connectionString);
        }

        public static DataBaseContext Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            instance = new DataBaseContext();
                        }
                    }
                }
                return instance;
            }
        }

        public SqlConnection GetConnection()
        {
            return dbConnection;
        }
    }

}
