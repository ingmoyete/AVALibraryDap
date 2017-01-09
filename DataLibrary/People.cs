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
    public class People
    {
        // Attributes
        private int     peopleId; 
        private int     regionId;
        private int dni;
        private string  name;
        private string  lastName;

        // Fully parameterized constructor
        public People (int _dni, int _peopleId, int _regionId, string _name, string _lastName)
        {
            peopleId        = _peopleId;
            regionId        = _regionId;
            name            = _name;
            lastName        = _lastName;
            dni             = _dni;
        }

        // Empty constructor
        public People()
        {
        }

        #region Methods
        // Methods
        
        // Get people by DNI
        public static Boolean dniExist(int _dni)
        {
            try
            {
                // Begin declaration
                string storeProcedure   = "getPeopleByDni";
                Boolean ret            = true;
                //People people = new People();
                // End declaration

                // Set parameters
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@Dni", _dni);

                //DataSet set;
                //set = Helper.obtenerDataSet("getBookById", parameters);

                // Set command with procedure and parameters
                using (Helper db = new Helper())
                {
                    using (SqlDataReader reader = db.ExecDataReader(storeProcedure, parameters))
                    {
                        if (!reader.Read())
                        {
                            ret = false;
                            /*
                            people.PeopleId = reader.GetInt32((reader.GetOrdinal("PeopleId")));
                            people.Name = reader.GetString((reader.GetOrdinal("Name")));
                            people.LastName = reader.GetString((reader.GetOrdinal("LastName")));
                            people.RegionId = reader.GetInt32((reader.GetOrdinal("RegionId")));
                            people.Dni = reader.GetInt32((reader.GetOrdinal("Dni")));
                             * */
                        }
                        
                    }
                }

                // false if it does not exist, true if it does
                return ret;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // Delete
        public static void deleteById(int _peopleId)
        {
            try
            {

                // Begin declaration
                string storeProcedure = "deletePeople";
                // End declaration

                // Set parameters
                SqlParameter[] parameter = new SqlParameter[1];
                parameter[0] = new SqlParameter("@PeopleId", _peopleId);

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
        public static int update(People _people)
        {
            try
            {

                // Begin declaration
                string storeProcedure = "updatePeople";
                // End declaration

                // Set parameters
                SqlParameter[] parameter = new SqlParameter[5];
                parameter[0] = new SqlParameter("@PeopleId",    _people.PeopleId);
                parameter[1] = new SqlParameter("@Name",        _people.Name);
                parameter[2] = new SqlParameter("@LastName",    _people.LastName);
                parameter[3] = new SqlParameter("@RegionId",    _people.RegionId);
                parameter[4] = new SqlParameter("@Dni",         _people.Dni);


                // Set command and execute query
                using (Helper db = new Helper())
                {
                    db.ExecNonQuery(storeProcedure, parameter);
                }

                // Get the id of the updated record
                return _people.PeopleId;

            }
            catch (Exception e)
            {
                throw e;
            }

        }

        // Insert
        public static int insert(People _people)
        {
            try
            {
                // Begin declaration
                string storeProcedure = "insertPeople";
                // End declaration

                // Set parameters
                SqlParameter[] parameter = new SqlParameter[4];
                SqlParameter output = new SqlParameter("@PeopleId", SqlDbType.Int);

                parameter[0] = new SqlParameter("@Name",        _people.Name);
                parameter[1] = new SqlParameter("@LastName",    _people.LastName);
                parameter[2] = new SqlParameter("@RegionId",    _people.RegionId);
                parameter[3] = new SqlParameter("@Dni",         _people.Dni);

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
        public static People getById(int _peopleId)
        {
            try
            {
                // Begin declaration
                string storeProcedure = "getPeopleById";
                People people = new People();
                // End declaration

                // Set parameters
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@PeopleId", _peopleId);

                //DataSet set;
                //set = Helper.obtenerDataSet("getBookById", parameters);

                // Set command with procedure and parameters
                using (Helper db = new Helper())
                {
                    using (SqlDataReader reader = db.ExecDataReader(storeProcedure, parameters))
                    {
                        if (reader.Read())
                        {
                            people.PeopleId = reader.GetInt32((reader.GetOrdinal    ("PeopleId")));
                            people.Name     = reader.GetString((reader.GetOrdinal   ("Name")));
                            people.LastName = reader.GetString((reader.GetOrdinal   ("LastName")));
                            people.RegionId = reader.GetInt32((reader.GetOrdinal    ("RegionId")));
                        }
                    }
                }

                return people;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        // Select All
        public static List<People> getAll()
        {
            try
            {
                // Begin declaration
                string storeProcedure = "getAllPeople";
                List<People> listPeople = new List<People>();
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
                            People people = new People();

                            // Get the columns of the row n
                            people.PeopleId = reader.GetInt32((reader.GetOrdinal("PeopleId")));
                            people.Name = reader.GetString((reader.GetOrdinal("Name")));
                            people.LastName = reader.GetString((reader.GetOrdinal("LastName")));
                            people.RegionId = reader.GetInt32((reader.GetOrdinal("RegionId")));

                            // Save the row n in a list
                            listPeople.Add(people);
                        }
                    }
                }

                return listPeople;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        #endregion

        #region Properties

        // Properties
        public int PeopleId
        {
            get { return peopleId; }
            set { peopleId = value; }
        }
        public int Dni
        {
            get { return dni; }
            set { dni = value; }
        }
        public int RegionId
        {
            get { return regionId; }
            set { regionId = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        #endregion

        
        
    }

}
