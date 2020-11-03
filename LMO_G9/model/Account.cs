using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMO_G9.model
{
    public class Account : BaseModel
    {
        private long accountId;
        private string fullname;
        private string address;
        private DateTime dateOfBirth;
        private string username;
        private string password;
        private string avatarPath;

        public Account()
        {
        }

        public Account(long accountId, string fullname, string address, DateTime dateOfBirth, string username, string password, string avatarPath)
        {
            this.AccountId = accountId;
            this.Fullname = fullname;
            this.Address = address;
            this.DateOfBirth = dateOfBirth;
            this.Username = username;
            this.Password = password;
            this.AvatarPath = avatarPath;
        }

        public long AccountId { get => accountId; set => accountId = value; }
        public string Fullname { get => fullname; set => fullname = value; }
        public string Address { get => address; set => address = value; }
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string AvatarPath { get => avatarPath; set => avatarPath = value; }
    }
}