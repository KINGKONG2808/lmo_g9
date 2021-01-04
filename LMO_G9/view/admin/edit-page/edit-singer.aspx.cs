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
    public partial class WebForm2 : System.Web.UI.Page
    {
        private static SingerResponsitory singerResponsitory = new SingerResponsitory();
        private static Account account;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Singer singer = (Singer)Session["singerEdit"];
                txtId.Text = singer.SingerId.ToString();
                txtName.Text = singer.Name.ToString();
                txtUpdateBy.Text = singer.UpdateBy.ToString();
                txtUpdateDate.Text = singer.UpdateDate.ToString();
                DataBind();
                account = (Account)Session["account"];
            }
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                Singer singer = new Singer();
                singer.SingerId = Int32.Parse(txtId.Text);
                singer.Name = txtName.Text;
                singer.ImagePath = txtImg.Text;
                singer.UpdateDate = DateTime.Now;
                singer.UpdateBy = account.AccountId;
                singerResponsitory.onUpdate(singer);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Sucess!'); window.location='" + Request.ApplicationPath + "view/admin/singer.aspx';", true);
            }


            catch (Exception ex)
            {
                Console.WriteLine(ex);
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('" + ex + "');", true);
            }
        }
    }
}