using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace 酒店客房管理系统_住宿登记
{
    public class SQLConnection
    {
        //连接数据库
        public static SqlConnection SqlConnection = new SqlConnection(@"server=.;database=JDKFGLXT;integrated security=sspi");
    }
}
