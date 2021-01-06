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
    public class SingerResponsitory : DataUtil
    {
        private static AccountRespository accountRespository = new AccountRespository();

        public List<SingerDto> getList()
        {
            List<SingerDto> li = new List<SingerDto>();
            String strSql = "select * from singer c";
            Connection.Open();
            SqlCommand cmd = new SqlCommand(strSql, Connection);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                SingerDto sig = new SingerDto();
                Account account = new Account();
                sig.SingerId = Convert.ToInt32(rd["singer_id"]);
                sig.Name = (string)rd["name"];
                sig.ImagePath = (string)rd["image_path"];
                sig.CreateDate = (DateTime)rd["create_date"];
                sig.CreateBy = Convert.ToInt32(rd["create_by"]);
                account = accountRespository.getById(sig.CreateBy);
                sig.CreatePeople = account.Fullname;
                sig.UpdateDate = (DateTime)rd["update_date"];
                sig.UpdateBy = Convert.ToInt32(rd["update_by"]);
                account = accountRespository.getById(sig.UpdateBy);
                sig.UpdatePeople = account.Fullname;

                li.Add(sig);
            }
            Connection.Close();
            return li;
        }
        public void Xoa(int singer_id)
        {
            Connection.Open();
            string strSql = "Delete from singer where singer_id=@singer_id";
            SqlCommand cmd = new SqlCommand(strSql, Connection);
            cmd.Parameters.AddWithValue("singer_id", singer_id);
            cmd.ExecuteNonQuery();
            Connection.Close();
        }
        public void Them(Singer sig)
        {
            Connection.Open();
            string strSql = "insert into singer(name,image_path,create_date,create_by,update_date,update_by) values(@name,@img,@cd,@cb,@ud,@ub)";
            SqlCommand cmd = new SqlCommand(strSql, Connection);
            cmd.Parameters.AddWithValue("name", sig.Name);
            cmd.Parameters.AddWithValue("img", sig.ImagePath);
            cmd.Parameters.AddWithValue("cd", sig.CreateDate);
            cmd.Parameters.AddWithValue("cb", sig.CreateBy);
            cmd.Parameters.AddWithValue("ud", sig.UpdateDate);
            cmd.Parameters.AddWithValue("ub", sig.UpdateBy);
            cmd.ExecuteNonQuery();
            Connection.Close();
        }
        public Singer getById(long id)
        {
            Connection.Open();
            string strSql = "select * from singer where singer_id = @id";
            SqlCommand cmd = new SqlCommand(strSql, Connection);
            cmd.Parameters.AddWithValue("id", id);
            SqlDataReader rd = cmd.ExecuteReader();
            Singer s = null;
            if (rd.Read())
            {
                s = new Singer();
                s.SingerId = (int)rd["singer_id"];
                s.Name = (string)rd["name"];
                s.CreateDate = (DateTime)rd["create_date"];
                s.CreateBy = (int)rd["create_by"];
                s.UpdateDate = (DateTime)rd["update_date"];
                s.UpdateBy = (int)rd["update_by"];
            }
            Connection.Close();

            return s;
        }
        public void onUpdate(Singer com)
        {
            Connection.Open();
            string strSql = "update singer " +
                " set name = @name," +
                " image_path = @imagePath," +
                " update_date = @ud," +
                " update_by = @ub " +
                " where singer_id = @id";
            SqlCommand cmd = new SqlCommand(strSql, Connection);
            cmd.Parameters.AddWithValue("name", com.Name);
            cmd.Parameters.AddWithValue("imagePath", com.ImagePath);
            cmd.Parameters.AddWithValue("ud", com.UpdateDate);
            cmd.Parameters.AddWithValue("ub", com.UpdateBy);
            cmd.Parameters.AddWithValue("id", com.SingerId);
            cmd.ExecuteNonQuery();
            Connection.Close();
        }
    }
}