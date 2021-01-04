using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using LMO_G9.util;
using LMO_G9.model;
using LMO_G9.dto;
namespace LMO_G9.respository
{
    public class ComposerRepository : DataUtil
    {
        private static AccountRespository accountRespository = new AccountRespository();

        public List<ComposeDto> getList()
        {
            List<ComposeDto> li = new List<ComposeDto>();
            String strSql = "select * from composer c";
            Connection.Open();
            SqlCommand cmd = new SqlCommand(strSql, Connection);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                ComposeDto com = new ComposeDto();
                Account account = new Account();
                com.ComposerId = Convert.ToInt32(rd["composer_id"]);
                com.Name = (string)rd["name"];
                com.ImagePath = (string)rd["image_path"];
                com.CreateDate = (DateTime)rd["create_date"];
                com.CreateBy = Convert.ToInt32(rd["create_by"]);
                account = accountRespository.getById(com.CreateBy);
                com.CreatePeople = account.Fullname;
                com.UpdateDate = (DateTime)rd["update_date"];
                com.UpdateBy = Convert.ToInt32(rd["update_by"]);
                account = accountRespository.getById(com.UpdateBy);
                com.UpdatePeople = account.Fullname;

                li.Add(com);
            }
            Connection.Close();
            return li;
        }

        public void Xoa(int composer_id)
        {
            Connection.Open();
            string strSql = "Delete from composer where composer_id=@composer_id";
            SqlCommand cmd = new SqlCommand(strSql, Connection);
            cmd.Parameters.AddWithValue("composer_id", composer_id);
            cmd.ExecuteNonQuery();
            Connection.Close();
        }

        public void Them(Composer com)
        {
            Connection.Open();
            string strSql = "insert into composer(name,image_path,create_date,create_by,update_date,update_by) values(@name,@img,@cd,@cb,@ud,@ub)";
            SqlCommand cmd = new SqlCommand(strSql, Connection);
            cmd.Parameters.AddWithValue("name", com.Name);
            cmd.Parameters.AddWithValue("img", com.ImagePath);
            cmd.Parameters.AddWithValue("cd", com.CreateDate);
            cmd.Parameters.AddWithValue("cb", com.CreateBy);
            cmd.Parameters.AddWithValue("ud", com.UpdateDate);
            cmd.Parameters.AddWithValue("ub", com.UpdateBy);
            cmd.ExecuteNonQuery();
            Connection.Close();
        }
        public Composer getById(long id)
        {
            Connection.Open();
            string strSql = "select * from composer where composer_id = @id";
            SqlCommand cmd = new SqlCommand(strSql, Connection);
            cmd.Parameters.AddWithValue("id", id);
            SqlDataReader rd = cmd.ExecuteReader();
            Composer s = null;
            if (rd.Read())
            {
                s = new Composer();
                s.ComposerId = (int)rd["composer_id"];
                s.Name = (string)rd["name"];
                s.CreateDate = (DateTime)rd["create_date"];
                s.CreateBy = (int)rd["create_by"];
                s.UpdateDate = (DateTime)rd["update_date"];
                s.UpdateBy = (int)rd["update_by"];
            }
            Connection.Close();

            return s;
        }
        public void onUpdate(Composer com)
        {
            Connection.Open();
            string strSql = "update composer " +
                " set name = @name," +
                " update_date = @ud," +
                " update_by = @ub " +
                " where composer_id = @id";
            SqlCommand cmd = new SqlCommand(strSql, Connection);
            cmd.Parameters.AddWithValue("name", com.Name);
            cmd.Parameters.AddWithValue("ud", com.UpdateDate);
            cmd.Parameters.AddWithValue("ub", com.UpdateBy);
            cmd.Parameters.AddWithValue("id", com.ComposerId);
            cmd.ExecuteNonQuery();
            Connection.Close();
        }
    }
}