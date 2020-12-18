using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMO_G9.model
{
    public class Account : BaseModel
    {
        private int accountId;
        private string fullname;
        private string address;
        private DateTime dateOfBirth;
        private int roleId;
        private string username;
        private string password;
        private string avatarPath;

        public Account()
        {
        }

        public Account(int accountId, string fullname, string address, DateTime dateOfBirth, int roleId, string username, string password, string avatarPath)
        {
            this.AccountId = accountId;
            this.Fullname = fullname;
            this.Address = address;
            this.DateOfBirth = dateOfBirth;
            this.RoleId = roleId;
            this.Username = username;
            this.Password = password;
            this.AvatarPath = avatarPath;
        }

        public int AccountId { get => accountId; set => accountId = value; }
        public string Fullname { get => fullname; set => fullname = value; }
        public string Address { get => address; set => address = value; }
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        public int RoleId { get => roleId; set => roleId = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string AvatarPath { get => avatarPath; set => avatarPath = value; }
    }
}