using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataLibrary;
using BussinessLibrary;

namespace Library.Web.UI.Users
{
    public partial class InsertUser : PageBase
    {
        DataLibrary.Users users = new DataLibrary.Users();

        protected void Page_Load(object sender, EventArgs e)
        {
            // It does this only the first time the page is loaded
            if (!IsPostBack)
            {
                // Load the dropDownList
                DdlRegion.DataSource = BRegions.getAll();
                DdlRegion.DataTextField = "Name";
                DdlRegion.DataValueField = "RegionId";
                DdlRegion.DataBind();

                // Shows sign up date and renewal date (just 6 months more)
                boxSignUp.Text = DateTime.Today.ToString("dd/MM/yyyy");
                boxRenewal.Enabled = false;
                boxRenewal.Text = DateTime.Today.AddMonths(6).ToString("dd/MM/yyyy");
            }
        }

        protected void ButInsertUser_Click(object sender, EventArgs e)
        {
            //Set the renewal day
            boxRenewal.Enabled = false;

            //boxRenewal.Text = DateTime.Today.AddMonths(6).ToShortDateString();

            // Set users
            users.UserName      = boxUserName.Text;
            users.Pass          = boxPass.Text;

            DateTime signD      = DateTime.ParseExact(boxSignUp.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            users.SignUpDate    = signD;
            DateTime renewD     = DateTime.ParseExact(boxRenewal.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            renewD = DateTime.Today.AddMonths(6);
            users.RenewalDate   = renewD;
            
            users.Name          = boxName.Text;
            users.LastName      = boxLastName.Text;
            users.RegionId      = Convert.ToInt32(DdlRegion.SelectedValue);
            users.Dni           = Convert.ToInt32(boxDNI.Text);

            try
            {
                BUsers.insert(users);
                Response.Redirect("~/Users/MainList.aspx");
            }
            catch (Exception generalException)
            {
                PanelInsertUser.Visible = true;
                LiteralInsertUser.Text = generalException.Message;
            }
        }
    }
}