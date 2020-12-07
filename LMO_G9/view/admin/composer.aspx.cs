using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LMO_G9.model;
using LMO_G9.respository;

namespace LMO_G9.view.admin
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        ComposerRepository composerRespository = new ComposerRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            hienthi();
        }

        private void hienthi()
        {
            grComposer.DataSource = composerRespository.dsComposer();
            DataBind();
        }
        protected void Xoa_Click(Object sender, CommandEventArgs e)
        {
            if (e.CommandName == "xoa")
            {
                int m = Convert.ToInt16(e.CommandArgument);
                composerRespository.Xoa(m);
                hienthi();
            }
        }
        protected void Sua_Click(Object sender, CommandEventArgs e)
        {
            if (e.CommandName == "sua")
            {
               
            }
        }
        protected void add_Command(Object sender, CommandEventArgs e)
        {
            if (e.CommandName == "sua")
            {

            }
        }
        protected void btnThem_Click(Object sender, CommandEventArgs e)
        {
            
        }
    }
}