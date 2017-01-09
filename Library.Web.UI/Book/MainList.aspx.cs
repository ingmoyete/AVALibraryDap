using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataLibrary;
using BussinessLibrary;
using System.Windows.Forms;

namespace Library.Web.UI.Book
{
    public partial class MainList : PageBase
    {
        List<BookDTO> allBooks = new List<BookDTO>();

        protected void Page_Load(object sender, EventArgs e)
        {
            GridMainList.DataSource = null;
            
            if (!IsPostBack)
            {
                // Fill filter
                DropDownSection.DataSource = BSection.getAll();
                DropDownSection.DataTextField = "Name";
                DropDownSection.DataValueField = "SectionId";
                DropDownSection.DataBind();


                // Fill the grid
                fillBookDTO();
            }

        }
        protected void fillBookDTO()
        {
            // Fill the grid with all records from BookDTO and save it in ViewState
            allBooks = Books.getBookDTOAll();
            ViewState["allBooks"] = allBooks;

            GridMainList.DataSource = allBooks;
            GridMainList.DataBind();
        }
        protected void GridMainList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Modify" || e.CommandName == "Delete" || e.CommandName == "Copies")
            {
                
                LinkButton linkButton = (LinkButton)e.CommandSource; // Button
                GridViewRow gridViewRow = (GridViewRow)linkButton.Parent.Parent; // Row
                GridView gridView = (GridView)sender; // Grid

                // Get the datakey of the selected record
                string id = gridView.DataKeys[gridViewRow.RowIndex].Value.ToString();

                // Do the action of the selected button
                switch (e.CommandName)
                {
                    case "Delete":
                        Response.Redirect("~/Book/Delete.aspx?bookId=" + id);
                        break;
                    case "Modify":
                        Response.Redirect("~/Book/Update.aspx?bookId=" + id);
                        break;
                    case "Copies":
                        Response.Redirect("~/Book/Copies.aspx?bookId=" + id);
                        break;
                }
            }
        }

        protected void GridMainList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridMainList.PageIndex = e.NewPageIndex;
            // Fill the grid
            if (ViewState["filterBooks"] != null)
            {
                allBooks = (List<BookDTO>)ViewState["filterBooks"];
                GridMainList.DataSource = allBooks;
                GridMainList.DataBind();
            }
            else
            {
                fillBookDTO();
            }

        }
        protected void filterBySectionAndCopy()
        {
            // 1.- Get latest datasource
            allBooks = (List<BookDTO>)ViewState["allBooks"];

            // 2.- Filter by Section and fill Grid
            if (DropDownSection.SelectedValue != "-1")
            {
                allBooks = BBooks.getBookDTOBySection(allBooks, DropDownSection.SelectedItem.Text);
            }

            // 3.- Filter by copy and fill Grid
            if (DropDownCopies.SelectedValue != "-1")
            {
                allBooks = BBooks.getBookDTOByCopies(allBooks, Convert.ToInt32(DropDownCopies.SelectedValue));
            }
            
            // 5.- Filter by author or title
            allBooks = BBooks.getBookDTOByAuthorOrTitle(allBooks, TextBoxSearch.Text);
 
            // 4.- Fill Grid and save it in viewState
            ViewState["filterBooks"] = allBooks;
            GridMainList.DataSource = allBooks;
            GridMainList.DataBind();
        }
        protected void DropDownSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterBySectionAndCopy();
        }

        protected void ButtonRemoveFilter_Click(object sender, EventArgs e)
        {
            // Reset Filters
            DropDownSection.SelectedValue = "-1";
            DropDownCopies.SelectedValue = "-1";
            ViewState.Remove("filterBooks");
            // Fill the grid
            fillBookDTO();
            
        }

        protected void DropDownCopies_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterBySectionAndCopy();
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            filterBySectionAndCopy();
        }

        protected void DropDownRegion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ButtonRemoveFilter_Click1(object sender, EventArgs e)
        {

        }
    }
}