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

namespace LMO_G9.view.admin
{
    public partial class WebForm16 : System.Web.UI.Page
    {
        private static ListMusicRepository listMusicRepository = new ListMusicRepository();
        private static MusicRepository musicRepository = new MusicRepository();
        private static CategoryRepository categoryRepository = new CategoryRepository();
        private static SingerResponsitory singerResponsitory = new SingerResponsitory();
        private static Account account;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadData();
                loadDdl();
            }
        }

        private void loadData()
        {
            grdDs.DataSource = listMusicRepository.getList();
            DataBind();
            account = (Account)Session["account"];
        }
        
        private void loadDdl()
        {
            //ddl cate
            ddlCategory.Items.Add("Choose the category...");
            ddlCategory.DataSource = categoryRepository.getList();
            ddlCategory.DataTextField = "name";
            ddlCategory.DataValueField = "categoryId";
            //ddl singer
            ddlSinger.DataSource = singerResponsitory.getList();
            ddlSinger.DataTextField = "name";
            ddlSinger.DataValueField = "singerId";
            //ddl singer feat
            ddlSingerFeat.DataSource = singerResponsitory.getList();
            ddlSingerFeat.DataTextField = "name";
            ddlSingerFeat.DataValueField = "singerId";


            DataBind();

            //add placeholder
            ddlCategory.Items.Insert(0, "Choose the category...");
            ddlCategory.Items[0].Value = "0";
            ddlSinger.Items.Insert(0, "Choose the singer...");
            ddlSinger.Items[0].Value = "0";
            ddlSingerFeat.Items.Insert(0, "Choose the singer featuring...");
            ddlSingerFeat.Items[0].Value = "0";
        }

        protected void delete_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "delete")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                musicRepository.onDelete(id);
                loadData();
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Xóa thành công');", true);
            }
        }

        protected void edit_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "edit")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                
            }
        }

        [WebMethod]
        [HttpPost]
        public static string saveMusic(string musicName, string categoryId, string singerId, string singerIdFeat,string imagePath)
        {
            string log;
            try
            {
                Music ms = new Music(); 
                ms.Name = musicName;
                ms.CategoryId = Int32.Parse(categoryId);
                ms.SignerId = Int32.Parse(singerId);
                Page page = (Page)HttpContext.Current.Handler;
                String path = HttpContext.Current.Server.MapPath("~/folder/");
                string timeString = DateTime.Now.ToString("ddMMyyyy_hhmmss_tt_");
                WebForm16 wf = new WebForm16();
                //FileUpload image = (FileUpload)page.FindControl("music").FindControl("imageFUL");
                //image.PostedFile.SaveAs(path + "images/"+ timeString + imagePath);
                ms.ImagePath = path + "images/" + timeString + imagePath;
                ms.ImagePath = wf.fileUtil(path);
                ms.FilePath = "";
                ms.CreateDate = DateTime.Now;
                ms.CreateBy = account.AccountId;
                ms.UpdateDate = DateTime.Now;
                ms.UpdateBy = account.AccountId;
                musicRepository.onAddNew(ms);
                if(singerIdFeat != "0" || singerIdFeat != singerId)
                {

                }
                log = "Sucess !!!";
            }
            catch (Exception ex)
            {
                log = "Something wrong with the error: " + ex.Message;
            }
            return log;
        }

        private string fileUtil(string path)
        {
            string timeString = DateTime.Now.ToString("ddMMyyyy_hhmmss_tt_");
            imageFUL.PostedFile.SaveAs(path + "images/" + timeString + imageFUL.FileName);
            return "images/" + timeString + imageFUL.FileName ;
        }

        bool CheckImageType(string fileName)
        {
            string ext = Path.GetExtension(fileName);
            switch (ext.ToLower())
            {
                case ".gif":
                    return true;
                case ".png":
                    return true;
                case ".jpg":
                    return true;
                case ".jpeg":
                    return true;
                default:
                    return false;
            }
        }

    }
}