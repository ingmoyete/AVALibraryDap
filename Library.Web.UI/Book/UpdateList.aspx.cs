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
    public partial class UpdateList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Fill the grid
            List<BookDTO> allBooks = new List<BookDTO>();
            allBooks = BBooks.getBookDTOAll();

            GridUpdateList.DataSource = allBooks;
            GridUpdateList.DataBind();
        }

        protected void GridUpdateList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Passing the index to the URL 
            string selectedIndex = GridUpdateList.SelectedDataKey.Value.ToString();
            Response.Redirect("~/Book/Update.aspx?selectedIndex=" + selectedIndex);
        }


    }
}