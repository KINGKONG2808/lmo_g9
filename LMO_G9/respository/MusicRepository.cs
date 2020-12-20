using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LMO_G9.model;
using LMO_G9.dto;
using LMO_G9.util;
using System.Data.SqlClient;
using System.Data.Sql;

namespace LMO_G9.respository
{
    public class MusicRepository : DataUtil
    {
        private static AccountRespository accountRespository = new AccountRespository();

        public List<Music> getByCategoryId(long categoryId)
        {
            Connection.Open();
            List<Music> li = new List<Music>();
            string strSql = "select * from music where category_id = @id";
            SqlCommand cmd = new SqlCommand(strSql, Connection);
            cmd.Parameters.AddWithValue("id", categoryId);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                Music ms = new Music();
                ms.MusicId = (int)rd["music_id"];
                ms.Name = (string)rd["name"];
                ms.FilePath = (string)rd["file_path"];
                ms.ImagePath = (string)rd["image_path"];
                ms.SignerId = (int)rd["singer_id"];
                ms.CategoryId = (int)rd["category_id"];
                ms.CreateDate = (DateTime)rd["create_date"];
                ms.CreateBy = (int)rd["create_by"];
                ms.UpdateDate = (DateTime)rd["update_date"];
                ms.UpdateBy = (int)rd["update_by"];

                li.Add(ms);
            }
            Connection.Close();

            return li;
        }
    }
}