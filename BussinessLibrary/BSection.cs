using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary;

namespace BussinessLibrary
{
    public static class BSection
    {
        // Insert
        public static int insert(Section _section)
        {
            // Validation goes here

            return Section.insert(_section);
        }

        // Update
        public static int update(Section _section)
        {
            // Validation goes here

            return Section.update(_section);
        }

        // Delete
        public static void deleteById(int _sectionId)
        {
            // Validation goes here

            Section.deleteById(_sectionId);
        }

        // Select by id
        public static Section getById(int _sectionId)
        {
            // Validation goes here

            return Section.getById(_sectionId);
        }

        // Select All
        public static List<Section> getAll()
        {
            // Validation goes here

            return Section.getAll();
        }
    }
}
