using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataLibrary
{
    public class Loan
    {
        // Attributes
        private int         loanId;
        private DateTime    loanDate;
        private DateTime    deliveryDate;
        private int         copyId;
        private int         userId;

        // Fully Parameterized constructor
        public Loan(int _loanId, DateTime _loanDate, DateTime _deliveryDate, int _copyId, int _userId)
        {
            loanId          = _loanId;
            loanDate        = _loanDate;
            deliveryDate    = _deliveryDate;
            copyId          = _copyId;
            userId          = _userId;
        }
        // Empty constructor
        public Loan()
        {
        }

        #region Methods

        // Delete
        public static void deleteById(int _loanId)
        {
            try
            {

                // Begin declaration
                string storeProcedure = "deleteLoan";
                // End declaration

                // Set parameters
                SqlParameter[] parameter = new SqlParameter[1];
                parameter[0] = new SqlParameter("@LoanId", _loanId);

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
        public static int update(Loan _loan)
        {
            try
            {

                // Begin declaration
                string storeProcedure = "updateLoan";
                // End declaration

                // Set parameters
                SqlParameter[] parameter = new SqlParameter[5];

                parameter[0] = new SqlParameter("@LoanId",          _loan.LoanId);
                parameter[1] = new SqlParameter("@LoanDate",        _loan.LoanDate);
                parameter[2] = new SqlParameter("@DeliveryDate",    _loan.DeliveryDate);
                parameter[3] = new SqlParameter("@CopyId",          _loan.CopyId);
                parameter[4] = new SqlParameter("@UserId",          _loan.UserId);

                // Set command and execute query
                using (Helper db = new Helper())
                {
                    db.ExecNonQuery(storeProcedure, parameter);
                }

                // Get the id of the updated record
                return _loan.LoanId;

            }
            catch (Exception e)
            {
                throw e;
            }

        }

        // Insert
        public static int insert(Loan _loan)
        {
            try
            {
                // Begin declaration
                string storeProcedure = "insertLoan";
                // End declaration

                // Set parameters
                SqlParameter[] parameter = new SqlParameter[4];
                SqlParameter output = new SqlParameter("@LoanId", SqlDbType.Int);

                parameter[0] = new SqlParameter("@LoanDate",        _loan.LoanDate);
                parameter[1] = new SqlParameter("@DeliveryDate",    _loan.DeliveryDate);
                parameter[2] = new SqlParameter("@CopyId",          _loan.CopyId);
                parameter[3] = new SqlParameter("@UserId",          _loan.UserId);

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
        public static Loan getById(int _loanId)
        {
            try
            {
                // Begin declaration
                string storeProcedure = "getLoanById";
                Loan loan = new Loan();
                // End declaration

                // Set parameters
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@LoanId", _loanId);

                ////DataSet set;
                //DataSet ds = new DataSet();
                //using (Helper db = new Helper())
                //{
                //    using (ds = db.ExecDataSet(storeProcedure, parameters));
                //}

                // Set command with procedure and parameters
                using (Helper db = new Helper())
                {
                    using (SqlDataReader reader = db.ExecDataReader(storeProcedure, parameters))
                    {
                        if (reader.Read())
                        {
                            loan.LoanId = reader.GetInt32((reader.GetOrdinal            ("LoanId")));
                            loan.LoanDate = reader.GetDateTime((reader.GetOrdinal       ("LoanDate")));
                            loan.DeliveryDate = reader.GetDateTime((reader.GetOrdinal   ("DeliveryDate")));
                            loan.CopyId = reader.GetInt32((reader.GetOrdinal            ("CopyId")));
                            loan.UserId = reader.GetInt32((reader.GetOrdinal            ("UserId")));

                        }
                    }
                }

                return loan;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        // Select Loan by copyId
        public static Loan getLoanByCopyId(int _copyId)
        {
            try
            {
                // Begin declaration
                string storeProcedure = "getLoanByCopyId";
                Loan loan = new Loan();
                // End declaration

                // Set parameters
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@CopyId", _copyId);

                ////DataSet set;
                //DataSet ds = new DataSet();
                //using (Helper db = new Helper())
                //{
                //    using (ds = db.ExecDataSet(storeProcedure, parameters));
                //}

                // Set command with procedure and parameters
                using (Helper db = new Helper())
                {
                    using (SqlDataReader reader = db.ExecDataReader(storeProcedure, parameters))
                    {
                        if (reader.Read())
                        {
                            loan.LoanId = reader.GetInt32((reader.GetOrdinal("LoanId")));
                            loan.LoanDate = reader.GetDateTime((reader.GetOrdinal("LoanDate")));
                            loan.DeliveryDate = reader.GetDateTime((reader.GetOrdinal("DeliveryDate")));
                            loan.CopyId = reader.GetInt32((reader.GetOrdinal("CopyId")));
                            loan.UserId = reader.GetInt32((reader.GetOrdinal("UserId")));
                        }
                    }
                }

                return loan;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        // Get number of available books
        public static int getAvailableCopiesByBookId(int _bookId)
        {
            try
            {
                // Begin declaration
                string storeProcedure       = "getAvailableBooks";
                int numberCopiesAvailable   = -1;
                // End declaration

                // Set parameters
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@BookId", _bookId);

                ////DataSet set;
                //DataSet ds = new DataSet();
                //using (Helper db = new Helper())
                //{
                //    using (ds = db.ExecDataSet(storeProcedure, parameters));
                //}

                // Set command with procedure and parameters
                using (Helper db = new Helper())
                {
                    using (SqlDataReader reader = db.ExecDataReader(storeProcedure, parameters))
                    {
                        if (reader.Read())
                        {
                            numberCopiesAvailable = reader.GetInt32((reader.GetOrdinal("AvailableBooks")));
                        }
                    }
                }

                return numberCopiesAvailable;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        // Get number of rented books
        public static int getRentedBooksByBookId(int _bookId)
        {
            try
            {
                // Begin declaration
                string storeProcedure = "getRemainingBooks";
                int numberRemainingCopies = -1;
                // End declaration

                // Set parameters
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@BookId", _bookId);

                ////DataSet set;
                //DataSet ds = new DataSet();
                //using (Helper db = new Helper())
                //{
                //    using (ds = db.ExecDataSet(storeProcedure, parameters));
                //}

                // Set command with procedure and parameters
                using (Helper db = new Helper())
                {
                    using (SqlDataReader reader = db.ExecDataReader(storeProcedure, parameters))
                    {
                        if (reader.Read())
                        {
                            numberRemainingCopies = reader.GetInt32((reader.GetOrdinal("RemainingBooks")));
                        }
                    }
                }

                return numberRemainingCopies;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        // Select All
        public static List<Loan> getAll()
        {
            try
            {
                // Begin declaration
                string storeProcedure = "getAllLoan";
                List<Loan> listLoans = new List<Loan>();

                //// Dataset
                //DataSet ds = new DataSet();
                //using (Helper db = new Helper())
                //{
                //    using (ds = db.ExecDataSet(storeProcedure));
                //}

                // Set command
                using (Helper db = new Helper())
                {
                    using (SqlDataReader reader = db.ExecDataReader(storeProcedure))
                    {
                        while (reader.Read())
                        {
                            Loan loan = new Loan();

                            // Get the columns of the row n
                            loan.LoanId = reader.GetInt32((reader.GetOrdinal("LoanId")));
                            loan.LoanDate = reader.GetDateTime((reader.GetOrdinal("LoanDate")));
                            loan.DeliveryDate = reader.GetDateTime((reader.GetOrdinal("DeliveryDate")));
                            loan.CopyId = reader.GetInt32((reader.GetOrdinal("CopyId")));
                            loan.UserId = reader.GetInt32((reader.GetOrdinal("UserId")));

                            // Save the row n in a list
                            listLoans.Add(loan);
                        }
                    }
                }

                return listLoans;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        
        // LoanDTO - Select All
        public static List<LoanDTO> getAllLoanDTO()
        {
            try
            {
                // Begin declaration
                string storeProcedure = "getAllLoanDTO";
                List<LoanDTO> listLoansDTO = new List<LoanDTO>();

                //// Dataset
                //DataSet ds = new DataSet();
                //using (Helper db = new Helper())
                //{
                //    using (ds = db.ExecDataSet(storeProcedure));
                //}

                // Set command
                using (Helper db = new Helper())
                {
                    using (SqlDataReader reader = db.ExecDataReader(storeProcedure))
                    {
                        while (reader.Read())
                        {
                            LoanDTO loan = new LoanDTO();

                            // Get the columns of the row n
                            loan.CopyId = reader.GetInt32((reader.GetOrdinal("CopyId")));
                            loan.LoanId = reader.GetInt32((reader.GetOrdinal("LoanId")));
                            loan.LoanDate = reader.GetDateTime((reader.GetOrdinal("LoanDate")));
                            loan.DeliveryDate = reader.GetDateTime((reader.GetOrdinal("DeliveryDate")));
                            loan.Name = reader.GetString((reader.GetOrdinal("Name")));
                            loan.LastName = reader.GetString((reader.GetOrdinal("LastName")));
                            loan.Dni = reader.GetInt32((reader.GetOrdinal("Dni")));
                            loan.Title = reader.GetString((reader.GetOrdinal("Title")));
                            loan.Author = reader.GetString((reader.GetOrdinal("Author")));
                            loan.Section = reader.GetString((reader.GetOrdinal("Section")));

                            // Save the row n in a list
                            listLoansDTO.Add(loan);
                        }
                    }
                }

                return listLoansDTO;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        // LoanDTO - Select by Id
        public static LoanDTO getLoanDTOById(int _loanId)
        {
            try
            {
                // Begin declaration
                string storeProcedure = "getLoanDTOByCopyId";
                LoanDTO loan = new LoanDTO();
                // End declaration

                // Set parameters
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@LoanId", _loanId);

                ////DataSet set;
                //DataSet ds = new DataSet();
                //using (Helper db = new Helper())
                //{
                //    using (ds = db.ExecDataSet(storeProcedure, parameters));
                //}

                // Set command with procedure and parameters
                using (Helper db = new Helper())
                {
                    using (SqlDataReader reader = db.ExecDataReader(storeProcedure, parameters))
                    {
                        if (reader.Read())
                        {
                            loan.CopyId = reader.GetInt32((reader.GetOrdinal("CopyId")));
                            loan.LoanId = reader.GetInt32((reader.GetOrdinal("LoanId")));
                            loan.LoanDate = reader.GetDateTime((reader.GetOrdinal("LoanDate")));
                            loan.DeliveryDate = reader.GetDateTime((reader.GetOrdinal("DeliveryDate")));
                            loan.Name = reader.GetString((reader.GetOrdinal("Name")));
                            loan.LastName = reader.GetString((reader.GetOrdinal("LastName")));
                            loan.Dni = reader.GetInt32((reader.GetOrdinal("Dni")));
                            loan.Title = reader.GetString((reader.GetOrdinal("Title")));
                            loan.Author = reader.GetString((reader.GetOrdinal("Author")));
                            loan.Section = reader.GetString((reader.GetOrdinal("Section")));

                        }
                    }
                }

                return loan;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        #endregion


        #region Properties

        //Properties
        public int LoanId
        {
            get { return loanId; }
            set { loanId = value; }
        }
        public DateTime LoanDate
        {
            get { return loanDate; }
            set { loanDate = value; }
        }
        public DateTime DeliveryDate
        {
            get { return deliveryDate; }
            set { deliveryDate = value; }
        }
        public int CopyId
        {
            get { return copyId; }
            set { copyId = value; }
        }
        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        #endregion
    }
}
