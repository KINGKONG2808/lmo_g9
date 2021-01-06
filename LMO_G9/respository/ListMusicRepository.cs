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
                    ms.Singer = new List<string>();
                    while (rdFt.Read())
                    {
                        ms.Singer.Add((string)rdFt["singerName"]);
                    }
                    Connection.Close();

                    Connection.Open();
                    string sqlCp = "select cp.name as composerName from composer cp, composer_music cm where cp.composer_id = cm.composer_id and cm.music_id = @msid";
                    SqlCommand cmdCp = new SqlCommand(sqlCp, Connection);
                    cmdCp.Parameters.AddWithValue("msid", ms.MusicId);
                    SqlDataReader rdCp = cmdCp.ExecuteReader();
                    ms.Composer = new List<string>();
                    while (rdCp.Read())
                    {
                        ms.Composer.Add((string)rdCp["composerName"]);
                        ms.ComposerName = (string)rdCp["composerName"];
                    }
                    Connection.Close();
                }
            }
            return li;

        }
        public List<int> getListFavoriteId(int accountId)
        {
            List<int> listId = new List<int>();
            string strSql = "select mf.music_id as musicId from music_favorite mf where mf.account_id = @accountId";
            Connection.Open();
            SqlCommand cmd = new SqlCommand(strSql, Connection);
            cmd.Parameters.AddWithValue("accountId", accountId);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                int n;
                n = (int)rd["musicId"];
                listId.Add(n);
            }
            Connection.Close();
            return listId;
        }
        public List<int> addToFavorite(int accountId, int musicId)
        {
            Connection.Open();
            string strSql = "insert into music_favorite values(@musicId,@accountId, @create_date, @create_by, @update_date, @update_by)";
            SqlCommand cmd = new SqlCommand(strSql, Connection);
            cmd.Parameters.AddWithValue("musicId", musicId);
            cmd.Parameters.AddWithValue("accountId", accountId);
            cmd.Parameters.AddWithValue("create_date", DateTime.Now);
            cmd.Parameters.AddWithValue("create_by", accountId);
            cmd.Parameters.AddWithValue("update_date", DateTime.Now);
            cmd.Parameters.AddWithValue("update_by", accountId);
            cmd.ExecuteNonQuery();
            Connection.Close();
           
            return getListFavoriteId(accountId);
        }
        public List<int> deleteFavorite(int accountId, int musicId)
        {
            Connection.Open();
            string strSql = "delete from music_favorite mf where mf.music_id = @musicId and mf.account_id = @accountId";
            SqlCommand cmd = new SqlCommand(strSql, Connection);
            cmd.Parameters.AddWithValue("musicId", musicId);
            cmd.Parameters.AddWithValue("accountId", accountId);
            cmd.ExecuteNonQuery();
            Connection.Close();

            return getListFavoriteId(accountId);
        }
        public List<Category> getAllCategories()
        {
            List<Category> lcg = new List<Category>();
            string strSql = "select ctg.category_id as categoryId , ctg.name as categoryName from category ctg ";
            Connection.Open();
            SqlCommand cmd = new SqlCommand(strSql, Connection);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                Category ctg = new Category();
                ctg.CategoryId = (int)rd["categoryId"];
                ctg.Name = (string)rd["categoryName"];
                lcg.Add(ctg);
            }
            Connection.Close();
            return lcg;
        }

        public List<MusicDto> getListWithCategory(int id)
        {
            List<MusicDto> li = new List<MusicDto>();
            string strSql = "select ms.music_id as musicID, ms.name as musicName, ms.file_path as audioPath, ms.image_path as imagePath," +
                " sng.name as singerName, ctg.name as categoryName," +
                " ms.create_date as createDate, ms.create_by as createBy, ms.update_date as updateDate, ms.update_by as updateBy " +
                " from music ms " +
                "left join singer sng on ms.singer_id = sng.singer_id " +
                "left join category ctg on ms.category_id = ctg.category_id " +
                "where ctg.category_id = @categotyId";
            Connection.Open();
            SqlCommand cmd = new SqlCommand(strSql, Connection);
            cmd.Parameters.AddWithValue("categotyId", id);
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
            if (li.Count > 0)
            {
                foreach (MusicDto ms in li)
                {
                    Connection.Open();
                    string sqlFt = "select sng.name as singerName from singer sng, music_factory mf where sng.singer_id = mf.singer_id and mf.music_id = @msid";
                    SqlCommand cmdFt = new SqlCommand(sqlFt, Connection);
                    cmdFt.Parameters.AddWithValue("msid", ms.MusicId);
                    SqlDataReader rdFt = cmdFt.ExecuteReader();
                    ms.Singer = new List<string>();
                    while (rdFt.Read())
                    {
                        ms.Singer.Add((string)rdFt["singerName"]);
                    }
                    Connection.Close();

                    Connection.Open();
                    string sqlCp = "select cp.name as composerName from composer cp, composer_music cm where cp.composer_id = cm.composer_id and cm.music_id = @msid";
                    SqlCommand cmdCp = new SqlCommand(sqlCp, Connection);
                    cmdCp.Parameters.AddWithValue("msid", ms.MusicId);
                    SqlDataReader rdCp = cmdCp.ExecuteReader();
                    ms.Composer = new List<string>();
                    while (rdCp.Read())
                    {
                        ms.Composer.Add((string)rdCp["composerName"]);
                    }
                    Connection.Close();
                }
            }
            return li;

        }


        public List<MusicDto> getListFavorite(int id)
        {
            List<MusicDto> li = new List<MusicDto>();
            string strSql = "select ms.music_id as musicID, ms.name as musicName, ms.file_path as audioPath, ms.image_path as imagePath," +
                " sng.name as singerName, ctg.name as categoryName," +
                " ms.create_date as createDate, ms.create_by as createBy, ms.update_date as updateDate, ms.update_by as updateBy " +
                " from music ms " +
                "left join singer sng on ms.singer_id = sng.singer_id " +
                "left join category ctg on ms.category_id = ctg.category_id " +
                "inner join music_favorite mf on ms.music_id = mf.music_id " +
                "where mf.account_id = @accountId ";
            Connection.Open();
            SqlCommand cmd = new SqlCommand(strSql, Connection);
            cmd.Parameters.AddWithValue("accountId", id);
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
            if (li.Count > 0)
            {
                foreach (MusicDto ms in li)
                {
                    Connection.Open();
                    string sqlFt = "select sng.name as singerName from singer sng, music_factory mf where sng.singer_id = mf.singer_id and mf.music_id = @msid";
                    SqlCommand cmdFt = new SqlCommand(sqlFt, Connection);
                    cmdFt.Parameters.AddWithValue("msid", ms.MusicId);
                    SqlDataReader rdFt = cmdFt.ExecuteReader();
                    ms.Singer = new List<string>();
                    while (rdFt.Read())
                    {
                        ms.Singer.Add((string)rdFt["singerName"]);
                    }
                    Connection.Close();

                    Connection.Open();
                    string sqlCp = "select cp.name as composerName from composer cp, composer_music cm where cp.composer_id = cm.composer_id and cm.music_id = @msid";
                    SqlCommand cmdCp = new SqlCommand(sqlCp, Connection);
                    cmdCp.Parameters.AddWithValue("msid", ms.MusicId);
                    SqlDataReader rdCp = cmdCp.ExecuteReader();
                    ms.Composer = new List<string>();
                    while (rdCp.Read())
                    {
                        ms.Composer.Add((string)rdCp["composerName"]);
                    }
                    Connection.Close();
                }
            }
            return li;

        }

        public List<MusicDto> getListSearch(string value)
        {
            List<MusicDto> li = new List<MusicDto>();
            string strSql = "select ms.music_id as musicID, ms.name as musicName, ms.file_path as audioPath, ms.image_path as imagePath," +
                " sng.name as singerName, ctg.name as categoryName," +
                " ms.create_date as createDate, ms.create_by as createBy, ms.update_date as updateDate, ms.update_by as updateBy " +
                " from music ms " +
                "left join singer sng on ms.singer_id = sng.singer_id " +
                "left join category ctg on ms.category_id = ctg.category_id " +
                "where ms.name LIKE '%" + value  + "%'";
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
            if (li.Count > 0)
            {
                foreach (MusicDto ms in li)
                {
                    Connection.Open();
                    string sqlFt = "select sng.name as singerName from singer sng, music_factory mf where sng.singer_id = mf.singer_id and mf.music_id = @msid";
                    SqlCommand cmdFt = new SqlCommand(sqlFt, Connection);
                    cmdFt.Parameters.AddWithValue("msid", ms.MusicId);
                    SqlDataReader rdFt = cmdFt.ExecuteReader();
                    ms.Singer = new List<string>();
                    while (rdFt.Read())
                    {
                        ms.Singer.Add((string)rdFt["singerName"]);
                    }
                    Connection.Close();

                    Connection.Open();
                    string sqlCp = "select cp.name as composerName from composer cp, composer_music cm where cp.composer_id = cm.composer_id and cm.music_id = @msid";
                    SqlCommand cmdCp = new SqlCommand(sqlCp, Connection);
                    cmdCp.Parameters.AddWithValue("msid", ms.MusicId);
                    SqlDataReader rdCp = cmdCp.ExecuteReader();
                    ms.Composer = new List<string>();
                    while (rdCp.Read())
                    {
                        ms.Composer.Add((string)rdCp["composerName"]);
                    }
                    Connection.Close();
                }
            }
            return li;

        }
    }
}