using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataLibrary;
using BussinessLibrary;

namespace Library.Web.UI.Book
{
    public partial class DeleteList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Fill the grid
            List<BookDTO> allBooks = new List<BookDTO>();
            allBooks = BBooks.getBookDTOAll();

            GridDeleteList.DataSource = allBooks;
            GridDeleteList.DataBind();
        }

        protected void GridDeleteList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Passing the index to the URL 
            string selectedIndex = GridDeleteList.SelectedDataKey.Value.ToString();
            Response.Redirect("~/Book/Delete.aspx?selectedIndex=" + selectedIndex);
        }
    }
}