using System.Data.SqlClient;

namespace 学生选课_成绩管理系统
{
    public class SQLConnection
    {
        public static SqlConnection SqlConnection = new SqlConnection(@"server =.; database=JWGLDB;integrated security = sspi");
    }
}
