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
    public class NewResponsitory : DataUtil
    {
        private static AccountRespository accountRespository = new AccountRespository();
        public List<NewDto> getList()
        {
            List<NewDto> li = new List<NewDto>();
            String strSql = "select * from news c";
            Connection.Open();
            SqlCommand cmd = new SqlCommand(strSql, Connection);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                NewDto news = new NewDto();
                Account account = new Account();
                news.NewsId = Convert.ToInt32(rd["news_id"]);
                news.Title = (string)rd["title"];
                news.ImagePath = (string)rd["image_path"];
                news.ShortContent = (string)rd["short_content"];
                news.Content = (string)rd["content"];
                news.CreateDate = (DateTime)rd["create_date"];
                news.CreateBy = Convert.ToInt32(rd["create_by"]);
                account = accountRespository.getById(news.CreateBy);
                news.CreatePeople = account.Fullname;
                news.UpdateDate = (DateTime)rd["update_date"];
                news.UpdateBy = Convert.ToInt32(rd["update_by"]);
                account = accountRespository.getById(news.UpdateBy);
                news.UpdatePeople = account.Fullname;

                li.Add(news);
            }
            Connection.Close();
            return li;
        }
        public void Xoa(int news_id)
        {
            Connection.Open();
            string strSql = "Delete from news where news_id=@news_id";
            SqlCommand cmd = new SqlCommand(strSql, Connection);
            cmd.Parameters.AddWithValue("news_id", news_id);
            cmd.ExecuteNonQuery();
            Connection.Close();
        }
        public void Them(New news)
        {
            Connection.Open();
            string strSql = "insert into news(title,short_content,content,image_path,create_date,create_by,update_date,update_by) values(@title,@short_content,@content,@img,@cd,@cb,@ud,@ub)";
            SqlCommand cmd = new SqlCommand(strSql, Connection);
            cmd.Parameters.AddWithValue("title", news.Title);
            cmd.Parameters.AddWithValue("short_content", news.ShortContent);
            cmd.Parameters.AddWithValue("content", news.Content);
            cmd.Parameters.AddWithValue("img", news.ImagePath);
            cmd.Parameters.AddWithValue("cd", news.CreateDate);
            cmd.Parameters.AddWithValue("cb", news.CreateBy);
            cmd.Parameters.AddWithValue("ud", news.UpdateDate);
            cmd.Parameters.AddWithValue("ub", news.UpdateBy);
            cmd.ExecuteNonQuery();
            Connection.Close();
        }
        public New getById(long id)
        {
            Connection.Open();
            string strSql = "select * from news where news_id = @id";
            SqlCommand cmd = new SqlCommand(strSql, Connection);
            cmd.Parameters.AddWithValue("id", id);
            SqlDataReader rd = cmd.ExecuteReader();
            New s = null;
            if (rd.Read())
            {
                s = new New();
                s.NewsId = (int)rd["news_id"];
                s.Title = (string)rd["title"];
                s.ShortContent = (string)rd["short_content"];
                s.Content = (string)rd["content"];
                s.CreateDate = (DateTime)rd["create_date"];
                s.CreateBy = (int)rd["create_by"];
                s.UpdateDate = (DateTime)rd["update_date"];
                s.UpdateBy = (int)rd["update_by"];
            }
            Connection.Close();

            return s;
        }
        public void onUpdate(New news)
        {
            Connection.Open();
            string strSql = "update new " +
                " set title = @title," +
                " set short_content = @short_content," +
                " set content = @content," +
                " set img_path = @img_path," +
                " update_date = @ud," +
                " update_by = @ub " +
                " where composer_id = @id";
            SqlCommand cmd = new SqlCommand(strSql, Connection);
            cmd.Parameters.AddWithValue("title", news.Title);
            cmd.Parameters.AddWithValue("short_content", news.ShortContent);
            cmd.Parameters.AddWithValue("content", news.Content);
            cmd.Parameters.AddWithValue("i_path", news.ImagePath);
            cmd.Parameters.AddWithValue("ud", news.UpdateDate);
            cmd.Parameters.AddWithValue("ub", news.UpdateBy);
            cmd.Parameters.AddWithValue("id", news.NewsId);
            cmd.ExecuteNonQuery();
            Connection.Close();
        }
    }
}