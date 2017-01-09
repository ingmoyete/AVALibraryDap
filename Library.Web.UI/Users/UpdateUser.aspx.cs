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
    public partial class UpdateUser : PageBase
    {
        // Begin declaration
        DataLibrary.Users users = new DataLibrary.Users();
        int userIndex;
        int peopleIndex;
        int writtenIndex;
        // End declaration

        protected void Page_Load(object sender, EventArgs e)
        {
            // It does this only the first time the page is loaded
            if (!IsPostBack)
            {
                // Get user index and usert object for that index
                userIndex = Convert.ToInt32(Request.QueryString["userId"]);
                users = BUsers.getById(userIndex);
                
                // Save the user object in viewState
                ViewState["users"] = users;
                

                // Load the dropDownList
                DdlRegion.DataSource = BRegions.getAll();
                DdlRegion.DataTextField = "Name";
                DdlRegion.DataValueField = "RegionId";
                DdlRegion.DataBind();

                // DNI cannot be modified
                boxDNI.Enabled = false;
                boxDNI.Text = users.Dni.ToString();

                // Set the value of the record
                DdlRegion.SelectedValue = users.RegionId.ToString();
                boxName.Text = users.Name;
                boxLastName.Text = users.LastName;

                boxSignUp.Text = users.SignUpDate.ToString("dd/MM/yyyy");
                boxRenewal.Text = users.RenewalDate.ToString("dd/MM/yyyy");
                boxUserName.Text = users.UserName;
                boxPass.Text = users.Pass;
            }
        }

        protected void ButUpdateUser_Click(object sender, EventArgs e)
        {
            // Gets people index from ViewState
            users = (DataLibrary.Users)ViewState["users"]; 

            // Set user
            
            users.Name      = boxName.Text;
            users.LastName  = boxLastName.Text;
            users.RegionId  = Convert.ToInt32(DdlRegion.SelectedValue);

            DateTime signDate = DateTime.ParseExact(boxSignUp.Text, "dd/MM/yyyy", null);
            users.SignUpDate = Convert.ToDateTime(signDate);
            DateTime renewDate = DateTime.ParseExact(boxRenewal.Text, "dd/MM/yyyy", null);
            users.RenewalDate = Convert.ToDateTime(renewDate);

            users.UserName = boxUserName.Text;
            users.Pass = boxPass.Text;

            BUsers.update(users);

            Response.Redirect("~/Users/MainList.aspx");
          
        }
    }
}