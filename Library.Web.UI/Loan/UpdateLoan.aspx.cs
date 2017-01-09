using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataLibrary;
using BussinessLibrary;

namespace Library.Web.UI.Loan
{
    public partial class UpdateLoan : PageBase
    {
        int loanId;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Disable the ones which cannot be updated
            disableFields();

            if (!IsPostBack)
            {
                // Get the loanId to update
                loanId = Convert.ToInt32(Request.QueryString["loanId"]);

                // Get the record
                LoanDTO loanDTO = new LoanDTO();
                loanDTO = DataLibrary.Loan.getLoanDTOById(loanId);

                // Loan section drop down list
                ddlSection.DataSource = Section.getAll();
                ddlSection.DataTextField = "Name";
                ddlSection.DataValueField = "SectionId";
                ddlSection.DataBind();
          
                // Fill the textBoxes
                boxCopyId.Text      = loanDTO.CopyId.ToString();
                boxLoanId.Text      = loanDTO.LoanId.ToString();
                boxName.Text        = loanDTO.Name;
                boxLastName.Text    = loanDTO.LastName;
                boxDni.Text         = loanDTO.Dni.ToString();
                boxTitle.Text       = loanDTO.Title;
                boxAuthor.Text      = loanDTO.Author;
                ddlSection.Text     = loanDTO.Section;

                boxDelivery.Text = loanDTO.DeliveryDate.ToString("dd/MM/yyyy");
                boxLoanDate.Text = loanDTO.LoanDate.ToString("dd/MM/yyyy");
            }
        }

        protected void ButUpdate_Click(object sender, EventArgs e)
        {
            // Get the loanId to update
            loanId = Convert.ToInt32(Request.QueryString["loanId"]);
            
            // Get the loan by id
            DataLibrary.Loan loan = new DataLibrary.Loan();
            loan = BLoan.getById(loanId);

            // Set values to update from fields and update loan record
            DateTime deliveryD = DateTime.ParseExact(boxDelivery.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            loan.DeliveryDate = Convert.ToDateTime(deliveryD);
            DateTime loanD = DateTime.ParseExact(boxLoanDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            loan.LoanDate = Convert.ToDateTime(loanD);

            BLoan.update(loan);
            
            // Go to main list page
            Response.Redirect("~/Loan/MainListLoan.aspx");
        }
        // Disable fields
        protected void disableFields()
        {
            boxCopyId.Enabled = false;
            boxLoanId.Enabled = false;
            boxName.Enabled = false;
            boxLastName.Enabled = false;
            boxDni.Enabled = false;
            boxTitle.Enabled = false;
            boxAuthor.Enabled = false;
            ddlSection.Enabled = false;
        }
    }
}