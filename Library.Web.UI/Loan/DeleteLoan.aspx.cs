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
    public partial class DeleteLoan : PageBase
    {
        int loanId;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Disable fields
            disableFields();

            // Get the loanId to update
            loanId = Convert.ToInt32(Request.QueryString["loanId"]);

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

                boxDelivery.Text    = loanDTO.DeliveryDate.ToString("dd/MM/yyyy");
                boxLoanDate.Text    = loanDTO.LoanDate.ToString("dd/MM/yyyy");
            }
        }

        protected void ButDelete_Click(object sender, EventArgs e)
        {
            // Delete de loan
            BLoan.deleteById(loanId);

            // Go to loan main list
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
            boxDelivery.Enabled = false;
            boxLoanDate.Enabled = false;
        }
    }
}