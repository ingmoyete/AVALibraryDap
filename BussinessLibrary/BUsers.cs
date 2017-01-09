using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary;
using System.Transactions;

namespace BussinessLibrary
{
    public static class BUsers
    {
        // Insert
        public static int insert(Users _users)
        {

            // If DNI exists, it throws an error
            if (People.dniExist(_users.Dni))
            {
                throw new Exception("Dni already exists");
            }

            #region Insert
            
            using (TransactionScope trans = new TransactionScope())
            {
                // Begin declaration
                int peopleId = -1;
                int userId  = -1;
                // End declaration

                // Set People
                People people = new People();

                people.Name = _users.Name;
                people.LastName = _users.LastName;
                people.RegionId = _users.RegionId;
                people.Dni = _users.Dni;

                // Insert People
                peopleId = People.insert(people);

                // Throws exception if people was not written
                if (peopleId == -1)
                {
                    throw new Exception("People was not written, BUsers, line39");
                }

                // Set PeopleId
                _users.PeopleId = peopleId;

                // Insert user
                userId = Users.insert(_users);
                    
                // Throws exception if user was not written
                if (userId == -1)
                {
                    throw new Exception("User was not written, BUsers, line 44");
                }

                trans.Complete();

                // return UserId
                return userId;

            }// End transaction
            #endregion
        }

        // Update
        public static int update(Users _users)
        {
            try
            {
                // PeopleId is not set
                if (_users.PeopleId == 0)
                {
                    throw new Exception("SysMessage: PeopleId is empty");
                }

                // UserId is not set
                if (_users.UserId == 0)
                {
                    throw new Exception("SysMessage: UserId is not set");
                }

                #region Update

                using (TransactionScope trans = new TransactionScope())
                {
                    // Begin declaration
                    int peopleId;
                    int userId;
                    // End declaration

                    // Set People
                    People people = new People();

                    people.PeopleId = _users.PeopleId;
                    people.Name = _users.Name;
                    people.LastName = _users.LastName;
                    people.RegionId = _users.RegionId;
                    people.Dni = _users.Dni;

                    // Insert People
                    peopleId = People.update(people);

                    // Throws exception if people was not written
                    if (peopleId == -1)
                    {
                        throw new Exception("People was not written, BUsers, line39");
                    }

                    // Insert user
                    userId = Users.update(_users);

                    // Throws exception if user was not written
                    if (userId == -1)
                    {
                        throw new Exception("User was not written, BUsers, line 44");
                    }

                    trans.Complete();

                    // return UserId
                    return userId;

                }// End transaction

            } // End try
                #endregion

            catch (Exception e)
            {
                throw e;
            }
        }

        // Delete
        public static void deleteById(int _userId, int _peopleId)
        {
            // If user has loans, it cannot be deleted
            if (Users.numberOfLoansByUserId(_userId) > 0)
            {
                throw new Exception("This user has loans");
            }
            // Delete 
            Users.deleteById(_userId);
            People.deleteById(_peopleId);
        }

        // Select by id
        public static Users getById(int _userId)
        {
            // Validation goes here

            return Users.getById(_userId);
        }

        // Select All
        public static List<Users> getAll()
        {
            // Validation goes here

            return Users.getAll();
        }

        // UsersDTO - Select All
        public static List<UserDTO> getAllUserDTO()
        {
            // Validation goes here

            return Users.getAllUserDTO();
        }

        // UsersDTO - Select by id
        public static UserDTO getUserDTOById(int _userDTOId)
        {
            // Validation goes here

            return Users.getUserDTOById(_userDTOId);
        }

        // DTO -Filter by Region
        public static List<UserDTO> filterByRegion(List<UserDTO> _userDTO, string _region)
        {
            var result = (
                            from records in _userDTO
                            where records.Region == _region
                            select records
                            ).ToList();

            return result;
            
        }

        // DTO -Filter name, lastname and dni by Keyword
        public static List<UserDTO> filterByNameLastNameDni(List<UserDTO> _userDTO, string _keyWord)
        {
            // Get all the words to search in uppercase and in an array
            _keyWord = _keyWord.ToLower();
            string[] _keyWordArray = _keyWord.Split(' ');

            List<UserDTO> listResult = new List<UserDTO>();

            // Search each word to search
            foreach (string word in _keyWordArray)
            {
                Boolean ret = true;

                // For each user
                foreach (UserDTO user in _userDTO)
                {
                    ret = true;

                    // If user already exist in the result list, ret is set to false
                    foreach (UserDTO userResult in listResult)
	                {
		                if (userResult.UserId.ToString().Contains(user.UserId.ToString()))
	                    {
                            ret = false;  
	                    }
	                }

                    // If user does not exist (ret = false), and Name, LastName, and Dni contains the word, the user is add to te result list
                    if (ret && ( user.Name.ToLower().Contains(word) || user.LastName.ToLower().Contains(word) || user.Dni.ToString().Contains(word) ))
                    {
                        listResult.Add(user);
                    }        
                }
                
            }

            return listResult;

        }
    }
}
