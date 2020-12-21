using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LMO_G9.respository;
using LMO_G9.model;
using LMO_G9.util;

namespace LMO_G9.view.admin
{
    public partial class WebForm13 : System.Web.UI.Page
    {
        private AccountRespository accountRespository = new AccountRespository();
        private string username;
        private string password;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void login()
        {
            if (username == "")
            {
                txtError.Text = "Usename is required !!!";
                return;
            }
            if (password == "")
            {
                txtError.Text = "Password is required !!!";
                return;
            }
            Account account = accountRespository.checkExistsAccount(null, username, password, Constant.ACCOUNT_ROLE_ADMIN);
            if (account.AccountId == 0)
            {
                txtError.Text = "Invalid account, check your usename or password is correct to sign in !!!";
                return;
            }

            Session["account"] = account;
            Response.Redirect("~/view/admin/index.aspx");
            txtError.Text = "";
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            username = txtUsername.Text;
            password = txtPassword.Text;
            
            try
            {
                login();
            } catch (Exception ex)
            {
                txtError.Text = "Other error: " + ex.Message;
            }
        }
    }
}