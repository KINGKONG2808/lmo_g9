using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using LMO_G9.respository;
using LMO_G9.model;
using System.Web.UI.WebControls;
using System.Web.Services;

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
                if(txtName.Text == null || txtName.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Không được bỏ trống tên thể loại!!');", true);
                    return;
                }
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
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Something wrong with the error: !" + ex.Message + "');", true);
            }
        }
    }
}