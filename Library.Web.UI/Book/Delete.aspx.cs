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
    public partial class Delete : PageBase
    {
        // Begin declaration
        Books bookToUpdate = new Books();
        int index;
        // End declaration


        protected void Page_Load(object sender, EventArgs e)
        {
            changeColorTextBox();

            if (!IsPostBack)
            {
                // Get the index of the book to update
                index = Convert.ToInt32(Request.QueryString["bookId"]);

                // Get the record and save it in viewState
                bookToUpdate = BBooks.getById(index);
                ViewState["bookToUpdate"] = bookToUpdate;

                // Load Section dropDownList
                ddlSection.DataSource = BSection.getAll();
                ddlSection.DataTextField = "Name";
                ddlSection.DataValueField = "SectionId";
                ddlSection.DataBind();

                boxTitle.Text = bookToUpdate.Title;
                boxAuthor.Text = bookToUpdate.Author;
                ddlSection.SelectedValue = bookToUpdate.SectionId.ToString();

            }
        }

        protected void ButDelete_Click(object sender, EventArgs e)
        {
            changeColorTextBox();

            // Get record from viewstate
            bookToUpdate = (Books)ViewState["bookToUpdate"];

            // Delete record in COPIES kand goes to DeleteList.aspx
            try
            {
                BBooks.deleteAllCopiesById(bookToUpdate.BookId);
                Response.Redirect("~/Book/MainList.aspx");
            }
            catch (Exception generalException)
            {
                PanelDeleteBook.Visible = true;
                LiteralDeleteBook.Text = generalException.Message;
            }
        }

        private void changeColorTextBox()
        {
            // Change the color of the text boxes into gray
            boxTitle.BackColor = System.Drawing.Color.Silver;
            boxAuthor.BackColor = System.Drawing.Color.Silver;
            ddlSection.Enabled = false;
        }
    }
}