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
    public partial class MainList : PageBase
    {
        List<UserDTO> allUsers = new List<UserDTO>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Fill the grid
                fillUsersGrid();
 
                // Fill drop down list
                DropDownRegion.DataSource = BRegions.getAll();
                DropDownRegion.DataTextField = "Name";
                DropDownRegion.DataValueField = "RegionId";
                DropDownRegion.DataBind();
            }
        }
        protected void fillUsersGrid()
        {
            // Fill the grid and save it in viewState
            allUsers = BUsers.getAllUserDTO();
            ViewState["allUsers"] = allUsers;

            GridMainDetailsUser.DataSource = allUsers;
            GridMainDetailsUser.DataBind();
        }
        protected void getUserIdinUrl(string _userIdAsString, string _url)
        {
            Response.Redirect(_url + "?userId=" + _userIdAsString);
        }

        protected void GridMainDetailsUser_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Modify" || e.CommandName == "Delete")     
            {
                LinkButton linkButton = (LinkButton)e.CommandSource; // Button
                GridViewRow gridViewRow = (GridViewRow)linkButton.Parent.Parent; // Row
                GridView gridView = (GridView)sender; // Grid

                // Get th edatakey of the selected record
                string id = gridView.DataKeys[gridViewRow.RowIndex].Value.ToString();

                // Do the action of the selected button
                switch (e.CommandName)
                {
                    case "Delete" :
                        getUserIdinUrl(id ,"~/Users/DeleteUsers.aspx");
                        break;
                    case "Modify":
                        getUserIdinUrl(id,"~/Users/UpdateUser.aspx");
                        break;
                }
            }
        }

        protected void GridMainDetailsUser_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridMainDetailsUser.PageIndex = e.NewPageIndex;
            if (ViewState["filterUsers"] != null)
            {
                allUsers = (List<UserDTO>)ViewState["filterUsers"];
                GridMainDetailsUser.DataSource = allUsers;
                GridMainDetailsUser.DataBind();
            }
            else
            {
                fillUsersGrid();
            }
            
        }

        protected void DropDownRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterUsers();
        }

        protected void ButtonRemoveFilter_Click(object sender, EventArgs e)
        {
            // Reset controls
            DropDownRegion.SelectedValue = "-1";
            ViewState.Remove("filterUsers");
            // Fill grid
            fillUsersGrid();
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            filterUsers();
        }
        protected void filterUsers()
        {
            // 1.- Get the last data source from viewstate
            allUsers = (List<UserDTO>)ViewState["allUsers"];

            // 2.- Filter by Region if value is not -1
            if (DropDownRegion.SelectedValue != "-1")
            {
                allUsers = BUsers.filterByRegion(allUsers, DropDownRegion.SelectedItem.Text);
            }

            // 3.- Filter by KeyWord
            allUsers = BUsers.filterByNameLastNameDni(allUsers, TextBoxSearch.Text);

            // 4.- Bind grid and save it in viewstate
            ViewState["filterUsers"] = allUsers;
            GridMainDetailsUser.DataSource = allUsers;
            GridMainDetailsUser.DataBind();
        }
    }
}