using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LMO_G9.model;
using LMO_G9.util;
using LMO_G9.respository;

namespace LMO_G9.view.client
{
    public partial class forgot_pasword : System.Web.UI.Page
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
                txtError.Text = "Tên đăng nhập là bắt buộc !!!";
                return;
            }

            try
            {
                Account account = accountRespository.checkExistsAccount(null, username, null, Constant.ACCOUNT_ROLE_USER);
                if (account.AccountId != 0)
                {
                    accountRespository.resetPasswordAccount(username);
                    txtError.Text = "";
                    ScriptManager.RegisterStartupScript(this,
                        this.GetType(),
                        "alert",
                        "alert('Đặt lại mật khẩu thành công. Click OK để đăng nhập !!!'); window.open(window.location.origin + '/view/client/signin.aspx', '_self');",
                        true);
                }
                else
                {
                    txtError.Text = "Tên đăng nhập: '" + username + "' không tồn tại.";
                    return;
                }
            }
            catch (Exception ex)
            {
                txtError.Text = "Lỗi hệ thống: " + ex.Message;
            }
        }
    }
}