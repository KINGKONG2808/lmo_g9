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
    public partial class WebForm15 : System.Web.UI.Page
    {

        private static CategoryRepository categoryRepository = new CategoryRepository();
        private static Account account;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadData();
            }
        }

        private void loadData()
        {
            grdDs.DataSource = categoryRepository.getList();
            DataBind();
            account = (Account)Session["account"];
        }

        protected void delete_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "delete")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                categoryRepository.onDelete(id);
                loadData();
            }
        }

        protected void edit_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "edit")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                Category category = categoryRepository.getById(id);
                Session["categoryEdit"] = category;
                Response.Redirect("~/view/admin/add-category.aspx");
            }
        }

        [WebMethod]
        public static string saveCategory(string categoryName)
        {
            string log;
            try
            {
                Category category = new Category();
                category.Name = categoryName;
                category.CreateDate = DateTime.Now;
                category.CreateBy = account.AccountId;
                category.UpdateDate = DateTime.Now;
                category.UpdateBy = account.AccountId;
                categoryRepository.onAddNew(category);
                log = "Add a new category complete !!!";
            } catch (Exception ex)
            {
                log = "Something wrong with the error: " + ex.Message;
            }
            return log;
        }
    }
}