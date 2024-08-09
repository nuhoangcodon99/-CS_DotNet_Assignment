// See https://aka.ms/new-console-template for more information

namespace NPL.Practice.T01.Problem03
{
    public class Program
    {
        static PhoneBookManagement phoneBookManagement = new PhoneBookManagement();
        public static void Main(string[] args)
        {
            MainMenu();
        }

        private static void MainMenu()
        {
            PhoneBookManagement phoneBookManagement = new PhoneBookManagement();
            Console.WriteLine("====== PhoneBook Management ======");
            Console.WriteLine("1. Add PhoneBook.");
            Console.WriteLine("2. Remove PhoneBook by name.");
            Console.WriteLine("3  Sort list PhoneBook by name in alphabet.");
            Console.WriteLine("4. Find PhoneBool by Name");
            Console.WriteLine("5. Exit.");
            Console.Write("Input: ");
            int input = int.Parse(Console.ReadLine());
            switch (input)
            {
                case 1:
                    AddPhoneBook();
                    break;
                case 2 :
                    RemovePhoneBook();
                    break;
                case 3 :
                    SortPhoneBook();
                    break;
                case 4 :
                    FindPhoneBook();
                    break;
                case 5 :
                    break;
            }
        }

        private static void RemovePhoneBook()
        {
            Console.WriteLine("====== Remove PhoneBook by name ======");
            Console.Write("Input phonebook name you want delete: ");
            string name = Console.ReadLine();
            phoneBookManagement.Remove(name);
            MainMenu();
        }

        private static void AddPhoneBook()
        {
            Console.WriteLine("====== Add PhoneBook ======");
            PhoneBook phoneBook = new PhoneBook();
            Console.Write("1. Name: ");
            phoneBook.Name = Console.ReadLine();
            Console.Write("2. PhoneNumber: ");
            string phoneNumber = Console.ReadLine();
            try
            {
                phoneBook.IsValidPhoneNumber(phoneNumber);
            }
            catch (PhoneBookException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

            phoneBook.PhoneNumber = phoneNumber;
            Console.Write("3. Email: ");
            phoneBook.Email = Console.ReadLine();
            Console.Write("4. Address: ");
            phoneBook.Address = Console.ReadLine();
            Console.Write("5. Group (\"Family\", \"Colleague\", \"Friend\", \"Other\"): ");
            string group = Console.ReadLine();
            try
            {
                phoneBook.IsValidGroup(group);
            }
            catch (PhoneBookException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

            phoneBook.Group = group;
            phoneBookManagement.Add(phoneBook);
            MainMenu();
        }

        private static void SortPhoneBook()
        {
            Console.WriteLine("====== Sort list PhoneBook by name in alphabet ======");
            phoneBookManagement.Sort();
            foreach (PhoneBook item in phoneBookManagement.listPhoneBook)
            {
                Console.WriteLine($"{item.Name}     {item.PhoneNumber}      {item.Email}      {item.Address}      {item.Group}");
            }
            MainMenu();
        }

        private static void FindPhoneBook()
        {
            Console.WriteLine("====== Find PhoneBool by name ======");
            Console.Write("Input phonebook name you want find: ");
            string nameFind = Console.ReadLine();
            PhoneBook result = phoneBookManagement.Find(nameFind);
            if (result != null)
            {
                Console.WriteLine($"{result.Name}     {result.PhoneNumber}      {result.Email}      {result.Address}      {result.Group}");
            }
            MainMenu();
        }
    }
}