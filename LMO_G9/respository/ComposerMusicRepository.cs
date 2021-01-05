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
    public class ComposerMusicRepository : DataUtil
    {
        public void onAddNew(ComposerMusic cm)
        {
            Connection.Open();
            string strSql = "insert into composer_music(music_id,composer_id,create_date,create_by,update_date,update_by) " +
                " values(@musicId,@composerId,@cd,@cb,@ud,@ub)";
            SqlCommand cmd = new SqlCommand(strSql, Connection);
            cmd.Parameters.AddWithValue("musicId", cm.MusicId);
            cmd.Parameters.AddWithValue("composerId", cm.ComposerId);
            cmd.Parameters.AddWithValue("cd", cm.CreateDate);
            cmd.Parameters.AddWithValue("cb", cm.CreateBy);
            cmd.Parameters.AddWithValue("ud", cm.UpdateDate);
            cmd.Parameters.AddWithValue("ub", cm.UpdateBy);
            cmd.ExecuteNonQuery();
            Connection.Close();
        }

        public ComposerMusic getByMusicId(long msId)
        {
            Connection.Open();
            string strSql = "select * from composer_music where music_id = @id";
            SqlCommand cmd = new SqlCommand(strSql, Connection);
            cmd.Parameters.AddWithValue("id", msId);
            SqlDataReader rd = cmd.ExecuteReader();
            ComposerMusic cm = null;
            if (rd.Read())
            {
                cm = new ComposerMusic();
                cm.ComposerMusicId = (int)rd["composer_music_id"];
                cm.MusicId = (int)rd["music_id"];
                cm.ComposerId = (int)rd["composer_Id"];
                cm.CreateDate = (DateTime)rd["create_date"];
                cm.CreateBy = (int)rd["create_by"];
                cm.UpdateDate = (DateTime)rd["update_date"];
                cm.UpdateBy = (int)rd["update_by"];
            }
            Connection.Close();

            return cm;
        }

        public void onUpdate(ComposerMusic cm)
        {
            Connection.Open();
            string strSql = "update composer_music " +
                " set music_id = @musicId," +
                " composer_id = @composerId," +
                " update_date = @ud," +
                " update_by = @ub " +
                " where composer_music_id = @id";
            SqlCommand cmd = new SqlCommand(strSql, Connection);
            cmd.Parameters.AddWithValue("musicId", cm.MusicId);
            cmd.Parameters.AddWithValue("composerId", cm.ComposerId);
            cmd.Parameters.AddWithValue("ud", cm.UpdateDate);
            cmd.Parameters.AddWithValue("ub", cm.UpdateBy);
            cmd.Parameters.AddWithValue("id", cm.ComposerMusicId);
            cmd.ExecuteNonQuery();
            Connection.Close();
        }
    }
}