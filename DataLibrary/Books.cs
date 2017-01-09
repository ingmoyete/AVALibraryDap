using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataLibrary
{
    [Serializable]
    public class Books
    {
        // Attributes
        private     int         bookId;
        private     int         sectionId;
        private     int         ibsn;
        private     string      author;
        private     string      title;
       
        // Fully parameterized constructor
        public Books(int _ibsn, int _bookId, int _sectionId, string _author, string _title)
        {
            bookId      = _bookId;
            sectionId   = _sectionId;
            author      = _author;
            title       = _title;
            ibsn        = _ibsn;
        }

        // Empty constructor
        public Books()
        {
        }

        # region Methods

        // DeleteByIdy
        public static void deleteById(int _bookId)
        {
            try
            {

                // Begin declaration
                string storeProcedure = "deleteBook";
                // End declaration

                // Set parameters
                SqlParameter[] parameter = new SqlParameter[1];
                parameter[0] = new SqlParameter("@BookId", _bookId);

                // Set command and execute query
                using (Helper db = new Helper())
                {
                    db.ExecNonQuery(storeProcedure, parameter);
                }

            }
            catch (Exception e)
            {
                throw e;
            }

        }

        // Update
        public static int update(Books _book)
        {
            try
            {
                
                // Begin declaration
                string storeProcedure = "updateBooks";
                // End declaration

                // Set parameters
                SqlParameter[] parameter = new SqlParameter[5];
                parameter[0] = new SqlParameter("@BookId",      _book.BookId);
                parameter[1] = new SqlParameter("@Author",      _book.Author);
                parameter[2] = new SqlParameter("@SectionId",   _book.SectionId);
                parameter[3] = new SqlParameter("@Title",       _book.Title);
                parameter[4] = new SqlParameter("@Ibsn",        _book.Ibsn);

                // Set command and execute query
                using (Helper db = new Helper())
                {
                    db.ExecNonQuery(storeProcedure, parameter);
                }

                // Get the id of the updated record
                return _book.BookId;

            }
            catch (Exception e)
            {
                throw e;
            }

        }

        // Insert
        public static int insert(Books _book)
        {
            try
            {
                // Begin declaration
                string storeProcedure = "insertBooks";
                // End declaration

                // Set parameters
                SqlParameter[] parameter = new SqlParameter[4];
                SqlParameter output = new SqlParameter("@BookId", SqlDbType.Int);
                parameter[0] = new SqlParameter("@Author",      _book.Author);
                parameter[1] = new SqlParameter("@SectionId",   _book.SectionId);
                parameter[2] = new SqlParameter("@Title",       _book.Title);
                parameter[3] = new SqlParameter("@Ibsn", _book.Ibsn);


                using (Helper db = new Helper())
                {
                    return db.ExecNonQuery(storeProcedure, parameter, output);
                }

            }
            catch (Exception e)
            {
                throw e;
            }

        }

        // Select by Id
        public static Books getById(int _bookId)
        {
            try
            {
                // Begin declaration
                string storeProcedure = "getBookById";
                Books books = new Books();
                // End declaration

                // Set parameters
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@BookId", _bookId);

                //DataSet set;
                //set = Helper.obtenerDataSet("getBookById", parameters);

                // Set command with procedure and parameters
                using (Helper db = new Helper())
                {
                    using (SqlDataReader reader = db.ExecDataReader(storeProcedure, parameters))
                    {
                        if (reader.Read())
                        {
                            books.BookId = reader.GetInt32((reader.GetOrdinal("BookId")));
                            books.Title = reader.GetString((reader.GetOrdinal("Title")));
                            books.Author = reader.GetString((reader.GetOrdinal("Author")));
                            books.SectionId = reader.GetInt32((reader.GetOrdinal("SectionId")));
                            books.Ibsn = reader.GetInt32((reader.GetOrdinal("Ibsn")));
    
                        }
                    }
                }

                return books;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        // Get BookId and Ibsn from copyId
        public static Books getIbsnAndBookIdByCopyId(int _copyId)
        {
            try
            {
                // Begin declaration
                string storeProcedure = "getIbsnAndBookIdByCopyId";
                Books books = new Books();
                // End declaration

                // Set parameters
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@CopyId", _copyId);

                //DataSet set;
                //set = Helper.obtenerDataSet("getBookById", parameters);

                // Set command with procedure and parameters
                using (Helper db = new Helper())
                {
                    using (SqlDataReader reader = db.ExecDataReader(storeProcedure, parameters))
                    {
                        if (reader.Read())
                        {
                            books.BookId = reader.GetInt32((reader.GetOrdinal("BookId")));
                            books.Ibsn = reader.GetInt32((reader.GetOrdinal("Ibsn")));

                        }
                    }
                }

                return books;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        // Select by Ibsn
        public static Books getByIbsn(int _ibsn)
        {
            try
            {
                // Begin declaration
                string storeProcedure = "getByIbsn";
                Books books = new Books();
                // End declaration

                // Set parameters
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@Ibsn", _ibsn);

                //DataSet set;
                //set = Helper.obtenerDataSet("getBookById", parameters);

                // Set command with procedure and parameters
                using (Helper db = new Helper())
                {
                    using (SqlDataReader reader = db.ExecDataReader(storeProcedure, parameters))
                    {
                        if (reader.Read())
                        {
                            books.BookId = reader.GetInt32((reader.GetOrdinal("BookId")));
                            books.Title = reader.GetString((reader.GetOrdinal("Title")));
                            books.Author = reader.GetString((reader.GetOrdinal("Author")));
                            books.SectionId = reader.GetInt32((reader.GetOrdinal("SectionId")));
                            books.Ibsn = reader.GetInt32((reader.GetOrdinal("Ibsn")));

                        }
                    }
                }

                return books;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        // IbsnExist
        public static int ibsnExist(int _ibsn)
        {

            // Begin declaration
            int bookId;
            Books book          = new Books();
            // End declaration

            book = Books.getByIbsn(_ibsn);

            // If Ibsn already exist. The bookId is taken 
            if (book.BookId > 0)
            {
                bookId      = book.BookId;
            }
            // If Ibsn does not exist. The bookId is set to -1;  
            else
            {
                bookId = -1;
            }

            // Return -1 if ibsn does not exist, a bookId if it exist
            return bookId;
        }

        // Select All
        public static List<Books> getAll()
        {
            try
            {
                // Begin declaration
                string storeProcedure = "getAllBooks";
                List<Books> listBooks = new List<Books>();
                //DataSet         set;
                //set = Helper.obtenerDataSet("getAllBooks");
                // End declaration

                // Set command
                using (Helper db = new Helper())
                {
                    using (SqlDataReader reader = db.ExecDataReader(storeProcedure))
                    {
                        while (reader.Read())
                        {
                            Books books = new Books();

                            // Get the columns of the row n
                            books.BookId = reader.GetInt32((reader.GetOrdinal("BookId")));
                            books.Title = reader.GetString((reader.GetOrdinal("Title")));
                            books.Author = reader.GetString((reader.GetOrdinal("Author")));
                            books.SectionId = reader.GetInt32((reader.GetOrdinal("SectionId")));
                            books.Ibsn = reader.GetInt32((reader.GetOrdinal("Ibsn")));

                            // Save the row n in a list
                            listBooks.Add(books);  
                        }
                    }
                }

                return listBooks;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        // BookDTO - Select All 
        public static List<BookDTO> getBookDTOAll()
        {
            try
            {
                // Begin declaration
                string storeProcedure = "getAllBookDTO";
                List<BookDTO> listBooksDTO = new List<BookDTO>();
                //DataSet         set;
                //set = Helper.obtenerDataSet("getAllBooks");
                // End declaration

                // Set command
                using (Helper db = new Helper())
                {
                    using (SqlDataReader reader = db.ExecDataReader(storeProcedure))
                    {
                        while (reader.Read())
                        {
                            BookDTO bookDTO = new BookDTO();

                            // Get the columns of the row n
                            bookDTO.BookId = reader.GetInt32((reader.GetOrdinal("BookId")));
                            bookDTO.Title = reader.GetString((reader.GetOrdinal("Title")));
                            bookDTO.Author = reader.GetString((reader.GetOrdinal("Author")));
                            bookDTO.SectionName = reader.GetString((reader.GetOrdinal("SectionName")));
                            bookDTO.copies = reader.GetInt32((reader.GetOrdinal("copies")));
                            bookDTO.Ibsn = reader.GetInt32((reader.GetOrdinal("Ibsn")));

                            // Save the row n in a list
                            listBooksDTO.Add(bookDTO);
                        }
                    }
                }

                return listBooksDTO;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        // BookDTO - Select by Id
        public static BookDTO getBookDTOById(int _bookDTOId)
        {
            try
            {
                // Begin declaration
                string storeProcedure = "getBookDTOById";
                BookDTO bookDTO = new BookDTO();
                // End declaration

                // Set parameters
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@BookId", _bookDTOId);

                //DataSet set;
                //set = Helper.obtenerDataSet("getBookById", parameters);

                // Set command with procedure and parameters
                using (Helper db = new Helper())
                {
                    using (SqlDataReader reader = db.ExecDataReader(storeProcedure, parameters))
                    {
                        if (reader.Read())
                        {
                            bookDTO.BookId = reader.GetInt32((reader.GetOrdinal("BookId")));
                            bookDTO.Title = reader.GetString((reader.GetOrdinal("Title")));
                            bookDTO.Author = reader.GetString((reader.GetOrdinal("Author")));
                            bookDTO.SectionName = reader.GetString((reader.GetOrdinal("SectionName")));
                            bookDTO.copies = reader.GetInt32((reader.GetOrdinal("copies")));
                            bookDTO.Ibsn = reader.GetInt32((reader.GetOrdinal("Ibsn")));

                        }
                    }
                }

                return bookDTO;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        #endregion

        // Properties
        #region Properties
        public int Ibsn
        {
            get { return ibsn; }
            set { ibsn = value; }
        }
        public int BookId
        {
            get { return bookId; }
            set { bookId = value; }
        }
        public int      SectionId
        {
            get { return sectionId; }
            set { sectionId = value; }
        }
        public string   Author
        {
            get { return author; }
            set { author = value; }
        }
        public string   Title
        {
            get { return title; }
            set { title = value; }
        }
        #endregion
    }
}
