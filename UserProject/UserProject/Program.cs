using UserProject.DataBase;
using UserProject.Models;
using UserProject.Services.Concrete;
using System.Net.Http.Headers;
using System.Text;

namespace UserProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            // User id,ad, soyad, email, password
            //Istifadeci elave et
            //Istifadecilere bax
            //Idsine gore istifadecini sil
            Console.OutputEncoding = Encoding.UTF8;
           UserManager userManager = new UserManager();

            while (true)
            {
                Console.WriteLine("1. User əlavə et");
                Console.WriteLine("2. Userlərə bax");
                Console.WriteLine("3. İdsinə görə useri sil");
                Console.WriteLine("4. Giriş etmək");
                Console.WriteLine("5. Update");
                Console.WriteLine("6. Proqramı sonlandır");

                int number = int.Parse(Console.ReadLine());

                switch (number)
                {
                    case 1:
                        Console.WriteLine("Id daxil et");
                        int id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Ad daxil et");
                        string name = Console.ReadLine();
                        Console.WriteLine("Soyad daxil et");
                        string surname = Console.ReadLine();
                        Console.WriteLine("Email daxil et");
                        string email = Console.ReadLine();
                        Console.WriteLine("Password daxil et");
                        string password = Console.ReadLine();
                        User newUser = new User()
                        {
                            Id = id,
                            Name = name,
                            Surname = surname,
                            Email = email,
                            Password = password
                        };

                        var findUser = DB.userList.Find(x => (x.Id == id || x.Email == email));

                        if (findUser is null)
                        {
                            DB.userList.Add(newUser);
                        }
                        else
                        {
                            Console.WriteLine("Bu Iddə və ya Emaildə istifadəçi artıq mövcuddur");
                        }


                        break;
                    case 2:
                        userManager.ShowAllUsers();
                        break;

                    case 3:
                        userManager.ShowAllUsers();

                        Console.WriteLine("Silmək istədiyiniz userin idsini yazın");
                        int userId = int.Parse(Console.ReadLine());

                        userManager.DeleteUserById(userId);
                        break;
                    case 4:
                        Console.WriteLine("email daxil edin:");
                        string email1 = Console.ReadLine();
                        Console.WriteLine("password daxil edin:");
                        string pass = Console.ReadLine();

                        bool check = userManager.Login(email1, pass);

                        if (check)
                        {
                            Console.WriteLine("email və ya password yanlışdır!");
                        }
                        else
                        {
                            Console.WriteLine("uğurlu giriş etdiniz");
                        }


                        break;
                    case 5:
                        userManager.ShowAllUsers();
                        Console.WriteLine("Update etmək istədiyiniz userin idsini yazın");
                        int updateId = int.Parse(Console.ReadLine());
                        var updateUser = DB.userList.Find(x => x.Id == updateId);

                        Console.WriteLine("Emaili dəyiş");
                        string updateEmail = Console.ReadLine();

                        updateUser.Email = updateEmail;
                        break;
                }

            }
        }
    }

  
}
