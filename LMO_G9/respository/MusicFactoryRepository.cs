using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LMO_G9.util;
using LMO_G9.model;
using LMO_G9.dto;
using System.Data.SqlClient;

namespace LMO_G9.respository
{
    public class MusicFactoryRepository : DataUtil
    {
        private static AccountRespository accountRespository = new AccountRespository();

        public MusicFactory getByMusicId(long msId)
        {
            Connection.Open();
            string strSql = "select * from music_factory where music_id = @id";
            SqlCommand cmd = new SqlCommand(strSql, Connection);
            cmd.Parameters.AddWithValue("id", msId);
            SqlDataReader rd = cmd.ExecuteReader();
            MusicFactory mf = null;
            if (rd.Read())
            {
                mf = new MusicFactory();
                mf.MusicFactoryId = (int)rd["music_factory_id"];
                mf.MusicId = (int)rd["music_id"];
                mf.SingerId = (int)rd["singer_Id"];
                mf.CreateDate = (DateTime)rd["create_date"];
                mf.CreateBy = (int)rd["create_by"];
                mf.UpdateDate = (DateTime)rd["update_date"];
                mf.UpdateBy = (int)rd["update_by"];
            }
            Connection.Close();

            return mf;
        }

        public void onAddNew(MusicFactory mf)
        {
            Connection.Open();
            string strSql = "insert into music_factory(music_id,singer_id,create_date,create_by,update_date,update_by) " +
                " values(@musicId,@singerId,@cd,@cb,@ud,@ub)";
            SqlCommand cmd = new SqlCommand(strSql, Connection);
            cmd.Parameters.AddWithValue("musicId", mf.MusicId);
            cmd.Parameters.AddWithValue("singerId", mf.SingerId);
            cmd.Parameters.AddWithValue("cd", mf.CreateDate);
            cmd.Parameters.AddWithValue("cb", mf.CreateBy);
            cmd.Parameters.AddWithValue("ud", mf.UpdateDate);
            cmd.Parameters.AddWithValue("ub", mf.UpdateBy);
            cmd.ExecuteNonQuery();
            Connection.Close();
        }

        public void onUpdate(MusicFactory mf)
        {
            Connection.Open();
            string strSql = "update music_factory " +
                " set music_id = @musicId," +
                " singer_id = @singerId," +
                " update_date = @ud," +
                " update_by = @ub " +
                " where music_factory_id = @id";
            SqlCommand cmd = new SqlCommand(strSql, Connection);
            cmd.Parameters.AddWithValue("musicId", mf.MusicId);
            cmd.Parameters.AddWithValue("singerId", mf.SingerId);
            cmd.Parameters.AddWithValue("ud", mf.UpdateDate);
            cmd.Parameters.AddWithValue("ub", mf.UpdateBy);
            cmd.Parameters.AddWithValue("id", mf.MusicFactoryId);
            cmd.ExecuteNonQuery();
            Connection.Close();
        }
    }
}