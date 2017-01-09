using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Users users = new Users();
            users.UserId = 28;
            users.RenewalDate = Convert.ToDateTime("15/11/2015");
            users.SignUpDate = Convert.ToDateTime("08/08/2015");
            users.PeopleId = 2;

            
            //Console.WriteLine("SELECT ALL");
            //displaygetAll(Users.getAll());
            
            //Console.WriteLine("SELECT BY ID");
            //displaygetById(Users.getById(25));

            //Console.WriteLine("INSERT");
            //int index = Users.insert(users);
            //displaygetById(Users.getById(index));

            Console.WriteLine("UPDATE");
            Users.update(users);
            displaygetById(Users.getById(users.UserId));

            //Console.WriteLine("DELETE");
            //Users.deleteById(25);
            //displaygetAll(Users.getAll());

            Console.ReadLine();
        }

        static void displaygetAll(List<Users> listSection)
        {
            for (int i = 0; i < listSection.Count; i++)
            {
                Console.WriteLine("User Id: {0}, Signup: {1}, Renewal: {2}, Peopleid: {3}",
                    listSection[i].UserId, listSection[i].SignUpDate, listSection[i].RenewalDate, listSection[i].PeopleId);
            }
        }

        static void displaygetById(Users listSection)
        {
            Console.WriteLine("User Id: {0}, Signup: {1}, Renewal: {2}, Peopleid: {3}",
                listSection.UserId, listSection.SignUpDate, listSection.RenewalDate, listSection.PeopleId);
            
        }
    }
}
