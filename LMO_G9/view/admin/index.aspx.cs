using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Threading;

namespace LMO_G9.view.admin
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string logout()
        {
            string result;
            try
            {
                HttpContext.Current.Session.Remove("account");
                result = "/view/admin/login.aspx";
            } catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }
    }
}