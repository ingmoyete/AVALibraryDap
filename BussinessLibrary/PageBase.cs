using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace BussinessLibrary
{
    public class PageBase : System.Web.UI.Page
    {
        public PageBase()
        {

        }

        protected override void OnLoad(EventArgs e)
        {
            //if (Session["loginAdmin"] == null)
            //{
            //    Response.Redirect("~/Login.aspx");
            //}

            base.OnLoad(e);
        }
    }
}
