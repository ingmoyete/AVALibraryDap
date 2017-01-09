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
    public partial class DeleteCopies : PageBase
    {
        Copy copy = new Copy();
        int copyId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Get Index of the copy to update and save it in viewstate
                copyId = Convert.ToInt32(Request.QueryString["copyId"]);

                // Get the copy record and save it in viewstate
                copy = BCopy.getById(copyId);
                ViewState["copy"] = copy;

                // Fill controls
                boxBookId.Text = copy.BookId.ToString();
                boxBookId.Enabled = false;

                boxCopyId.Text = copy.CopyId.ToString();
                boxCopyId.Enabled = false;

                boxRenewal.Text = copy.RenewalDate.ToString("dd/MM/yyyy");
                boxRenewal.Enabled = false;

                boxPurchase.Text = copy.PurchaseDate.ToString("dd/MM/yyyy");
                boxPurchase.Enabled = false;
            }
        }

        protected void LinkGoCopyList_Click(object sender, EventArgs e)
        {

        }

        protected void ButUpdate_Click(object sender, EventArgs e)
        {
            // Get the record from viewstate
            copy = (Copy)ViewState["copy"];

            // Get values from controls
            DateTime renewD = DateTime.ParseExact(boxRenewal.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            copy.RenewalDate = renewD;
            DateTime purchaseD = DateTime.ParseExact(boxPurchase.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            copy.PurchaseDate = purchaseD;

            try
            {
                // Update and goes to copy list
                BCopy.deleteById(copy.CopyId);
                Response.Redirect("~/Book/Copies.aspx?bookId=" + copy.BookId);
            }
            catch (Exception generalException)
            {
                PanelDeleteCopy.Visible = true;
                LiteralDeleteCopy.Text = generalException.Message;
            }
        }

        protected void ButCancel_Click(object sender, EventArgs e)
        {
            // Get the record from viewstate and goes to copy list
            copy = (Copy)ViewState["copy"];
            Response.Redirect("~/Book/Copies.aspx?bookId=" + copy.BookId);
        }
    }
}