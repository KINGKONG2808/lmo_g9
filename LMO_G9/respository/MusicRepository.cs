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

        public Music getById(long id)
        {
            Connection.Open();
            string strSql = "select * from music where music_id = @id";
            SqlCommand cmd = new SqlCommand(strSql, Connection);
            cmd.Parameters.AddWithValue("id", id);
            SqlDataReader rd = cmd.ExecuteReader();
            Music ms = null;
            if (rd.Read())
            {
                ms = new Music();
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
            }
            Connection.Close();

            return ms;
        }

        public Music getByCreateDateAndCreateBy(DateTime cd, int cb)
        {
            Connection.Open();
            string strSql = "select * from music where create_date=@cd and create_by=@cb";
            SqlCommand cmd = new SqlCommand(strSql, Connection);
            cmd.Parameters.AddWithValue("cd", cd);
            cmd.Parameters.AddWithValue("cb", cb);
            SqlDataReader rd = cmd.ExecuteReader();
            Music ms = null;
            if (rd.Read())
            {
                ms = new Music();
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
            }
            Connection.Close();

            return ms;
        }

        public void onDelete(long id)
        {
            //delete in composer_music
            Connection.Open();
            string strSqlCM = "delete from composer_music where music_id = @id";
            SqlCommand cmdCM = new SqlCommand(strSqlCM, Connection);
            cmdCM.Parameters.AddWithValue("id", id);
            cmdCM.ExecuteNonQuery();
            //delete in music_factory(featuring)
            string strSqlMFt = "delete from music_factory where music_id = @id";
            SqlCommand cmdMFt = new SqlCommand(strSqlMFt, Connection);
            cmdMFt.Parameters.AddWithValue("id", id);
            cmdMFt.ExecuteNonQuery();
            //delete in music_favorite
            string strSqlMF = "delete from music_favorite where music_id = @id";
            SqlCommand cmdMF = new SqlCommand(strSqlMF, Connection);
            cmdMF.Parameters.AddWithValue("id", id);
            cmdMF.ExecuteNonQuery();
            //delete in mussic
            string strSqlM = "delete from music where music_id = @id";
            SqlCommand cmdM = new SqlCommand(strSqlM, Connection);
            cmdM.Parameters.AddWithValue("id", id);
            cmdM.ExecuteNonQuery();
            Connection.Close();
        }


        public void onAddNew(Music ms)
        {
            Connection.Open();
            string strSql = "insert into music(name,file_path,image_path,singer_id,category_id,create_date,create_by,update_date,update_by) " +
                " values(@name,@audio,@image,@singerId,@cateId,@cd,@cb,@ud,@ub)";
            SqlCommand cmd = new SqlCommand(strSql, Connection);
            cmd.Parameters.AddWithValue("name", ms.Name);
            cmd.Parameters.AddWithValue("audio", ms.FilePath);
            cmd.Parameters.AddWithValue("image", ms.ImagePath);
            cmd.Parameters.AddWithValue("singerId", ms.SignerId);
            cmd.Parameters.AddWithValue("cateId", ms.CategoryId);
            cmd.Parameters.AddWithValue("cd", ms.CreateDate);
            cmd.Parameters.AddWithValue("cb", ms.CreateBy);
            cmd.Parameters.AddWithValue("ud", ms.UpdateDate);
            cmd.Parameters.AddWithValue("ub", ms.UpdateBy);
            cmd.ExecuteNonQuery();
            Connection.Close();
        }

        public void onUpdate(Music ms)
        {
            Connection.Open();
            string strSql = "update music " +
                " set name= @name," +
                " file_path = @audio," +
                " image_path = @image," +
                " singer_id = @singerId," +
                " category_id = @cateId," +
                " update_date = @ud," +
                " update_by = @ub " +
                " where music_id = @id";
            SqlCommand cmd = new SqlCommand(strSql, Connection);
            cmd.Parameters.AddWithValue("name", ms.Name);
            cmd.Parameters.AddWithValue("audio", ms.FilePath);
            cmd.Parameters.AddWithValue("image", ms.ImagePath);
            cmd.Parameters.AddWithValue("singerId", ms.SignerId);
            cmd.Parameters.AddWithValue("cateId", ms.CategoryId);
            cmd.Parameters.AddWithValue("ud", ms.UpdateDate);
            cmd.Parameters.AddWithValue("ub", ms.UpdateBy);
            cmd.Parameters.AddWithValue("id", ms.MusicId);
            cmd.ExecuteNonQuery();
            Connection.Close();
        }
    }
}