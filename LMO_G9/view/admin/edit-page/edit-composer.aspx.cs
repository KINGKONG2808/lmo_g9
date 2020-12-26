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
    public partial class WebForm1 : System.Web.UI.Page
    {
        private static ComposerRepository composerRepository = new ComposerRepository();
        private static Account account;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Composer composer = (Composer)Session["composerEdit"];
                txtId.Text = composer.ComposerId.ToString();
                txtName.Text = composer.Name.ToString();
                txtUpdateBy.Text = composer.UpdateBy.ToString();
                txtUpdateDate.Text = composer.UpdateDate.ToString();
                DataBind();
                account = (Account)Session["account"];
            }

        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
           
                Composer composer = new Composer();
                composer.ComposerId = Int32.Parse(txtId.Text);
                composer.Name = txtName.Text;
                composer.ImagePath = txtImg.Text;
                composer.UpdateDate = DateTime.Now;
                composer.UpdateBy = account.AccountId;
                composerRepository.onUpdate(composer);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Sucess!'); window.location='" + Request.ApplicationPath + "view/admin/composer.aspx';", true);
            
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex);
            //    ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('" + ex + "');", true);
            //} 
        }
    }
}