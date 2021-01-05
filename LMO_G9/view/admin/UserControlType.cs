using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMO_G9.view.admin
{
    internal class UserControlType
    {
        public static explicit operator UserControlType(Control v)
        {
            throw new NotImplementedException();
        }

        internal FileUpload FindControl(object fuid)
        {
            throw new NotImplementedException();
        }
    }
}