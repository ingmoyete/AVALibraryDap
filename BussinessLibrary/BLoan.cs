using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary;

namespace BussinessLibrary
{
    public class BLoan
    {
        // Insert
        public static int insert(Loan _loan)
        {
            // Check if userId and copyId exist
            if (_loan.UserId <= 0)
            {
                throw new Exception("SysMessage: There is no userId"); 
            }

            // Check if userId and copyId exist
            if (_loan.CopyId <= 0)
            {
                throw new Exception("SysMessage: There is no copyId");
            }

            // Check if there is available book
            Books book = new Books();
            book = Books.getIbsnAndBookIdByCopyId(_loan.CopyId);
            
            if (BLoan.getAvailableCopiesByBookId(book.BookId) <= 0)
            {
                throw new Exception("There are no more books available");    
            }

            // Check if copy is already taken
            if (BLoan.getLoanByCopyId(_loan.CopyId).LoanId > 0)
            {
                throw new Exception("The copy " + _loan.CopyId + " is already taken");    
            }

            // Insert Loan
            return Loan.insert(_loan);
        }

        // Update
        public static int update(Loan _loan)
        {
            // Check LoanId
            if (_loan.LoanId <= 0)
            {
                throw new Exception("LoanId does not exist");   
            }
            // Check if userId 
            if (_loan.UserId <= 0)
            {
                throw new Exception("There is no userId");
            }

            // Check if copyId exist
            if (_loan.CopyId <= 0)
            {
                throw new Exception("There is no copyId");
            }

            // Update Loan
            return Loan.update(_loan);
        }

        // Delete
        public static void deleteById(int _loanId)
        {
            // Validation goes here

            Loan.deleteById(_loanId);
        }

        // Select by id
        public static Loan getById(int _loanId)
        {
            // Validation goes here

            return Loan.getById(_loanId);
        }

        // Get number of available books
        public static int getAvailableCopiesByBookId(int _bookId)
        {
            return Loan.getAvailableCopiesByBookId(_bookId);
        }

        // Get number of Rented books
        public static int getRentedBooksByBookId(int _bookId)
        {
            return Loan.getRentedBooksByBookId(_bookId);
        }

        // Select All
        public static List<Loan> getAll()
        {
            // Validation goes here

            return Loan.getAll();
        }

        // LoanDTO - Select All
        public static List<LoanDTO> getAllLoanDTO()
        {
            // Validation goes here

            return Loan.getAllLoanDTO();
        }

        // LoanDTO - Select by Id
        public static LoanDTO getLoanDTOById(int _loanId)
        {
            return Loan.getLoanDTOById(_loanId);
        }

        // Select Loan by copyId
        public static Loan getLoanByCopyId(int _copyId)
        {
            return Loan.getLoanByCopyId(_copyId);
        }

        // LoanDTO - Filter by Section
        public static List<LoanDTO> FilterBySection(List<LoanDTO> _loanDTO, string _section)
        {
            var result = (
                            from records in _loanDTO
                            where records.Section == _section
                            select records
                        ).ToList();

            return result;
        }

        // LoanDTO - Filter by loan date
        public static List<LoanDTO> filterByLoanDate(List<LoanDTO> _loanDTO, DateTime _loanDate)
        {
            var result = (
                            from records in _loanDTO
                            where records.LoanDate == _loanDate
                            select records
                        ).ToList();

            return result;
        }

        // LoanDTO - Filter by delivery date
        public static List<LoanDTO> filterByDeliveryDate(List<LoanDTO> _loanDTO, DateTime _deliveryDate)
        {
            var result = (
                            from records in _loanDTO
                            where records.DeliveryDate == _deliveryDate
                            select records
                        ).ToList();

            return result;
        }

        // LoanDTO - Filter by keyword
        public static List<LoanDTO> filterByKeyWord(List<LoanDTO> _loanDTO, string _keyWord)
        {
            // Get all the words to search in uppercase and in an array
            _keyWord = _keyWord.ToLower();
            string[] _keyWordArray = _keyWord.Split(' ');

            List<LoanDTO> listResult = new List<LoanDTO>();

            // Search each word to search
            foreach (string word in _keyWordArray)
            {
                Boolean ret = true;

                // For each loan
                foreach (LoanDTO loan in _loanDTO)
                {
                    ret = true;

                    // If user already exist in the result list, ret is set to false
                    foreach (LoanDTO loanResult in listResult)
                    {
                        if (loanResult.LoanId.ToString().Contains(loan.LoanId.ToString()))
                        {
                            ret = false;
                        }
                    }

                    // If user does not exist (ret = false), and Name, LastName, Dni etc contains the word, the loan is add to te result list
                    if (ret && (loan.Author.ToLower().Contains(word) 
                                || loan.Title.ToLower().Contains(word) 
                                || loan.Name.ToLower().Contains(word)
                                || loan.LastName.ToLower().Contains(word)
                                || loan.Dni.ToString().Contains(word))
                       )
                    {
                        listResult.Add(loan);
                    }
                }

            }

            return listResult;
        }
    }
}
