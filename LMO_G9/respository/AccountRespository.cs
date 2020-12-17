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
            string sb = "select * from account acc where acc.username = @username and acc.password = @password and acc.role_id = @roleId";
            SqlCommand cmd = new SqlCommand(sb, Connection);
            cmd.Parameters.AddWithValue("username", username);
            cmd.Parameters.AddWithValue("password", password);
            cmd.Parameters.AddWithValue("roleId", roleId);
            SqlDataReader rd = cmd.ExecuteReader();
            Account account = pushDataAccount(rd);
            Connection.Close();
            return account;
        }

        public Account getInforAccount(int accountId)
        {
            Connection.Open();
            string sb = "select * from account acc where acc.account_id = @accountId";
            SqlCommand cmd = new SqlCommand(sb, Connection);
            cmd.Parameters.AddWithValue("accountId", accountId);
            SqlDataReader rd = cmd.ExecuteReader();
            Account account = pushDataAccount(rd);
            Connection.Close();
            return account;
        }

        public void createAccount(Account account)
        {
            Connection.Open();
            string sb = "insert into account(" +
                "fullname, " +
                "address, " +
                "date_of_birth, " +
                "role_id, " +
                "username, " +
                "password, " +
                "avatar_path, " +
                "create_date, " +
                "create_by, " +
                "update_date, " +
                "update_by) " +
                "values (" +
                "@fullname, " +
                "@address, " +
                "@dateOfBirth, " +
                "@roleId, " +
                "@username, " +
                "@password, " +
                "@avatarPath, " +
                "@createDate, " +
                "@createBy, " +
                "@updateDate, " +
                "@updateBy)";
            SqlCommand cmd = new SqlCommand(sb, Connection);
            cmd.Parameters.AddWithValue("fullname", account.Fullname);
            cmd.Parameters.AddWithValue("address", account.Address);
            cmd.Parameters.AddWithValue("dateOfBirth", account.DateOfBirth);
            cmd.Parameters.AddWithValue("roleId", account.RoleId);
            cmd.Parameters.AddWithValue("username", account.Username);
            cmd.Parameters.AddWithValue("password", account.Password);
            cmd.Parameters.AddWithValue("avatarPath", account.AvatarPath);
            cmd.Parameters.AddWithValue("createDate", account.CreateDate);
            cmd.Parameters.AddWithValue("createBy", account.CreateBy);
            cmd.Parameters.AddWithValue("updateDate", account.UpdateDate);
            cmd.Parameters.AddWithValue("updateBy", account.UpdateBy);
            cmd.ExecuteNonQuery();
            Connection.Close();
        }
    }
}