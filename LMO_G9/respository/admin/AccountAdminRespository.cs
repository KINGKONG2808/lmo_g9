using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LMO_G9.util;
using LMO_G9.model;
using System.Data.SqlClient;
using System.Data.Sql;

namespace LMO_G9.respository
{
    public class AccountAdminRespository : DataUtil
    {
        public Account checkExistsEmail(string username, string password)
        {
            Connection.Open();
            Account account = new Account();
            string sb = "select * from account acc where acc.username = @username and acc.password = @password";
            SqlCommand cmd = new SqlCommand(sb, Connection);
            cmd.Parameters.AddWithValue("username", username);
            cmd.Parameters.AddWithValue("password", password);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                account.AccountId = Convert.ToInt64(rd["account_id"]);
                account.Fullname = (string)rd["fullname"];
                account.Address = (string)rd["address"];
                account.DateOfBirth = (DateTime)rd["date_of_birth"];
                account.Username = (string)rd["username"];
                account.Password = (string)rd["password"];
                account.AvatarPath = (string)rd["avatar_path"];
            }
            Connection.Close();
            return account;
        }
    }
}