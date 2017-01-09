using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataLibrary;
using BussinessLibrary;
using Microsoft.AspNet.FriendlyUrls;

namespace AVALibraryDap
{
    public partial class ListBooks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Fill the grid
            List<Books> allBooks = new List<Books>();
            allBooks = BBooks.getAll();
            
            gridBookList.DataSource = allBooks;
            gridBookList.DataBind();

            // Insert Books
            Books book = new Books();
        }

        protected void gridBookList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Response.Redirect(FriendlyUrl.Href("~/ListBooks", gridBookList.SelectedDataKey.Value.ToString()));
        }
    }
}