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
    public partial class Copies : PageBase
    {
        int bookId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Get the index of the book to update and save it in viewstate
                bookId = Convert.ToInt32(Request.QueryString["bookId"]);
                ViewState["bookId"] = bookId;

                // Get all the copies
                fillCopiesByBookID(bookId);
            }
        }
        protected void fillCopiesByBookID(int _bookId)
        {
            // Get all the copies
            List<Copy> listCopy = new List<Copy>();
            listCopy = BCopy.getAllCopyByBookId(_bookId);
            GridCopyList.DataSource = listCopy;
            GridCopyList.DataBind();
        }
        protected void GridCopyList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Modify" || e.CommandName == "Delete")
            {
                
                LinkButton linkButton = (LinkButton)e.CommandSource; // Button
                GridViewRow gridViewRow = (GridViewRow)linkButton.Parent.Parent; // Row
                GridView gridView = (GridView)sender; // Grid

                // Get CopyId as the datakey of the selected record
                string copyId = gridView.DataKeys[gridViewRow.RowIndex].Value.ToString();

                // Do the action of the selected button
                switch (e.CommandName)
                {
                    case "Delete":
                        Response.Redirect("~/Book/DeleteCopies.aspx?copyId=" + copyId);
                        break;
                    case "Modify":
                        Response.Redirect("~/Book/UpdateCopies.aspx?copyId=" + copyId);
                        break;
                }
            }
        }

        protected void GridCopyList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridCopyList.PageIndex = e.NewPageIndex;
            bookId = (int)ViewState["bookId"];
            fillCopiesByBookID(bookId);
        }
    }
}