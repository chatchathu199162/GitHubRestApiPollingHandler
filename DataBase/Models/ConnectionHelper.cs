namespace PollingScheduler.DataBase.Models
{
    public class ConnectionHelper
    {

        public static string GetRDSConnectionString()
        {


            string dbname = "ProductivityTracker";

            if (string.IsNullOrEmpty(dbname)) return null;

            string username = "admin";
            string password = "19901231";
            string hostname = "database-1.c42lxbt48cts.us-east-1.rds.amazonaws.com,1433";
            string port = "1433";

            return "Data Source=" + hostname + ";Initial Catalog=" + dbname + ";User ID=" + username + ";Password=" +
                   password + ";";
        }
    }
}
