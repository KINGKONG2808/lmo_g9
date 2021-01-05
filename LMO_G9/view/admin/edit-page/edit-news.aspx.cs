using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LMO_G9.respository;
using LMO_G9.model;

namespace LMO_G9.view.admin
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        private static NewResponsitory newResponsitory = new NewResponsitory();
        private static Account account;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                New news = (New)Session["newEdit"];
                txtId.Text = news.NewsId.ToString();
                txtTitle.Text = news.Title.ToString();
                txtShort_Content.Text = news.ShortContent.ToString();
                txtContent.Text = news.Content.ToString();

                txtUpdateBy.Text = news.UpdateBy.ToString();
                txtUpdateDate.Text = news.UpdateDate.ToString();
                DataBind();
                account = (Account)Session["account"];
            }
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {

            try
            {
                New news = new New();
                news.NewsId = Int32.Parse(txtId.Text);
                news.Title = txtTitle.Text;
                news.ShortContent = txtShort_Content.Text;
                news.Content = txtContent.Text;
                news.ImagePath = txtImg.Text;
                news.UpdateDate = DateTime.Now;
                news.UpdateBy = account.AccountId;
                newResponsitory.onUpdate(news);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Sucess!'); window.location='" + Request.ApplicationPath + "view/admin/news.aspx';", true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('" + ex + "');", true);
            }
        }
    }
}