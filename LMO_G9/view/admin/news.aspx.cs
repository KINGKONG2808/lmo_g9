using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using LMO_G9.respository;
using LMO_G9.model;

namespace LMO_G9.view.admin
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        private static NewResponsitory newResponsitory = new NewResponsitory();
        private static Account account;
        private static MusicRepository musicRepository = new MusicRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            grNews.DataSource = newResponsitory.getList();
            DataBind();
            account = (Account)Session["account"];
        }
        protected void delete_Command(Object sender, CommandEventArgs e)
        {
            if (e.CommandName == "delete")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                List<Music> msList = musicRepository.getByCategoryId(id);
                if (msList.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Không thể xóa vì thể loại đang được sử dụng');", true);
                    loadData();
                    return;
                }
                newResponsitory.Xoa(id);
                loadData();
            }
        }
        protected void edit_Command(Object sender, CommandEventArgs e)
        {
            if (e.CommandName == "edit")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                New news = newResponsitory.getById(id);
                Session["composerEdit"] = news;
                //Response.Redirect("~/view/admin/edit-page/edit-composer.aspx");
            }
        }
        [WebMethod]
        public static string saveNew(string title, string imgPath , string shortContent , string content)
        {
            string log;
            try
            {
                New news = new New();
                news.Title = title;
                news.ShortContent = shortContent;
                news.Content = content;
                news.ImagePath = imgPath;
                news.CreateDate = DateTime.Now;
                news.CreateBy = account.AccountId;
                news.UpdateDate = DateTime.Now;
                news.UpdateBy = account.AccountId;
                newResponsitory.Them(news);
                log = "Sucess !!!";
            }
            catch (Exception ex)
            {
                log = "Something wrong with the error: " + ex.Message;
            }
            return log;
        }
    }
}