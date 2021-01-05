using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LMO_G9.model;
using LMO_G9.util;
using LMO_G9.respository;
using System.Globalization;

namespace LMO_G9.view.admin
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        public AccountRespository accountRespository = new AccountRespository();
        public Account account = new Account();

        protected void Page_Load(object sender, EventArgs e)
        {
            account = (Account)Session["account"];

            if (!IsPostBack)
            {
                labelFullname.Text = account.Fullname;
                txtFullname.Text = account.Fullname;
                txtAddress.Text = account.Address;
                txtDateOfBirth.Text = account.DateOfBirth.ToString();
                txtUsername.Text = account.Username;
                txtPassword.Text = account.Password;
                avatarPath.ImageUrl = account.AvatarPath == null ? Constant.NO_PATH_AVATAR : account.AvatarPath;
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (Page.IsValid && FileUpload1.HasFile && CheckFileType(FileUpload1.FileName))
            {
                string fileName = Constant.RESOURCE_PATH + FileUpload1.FileName;
                string filePath = MapPath(fileName);
                FileUpload1.SaveAs(filePath);
                avatarPath.ImageUrl = fileName;
                account.AvatarPath = fileName;
            }
        }

        bool CheckFileType(string fileName)
        {
            string ext = Path.GetExtension(fileName);
            switch (ext.ToLower())
            {
                case ".gif":
                    return true;
                case ".png":
                    return true;
                case ".jpg":
                    return true;
                case ".jpeg":
                    return true;
                default:
                    return false;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string fullname = txtFullname.Text;
            string address = txtAddress.Text;
            string dateOfBirth = txtDateOfBirth.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            try
            {
                Account accountSave = new Account();

                accountSave.AccountId = account.AccountId;
                accountSave.Fullname = fullname;
                accountSave.Address = address;
                accountSave.DateOfBirth = Convert.ToDateTime(dateOfBirth);
                accountSave.RoleId = account.RoleId;
                accountSave.Username = username;
                accountSave.Password = password;
                accountSave.AvatarPath = account.AvatarPath;
                accountSave.CreateBy = account.AccountId;
                accountSave.UpdateBy = account.AccountId;

                accountRespository.updateAccount(accountSave);
            }
            catch (Exception ex)
            {

            }
        }
    }
}