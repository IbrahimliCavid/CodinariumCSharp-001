using System.Text;
using System.Threading.Channels;
using UserProject.Models;
using UserProject.Services.Concrete;

namespace UserProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            UserManager userManager = new UserManager();
         

            while (true)
            {
                Console.WriteLine("1. İstifadəçi əlavə edin");
                Console.WriteLine("2. İstifadəçilərə baxın");
                Console.WriteLine("3. İdsinə görə istifadəçi sil");
                Console.WriteLine("4. İstifadəçinin emailini redaktə et");
                Console.WriteLine("5. Giriş et");
                Console.WriteLine("6. Proqramı sonlandır");

                int number = int.Parse(Console.ReadLine());
                switch (number)
                {
                    case 1:
                        {
                            Console.Clear();
                            startId:
                            Console.WriteLine("Id daxil edin");
                            int id = int.Parse(Console.ReadLine());
                            Console.WriteLine("Ad daxil edin");
                            string name = Console.ReadLine();
                            Console.WriteLine("Soyad  daxil edin");
                            string surname = Console.ReadLine();
                            Console.WriteLine("Email daxil edin");
                            string email = Console.ReadLine();
                            Console.WriteLine("Password daxil edin");
                            string password = Console.ReadLine();

                            User user = new User()
                            {
                                Id = id,
                                Name = name,
                                Surname = surname,
                                Email = email,
                                Password = password
                            };
                           
                            bool checkId = userManager.CheckId(id);
                            //checkEmail metodunu yazın

                            if (checkId)
                                userManager.Add(user);
                            else
                            {
                                Console.WriteLine("Bu idli istifadəçi artıq mövcuddur!");
                                goto startId;
                            }
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            userManager.ShowAllUser();
                        }
                        break;
                    case 3:
                        {
                            Console.Clear();
                            userManager.ShowAllUser();
                            int id = int.Parse(Console.ReadLine());
                            userManager.DeleteUserByID(id);
                        }
                        break;
                    case 4:
                        {
                            Console.Clear();
                            Console.WriteLine("Emailini dəyişmək istədiyiniz istifadəçinin idsini daxil edin");
                            int id = int.Parse(Console.ReadLine());
                            Console.WriteLine("Emaili daxil edin");
                            string email = Console.ReadLine();

                            userManager.UpdateEmail(id, email);
                        }
                        break;
                    case 5:
                        {
                            Console.Clear();
                            Console.WriteLine("Emaili daxil edin");
                            string email = Console.ReadLine();

                            Console.WriteLine("Passwordu daxil edin");
                            string password = Console.ReadLine();

                          bool checkUser =  userManager.Login(email, password);

                            if (checkUser)
                            {
                                Console.WriteLine("Giriş uğurludur");
                            }
                            else
                            {
                                Console.WriteLine("Giris ugursuzdur!");
                            }
                        }
                        break;
                    case 6:
                        break;
                    default:
                        Console.WriteLine("Düzgün seçim edin!");
                        break;

                }
            }
        }
    }
}
