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
    public partial class DeleteUsers : PageBase
    {
        // Begin declaration
        DataLibrary.Users users = new DataLibrary.Users();
        int userIndex;
        int peopleIndex;
        // End declaration

        protected void Page_Load(object sender, EventArgs e)
        {
            // It does this only the first time the page is loaded
            if (!IsPostBack)
            {
                // Get the record to update through the index in the url
                userIndex = Convert.ToInt32(Request.QueryString["userId"]);
                users = BUsers.getById(userIndex);

                // Sets people id in viewState
                ViewState["users"] = users;

                // Load the dropDownList
                DdlRegion.DataSource = BRegions.getAll();
                DdlRegion.DataTextField = "Name";
                DdlRegion.DataValueField = "RegionId";
                DdlRegion.DataBind();

                // Set the value of the record
                DdlRegion.SelectedValue = users.RegionId.ToString();
                boxName.Text = users.Name;
                boxLastName.Text = users.LastName;
                boxDNI.Text = users.Dni.ToString();
                boxSignUp.Text = users.SignUpDate.ToShortDateString();
                boxRenewal.Text = users.RenewalDate.ToShortDateString();
                boxUserName.Text = users.UserName;
                boxPass.Text = users.Pass;

                // Disable fields
                disableFields();
            }
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            // Get the record
            users = (DataLibrary.Users)ViewState["users"];

            // Gets people and user index
            userIndex = users.UserId;
            peopleIndex = users.PeopleId;

            try
            {
                // Delete Users
                BUsers.deleteById(userIndex, peopleIndex);
                Response.Redirect("~/Users/MainList.aspx");
            }
            catch (Exception generalException)
            {
                PanelDeleteUser.Visible = true;
                LiteralDeleteUser.Text = generalException.Message; 
            }
        }
        public void disableFields()
        {
            DdlRegion.Enabled = false;
            boxName.Enabled = false;
            boxLastName.Enabled = false;
            boxDNI.Enabled = false;
            boxSignUp.Enabled = false;
            boxRenewal.Enabled = false;
            boxUserName.Enabled = false;
            boxPass.Enabled = false;
        }
    }
}