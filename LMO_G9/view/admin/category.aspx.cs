using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LMO_G9.util;
using LMO_G9.respository;
using LMO_G9.model;

namespace LMO_G9.view.admin
{
    public partial class WebForm15 : System.Web.UI.Page
    {

        CategoryRepository categoryRepository = new CategoryRepository();

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
                txtName.Text = category.Name;
            }
        }

        protected void add_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "add")
            {
                Category category = new Category();
            }
        }
    }
}