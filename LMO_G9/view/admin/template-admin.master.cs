using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LMO_G9.model;

namespace LMO_G9.view.admin
{
    public partial class template_admin : System.Web.UI.MasterPage
    {
        public Account account;

        protected void Page_Load(object sender, EventArgs e)
        {
            account = (Account)Session["account"];
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.Remove("account");
            Response.Redirect("~/view/admin/login.aspx");
        }
    }
}