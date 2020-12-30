using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace 酒店客房管理系统_住宿登记
{
    public class RoomAvailable
    {
        static string sql = "SELECT COUNT(*) FROM room WHERE condition = '空闲'";
        public static SqlCommand SqlCommand = new SqlCommand(sql, SQLConnection.SqlConnection);
    }
}
