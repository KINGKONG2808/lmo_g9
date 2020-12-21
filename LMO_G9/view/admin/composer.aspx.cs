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
    public partial class WebForm7 : System.Web.UI.Page
    {
        private static ComposerRepository composerRepository = new ComposerRepository();
        private static Account account;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hienthi();
                account = (Account)Session["account"];
            }
           
        }

        private void hienthi()
        {
            grComposer.DataSource = composerRepository.dsComposer();
            DataBind();
        }
        protected void delete_Command(Object sender, CommandEventArgs e)
        {
            if (e.CommandName == "delete")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                composerRepository.Xoa(id);
                hienthi();
            }
        }
        
        protected void edit_Command(Object sender, CommandEventArgs e)
        {
            if (e.CommandName == "edit")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                Composer com = composerRepository.getById(id);
                Session["composerEdit"] = com;
                Response.Redirect("~/view/admin/edit-page/edit-composer.aspx");
            }
        }

        [WebMethod]
        public static string saveComposer(string composerName, string imgPath)
        {
            string log;
            try
            {
                Composer composer = new Composer();
                composer.Name = composerName;
                composer.ImagePath = imgPath;
                composer.CreateDate = DateTime.Now;
                composer.CreateBy = account.AccountId;
                composer.UpdateDate = DateTime.Now;
                composer.UpdateBy = account.AccountId;
                composerRepository.Them(composer);
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