using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataLibrary;
using BussinessLibrary;
using System.IO;

namespace Library.Web.UI.Loan
{
    public partial class InsertLoan : PageBase
    {
        DataLibrary.UserDTO userDTO = new UserDTO();
        CopyDTO copyDTO = new CopyDTO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Disable fields
                disableFields();

                // Load section ddl
                loadDdlSection();

                // Set the loan and delivery date
                boxDelivery.Text = DateTime.Today.AddDays(20).ToString("dd/MM/yyyy");
                boxLoanDate.Text = DateTime.Today.ToString("dd/MM/yyyy");   
            }
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
        protected string writeRequireLabel()
        {
            StringWriter stringWriter = new StringWriter();

            using (HtmlTextWriter textWriter = new HtmlTextWriter(stringWriter))
            {
                string classValue = "error";

                textWriter.AddAttribute(HtmlTextWriterAttribute.Class, classValue);
                textWriter.RenderBeginTag(HtmlTextWriterTag.Label);
                textWriter.Write("This Field is required.");
                textWriter.RenderEndTag();
            }

            return stringWriter.ToString();
        }
        protected string writeDBLabel()
        {
            StringWriter stringWriter = new StringWriter();

            using (HtmlTextWriter textWriter = new HtmlTextWriter(stringWriter))
            {
                string classValue = "error";

                textWriter.AddAttribute(HtmlTextWriterAttribute.Class, classValue);
                textWriter.RenderBeginTag(HtmlTextWriterTag.Label);
                textWriter.Write("This ID does not exist.");
                textWriter.RenderEndTag();
            }

            return stringWriter.ToString();
        }
        protected void boxIbsn_TextChanged(object sender, EventArgs e)
        {
            copyIdValidation.Validate();

            if (copyIdValidation.IsValid)
            {
                loadDdlSection();

                boxTitle.Text = copyDTO.Title;
                boxAuthor.Text = copyDTO.Author;
                ddlSection.SelectedValue = copyDTO.SectionId.ToString();
            }
        }

        // Disable fields
        protected void disableFields()
        {
            // User
            boxName.Enabled         = false;
            boxLastName.Enabled     = false;
            boxDni.Enabled          = false;

            // Book
            boxTitle.Enabled    = false;
            boxAuthor.Enabled   = false;
            ddlSection.Enabled  = false;
        }

        // Load section drop down list
        protected void loadDdlSection()
        {
            // Load drop down List
            ddlSection.DataSource = Section.getAll();
            ddlSection.DataTextField = "Name";
            ddlSection.DataValueField = "SectionId";
            ddlSection.DataBind();
        }

        protected void InsertLoan_Click(object sender, EventArgs e)
        {
            if (userIdValidation.IsValid && copyIdValidation.IsValid)
            {
                DataLibrary.Loan loan = new DataLibrary.Loan();

                // Get values from controls
                loan.CopyId = Convert.ToInt32(boxCopyId.Text);
                loan.UserId = Convert.ToInt32(boxUserId.Text);
                DateTime deliveryD = DateTime.ParseExact(boxDelivery.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                loan.DeliveryDate = Convert.ToDateTime(deliveryD);
                DateTime loanD = DateTime.ParseExact(boxLoanDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                loan.LoanDate = Convert.ToDateTime(loanD);

                try
                {
                    // Insert Loan
                    int loanId = BLoan.insert(loan);
                    // Goest to mainLisLoan
                    Response.Redirect("~/Loan/MainListLoan.aspx");
                }
                catch (Exception generalException)
                {
                    PanelInsertLoan.Visible = true;
                    LiteralInsertLoan.Text = generalException.Message;
                }
            }

        }

        protected void boxUserId_TextChanged(object sender, EventArgs e)
        {
     
            userIdValidation.Validate();

            if (userIdValidation.IsValid)
            {
                boxName.Text = userDTO.Name;
                boxLastName.Text = userDTO.LastName;
                boxDni.Text = userDTO.Dni.ToString();
            } 

        }

        protected void userIdValidation_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Validate field for "is integer", 
            LiteralUserId.Text = "";
            int value;
            Boolean ret = true;
            if (!Int32.TryParse(boxUserId.Text, out value))
            {
                ret = false;
                LiteralUserId.Text = writeDigitsLabel();
            }

            // Validate field for "Required", 
            if (string.IsNullOrEmpty(boxUserId.Text))
            {
                ret = false;
                LiteralUserId.Text = writeRequireLabel();
            }

            // If digit ok and require ok, it checks if data exists in DB
            if (ret)
            {
                // Get the user record 
                int userId = Convert.ToInt32(boxUserId.Text);
                userDTO = DataLibrary.Users.getUserDTOById(userId);

                // If the record does not exist, ret is set to false
                if (userDTO.UserId <= 0)
                {
                    LiteralUserId.Text = writeDBLabel();
                    ret = false;
                }
            }

            // Set args to ret
            args.IsValid = ret;
        }

        protected void copyIdValidation_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Validate field for "is integer", 
            int value;
            Boolean ret = true;
            LiteralCopyId.Text = "";
            if (!Int32.TryParse(boxCopyId.Text, out value))
            {
                ret = false;
                LiteralCopyId.Text = writeDigitsLabel();
            }

            // Validate field for "require", 
            if (string.IsNullOrEmpty(boxCopyId.Text))
            {
                ret = false;
                LiteralCopyId.Text = writeRequireLabel();
            }

            // Check if record exist in database if above validations are met
            if (ret)
            {
                // Get the copy record
                int copyId = Convert.ToInt32(boxCopyId.Text);
                copyDTO = BCopy.getCopyByCopyId(copyId);

                // If record does not exist, ret is set to false
                if (copyDTO.CopyId <= 0)
                {
                    LiteralCopyId.Text = writeDBLabel();
                    ret = false;
                }
            }

            // IsValid is set to ret and return
            args.IsValid = ret;
        }
    }
}