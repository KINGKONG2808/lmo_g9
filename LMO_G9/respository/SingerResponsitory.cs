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
    public class SingerResponsitory : DataUtil
    {


        public List<Singer> dsSinger()
        {
            List<Singer> li = new List<Singer>();
            string strSql = "select * from singer";
            Connection.Open();
            SqlCommand cmd = new SqlCommand(strSql, Connection);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                Singer s = new Singer();
                s.SingerId = Convert.ToInt64(rd["singer_id"]);
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
        public void Xoa(int singer_id)
        {
            Connection.Open();
            string strSql = "Delete from singer where singer_id=@singer_id";
            SqlCommand cmd = new SqlCommand(strSql, Connection);
            cmd.Parameters.AddWithValue("singer_id", singer_id);
            cmd.ExecuteNonQuery();
            Connection.Close();
        }
    }
}