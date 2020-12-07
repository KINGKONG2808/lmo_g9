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
    public class AccountRespository : DataUtil
    {
        public Account checkExistsAccount(string username, string password, int roleId)
        {
            Connection.Open();
            Account account = new Account();
            string sb = "select * from account acc where acc.username = @username and acc.password = @password and acc.role_id = @roleId";
            SqlCommand cmd = new SqlCommand(sb, Connection);
            cmd.Parameters.AddWithValue("username", username);
            cmd.Parameters.AddWithValue("password", password);
            cmd.Parameters.AddWithValue("roleId", roleId);
            SqlDataReader rd = cmd.ExecuteReader();
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
            Connection.Close();
            return account;
        }
    }
}