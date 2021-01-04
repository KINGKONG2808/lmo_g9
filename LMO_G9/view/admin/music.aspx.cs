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
    public partial class WebForm16 : System.Web.UI.Page
    {
        private static ListMusicRepository musicRepository = new ListMusicRepository();
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
            grdDs.DataSource = musicRepository.getList();
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
            ddlSinger.DataSource = singerResponsitory.dsSinger();
            ddlSinger.DataTextField = "name";
            ddlSinger.DataValueField = "singerId";
            //ddl singer feat
            ddlSingerFeat.DataSource = singerResponsitory.dsSinger();
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
                loadData();
            }
        }

        protected void edit_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "edit")
            {
                int id = Convert.ToInt32(e.CommandArgument);
            }
        }
    }
}