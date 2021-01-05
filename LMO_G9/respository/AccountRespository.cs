using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LMO_G9.util;
using LMO_G9.model;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Text;

namespace LMO_G9.respository
{
    public class AccountRespository : DataUtil
    {
        public Account checkExistsAccount(int? accountId, string username, string password, int? roleId)
        {
            Connection.Open();
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from account where 1 = 1 ");
            if (accountId != null)
            {
                sb.Append(" and account_id = @accountId ");
            }
            if (username != null)
            {
                sb.Append(" and username = @username ");
            }
            if (password != null)
            {
                sb.Append(" and password = @password ");
            }
            if (roleId != null)
            {
                sb.Append(" and role_id = @roleId ");
            }

            SqlCommand cmd = new SqlCommand(sb.ToString(), Connection);
            if (accountId != null)
            {
                cmd.Parameters.AddWithValue("accountId", accountId);
            }
            if (username != null)
            {
                cmd.Parameters.AddWithValue("username", username);
            }
            if (password != null)
            {
                cmd.Parameters.AddWithValue("password", password);
            }
            if (roleId != null)
            {
                cmd.Parameters.AddWithValue("roleId", roleId);
            }
            SqlDataReader rd = cmd.ExecuteReader();
            Account account = pushDataAccount(rd);
            Connection.Close();
            return account;
        }

        public void createAccount(Account account)
        {
            Connection.Open();
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into account(" +
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
                "@updateBy)");
            SqlCommand cmd = new SqlCommand(sb.ToString(), Connection);
            cmd.Parameters.AddWithValue("fullname", account.Fullname);
            cmd.Parameters.AddWithValue("address", account.Address);
            cmd.Parameters.AddWithValue("dateOfBirth", account.DateOfBirth);
            cmd.Parameters.AddWithValue("roleId", account.RoleId);
            cmd.Parameters.AddWithValue("username", account.Username);
            cmd.Parameters.AddWithValue("password", account.Password);
            cmd.Parameters.AddWithValue("avatarPath", Constant.NO_PATH_AVATAR);
            cmd.Parameters.AddWithValue("createDate", DateTime.Now);
            cmd.Parameters.AddWithValue("createBy", account.CreateBy);
            cmd.Parameters.AddWithValue("updateDate", DateTime.Now);
            cmd.Parameters.AddWithValue("updateBy", account.UpdateBy);
            cmd.ExecuteNonQuery();
            Connection.Close();
        }

        public void updateAccount(Account account)
        {
            Connection.Open();
            StringBuilder sb = new StringBuilder();
            sb.Append("update account set " +
                "fullname = @fullname, " +
                "address = @address, " +
                "date_of_birth = @dateOfBirth, " +
                "username = @username, " +
                "password = @password, " +
                "avatar_path = @avatarPath, " +
                "create_by = @createBy, " +
                "update_by = @updateBy, " +
                "update_date = @updateDate " +
                "where account_id = @accountId");
            SqlCommand cmd = new SqlCommand(sb.ToString(), Connection);
            cmd.Parameters.AddWithValue("fullname", account.Fullname);
            cmd.Parameters.AddWithValue("address", account.Address);
            cmd.Parameters.AddWithValue("dateOfBirth", account.DateOfBirth);
            cmd.Parameters.AddWithValue("username", account.Username);
            cmd.Parameters.AddWithValue("password", account.Password);
            cmd.Parameters.AddWithValue("avatarPath", account.AvatarPath);
            cmd.Parameters.AddWithValue("createBy", account.CreateBy);
            cmd.Parameters.AddWithValue("updateDate", DateTime.Now);
            cmd.Parameters.AddWithValue("updateBy", account.UpdateBy);
            cmd.Parameters.AddWithValue("accountId", account.AccountId);
            cmd.ExecuteNonQuery();
            Connection.Close();
        }

        public void resetPasswordAccount(string username)
        {
            Connection.Open();
            StringBuilder sb = new StringBuilder();
            sb.Append("update account set password = " + Constant.DEFAULT_PASSWORD + " where username = @username");
            SqlCommand cmd = new SqlCommand(sb.ToString(), Connection);
            cmd.Parameters.AddWithValue("username", username);
            cmd.ExecuteNonQuery();
            Connection.Close();
        }

        public Account pushDataAccount(SqlDataReader rd)
        {
            Account account = new Account();
            while (rd.Read())
            {
                account = setAccount(rd);
            }
            return account;
        }

        public List<Account> pushDataAccountList(SqlDataReader rd)
        {
            List<Account> accounts = new List<Account>();
            while (rd.Read())
            {
                Account account = setAccount(rd);
                accounts.Add(account);
            }
            return accounts;
        }

        public Account setAccount(SqlDataReader rd)
        {
            Account account = new Account();
            account.AccountId = Convert.ToInt32(rd["account_id"]);
            account.Fullname = (string)rd["fullname"];
            account.Address = rd["address"] == DBNull.Value ? null : (string)rd["address"];
            account.DateOfBirth = (DateTime)rd["date_of_birth"];
            account.RoleId = Convert.ToInt32(rd["role_id"]);
            account.Username = (string)rd["username"];
            account.Password = (string)rd["password"];
            account.AvatarPath = rd["avatar_path"] == DBNull.Value ? null : (string)rd["avatar_path"];
            account.CreateBy = Convert.ToInt32(rd["create_by"]);
            account.CreateDate = (DateTime)rd["create_date"];
            account.UpdateBy = Convert.ToInt32(rd["update_by"]);
            account.UpdateDate = (DateTime)rd["update_date"];
            return account;
        }

        public Account getById(long id)
        {
            Connection.Open();
            string strSql = "select * from account where account_id = @id";
            SqlCommand cmd = new SqlCommand(strSql, Connection);
            cmd.Parameters.AddWithValue("id", id);
            SqlDataReader rd = cmd.ExecuteReader();
            Account account = pushDataAccount(rd);
            Connection.Close();
            return account;
        }
    }
}