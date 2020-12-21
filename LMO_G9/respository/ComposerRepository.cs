using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using LMO_G9.util;
using LMO_G9.model;

namespace LMO_G9.respository
{
    public class ComposerRepository : DataUtil
    {
        public List<Composer> dsComposer()
        {
            List<Composer> li = new List<Composer>();
            string strSql = "select * from composer";
            Connection.Open();
            SqlCommand cmd = new SqlCommand(strSql, Connection);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                Composer s = new Composer();
                s.ComposerId = Convert.ToInt32(rd["composer_id"]);
                s.Name = (string)rd["name"];
                s.ImagePath = (string)rd["image_path"];
                s.CreateBy = Convert.ToInt32(rd["create_by"]);
                s.CreateDate = (DateTime)rd["create_date"];
                s.UpdateBy = Convert.ToInt32(rd["update_by"]);
                s.UpdateDate = (DateTime)rd["update_date"];
                li.Add(s);
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

        public void Them(Composer s)
        {
            Connection.Open();
            string sql = "insert into composer(name,image_path,create_by,create_date,update_by,update_date) values(@name,@imgpath,@cb,@cd,@ub,@ud)";
            SqlCommand cmd = new SqlCommand(sql, Connection);
            cmd.Parameters.AddWithValue("name", s.Name);
            cmd.Parameters.AddWithValue("imgpath", s.ImagePath);
            cmd.Parameters.AddWithValue("cb", s.CreateBy);
            cmd.Parameters.AddWithValue("cd", s.CreateDate);
            cmd.Parameters.AddWithValue("ub", s.UpdateBy);
            cmd.Parameters.AddWithValue("ud", s.UpdateDate);
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
        public void onUpdate(Composer s)
        {
            Connection.Open();
            string strSql = "update composer " +
                " set name = @name," +
                " set image_path = @imgpath," +
                " update_date = @ud," +
                " update_by = @ub " +
                " where category_id = @id";
            SqlCommand cmd = new SqlCommand(strSql, Connection);
            cmd.Parameters.AddWithValue("name", s.Name);
            cmd.Parameters.AddWithValue("imgpath", s.ImagePath);
            cmd.Parameters.AddWithValue("ud", s.UpdateDate);
            cmd.Parameters.AddWithValue("ub", s.UpdateBy);
            cmd.Parameters.AddWithValue("id", s.ComposerId);
            cmd.ExecuteNonQuery();
            Connection.Close();
        }
    }
}