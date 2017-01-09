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
    public partial class DeleteListUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Fill the grid
            List<UserDTO> allUsers = new List<UserDTO>();
            allUsers = BUsers.getAllUserDTO();

            GridDeleteListUser.DataSource = allUsers;
            GridDeleteListUser.DataBind();
        }

        protected void GridDeleteListUser_SelectedIndexChanged(object sender, EventArgs e)
        {
             // Passing the index to the URL 
            string selectedIndex = GridDeleteListUser.SelectedDataKey.Value.ToString();
            Response.Redirect("~/Users/DeleteUsers.aspx?selectedIndex=" + selectedIndex);
        }
    }
}