using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary;
using System.Transactions;
using System.Web;

namespace BussinessLibrary
{
    public static class BBooks
    {
        // Insert
        public static int insert(Books _books, Copy _copy, int _numberOfCopies)
        {
            // Begin declaration
            int bookId;
            int copyId;
            // End declaration

            using (TransactionScope trans = new TransactionScope())
            {
                // bookId = -1 if ibsn does not exist, bookId > 0 if ibsn exists
                bookId = Books.ibsnExist(_books.Ibsn);

                // Insert both book and copy if Ibsn does not exist 
                if (bookId == -1)
                {
                    bookId = Books.insert(_books);
                    for (int i = 0; i < _numberOfCopies; i++)
                    {
                        _copy.BookId = bookId;
                        copyId = Copy.insert(_copy);     
                    }
                        
                }
                // Insert copies if ibsn exists
                else
                {
                    for (int i = 0; i < _numberOfCopies; i++)
                    {
                        _copy.BookId = bookId;
                        copyId = Copy.insert(_copy);
                    }
                }
                // Complete transaction
                trans.Complete();

            }  
       
        // -1 if record was not written; otherwise it returns a value higher than 0
        return bookId;
    }

        // Update
        public static int update(Books _books)
        {

            return Books.update(_books);
        }

        // Delete All copies
        public static void deleteAllCopiesById(int _bookId)
        {
            // Check if the book to delete is borrowed
            if (existLoanByBookId(_bookId))
            {
                throw new Exception("There are loans with these books");
            }

            int numberCopies = Copy.getNumberOfCopiesByBookId(_bookId);

            for (int i = 0; i < numberCopies; i++)
            {
                Copy.deleteOneCopyByBookId(_bookId);
            }
            Books.deleteById(_bookId);
        }

        // Exist loan of this bookId(few copyids)
        private static Boolean existLoanByBookId(int _bookId)
        {
            Boolean ret = false;

            // If there is book borrowed, ret is set to true
            if (Loan.getRentedBooksByBookId(_bookId) > 0)
            {
                ret = true;
            }

            // True if loan exists for that copyId; otherwise false
            return ret;
        }

        // Select by id
        public static Books getById(int _bookId)
        {
            // Validation goes here

            return Books.getById(_bookId);
        }

        // Select All
        public static List<Books> getAll()
        {
            // Validation goes here

            return Books.getAll();
        }

        // BookDTO - Select by id
        public static BookDTO getBookDTOById(int _bookDTOId)
        {
            // Validation goes here

            return Books.getBookDTOById(_bookDTOId);
        }

        // BookDTO - Select All
        public static List<BookDTO> getBookDTOAll()
        {
            // Validation goes here

            return Books.getBookDTOAll();
        }

        // IbsnExist
        public static int ibsnExist(int _ibsn)
        {
            return Books.ibsnExist(_ibsn);
        }

        // Filter by Section
        public static List<BookDTO> getBookDTOBySection(List<BookDTO> _bookDTO, string _section)
        {
            var result = (
                            from records in _bookDTO
                            where records.SectionName == _section
                            select records

                         ).ToList();

            return result;
        }

        // Filter by Copies
        public static List<BookDTO> getBookDTOByCopies(List<BookDTO> _bookDTO, int _numberOfCopies)
        {
            var result = new List<BookDTO>();

            // If number of copies < 5
            if (_numberOfCopies == 1)
            {
                result = (
                                from records in _bookDTO
                                where records.copies < 5
                                select records
                                ).ToList();
            }
            // If number of copies > 5
            else
            {
                result = (
                                from records in _bookDTO
                                where records.copies > 5
                                select records
                                ).ToList();
            }

            return result;
        }

        // Filter by author or title
        public static List<BookDTO> getBookDTOByAuthorOrTitle(List<BookDTO> _bookDTO, string _keyWord)
        {
            // Get all the words to search in uppercase and in an array
            _keyWord = _keyWord.ToLower();
            string[] _keyWordArray = _keyWord.Split(' ');

            List<BookDTO> bookResult = new List<BookDTO>();

            // Search each word to search
            foreach (string word in _keyWordArray)
            {
                Boolean ret = true;

                // For each user
                foreach (BookDTO book in _bookDTO)
                {
                    ret = true;

                    // If user already exist in the result list, ret is set to false
                    foreach (BookDTO userResult in bookResult)
                    {
                        if (userResult.BookId.ToString().Contains(book.BookId.ToString()))
                        {
                            ret = false;
                        }
                    }

                    // If user does not exist (ret = false), and Name, LastName, and Dni contains the word, the user is add to te result list
                    if (ret && (book.Author.ToLower().Contains(word) || book.Title.ToLower().Contains(word) ) )
                    {
                        bookResult.Add(book);
                    }
                }

            }

            return bookResult;
        }
      
    }
}
