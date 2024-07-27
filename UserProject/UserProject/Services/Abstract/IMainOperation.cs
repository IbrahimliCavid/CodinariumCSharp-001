using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserProject.Services.Abstract
{
    public interface IMainOperation
    {
        void ShowAllUsers();
        void DeleteUserById(int id);
        bool Login(string email, string password);
    }
}
