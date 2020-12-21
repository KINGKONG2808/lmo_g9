using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LMO_G9.model;
using LMO_G9.util;
using LMO_G9.respository;

namespace LMO_G9.view.admin
{
    public partial class WebForm14 : System.Web.UI.Page
    {
        private AccountRespository accountRespository = new AccountRespository();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnResetPassword_Click(object sender, EventArgs e)
        {
            string username = txtUsernameReset.Text;
            if (username.CompareTo("") == 0)
            {
                txtError.Text = "Username is required !!!";
                return;
            }

            try
            {
                Account account = accountRespository.checkExistsAccount(null, username, null, Constant.ACCOUNT_ROLE_ADMIN);
                if (account.AccountId != 0)
                {
                    accountRespository.resetPasswordAccount(username);
                    txtError.Text = "";
                    ScriptManager.RegisterStartupScript(this,
                        this.GetType(),
                        "alert",
                        "alert('Reset your password to default complete. Enter OK to login now !!!'); window.open(window.location.origin + '/view/admin/login.aspx', '_self');",
                        true);
                } else
                {
                    txtError.Text = "The usename: '" + username + "' is not exists.";
                    return;
                }
            } catch (Exception ex)
            {
                txtError.Text = "Error: " + ex.Message;
            }
        }
    }
}