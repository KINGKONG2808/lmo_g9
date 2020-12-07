using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.Sql;
using LMO_G9.util;

namespace LMO_G9.util
{
    public class DataUtil
    {
        SqlConnection connection;

        public DataUtil()
        {
            string connectString = Constant.CONNECTING_STRING_K2;
            connection = new SqlConnection(connectString);
        }


    }
}