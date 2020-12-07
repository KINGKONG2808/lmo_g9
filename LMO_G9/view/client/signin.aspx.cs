using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LMO_G9.respository;
using LMO_G9.model;
using LMO_G9.util;

namespace LMO_G9.view.client
{
    public partial class signin : System.Web.UI.Page
    {
        private AccountRespository accountRespository = new AccountRespository();
        private string username;
        private string password;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void clear()
        {
            username = null;
            password = null;
        }

        private void login()
        {
            Account account = accountRespository.checkExistsAccount(username, password, Constant.ACCOUNT_ROLE_USER);
            if (account.AccountId == 0)
            {
                txtError.Text = "Tài khoản hoặc mật khẩu không chính xác !!!";
                return;
            }

            Session["accountClient"] = account;
            Response.Redirect("~/view/client/index.aspx");
            txtError.Text = "";
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            username = txtUsername.Text;
            password = txtPassword.Text;

            try
            {
                login();
            }
            catch (Exception ex)
            {
                txtError.Text = "Other error: " + ex.Message;
            }
        }
    }
}