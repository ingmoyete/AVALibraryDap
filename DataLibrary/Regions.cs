using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataLibrary
{
    public class Regions
    {
        // Attributes
        private int     regionId;
        private string  name;

        #region Constructors
        
        // Fully parameterized constructor
        public Regions(int _regionId, string _name)
        {
            regionId = _regionId;
            name = _name;
        }
        // Empty parameterized constructor
        public Regions()
        {
        }

        #endregion

        // Properties
        public static List<Regions> getAll()
        {
            try
            {
                // Begin declaration
                string storeProcedure = "getAllRegions";
                List<Regions> listRegions = new List<Regions>();
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
                            Regions regions = new Regions();

                            // Get the columns of the row n
                            regions.RegionId = reader.GetInt32((reader.GetOrdinal("RegionId")));
                            regions.Name = reader.GetString((reader.GetOrdinal("Name")));

                            // Save the row n in a list
                            listRegions.Add(regions);
                        }
                    }
                }

                return listRegions;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #region Properties
        // Properties
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

        #endregion
    }
}
