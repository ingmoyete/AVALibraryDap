using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BussinessLibrary;

namespace Library.Web.UI
{
    public partial class Default : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                
        }

        protected void LinkButtonCloseSection_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("~/Login.aspx");
        }
        
    }
}