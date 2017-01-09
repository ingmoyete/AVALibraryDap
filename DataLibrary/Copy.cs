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
    public class Copy
    {
        // Attributes
        private int         copyId;
        private int         bookId;
        private DateTime    purchaseDate;
        private DateTime    renewalDate;

        // Fully parameterized constructor
        public Copy(int _copyId, int _bookId, DateTime _purchaseDate, DateTime _renewalDate)
        {
            copyId          = _copyId;
            bookId          = _bookId;
            purchaseDate    = _purchaseDate;
            renewalDate     = _renewalDate;
        }

        // Empty constructor
        public Copy()
        {

        }

        #region Methods

        // Delete
        public static void deleteById(int _copyId)
        {
            try
            {

                // Begin declaration
                string storeProcedure = "deleteCopy";
                // End declaration

                // Set parameters
                SqlParameter[] parameter = new SqlParameter[1];
                parameter[0] = new SqlParameter("@CopyId", _copyId);

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

        // Delete One Copy by BookId
        public static void deleteOneCopyByBookId(int _BookId)
        {
            try
            {

                // Begin declaration
                string storeProcedure = "deleteCopyByBookId";
                // End declaration

                // Set parameters
                SqlParameter[] parameter = new SqlParameter[1];
                parameter[0] = new SqlParameter("@BookId", _BookId);

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
        public static int update(Copy _copy)
        {
            try
            {

                // Begin declaration
                string storeProcedure = "updateCopy";
                // End declaration

                // Set parameters
                SqlParameter[] parameter = new SqlParameter[4];
                parameter[0] = new SqlParameter("@PurchaseDate",    _copy.PurchaseDate);
                parameter[1] = new SqlParameter("@RenewalDate",     _copy.RenewalDate);
                parameter[2] = new SqlParameter("@BookId",          _copy.BookId);
                parameter[3] = new SqlParameter("@CopyId",          _copy.CopyId);

                // Set command and execute query
                using (Helper db = new Helper())
                {
                    db.ExecNonQuery(storeProcedure, parameter);
                }

                // Get the id of the updated record
                return _copy.CopyId;

            }
            catch (Exception e)
            {
                throw e;
            }

        }

        // Insert
        public static int insert(Copy _copy)
        {
            try
            {
                // Begin declaration
                string storeProcedure = "insertCopy";
                // End declaration

                // Set parameters
                SqlParameter[] parameter = new SqlParameter[3];
                SqlParameter output = new SqlParameter("@CopyId", SqlDbType.Int);

                parameter[0] = new SqlParameter("@PurchaseDate",    _copy.PurchaseDate);
                parameter[1] = new SqlParameter("@RenewalDate",     _copy.RenewalDate);
                parameter[2] = new SqlParameter("@BookId",          _copy.BookId);

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
        public static Copy getById(int _copyId)
        {
            try
            {
                // Begin declaration
                string storeProcedure = "getCopyById";
                Copy copy = new Copy();
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
                            copy.CopyId = reader.GetInt32((reader.GetOrdinal("CopyId")));
                            copy.PurchaseDate = reader.GetDateTime((reader.GetOrdinal("PurchaseDate")));
                            copy.RenewalDate= reader.GetDateTime((reader.GetOrdinal("RenewalDate")));
                            copy.BookId = reader.GetInt32((reader.GetOrdinal("BookId")));
                        }
                    }
                }

                return copy;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        // Select by Id
        public static int getNumberOfCopiesByBookId(int _bookId)
        {
            try
            {
                // Begin declaration
                string storeProcedure = "getNumberCopiesByBookId";
                int copies = -1;
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
                            copies = reader.GetInt32((reader.GetOrdinal("copies")));
                        }
                    }
                }

                // return -1 If there is no copies, >0 if there are copies
                return copies;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        // Select All
        public static List<Copy> getAll()
        {
            try
            {
                // Begin declaration
                string storeProcedure = "getAllCopy";
                List<Copy> listCopies = new List<Copy>();

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
                            Copy copy = new Copy();

                            // Get the columns of the row n
                            copy.CopyId = reader.GetInt32((reader.GetOrdinal("CopyId")));
                            copy.PurchaseDate = reader.GetDateTime((reader.GetOrdinal("PurchaseDate")));
                            copy.RenewalDate = reader.GetDateTime((reader.GetOrdinal("RenewalDate")));
                            copy.BookId = reader.GetInt32((reader.GetOrdinal("BookId")));

                            // Save the row n in a list
                            listCopies.Add(copy);
                        }
                    }
                }

                return listCopies;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        // Select All by BookId
        public static List<Copy> getAllCopyByBookId(int _bookId)
        {
            try
            {
                // Begin declaration
                string storeProcedure = "getAllCopyByBookId";
                List<Copy> listCopies = new List<Copy>();

                //// Dataset
                //DataSet ds = new DataSet();
                //using (Helper db = new Helper())
                //{
                //    using (ds = db.ExecDataSet(storeProcedure));
                //}

                // Set parameters
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@BookId", _bookId);

                // Set command
                using (Helper db = new Helper())
                {
                    using (SqlDataReader reader = db.ExecDataReader(storeProcedure, parameters))
                    {
                        while (reader.Read())
                        {
                            Copy copy = new Copy();

                            // Get the columns of the row n
                            copy.CopyId = reader.GetInt32((reader.GetOrdinal("CopyId")));
                            copy.PurchaseDate = reader.GetDateTime((reader.GetOrdinal("PurchaseDate")));
                            copy.RenewalDate = reader.GetDateTime((reader.GetOrdinal("RenewalDate")));
                            copy.BookId = reader.GetInt32((reader.GetOrdinal("BookId")));

                            // Save the row n in a list
                            listCopies.Add(copy);
                        }
                    }
                }

                return listCopies;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        // CopyDTO - Select Copy by CopyId
        public static CopyDTO getCopyByCopyId(int _copyId)
        {
            try
            {
                // Begin declaration
                string storeProcedure = "getCopyByCopyId";
                CopyDTO copyDTO = new CopyDTO();
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
                            copyDTO.CopyId = reader.GetInt32((reader.GetOrdinal("CopyId")));
                            copyDTO.Ibsn = reader.GetInt32((reader.GetOrdinal("Ibsn")));
                            copyDTO.Author = reader.GetString((reader.GetOrdinal("Author")));
                            copyDTO.Title = reader.GetString((reader.GetOrdinal("Title")));
                            copyDTO.SectionId = reader.GetInt32((reader.GetOrdinal("SectionId")));
                        }
                    }
                }

                // return -1 If there is no copies, >0 if there are copies
                return copyDTO;
            }
            catch (Exception e)
            {
                throw e;
            }

        }


        #endregion

        #region Properties

        // Properties
        public int CopyId
        {
            get { return bookId; }
            set { bookId = value; }
        }
        public int BookId
        {
            get { return copyId; }
            set { copyId = value; }
        }
        public DateTime PurchaseDate
        {
            get { return purchaseDate; }
            set { purchaseDate = value; }
        }
        public DateTime RenewalDate
        {
            get { return renewalDate; }
            set { renewalDate = value; }
        }
        
        #endregion
    }
}
