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
            string connectString = Constant.CONNECTING_STRING_HIEU;
            Connection = new SqlConnection(connectString);
        }

        public SqlConnection Connection { get => connection; set => connection = value; }

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
                s.ComposerId = Convert.ToInt64(rd["composer_id"]);
                s.MusicId = Convert.ToInt64(rd["music_id"]);
                s.Name = (string)rd["name"];
                s.ImagePath = (string)rd["image_path"];
                s.CreateBy = Convert.ToInt64(rd["create_by"]);
                s.CreateDate = (DateTime)rd["create_date"];
                s.UpdateBy = Convert.ToInt64(rd["update_by"]);
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
            string sql = "insert into sinhvien(name,imagePath) values(@name,@imgpath)";
            SqlCommand cmd = new SqlCommand(sql, Connection);
            cmd.Parameters.AddWithValue("name", s.Name);
            cmd.Parameters.AddWithValue("imgpath", s.ImagePath);
            cmd.ExecuteNonQuery();
            Connection.Close();
        }
    }
}