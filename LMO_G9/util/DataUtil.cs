using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.Sql;
using LMO_G9.util;
using LMO_G9.model;
namespace LMO_G9.util
{
    public class DataUtil
    {
        SqlConnection connection;

        public DataUtil()
        {
            string connectString = Constant.CONNECTING_STRING_K2;
            Connection = new SqlConnection(connectString);
        }

        public Account pushDataAccount(SqlDataReader rd)
        {
            Account account = new Account();
            while (rd.Read())
            {
                account.AccountId = Convert.ToInt64(rd["account_id"]);
                account.Fullname = (string)rd["fullname"];
                account.Address = rd["address"] == DBNull.Value ? null : (string)rd["address"];
                account.DateOfBirth = (DateTime)rd["date_of_birth"];
                account.RoleId = Convert.ToInt32(rd["role_id"]);
                account.Username = (string)rd["username"];
                account.Password = (string)rd["password"];
                account.AvatarPath = rd["avatar_path"] == DBNull.Value ? null : (string)rd["avatar_path"];
            }
            return account;
        }

        public SqlConnection Connection { get => connection; set => connection = value; }
    }
}