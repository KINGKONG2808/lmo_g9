using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LMO_G9.respository;
using LMO_G9.model;
using System.Web.Services;
using System.IO;
using LMO_G9.util;


namespace LMO_G9.view.admin
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private static ComposerRepository composerRepository = new ComposerRepository();
        private static CategoryRepository categoryRepository = new CategoryRepository();
        private static SingerResponsitory singerResponsitory = new SingerResponsitory();
        private static MusicFactoryRepository musicFactoryRepository = new MusicFactoryRepository();

        private static ComposerMusicRepository composerMusicRepository = new ComposerMusicRepository();
        private static Account account;
        private static Music msBak = new Music();
        private static MusicFactory mfBak = new MusicFactory();
        private static ComposerMusic cmBak = new ComposerMusic();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["composerEdit"] != null)
                {
                    Composer composer = (Composer)Session["composerEdit"];
                    txtId.Text = composer.ComposerId.ToString();
                    txtName.Text = composer.Name.ToString();
                    txtUpdateBy.Text = composer.UpdateBy.ToString();
                    txtUpdateDate.Text = composer.UpdateDate.ToString();
                    DataBind();

                }
                account = (Account)Session["account"];
            }
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {

                Composer composer = new Composer();
                composer.ComposerId = Int32.Parse(txtId.Text);
                composer.Name = txtName.Text;
                string path = Server.MapPath(Constant.RESOURCE_PATH);
                string timeString = DateTime.Now.ToString("ddMMyyyy_hhmmss_tt_");
                imageFUL.PostedFile.SaveAs(path + timeString + imageFUL.FileName);
                composer.ImagePath = Constant.RESOURCE_PATH + timeString + imageFUL.FileName;
                composer.UpdateDate = DateTime.Now;
                composer.UpdateBy = account.AccountId;
                composer.CreateDate = DateTime.Now;
                composer.CreateBy = account.AccountId;
                composerRepository.onUpdate(composer);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Sucess!'); window.location='" + Request.ApplicationPath + "view/admin/composer.aspx';", true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('" + ex + "');", true);
            }
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Composer composer = new Composer();

                composer.Name = txtName.Text;
                string path = Server.MapPath(Constant.RESOURCE_PATH);
                string timeString = DateTime.Now.ToString("ddMMyyyy_hhmmss_tt_");
                imageFUL.PostedFile.SaveAs(path + timeString + imageFUL.FileName);
                composer.ImagePath = Constant.RESOURCE_PATH + timeString + imageFUL.FileName;
                composer.CreateDate = DateTime.Now;
                composer.CreateBy = account.AccountId;
                composer.UpdateDate = DateTime.Now;
                composer.UpdateBy = account.AccountId;
                composerRepository.Them(composer);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Sucess!'); window.location='" + Request.ApplicationPath + "view/admin/composer.aspx';", true);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('" + ex + "');", true);
            }
        }
    }
}