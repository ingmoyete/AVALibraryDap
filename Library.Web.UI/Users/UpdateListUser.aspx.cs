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
    public partial class UpdateListUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Fill the grid
            List<UserDTO> allUsers = new List<UserDTO>();
            allUsers = BUsers.getAllUserDTO();

            GridUpdateListUsers.DataSource = allUsers;
            GridUpdateListUsers.DataBind();
        }

        protected void GridUpdateListUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            string indexSelected = GridUpdateListUsers.SelectedDataKey.Value.ToString();
            Response.Redirect("~/Users/UpdateUser.aspx?indexSelected=" + indexSelected);
        }
    }
}