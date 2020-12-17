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
        public string fullname;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                account = (Account)Session["account"];
                fullname = account.Fullname == null ? "ADMIN" : account.Fullname;
            }
        }
    }
}