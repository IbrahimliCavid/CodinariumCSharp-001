using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProject.Models;

namespace UserProject.Services.Abstract
{
    public interface IMainOperation
    {
        void Add(User user);
        void ShowAllUser();
        void DeleteUserByID(int id);
        void UpdateEmail(int id, string changeEmail);
        bool Login(string email, string password);
        bool CheckId(int id);
    }
}
