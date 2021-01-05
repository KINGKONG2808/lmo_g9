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
    public partial class WebForm5 : System.Web.UI.Page
    {
        private static MusicRepository musicRepository = new MusicRepository();
        private static CategoryRepository categoryRepository = new CategoryRepository();
        private static SingerResponsitory singerResponsitory = new SingerResponsitory();
        private static MusicFactoryRepository musicFactoryRepository = new MusicFactoryRepository();
        private static ComposerRepository composerRepository = new ComposerRepository();
        private static ComposerMusicRepository composerMusicRepository = new ComposerMusicRepository();
        private static Account account;
        private static Music msBak = new Music();
        private static MusicFactory mfBak = new MusicFactory();
        private static ComposerMusic cmBak = new ComposerMusic();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadDdl();
                typeP.Text = "Add";
                account = (Account)Session["account"];
                if (Session["musicEdit"] != null)
                {
                    typeP.Text = "Edit";
                    Music music = (Music)Session["musicEdit"];
                    msBak = music;
                    txtId.Text = music.MusicId.ToString();
                    txtName.Text = music.Name.ToString();
                    ddlCategory.SelectedValue = music.CategoryId.ToString();
                    ddlSinger.SelectedValue = music.SignerId.ToString();
                    MusicFactory mf = musicFactoryRepository.getByMusicId(music.MusicId);
                    mfBak = mf;
                    if (mf != null)
                    {
                        ddlSingerFeat.SelectedValue = mf.SingerId.ToString();
                    }
                    ComposerMusic cm = composerMusicRepository.getByMusicId(music.MusicId);
                    cmBak = cm;
                    ddlComposer.SelectedValue = cm.ComposerId.ToString();
                    txtUpdateBy.Text = music.UpdateBy.ToString();
                    txtUpdateDate.Text = music.UpdateDate.ToString();
                    DataBind();
                    addPlaceholder();
                    account = (Account)Session["account"];
                }
            }

        }

        private void loadDdl()
        {
            //ddl cate
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
            //ddl composer
            ddlComposer.DataSource = composerRepository.getList();
            ddlComposer.DataTextField = "name";
            ddlComposer.DataValueField = "composerId";


            DataBind();

            addPlaceholder();
        }
        private void addPlaceholder()
        {

            ddlCategory.Items.Insert(0, "Choose the category...");
            ddlCategory.Items[0].Value = "0";
            ddlSinger.Items.Insert(0, "Choose the singer...");
            ddlSinger.Items[0].Value = "0";
            ddlSingerFeat.Items.Insert(0, "Choose the singer featuring...");
            ddlSingerFeat.Items[0].Value = "0";
            ddlComposer.Items.Insert(0, "Choose the composer...");
            ddlComposer.Items[0].Value = "0";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!checkValidate())
                {
                    return;
                }
                Music ms = new Music();
                ms.Name = txtName.Text;
                ms.CategoryId = Int32.Parse(ddlCategory.SelectedValue);
                ms.SignerId = Int32.Parse(ddlSinger.SelectedValue);
                string path = Server.MapPath(Constant.RESOURCE_PATH);
                string timeString = DateTime.Now.ToString("ddMMyyyy_hhmmss_tt_");
                imageFUL.PostedFile.SaveAs(path + timeString + imageFUL.FileName);
                ms.ImagePath = Constant.RESOURCE_PATH + timeString + imageFUL.FileName;
                audioFUL.PostedFile.SaveAs(path + timeString + audioFUL.FileName);
                ms.FilePath = Constant.RESOURCE_PATH + timeString + audioFUL.FileName;
                if (Session["musicEdit"] == null)
                {
                    ms.CreateDate = DateTime.Now;
                    ms.CreateBy = account.AccountId;
                    ms.UpdateDate = DateTime.Now;
                    ms.UpdateBy = account.AccountId;
                    musicRepository.onAddNew(ms);
                    ms = musicRepository.getByCreateDateAndCreateBy(ms.CreateDate, ms.CreateBy);

                    if (ddlSingerFeat.Text != "0")
                    {
                        MusicFactory mf = new MusicFactory();
                        mf.MusicId = ms.MusicId;
                        mf.SingerId = Int32.Parse(ddlSingerFeat.SelectedValue);
                        mf.CreateDate = DateTime.Now;
                        mf.CreateBy = account.AccountId;
                        mf.UpdateDate = DateTime.Now;
                        mf.UpdateBy = account.AccountId;
                        musicFactoryRepository.onAddNew(mf);
                    }

                    ComposerMusic cm = new ComposerMusic();
                    cm.MusicId = ms.MusicId;
                    cm.ComposerId = Int32.Parse(ddlComposer.SelectedValue);
                    cm.CreateDate = DateTime.Now;
                    cm.CreateBy = account.AccountId;
                    cm.UpdateDate = DateTime.Now;
                    cm.UpdateBy = account.AccountId;
                    composerMusicRepository.onAddNew(cm);
                }
                else
                {
                    ms.MusicId = Int32.Parse(txtId.Text);
                    ms.CreateDate = DateTime.Now;
                    ms.CreateBy = account.AccountId;
                    ms.UpdateDate = DateTime.Now;
                    ms.UpdateBy = account.AccountId;
                    musicRepository.onUpdate(ms);

                    if( mfBak != null)
                    {
                        if(ddlSingerFeat.SelectedValue != mfBak.SingerId.ToString())
                        {
                            MusicFactory mf = new MusicFactory();
                            mf.MusicFactoryId = mfBak.MusicFactoryId;
                            mf.MusicId = ms.MusicId;
                            mf.SingerId = Int32.Parse(ddlSingerFeat.SelectedValue);
                            mf.UpdateDate = DateTime.Now;
                            mf.UpdateBy = account.AccountId;
                            musicFactoryRepository.onUpdate(mf);
                        }
                    }

                    if(ddlComposer.SelectedValue != cmBak.ComposerId.ToString())
                    {
                        ComposerMusic cm = new ComposerMusic();
                        cm.ComposerMusicId = cmBak.ComposerMusicId;
                        cm.MusicId = ms.MusicId;
                        cm.ComposerId = Int32.Parse(ddlComposer.SelectedValue);
                        cm.UpdateDate = DateTime.Now;
                        cm.UpdateBy = account.AccountId;
                        composerMusicRepository.onUpdate(cm);
                    }
                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Sucess!'); window.location='" + Request.ApplicationPath + "view/admin/music.aspx';", true);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Something wrong with the error: !" + ex.Message + "');", true);
            }
        }

        private bool checkValidate()
        {
            if (txtName.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "show", "alert('Không được bỏ trống tên nhạc!!');", true);
                return false;
            }
            if (ddlCategory.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "show", "alert('Không được bỏ trống thể loại!!');", true);
                return false;
            }
            if (ddlSinger.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "show", "alert('Không được bỏ trống ca sĩ!!');", true);
                return false;
            }
            if (ddlSingerFeat.SelectedValue == ddlSinger.SelectedValue && ddlSingerFeat.SelectedValue != "0")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "show", "alert('Ca sĩ hát chung không được trùng!!');", true);
                return false;
            }
            if (ddlComposer.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "show", "alert('Không được bỏ trống nhạc sĩ!!');", true);
                return false;
            }
            if (!imageFUL.HasFile || !CheckImageType(imageFUL.FileName))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "show", "alert('Ảnh chưa được chọn hoặc không đúng định dạng!!');", true);
                return false;
            }
            if (!audioFUL.HasFile)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "show", "alert('File audio chưa được chọn!!');", true);
                return false;
            }
            return true;
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