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
        public string fullname = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (HttpContext.Current.Session["account"] != null)
                {
                    account = (Account)Session["account"];
                    if (account.Fullname != null)
                    {
                        fullname = account.Fullname;
                    }
                } else
                {
                    Response.Redirect("~/view/library/404.html");
                }
            }
        }
    }
}