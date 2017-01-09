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
    public partial class MainListLoan : PageBase
    {
        List<LoanDTO> allLoans = new List<LoanDTO>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Fill the grid
                fillLoansDTO();

                // Fill dropdownlist
                DropDownSection.DataSource = Section.getAll();
                DropDownSection.DataTextField = "Name";
                DropDownSection.DataValueField = "SectionId";
                DropDownSection.DataBind();
            }
        }
        protected void fillLoansDTO()
        {
            // Fill the grid and save it in viewstate
            allLoans = DataLibrary.Loan.getAllLoanDTO();
            ViewState["allLoans"] = allLoans;

            GridListLoans.DataSource = allLoans;
            GridListLoans.DataBind();
        }
        protected void GridListLoans_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Modify" || e.CommandName == "Delete")
            {
                LinkButton linkButton = (LinkButton)e.CommandSource; // Button
                GridViewRow gridViewRow = (GridViewRow)linkButton.Parent.Parent; // Row
                GridView gridView = (GridView)sender; // Grid

                // Get the datakey of the selected record
                string loanId = gridView.DataKeys[gridViewRow.RowIndex].Value.ToString();

                // Do the action of the selected button
                switch (e.CommandName)
                {
                    case "Delete":
                        Response.Redirect("~/Loan/DeleteLoan.aspx?loanId=" + loanId);
                        break;
                    case "Modify":
                        Response.Redirect("~/Loan/UpdateLoan.aspx?loanId=" + loanId);
                        break;
                }
            }
        }

        protected void GridListLoans_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridListLoans.PageIndex = e.NewPageIndex;
            // Fill the grid

            if (ViewState["filterAllLoans"] != null)
            {
                allLoans = (List<LoanDTO>)ViewState["filterAllLoans"];
                GridListLoans.DataSource = allLoans;
                GridListLoans.DataBind();     
            }
            else
            {
                fillLoansDTO();
            }

        }

        protected void TextBoxDelivery_TextChanged(object sender, EventArgs e)
        {
            filterLoan();
        }

        protected void TextBoxLoan_TextChanged(object sender, EventArgs e)
        {
            filterLoan();
        }

        protected void ButtonRemoveFilter_Click(object sender, EventArgs e)
        {
            fillLoansDTO();

            ViewState.Remove("filterAllLoans");
            DropDownSection.SelectedValue = "-1";
            TextBoxDelivery.Text = "--Select Delivery Date--";
            TextBoxLoan.Text = "--Select Loan Date--";
            
        }

        protected void DropDownRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterLoan();
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            filterLoan();
        }
        protected void filterLoan()
        {
            // 1.- Get the latest datasource
            allLoans = (List<LoanDTO>)ViewState["allLoans"];

            // 2.- Filter by Region is value is not -1
            if (DropDownSection.SelectedValue != "-1")
            {
                allLoans = BLoan.FilterBySection(allLoans, DropDownSection.SelectedItem.Text);
            }

            // 3.- Filter by loan date if it is a valid date
            DateTime result;
            if (DateTime.TryParse(TextBoxLoan.Text, out result))
            {
                allLoans = BLoan.filterByLoanDate(allLoans, Convert.ToDateTime(TextBoxLoan.Text));   
            }

            // 4.- Filter by delivery date if it is a valid date
            if (DateTime.TryParse(TextBoxDelivery.Text, out result))
            {
                allLoans = BLoan.filterByDeliveryDate(allLoans, Convert.ToDateTime(TextBoxDelivery.Text));
            }

            // 5.- Filter by Keyword
            allLoans = BLoan.filterByKeyWord(allLoans, TextBoxSearch.Text);

            // 6.- Bind grid to datasource and save it in viewstate
            ViewState["filterAllLoans"] = allLoans;
            GridListLoans.DataSource = allLoans;
            GridListLoans.DataBind();
        }
    }
}