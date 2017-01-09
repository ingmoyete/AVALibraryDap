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
    public class Users : People
    {
        // Attributes
        private int         userId; 
        private int         peopleId;
        private DateTime    signUpDate;    
        private DateTime    renewalDate;
        private string      userName;
        private string      pass;

        // Fully parameterized constructor
        public Users(string _userName, string _pass, int _userId, int _peopleId, DateTime _signUpDate, DateTime _renewalDate) : base()
        {
            userId          = _userId;
            peopleId        = _peopleId;
            signUpDate      = _signUpDate;
            renewalDate     = _renewalDate;
            userName        = _userName;
            pass            = _pass;
        }

        // Empty constructor
        public Users()
        {
        }

        #region Methods

        // Delete
        public static void deleteById(int _userId)
        {
            try
            {

                // Begin declaration
                string storeProcedure = "deleteUser";
                // End declaration

                // Set parameters
                SqlParameter[] parameter = new SqlParameter[1];
                parameter[0] = new SqlParameter("@UserId", _userId);

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
        public static int update(Users _users)
        {
            try
            {

                // Begin declaration
                string storeProcedure = "updateUser";
                // End declaration

                // Set parameters
                SqlParameter[] parameter = new SqlParameter[6];
                parameter[0] = new SqlParameter("@UserId",          _users.UserId);
                parameter[1] = new SqlParameter("@SignUpDate",      _users.SignUpDate);
                parameter[2] = new SqlParameter("@RenewalDate",     _users.RenewalDate);
                parameter[3] = new SqlParameter("@PeopleId",        _users.PeopleId);
                parameter[4] = new SqlParameter("@UserName", _users.UserName);
                parameter[5] = new SqlParameter("@Pass",        _users.Pass);

                // Set command and execute query
                using (Helper db = new Helper())
                {
                    db.ExecNonQuery(storeProcedure, parameter);
                }

                // Get the id of the updated record
                return _users.UserId;

            }
            catch (Exception e)
            {
                throw e;
            }

        }

        // Insert
        public static int insert(Users _users)
        {
            try
            {
                // Begin declaration
                string storeProcedure = "insertUsers";
                // End declaration

                // Set parameters
                SqlParameter[] parameter = new SqlParameter[5];
                SqlParameter output = new SqlParameter("@UserId", SqlDbType.Int);

                parameter[0] = new SqlParameter("@SignUpDate",      _users.SignUpDate);
                parameter[1] = new SqlParameter("@RenewalDate",     _users.RenewalDate);
                parameter[2] = new SqlParameter("@PeopleId",        _users.PeopleId);
                parameter[3] = new SqlParameter("@UserName",        _users.UserName);
                parameter[4] = new SqlParameter("@Pass",            _users.Pass);


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
        public static Users getById(int _userId)
        {
            try
            {
                // Begin declaration
                string storeProcedure = "getUserById";
                Users users             = new Users();
                // End declaration

                // Set parameters
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@UserId", _userId);

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
                            users.UserId = reader.GetInt32((reader.GetOrdinal("UserId")));
                            users.SignUpDate= reader.GetDateTime((reader.GetOrdinal("SignUpDate")));
                            users.RenewalDate= reader.GetDateTime((reader.GetOrdinal("RenewalDate")));
                            users.PeopleId= reader.GetInt32((reader.GetOrdinal("PeopleId")));

                            users.Name      = reader.GetString((reader.GetOrdinal("Name")));
                            users.LastName  = reader.GetString((reader.GetOrdinal("LastName")));
                            users.Dni = reader.GetInt32((reader.GetOrdinal("Dni")));
                            users.RegionId  = reader.GetInt32((reader.GetOrdinal("RegionId")));

                            users.UserName = reader.GetString((reader.GetOrdinal("UserName")));
                            users.Pass = reader.GetString((reader.GetOrdinal("Pass")));

                        }
                    }
                }

                return users;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        // Select user who has loans
        public static int numberOfLoansByUserId(int _userId)
        {
            try
            {
                // Begin declaration
                string storeProcedure = "userHasLoans";
                int numberOfLoans = -1;
                // End declaration

                // Set parameters
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@UserId", _userId);

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
                            numberOfLoans = reader.GetInt32((reader.GetOrdinal("userHasLoans")));
                        }
                    }
                }

                // Throws an error if numberOfLoans is - 1
                if (numberOfLoans == -1)
                {
                    throw new Exception("SysMessage: Number of loans cannot be -1");
                }
                return numberOfLoans;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        // Select All
        public static List<Users> getAll()
        {
            try
            {
                // Begin declaration
                string storeProcedure = "getAllUsers";
                List<Users> listUsers = new List<Users>();
                
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
                            Users users = new Users();

                            // Get the columns of the row n
                            users.UserId = reader.GetInt32((reader.GetOrdinal("UserId")));
                            users.SignUpDate = reader.GetDateTime((reader.GetOrdinal("SignUpDate")));
                            users.RenewalDate = reader.GetDateTime((reader.GetOrdinal("RenewalDate")));
                            users.PeopleId = reader.GetInt32((reader.GetOrdinal("PeopleId")));

                            users.Name = reader.GetString((reader.GetOrdinal("Name")));
                            users.LastName = reader.GetString((reader.GetOrdinal("LastName")));
                            users.Dni = reader.GetInt32((reader.GetOrdinal("Dni")));
                            users.RegionId = reader.GetInt32((reader.GetOrdinal("RegionId")));

                            users.UserName = reader.GetString((reader.GetOrdinal("UserName")));
                            users.Pass = reader.GetString((reader.GetOrdinal("Pass")));

                            // Save the row n in a list
                            listUsers.Add(users);
                        }
                    }
                }

                return listUsers;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        // UserDTO - Select All
        public static List<UserDTO> getAllUserDTO()
        {
            try
            {
                // Begin declaration
                string storeProcedure = "getAllUserDTO";
                List<UserDTO> listUsers = new List<UserDTO>();

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
                            UserDTO userDTO = new UserDTO();

                            // Get the columns of the row n
                            userDTO.UserId = reader.GetInt32((reader.GetOrdinal("UserId")));
                            userDTO.UserName = reader.GetString((reader.GetOrdinal("UserName")));
                            userDTO.Pass = reader.GetString((reader.GetOrdinal("Pass")));
                            userDTO.SignUpDate = reader.GetDateTime((reader.GetOrdinal("SignUpDate")));
                            userDTO.Name = reader.GetString((reader.GetOrdinal("Name")));
                            userDTO.LastName = reader.GetString((reader.GetOrdinal("LastName")));
                            userDTO.Dni = reader.GetInt32((reader.GetOrdinal("Dni")));
                            userDTO.Region = reader.GetString((reader.GetOrdinal("Region")));

                            // Save the row n in a list
                            listUsers.Add(userDTO);
                        }
                    }
                }

                return listUsers;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        // UserDTO - Select by Id
        public static UserDTO getUserDTOById(int _userId)
        {
            try
            {
                // Begin declaration
                string storeProcedure = "getUserDTOById";
                UserDTO userDTO = new UserDTO();
                // End declaration

                // Set parameters
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@UserId", _userId);

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
                            userDTO.UserId = reader.GetInt32((reader.GetOrdinal("UserId")));
                            userDTO.UserName = reader.GetString((reader.GetOrdinal("UserName")));
                            userDTO.Pass = reader.GetString((reader.GetOrdinal("Pass")));
                            userDTO.SignUpDate = reader.GetDateTime((reader.GetOrdinal("SignUpDate")));
                            userDTO.Name = reader.GetString((reader.GetOrdinal("Name")));
                            userDTO.LastName = reader.GetString((reader.GetOrdinal("LastName")));
                            userDTO.Dni = reader.GetInt32((reader.GetOrdinal("Dni")));
                            userDTO.Region = reader.GetString((reader.GetOrdinal("Region")));
                        }
                    }
                }

                return userDTO;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        #endregion

        #region Properties

        // Properties
        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        public DateTime SignUpDate
        {
            get { return signUpDate; }
            set { signUpDate = value; }
        }
        public DateTime RenewalDate
        {
            get { return renewalDate; }
            set { renewalDate = value; }
        }
        public int PeopleId
        {
            get { return peopleId; }
            set { peopleId = value; }
        }
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        public string Pass
        {
            get { return pass; }
            set { pass = value; }
        }

        #endregion


    }
}
