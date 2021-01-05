using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMO_G9.util
{
    public class Constant
    {
        // connect string config
        public static string CONNECTING_STRING_K2 = @"Data Source=KINGKONG;Initial Catalog=lmo_g9;Integrated Security=True";
        public static string CONNECTING_STRING_NIET = @"Data Source=NIET\SQLEXPRESS;Initial Catalog=lmo_g9;Integrated Security=True";
        public static string CONNECTING_STRING_HIEU = @"Data Source=DESKTOP-L3U3G83;Initial Catalog=lmo_g9;Integrated Security=True";
        public static string CONNECTING_STRING_JALS = @"Data Source=ADMIN;Initial Catalog=lmo_g9;Integrated Security=True";

        public static int ACCOUNT_ROLE_USER = 0;
        public static int ACCOUNT_ROLE_ADMIN = 1;

        public static string DEFAULT_USERNAME = "1";
        public static string DEFAULT_PASSWORD = "1";

        public static string NO_PATH_AVATAR = "~/view/template/images/no-avatar.jpg";
        public static string RESOURCE_PATH = "~/target/upload/";
    }
}