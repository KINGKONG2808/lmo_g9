using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LMO_G9.dto;
using LMO_G9.model;
using LMO_G9.respository;
using System.Web.Services;

namespace LMO_G9.view.client
{
    public partial class Category : System.Web.UI.Page
    {
        public static Account account = new Account();
        public static List<model.Category> lcg;
        public static ListMusicRepository lm = new ListMusicRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            lcg = lm.getAllCategories();
        }
    }
}