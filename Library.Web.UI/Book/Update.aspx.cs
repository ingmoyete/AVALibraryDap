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
    public partial class Update : PageBase
    {
        Books bookToUpdate = new Books();
        Copy copyToUpdate = new Copy();
        int index;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Get the index of the book to update
                index = Convert.ToInt32(Request.QueryString["bookId"]);

                // Get the record and save it in viewstate
                bookToUpdate = BBooks.getById(index);
                ViewState["bookToUpdate"] = bookToUpdate;

                // Load Section dropDownList
                ddlSection.DataSource = BSection.getAll();
                ddlSection.DataTextField = "Name";
                ddlSection.DataValueField = "SectionId";
                ddlSection.DataBind(); 

                // Fill the textBoxes
                boxTitle.Text               = bookToUpdate.Title;
                boxAuthor.Text              = bookToUpdate.Author;
                ddlSection.SelectedValue    = bookToUpdate.SectionId.ToString();

                boxIbsn.Enabled = false;
                boxIbsn.Text = bookToUpdate.Ibsn.ToString();
            }

        }
        protected void ButUpdate_Click(object sender, EventArgs e)
        {

            // Gets record to update
            bookToUpdate = (Books)ViewState["bookToUpdate"];

            // Modify record
            bookToUpdate.Title = boxTitle.Text;
            bookToUpdate.Author = boxAuthor.Text;
            bookToUpdate.SectionId = Convert.ToInt32(ddlSection.SelectedValue);

            // Update record and goes to MainList.aspx
            BBooks.update(bookToUpdate);
            Response.Redirect("~/Book/MainList.aspx");
        }
    }
}