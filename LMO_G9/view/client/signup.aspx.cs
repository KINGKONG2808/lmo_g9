using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LMO_G9.respository;
using LMO_G9.util;
using LMO_G9.model;

namespace LMO_G9.view.client
{
    public partial class signup : System.Web.UI.Page
    {
        public AccountRespository accountRespository = new AccountRespository();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string fullname = txtFullname.Text;
            string address = txtAddress.Text;
            string dateOfBirth = txtDateOfBirth.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string repassword = txtRepassword.Text;

            if (repassword.CompareTo(password) != 0)
            {
                txtError.Text = "Mật khẩu nhập lại chưa chính xác !!!";
                return;
            }

            try
            {
                Account account = new Account();
                account.Fullname = fullname;
                account.Address = address;
                account.DateOfBirth = Convert.ToDateTime(dateOfBirth);
                account.RoleId = Constant.ACCOUNT_ROLE_USER;
                account.Username = username;
                account.Password = password;
                account.CreateDate = DateTime.Now;
                account.UpdateDate = DateTime.Now;

                Account accountCheckExists = accountRespository.checkExistsAccount(null, username, null, Constant.ACCOUNT_ROLE_USER);
                if (accountCheckExists.AccountId == 0)
                {
                    accountRespository.createAccount(account);
                    txtError.Text = "";
                    ScriptManager.RegisterStartupScript(this,
                        this.GetType(),
                        "alert",
                        "alert('Tài khoản mới của bạn đã sẵn sàng để đăng nhập. Nhập OK để đăng nhập ngay bây giờ !!!'); window.open(window.location.origin + '/view/client/signin.aspx', '_self');",
                        true);
                }
                else
                {
                    txtError.Text = "Tên người dùng đã tồn tại, vui lòng nhập một tên người dùng khác ...";
                    return;
                }
            }
            catch (Exception ex)
            {
                txtError.Text = ex.Message;
            }
        }
    }
}