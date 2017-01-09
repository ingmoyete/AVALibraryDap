using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataLibrary;
using BussinessLibrary;

namespace AVALibraryDap
{
    public partial class insertBooks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void buttonInsertBook_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                // Insert books
                Books book = new Books();

                book.Title = boxTitle.Text;
                book.Author = boxAuthor.Text;
                book.SectionId = Convert.ToInt32(boxSection.Text);

                BBooks.insert(book);
                Response.Redirect("~/ListBooks.aspx");
            }
        }
    }
}