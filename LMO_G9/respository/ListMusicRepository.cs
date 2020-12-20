using LMO_G9.dto;
using LMO_G9.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using LMO_G9.model;

namespace LMO_G9.respository
{
    public class ListMusicRepository : DataUtil
    {
        private static AccountRespository accountRespository = new AccountRespository();

        public List<MusicDto> getList()
        {
            List<MusicDto> li = new List<MusicDto>();
            string strSql = "select ms.music_id as musicID, ms.name as musicName, ms.file_path as audioPath, ms.image_path as imagePath," +
                " sng.name as singerName, ctg.name as categoryName," +
                " ms.create_date as createDate, ms.create_by as createBy, ms.update_date as updateDate, ms.update_by as updateBy " +
                " from music ms " +
                "left join singer sng on ms.singer_id = sng.singer_id " +
                "left join category ctg on ms.category_id = ctg.category_id ";
            Connection.Open();
            SqlCommand cmd = new SqlCommand(strSql, Connection);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                MusicDto s = new MusicDto();
                Account account = new Account();
                s.MusicId = Convert.ToInt32(rd["musicID"]);
                s.Name = (string)rd["musicName"];
                s.AudioPath = (string)rd["audioPath"];
                s.ImagePath = (string)rd["imagePath"];
                s.SingerName = (string)rd["singerName"];
                s.CategoryName = (string)rd["categoryName"];
                s.CreateDate = (DateTime)rd["createDate"];
                s.CreateBy = (int)rd["createBy"];
                account = accountRespository.getById(s.CreateBy);
                s.CreatePeople = account.Fullname;
                s.UpdateDate = (DateTime)rd["updateDate"];
                s.UpdateBy = (int)rd["updateBy"];
                account = accountRespository.getById(s.UpdateBy);
                s.UpdatePeople = account.Fullname;

                li.Add(s);
            }
            Connection.Close();
            if(li.Count > 0)
            {
                foreach(MusicDto ms in li)
                {
                    Connection.Open();
                    string sqlFt = "select sng.name as singerName from singer sng, music_factory mf where sng.singer_id = mf.singer_id and mf.music_id = @msid";
                    SqlCommand cmdFt = new SqlCommand(sqlFt, Connection);
                    cmdFt.Parameters.AddWithValue("msid", ms.MusicId);
                    SqlDataReader rdFt = cmdFt.ExecuteReader();
                    while (rdFt.Read())
                    {
                        ms.Singer.Add((string)rd["singerName"]);
                    }
                    Connection.Close();

                    Connection.Open();
                    string sqlCp = "select cp.name as composerName from composer cp, composer_music cm where cp.composer_id = cm.composer_id and cm.music_id = @msid";
                    SqlCommand cmdCp = new SqlCommand(sqlCp, Connection);
                    cmdCp.Parameters.AddWithValue("msid", ms.MusicId);
                    SqlDataReader rdCp = cmdCp.ExecuteReader();
                    while (rdCp.Read())
                    {
                        ms.Composer.Add((string)rd["composerName"]);
                    }
                    Connection.Close();
                }
            }
            return li;

        }
    }
}