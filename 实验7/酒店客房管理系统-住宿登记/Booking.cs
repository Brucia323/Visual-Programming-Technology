using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 酒店客房管理系统_住宿登记
{
    public class Booking
    {
        //获取预订的房型
        static string sql = "";
        public static SqlCommand SqlCommand = new SqlCommand(sql, SQLConnection.SqlConnection);
    }
}
