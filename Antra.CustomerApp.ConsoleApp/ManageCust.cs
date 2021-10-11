using System;
using System.Collections.Generic;
using System.Text;
using Antra.CustomerApp.Data.Model;
using Antra.CustomerApp.Data.Repository;

namespace Antra.CustomerApp.ConsoleApp
{
    class ManageCust
    {
        IRepository<Cust> custRepository;
        public ManageCust()
        {
            custRepository = new CustRepository();
        }
        void AddCustomer()
        {
            Cust c = new Cust();
            Console.Write("Enter First Name = ");
            c.FirstName = Console.ReadLine();
            Console.Write("Enter Last Name = ");
            c.LastName = Console.ReadLine();
            Console.Write("Enter Mobile = ");
            c.Mobile = Console.ReadLine();
            Console.Write("Enter Email Id = ");
            c.EmailId = Console.ReadLine();
            Console.Write("Enter City = ");
            c.City = Console.ReadLine();
            Console.Write("Enter State = ");
            c.State = Console.ReadLine();
            int insert = custRepository.Insert(c);
            if (insert > -1)
                Console.WriteLine("success");
            else
                Console.WriteLine("error!");
        }

        void UpdateCustomer()
        {
            Cust c = new Cust();
            Console.Write("Enter First Name = ");
            c.FirstName = Console.ReadLine();
            Console.Write("Enter Last Name = ");
            c.LastName = Console.ReadLine();
            Console.Write("Enter Mobile = ");
            c.Mobile = Console.ReadLine();
            Console.Write("Enter Email Id = ");
            c.EmailId = Console.ReadLine();
            Console.Write("Enter City = ");
            c.City = Console.ReadLine();
            Console.Write("Enter State = ");
            c.State = Console.ReadLine();
            int update = custRepository.Update(c);
            if (update > -1)
                Console.WriteLine("success");
            else
                Console.WriteLine("error!");
        }

        void DeleteCustomer()
        {
            Console.WriteLine("Delete Customer with id = ");
            int id = Convert.ToInt32(Console.ReadLine());
            int delete = custRepository.Delete(id);
            if (delete > -1)
                Console.WriteLine("success");
            else
                Console.WriteLine("error!");
        }

        void PrintCustomer()
        {
            IEnumerable<Cust> collection = custRepository.GetAll();

            bool isEmpty = true;

            if (collection != null)
            {
                foreach (var item in collection)
                {
                    isEmpty = false;
                    break;
                }
            }
            else
            {
                Console.WriteLine("Something went horribly wrong, this should not be happening!");
            }

            if (!isEmpty)
            {
                foreach (var item in collection)
                {
                    Console.WriteLine($"{item.Id} \t {item.FirstName} \t {item.LastName} \t {item.Mobile} \t {item.EmailId} \t {item.City} \t {item.State}");
                }
            }
            else
            {
                Console.WriteLine("No records yet!");
            }
        }

        void PrintCustomerById()
        {
            Console.Write("Enter Id = ");
            int id = Convert.ToInt32(Console.ReadLine());
            Cust item = custRepository.GetById(id);
            if (item != null)
            {
                Console.WriteLine($"{item.Id} \t {item.FirstName} \t {item.LastName} \t {item.Mobile} \t {item.EmailId} \t {item.City} \t {item.State}");
            }
            else
            {
                Console.WriteLine("No record found");
            }
        }

        public void Run()
        {
            Console.WriteLine("Press 1 for all Customer info");
            Console.WriteLine("Press 2 for specific Customer info");
            Console.WriteLine("Press 3 to update a specific Customer's info");
            Console.WriteLine("Press 4 to add a customer to database");
            Console.WriteLine("Press 5 to delete a customer from database by their id");

            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    PrintCustomer();
                    break;
                case 2:
                    PrintCustomerById();
                    break;
                case 3:
                    UpdateCustomer();
                    break;
                case 4:
                    AddCustomer();
                    break;
                case 5:
                    DeleteCustomer();
                    break;
                default:
                    Console.WriteLine("Please enter a number 1 through 5");
                    break;
            }

        }
    }
}
