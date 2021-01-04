using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LMO_G9.model;
using LMO_G9.util;

namespace LMO_G9.view.client
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        public Account account = new Account();

        protected void Page_Load(object sender, EventArgs e)
        {
            account = (Account)Session["accountClient"];
            labelFullname.Text = account.Fullname;
            txtFullname.Text = account.Fullname;
            txtAddress.Text = account.Address;
            txtDateOfBirth.Text = account.DateOfBirth.ToString("dd/MM/yyyy");
            txtUsername.Text = account.Username;
            txtPassword.Text = account.Password;
            avatarPath.ImageUrl = account.AvatarPath == null ? Constant.NO_PATH_AVATAR : account.AvatarPath;
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (Page.IsValid && FileUpload1.HasFile && CheckFileType(FileUpload1.FileName))
            {
                string fileName = "~/target/upload/" + FileUpload1.FileName;
                string filePath = MapPath(fileName);
                FileUpload1.SaveAs(filePath);
                avatarPath.ImageUrl = fileName;
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
    }
}