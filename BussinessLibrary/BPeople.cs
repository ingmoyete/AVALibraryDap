using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary;

namespace BussinessLibrary
{
    public static class BPeople
    {
        // Insert
        public static int insert(People _people)
        {
            return People.insert(_people);
        }

        // Update
        public static int update(People _people)
        {
            return People.update(_people);
        }

        // Delete
        public static void deleteById(int _peopleId)
        {
            // Validation goes here

            People.deleteById(_peopleId);
        }

        // Select by id
        public static People getById(int _peopleId)
        {
            // Validation goes here

            return People.getById(_peopleId);
        }

        // Select All
        public static List<People> getAll()
        {
            // Validation goes here

            return People.getAll();
        }
    }
}
