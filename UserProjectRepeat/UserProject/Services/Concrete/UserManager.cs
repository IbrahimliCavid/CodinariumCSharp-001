using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProject.DataBase;
using UserProject.Models;
using UserProject.Services.Abstract;

namespace UserProject.Services.Concrete
{
    public class UserManager : IMainOperation
    {
        public void Add(User user)
        {
           DB.listUser.Add(user);
        }

        public bool CheckId(int id)
        {
            var findUser = DB.listUser.Find(x => x.Id == id);
            if (findUser is null)
                return true;
            else
                return false;
            
        }

        public void DeleteUserByID(int id)
        {
            var findUser = DB.listUser.Find(x => x.Id == id);

            DB.listUser.Remove(findUser);
        }

        public bool Login(string email, string password)
        {
            var loginUser = DB.listUser.Find(x=>(x.Email == email && x.Password == password));

            if (loginUser is null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void ShowAllUser()
        {
            var list = DB.listUser;
            foreach (var item in list)
            {
                Console.WriteLine($"Id: {item.Id} \n" +
                    $"Ad: {item.Name} \n" +
                    $"Soyad {item.Surname} \n" +
                    $"Email : {item.Email} \n" +
                    $"Password {item.Password} \n\n");
            }
        }

        public void UpdateEmail(int id, string changeEmail)
        {
            var findUser = DB.listUser.Find(x => x.Id == id);

            findUser.Email = changeEmail;
        }
    }
}
