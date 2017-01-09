using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary;

namespace BussinessLibrary
{
    public class BCopy
    {
        // Insert
        public static int insert(Copy _copy)
        {
            // Validation goes here

            return Copy.insert(_copy);
        }

        // Update
        public static int update(Copy _copy)
        {
            if (_copy.BookId == 0)
            {
                throw new Exception("There is no bookId");
            }

            if (_copy.CopyId == 0)
            {
                throw new Exception("There is no bookId");
            }

            return Copy.update(_copy);
        }

        // Delete
        public static void deleteById(int _copyId)
        {
            // Check if there is a loan with this copyId
            if (existLoanByCopyId(_copyId))
            {
                throw new Exception("There is a book in loan");
            }

            // Delete
            Copy.deleteById(_copyId);
        }

        // Exist loan of this copyId
        private static Boolean existLoanByCopyId(int _copyId)
        {
            Boolean ret = false;

            // Get the copy record
            Copy copy = new Copy();
            copy = BCopy.getById(_copyId);

            // If there is book borrowed, ret is set to true
            if (Loan.getRentedBooksByBookId(copy.BookId) > 0)
            {
                ret = true;
            }

            // True if loan exists for that copyId; otherwise false
            return ret;
        }

        // Select by id
        public static Copy getById(int _copyId)
        {
            // Validation goes here

            return Copy.getById(_copyId);
        }

        // Select All
        public static List<Copy> getAll()
        {
            // Validation goes here

            return Copy.getAll();
        }
        // Select all copyes by bookId
        public static List<Copy> getAllCopyByBookId(int _bookId)
        {
            return Copy.getAllCopyByBookId(_bookId);
        }

        // CopyDTO - Select Copy by Ibsn
        public static CopyDTO getCopyByCopyId(int _copyId)
        {
            return Copy.getCopyByCopyId(_copyId);

        }
    }
}
