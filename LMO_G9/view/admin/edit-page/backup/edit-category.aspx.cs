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
    public partial class WebForm19 : System.Web.UI.Page
    {
        private static CategoryRepository categoryRepository = new CategoryRepository();
        private static Account account;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Category category = (Category)Session["categoryEdit"];
                txtId.Text = category.CategoryId.ToString();
                txtName.Text = category.Name.ToString();
                txtUpdateBy.Text = category.UpdateBy.ToString();
                txtUpdateDate.Text = category.UpdateDate.ToString();
                DataBind();
                account = (Account)Session["account"];
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                Category category = new Category();
                category.CategoryId = Int32.Parse(txtId.Text);
                category.Name = txtName.Text;
                category.UpdateDate = DateTime.Now;
                category.UpdateBy = account.AccountId;
                categoryRepository.onUpdate(category);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Sucess!'); window.location='" + Request.ApplicationPath + "view/admin/category.aspx';", true);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('"+ ex +"');", true);
            }
        }
    }
}