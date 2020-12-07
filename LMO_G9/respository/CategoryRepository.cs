using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LMO_G9.model;
using LMO_G9.util;
using System.Data.SqlClient;
using System.Data.Sql;

namespace LMO_G9.respository
{
    public class CategoryRepository : DataUtil
    {

        public List<Category> getList()
        {
            List<Category> li = new List<Category>();
            String strSql = "select * from category ";
            Connection.Open();
            SqlCommand cmd = new SqlCommand(strSql, Connection);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                Category cate = new Category();
                cate.CategoryId = Convert.ToInt64(rd["category_id"]);
                cate.Name = (string)rd["name"];
                cate.CreateDate = (DateTime)rd["create_date"];
                cate.CreateBy = Convert.ToInt64(rd["create_by"]);
                cate.UpdateDate = (DateTime)rd["update_date"];
                cate.UpdateBy = Convert.ToInt64(rd["update_by"]);

                li.Add(cate);
            }
            Connection.Close();
            return li;
        }

        public void onAddNew(Category cate)
        {
            Connection.Open();
            string strSql = "insert into category(name,create_date,create_by,update_date,update_by) values(@name,@cd,@cb,@ud,@ub)";
            SqlCommand cmd = new SqlCommand(strSql, Connection);
            cmd.Parameters.AddWithValue("name", cate.Name);
            cmd.Parameters.AddWithValue("cd", cate.CreateDate);
            cmd.Parameters.AddWithValue("cb", cate.CreateBy);
            cmd.Parameters.AddWithValue("ud", cate.UpdateDate);
            cmd.Parameters.AddWithValue("ub", cate.UpdateBy);
            cmd.ExecuteNonQuery();
            Connection.Close();
        }

        public void onDelete(long id)
        {
            Connection.Open();
            string strSql = "delete from category where category_id = @id";
            SqlCommand cmd = new SqlCommand(strSql, Connection);
            cmd.Parameters.AddWithValue("id", id);
            cmd.ExecuteNonQuery();
            Connection.Close();
        }

        public Category getById(long id)
        {
            Connection.Open();
            string strSql = "select * from category where category_id = @id";
            SqlCommand cmd = new SqlCommand(strSql, Connection);
            cmd.Parameters.AddWithValue("id", id);
            SqlDataReader rd = cmd.ExecuteReader();
            Category cate = null;
            if (rd.Read())
            {
                cate = new Category();
                cate.CategoryId = (long)rd["category_id"];
                cate.Name = (string)rd["name"];
                cate.CreateDate = (DateTime)rd["create_date"];
                cate.CreateBy = (long)rd["create_by"];
                cate.UpdateDate = (DateTime)rd["update_date"];
                cate.UpdateBy = (long)rd["update_by"];
            }
            Connection.Close();

            return cate;
        }

        public void onUpdate(Category cate)
        {
            Connection.Open();
            string strSql = "update sinhvien " +
                " set name = @name," +
                " update_date = @ud," +
                " update_by = @ub," +
                "where category_id = @id";
            SqlCommand cmd = new SqlCommand(strSql, Connection);
            cmd.Parameters.AddWithValue("name", cate.Name);
            cmd.Parameters.AddWithValue("ud", cate.UpdateDate);
            cmd.Parameters.AddWithValue("ub", cate.UpdateBy);
            cmd.Parameters.AddWithValue("id", cate.CategoryId);
            cmd.ExecuteNonQuery();
            Connection.Close();
        }
    }
}