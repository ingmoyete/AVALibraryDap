using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataLibrary;
using BussinessLibrary;
using System.IO;


namespace Library.Web.UI.Book
{
    public partial class Insert : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Load dropDownList
                ddlSection.DataSource = BSection.getAll();
                ddlSection.DataTextField = "Name";
                ddlSection.DataValueField = "SectionId";
                ddlSection.DataBind();

                // Set today date
                boxPurchase.Text = DateTime.Today.ToString("dd/MM/yyyy");
            }  
        }
        protected void ButInsert_Click(object sender, EventArgs e)
        {
            // Set book
            Books book = new Books();

            book.Title      = boxTitle.Text;
            book.Author     = boxAuthor.Text;
            book.SectionId  = Convert.ToInt32(ddlSection.SelectedValue);
            book.Ibsn       = Convert.ToInt32(boxIbsn.Text);

            // Set Copy
            Copy copy = new Copy();
            DateTime renewD = DateTime.ParseExact(boxRenewal.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            copy.RenewalDate = renewD;
            DateTime purchaseD = DateTime.ParseExact(boxPurchase.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            copy.PurchaseDate = purchaseD;

            // Set the number of copies
            int numberCopies = Convert.ToInt32(boxCopies.Text);

            // Insert Book and go the list page
            int bookId = BBooks.insert(book, copy, numberCopies);
            Response.Redirect("~/Book/MainList.aspx");
          
        }
        protected string writeDigitsLabel()
        {
            StringWriter stringWriter = new StringWriter();

            using (HtmlTextWriter textWriter = new HtmlTextWriter(stringWriter))
            {
                string classValue = "error";

                textWriter.AddAttribute(HtmlTextWriterAttribute.Class, classValue);
                textWriter.RenderBeginTag(HtmlTextWriterTag.Label);
                textWriter.Write("Please enter only digits.");
                textWriter.RenderEndTag();
            }

            return stringWriter.ToString();
        }
        protected void boxIbsn_TextChanged(object sender, EventArgs e)
        {

            // Enable Fields
            boxTitle.Enabled = true;
            //boxTitle.Text = "";

            boxAuthor.Enabled = true;
            //boxAuthor.Text = "";

            ddlSection.Enabled = true;

            // Validate text field
            literalIbsn.Text = "";
            int value;
            if (!int.TryParse(boxIbsn.Text, out value))
            {
                literalIbsn.Text = writeDigitsLabel(); 
            }

            // If textBox contains data and is a number it does the logic
            if (!string.IsNullOrEmpty(boxIbsn.Text) && int.TryParse(boxIbsn.Text, out value))
            {
                int ibsnToCheck = Convert.ToInt32(boxIbsn.Text);
                int bookId      = BBooks.ibsnExist(ibsnToCheck);
                // If ibsn exist, some controls are filled and ibsn is blocked
                if (bookId > 0)
                {
                    // Get the book record
                    Books book = new Books();
                    book = BBooks.getById(bookId);

                    // Book: Fill fields and diable them
                    boxTitle.Enabled = false;
                    boxTitle.Text = book.Title;

                    boxAuthor.Enabled = false;
                    boxAuthor.Text = book.Author;

                    ddlSection.Enabled = false;
                    ddlSection.SelectedValue = book.SectionId.ToString();
                }
            }
        }
    }
}