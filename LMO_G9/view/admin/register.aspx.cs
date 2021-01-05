using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LMO_G9.respository;
using LMO_G9.util;
using LMO_G9.model;
using System.Globalization;

namespace LMO_G9.view.admin
{
    public partial class WebForm12 : System.Web.UI.Page
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

            if (fullname.CompareTo("") == 0)
            {
                txtError.Text = "Fullname is required !!!";
                return;
            }
            if (address.CompareTo("") == 0)
            {
                txtError.Text = "Address is required !!!";
                return;
            }
            if (username.CompareTo("") == 0)
            {
                txtError.Text = "Username is required !!!";
                return;
            }
            if (dateOfBirth.CompareTo("") == 0)
            {
                txtError.Text = "Date of birth is required !!!";
                return;
            }
            if (password.CompareTo("") == 0)
            {
                txtError.Text = "Password is required !!!";
                return;
            }
            if (repassword.CompareTo("") == 0)
            {
                txtError.Text = "Repassword is required !!!";
                return;
            }
            if (repassword.CompareTo(password) != 0)
            {
                txtError.Text = "Repassword is not match with password !!!";
                return;
            }

            try
            {
                Account account = new Account();
                account.Fullname = fullname;
                account.Address = address;
                account.DateOfBirth = DateTime.ParseExact(dateOfBirth, "dd/mm/yyyy", CultureInfo.InvariantCulture);
                account.RoleId = Constant.ACCOUNT_ROLE_ADMIN;
                account.Username = username;
                account.Password = password;
                account.CreateDate = DateTime.Now;
                account.UpdateDate = DateTime.Now;

                Account accountCheckExists = accountRespository.checkExistsAccount(null, username, null, Constant.ACCOUNT_ROLE_ADMIN);
                if (accountCheckExists.AccountId == 0)
                {
                    accountRespository.createAccount(account);
                    txtError.Text = "";
                    ScriptManager.RegisterStartupScript(this,
                        this.GetType(),
                        "alert",
                        "alert('Your new account is ready to sign in. Enter OK to login now !!!'); window.open(window.location.origin + '/view/admin/login.aspx', '_self');",
                        true);
                } else
                {
                    txtError.Text = "The username already exists, please enter an other username place ...";
                    return;
                }
            } catch (Exception ex)
            {
                txtError.Text = ex.Message;
            }
        }
    }
}