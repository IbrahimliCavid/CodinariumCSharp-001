using UserProject.DataBase;
using UserProject.Models;
using UserProject.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserProject.Services.Concrete
{
    public class UserManager : IMainOperation
    {
        public void DeleteUserById(int id)
        {
            var deletUser = DB.userList.Find(x => x.Id == id);
            DB.userList.Remove(deletUser);
        }

        public bool Login(string email, string password)
        {
            var user = DB.userList.Find(x => (x.Email == email && x.Password == password));

            if (user is null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void ShowAllUsers()
        {
            foreach (var user in DB.userList)
            {
                Console.WriteLine($"Id: {user.Id} Ad: {user.Name} Soyad: {user.Surname} Email: {user.Email} Password: {user.Password}");
            }
        }
    }
}
