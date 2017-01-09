using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataLibrary
{
    public class Section
    {
        // Attributtes

        private int     sectionId;
        private int     corridorNumber;

        private string  name;
        private string  letter;
        
        // Fully parameterized constructor
        public Section(int _sectionId, string _name, string _letter, int _corridorNumber)
        {
            sectionId           = _sectionId;
            name                = _name;
            letter              = _letter;
            corridorNumber      = _corridorNumber;
        }
        
        // Empty constructor
        public Section()
        {
        }

        #region Methods

        // Delete
        public static void deleteById(int _sectionId)
        {
            try
            {

                // Begin declaration
                string storeProcedure = "deleteSection";
                // End declaration

                // Set parameters
                SqlParameter[] parameter = new SqlParameter[1];
                parameter[0] = new SqlParameter("@SectionId", _sectionId);

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
        public static int update(Section _section)
        {
            try
            {

                // Begin declaration
                string storeProcedure = "updateSection";
                // End declaration

                // Set parameters
                SqlParameter[] parameter = new SqlParameter[4];
                parameter[0] = new SqlParameter("@SectionId",       _section.SectionId);
                parameter[1] = new SqlParameter("@Name",            _section.Name);
                parameter[2] = new SqlParameter("@Letter",          _section.Letter);
                parameter[3] = new SqlParameter("@CorridorNumber",  _section.CorridorNumber);

                // Set command and execute query
                using (Helper db = new Helper())
                {
                    db.ExecNonQuery(storeProcedure, parameter);
                }

                // Get the id of the updated record
                return _section.SectionId;

            }
            catch (Exception e)
            {
                throw e;
            }

        }

        // Insert
        public static int insert(Section _section)
        {
            try
            {
                // Begin declaration
                string storeProcedure = "insertSection";
                // End declaration

                // Set parameters
                SqlParameter[] parameter    = new SqlParameter[3];
                SqlParameter output         = new SqlParameter("@SectionId", SqlDbType.Int);

                parameter[0] = new SqlParameter("@Name",            _section.Name);
                parameter[1] = new SqlParameter("@Letter",          _section.Letter);
                parameter[2] = new SqlParameter("@CorridorNumber",  _section.CorridorNumber);

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
        public static Section getById(int _sectionId)
        {
            try
            {
                // Begin declaration
                string storeProcedure   = "getSectionById";
                Section section         = new Section();
                // End declaration

                // Set parameters
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@SectionId", _sectionId);

                //DataSet set;
                //set = Helper.obtenerDataSet("getBookById", parameters);

                // Set command with procedure and parameters
                using (Helper db = new Helper())
                {
                    using (SqlDataReader reader = db.ExecDataReader(storeProcedure, parameters))
                    {
                        if (reader.Read())
                        {
                            section.SectionId       = reader.GetInt32((reader.GetOrdinal("SectionId")));
                            section.Name            = reader.GetString((reader.GetOrdinal("Name")));
                            section.Letter          = reader.GetString((reader.GetOrdinal("Letter")));
                            section.CorridorNumber  = reader.GetInt32((reader.GetOrdinal("CorridorNumber")));
                        }
                    }
                }

                return section;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        // Select All
        public static List<Section> getAll()
        {
            try
            {
                // Begin declaration
                string storeProcedure = "getAllSections";
                List<Section> listSections = new List<Section>();
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
                            Section section = new Section();

                            // Get the columns of the row n
                            section.SectionId = reader.GetInt32((reader.GetOrdinal("SectionId")));
                            section.Name = reader.GetString((reader.GetOrdinal("Name")));
                            section.Letter = reader.GetString((reader.GetOrdinal("Letter")));
                            section.CorridorNumber = reader.GetInt32((reader.GetOrdinal("CorridorNumber")));

                            // Save the row n in a list
                            listSections.Add(section);
                        }
                    }
                }

                return listSections;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        #endregion

        #region Properties

        public int SectionId
        {
            get { return sectionId; }
            set { sectionId = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Letter
        {
            get { return letter; }
            set { letter = value; }
        }
        public int CorridorNumber
        {
            get { return corridorNumber; }
            set { corridorNumber = value; }
        }

        #endregion
    }
}
