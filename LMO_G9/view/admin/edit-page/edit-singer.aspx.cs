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
    public partial class WebForm2 : System.Web.UI.Page
    {
        private static SingerResponsitory singerResponsitory = new SingerResponsitory();
        private static CategoryRepository categoryRepository = new CategoryRepository();
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
                if (Session["singerEdit"] != null)
                {
                    Singer singer = (Singer)Session["singerEdit"];
                    txtId.Text = singer.SingerId.ToString();
                    txtName.Text = singer.Name.ToString();
                    txtUpdateBy.Text = singer.UpdateBy.ToString();
                    txtUpdateDate.Text = singer.UpdateDate.ToString();
                    DataBind();
                }
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
                string path = Server.MapPath(Constant.RESOURCE_PATH);
                string timeString = DateTime.Now.ToString("ddMMyyyy_hhmmss_tt_");
                imageFUL.PostedFile.SaveAs(path + timeString + imageFUL.FileName);
                singer.ImagePath = Constant.RESOURCE_PATH + timeString + imageFUL.FileName;
                singer.UpdateDate = DateTime.Now;
                singer.UpdateBy = account.AccountId;
                singer.CreateDate = DateTime.Now;
                singer.CreateBy = account.AccountId;
                singerResponsitory.onUpdate(singer);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Sucess!'); window.location='" + Request.ApplicationPath + "view/admin/singer.aspx';", true);
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
                Singer singer = new Singer();
                singer.Name = txtName.Text;
                string path = Server.MapPath(Constant.RESOURCE_PATH);
                string timeString = DateTime.Now.ToString("ddMMyyyy_hhmmss_tt_");
                imageFUL.PostedFile.SaveAs(path + timeString + imageFUL.FileName);
                singer.ImagePath = Constant.RESOURCE_PATH + timeString + imageFUL.FileName;
                singer.CreateDate = DateTime.Now;
                singer.CreateBy = account.AccountId;
                singer.UpdateDate = DateTime.Now;
                singer.UpdateBy = account.AccountId;
                singerResponsitory.Them(singer);
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