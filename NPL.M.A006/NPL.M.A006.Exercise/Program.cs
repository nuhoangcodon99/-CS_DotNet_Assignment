using System.Collections;
using System.Text.RegularExpressions;

namespace NPL.M.A006.Exercise;

public class Program
{
    static List<HourlyEmployee> hourlyEmployees = new List<HourlyEmployee>();
    static List<SalariedEmployee> salariedEmployees = new List<SalariedEmployee>();
    static List<Employee> employees = new List<Employee>();
    public static void Menu()
    {
        Console.WriteLine("========= Assignment 06 - EmployeeManagement =========");
        Console.WriteLine("Please select the admin area you require:");
        Console.WriteLine("1. Import Employee.");
        Console.WriteLine("2. Display Employees Information.");
        Console.WriteLine("3. Search Employee.");
        Console.WriteLine("4. Exit.");
        Console.Write("Enter Menu Option Number: ");
        string? inp = Console.ReadLine();
        // Console.WriteLine(inp);
        switch (inp)
        {
            case "1":
                ImportEmployee();
                break;
            case "2":
                DisplayEmployee();
                break;
            case "3" :
                SearchEmployee();
                break;
            case "4":
                break;
        }
            
        
    }

    public static void SearchEmployee()
    {
        Console.WriteLine("========= Search Employee =========");
        Console.WriteLine("1. By Employee Type.");
        Console.WriteLine("2. By Employee Name.");
        Console.WriteLine("3. Main Menu.");
        Console.Write("Enter Menu Option Number: ");
        string? inp = Console.ReadLine();
        if (String.Compare(inp, "1", StringComparison.Ordinal) == 0)
        {
            Console.Write("Enter your Type Employee: ");
            string type = Console.ReadLine();
            if (type == "Hourly")
            {
                foreach (var employee in hourlyEmployees)
                {
                    employee.Display();
                }
                SearchEmployee();
            }
            else if (type == "Salaried")
            {
                foreach (var employee in salariedEmployees)
                {
                    employee.Display();
                }
                SearchEmployee();
            }
        }
        else
        {
            if (String.Compare(inp, "2", StringComparison.Ordinal) == 0)
            {
                Console.Write("Enter Name Employee: ");
                string name = Console.ReadLine();
                // Console.WriteLine(name);
                bool check = true;
                foreach (var employee in employees)
                {
                    if (String.Compare(name, employee.FirstName, StringComparison.Ordinal) == 0)
                    {
                        employee.Display();
                        check = false;
                    }
                    // else
                    // {
                    //     Console.WriteLine(employee.FirstName);
                    // }
                }

                if (check)
                {
                    Console.WriteLine("Not found!");
                }
                SearchEmployee();
            }
            else
            {
                if (String.Compare(inp, "3", StringComparison.Ordinal) == 0)
                {
                    Menu();
                }
            }
            
        }
    }
    public static void DisplayEmployee()
    {
        Console.WriteLine("========= Display Employee =========");
        foreach (var employee in employees)
        {
            employee.Display();

        }
        Menu();
    }
    public static void ImportEmployee()
    {
        Console.WriteLine("========= Import Employee =========");
        Console.WriteLine("1. Salaried Employee.");
        Console.WriteLine("2. Hourly Employee.");
        Console.WriteLine("3. Main Menu.");
        Console.Write("Enter Menu Option Number: ");
        string? inp = Console.ReadLine();
        if (String.Compare(inp, "1", StringComparison.Ordinal) == 0)
        {
            var salariedEmployee = new SalariedEmployee();
            Console.Write("1. SSN: ");
            salariedEmployee.SSN = Console.ReadLine();
            Console.Write("2. FirstName: ");
            salariedEmployee.FirstName = Console.ReadLine();
            Console.Write("2. LastName: ");
            salariedEmployee.LastName = Console.ReadLine();
            Console.Write("3. BirthDate: ");
            string format = "dd/MM/yyyy";
            string? birthDate = Console.ReadLine();
            if (DateTime.TryParseExact(birthDate, format, null, System.Globalization.DateTimeStyles.None,
                    out DateTime result))
            {
                salariedEmployee.BirthDate = result.Date;
            }
                
            Console.Write("4. Phone: ");
            string? phoneNumber = Console.ReadLine();
            while (phoneNumber == null  || !IsValidPhoneNumber(phoneNumber))
            {
                Console.WriteLine("Phone Number is Invalid");
                Console.Write("4. Phone: ");
                phoneNumber = Console.ReadLine();
                
            }

            salariedEmployee.Phone = phoneNumber;
            Console.Write("5. Email: ");
            string? email = Console.ReadLine();
            while (email == null || !IsValidEmail(email))
            {
                Console.WriteLine("Email is Invalid");
                Console.Write("5. Email: ");
                email = Console.ReadLine();
            }

            salariedEmployee.Email = email;
            Console.Write("6. CommissionRate: ");
            salariedEmployee.CommissionRate = (double)Console.Read();
            Console.ReadLine();
            Console.Write("7. GrossSales: ");
            salariedEmployee.GrossSales = (double)Console.Read();
            Console.ReadLine();
            Console.Write("8. BasicSalary: ");
            salariedEmployee.BasicSalary = (double)Console.Read();
            Console.ReadLine();
            employees.Add(salariedEmployee);
            salariedEmployees.Add(salariedEmployee);
            Console.WriteLine("Successful import of employee!");
            ImportEmployee();
        }
        else
        {
            if (String.Compare(inp, "2", StringComparison.Ordinal) == 0)
            {
                var hourlyEmployee = new HourlyEmployee();
                Console.Write("1. SSN: ");
                hourlyEmployee.SSN = Console.ReadLine();
                Console.Write("2. FirstName: ");
                hourlyEmployee.FirstName = Console.ReadLine();
                Console.Write("2. LastName: ");
                hourlyEmployee.LastName = Console.ReadLine();
                Console.Write("3. BirthDate: ");
                string format = "dd/MM/yyyy";
                string? birthDate = Console.ReadLine();
                if (DateTime.TryParseExact(birthDate, format, null, System.Globalization.DateTimeStyles.None,
                        out DateTime result))
                {
                    hourlyEmployee.BirthDate = result.Date;
                }
                
                Console.Write("4. Phone: ");
                string? phoneNumber = Console.ReadLine();
                while (phoneNumber == null  || !IsValidPhoneNumber(phoneNumber))
                {
                    Console.WriteLine("Phone Number is Invalid");
                    Console.Write("4. Phone: ");
                    phoneNumber = Console.ReadLine();
                
                }

                hourlyEmployee.Phone = phoneNumber;
                Console.Write("5. Email: ");
                string? email = Console.ReadLine();
                while (email == null || !IsValidEmail(email))
                {
                    Console.Write("5. Email: ");
                    email = Console.ReadLine();
                }

                hourlyEmployee.Email = email;
                Console.Write("6. Wage: ");
                hourlyEmployee.Wage = (double)Console.Read();
                Console.ReadLine();
                Console.Write("7. WorkingHour: ");
                hourlyEmployee.WorkingHour = (double)Console.Read();
                Console.ReadLine();
                employees.Add(hourlyEmployee);
                hourlyEmployees.Add(hourlyEmployee);
                Console.WriteLine("Successful import of employee!");
                ImportEmployee();
            }

            if (String.Compare(inp, "3", StringComparison.Ordinal) == 0)
            {
                Menu();
            }
        }
        
    }

    private static DateTime ConvertToDateTime(string birthDate)
    {
        string format = "dd/MM/yyyy";
        DateTime myDate = DateTime.ParseExact(birthDate, format, System.Globalization.CultureInfo.InvariantCulture);
        Console.WriteLine(myDate);
        return myDate;
    }
    private static bool IsValidDateTime(string birthDate)
    {
        string format = "dd/MM/yyyy";
        if (DateTime.TryParseExact(birthDate, format, null, System.Globalization.DateTimeStyles.None,
                out DateTime result))
        {
            return true;
        }

        return false;
    }
    private static bool IsValidPhoneNumber(string phoneNumber)
    {
        
        string regex = @"^\d+$";
        
        if (Regex.IsMatch(phoneNumber, regex) && phoneNumber.Length >= 7)
        {
            return true;
        }

        return false;
    }
    private static bool IsValidEmail(string email)
    { 
        string regex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$";

        return Regex.IsMatch(email, regex, RegexOptions.IgnoreCase);
    }

    public static void Main(string[] args)
    {
        employees.Add(new HourlyEmployee(){SSN = "001",FirstName = "Diep",LastName = "Trinh",BirthDate = ConvertToDateTime("12/12/2002"),Phone = "0971715520",Email = "trinhquyendiep@gmail.com", Wage = 3.0,WorkingHour = 4.5});
        hourlyEmployees.Add(new HourlyEmployee(){SSN = "001",FirstName = "Diep",LastName = "Trinh",BirthDate = ConvertToDateTime("12/12/2002"),Phone = "0971715520",Email = "trinhquyendiep@gmail.com", Wage = 3.0,WorkingHour = 4.5});
        employees.Add(new HourlyEmployee(){SSN = "002",FirstName = "Long",LastName = "Lanh",BirthDate = ConvertToDateTime("12/12/2003"),Phone = "0971715520",Email = "trinhquyendiep@gmail.com", Wage = 3.0,WorkingHour = 4.5});
        hourlyEmployees.Add(new HourlyEmployee(){SSN = "003",FirstName = "Nam",LastName = "Trinh",BirthDate = ConvertToDateTime("12/12/2002"),Phone = "0971715520",Email = "trinhquyendiep@gmail.com", Wage = 3.0,WorkingHour = 4.5});
        hourlyEmployees.Add(new HourlyEmployee(){SSN = "002",FirstName = "Long",LastName = "Lanh",BirthDate = ConvertToDateTime("12/12/2003"),Phone = "0971715520",Email = "trinhquyendiep@gmail.com", Wage = 3.0,WorkingHour = 4.5});
        employees.Add(new HourlyEmployee(){SSN = "003",FirstName = "Nam",LastName = "Trinh",BirthDate = ConvertToDateTime("12/12/2002"),Phone = "0971715520",Email = "trinhquyendiep@gmail.com", Wage = 3.0,WorkingHour = 4.5});
        employees.Add(new SalariedEmployee(){SSN = "004",FirstName = "Lan",LastName = "Nguyen",BirthDate = ConvertToDateTime("12/12/2002"),Phone = "0971715520",Email = "trinhquyendiep@gmail.com",CommissionRate = 2.0, GrossSales = 1.4, BasicSalary = 1.7});
        employees.Add(new SalariedEmployee(){SSN = "005",FirstName = "Ngoc",LastName = "Vu",BirthDate = ConvertToDateTime("12/12/2002"),Phone = "0971715520",Email = "trinhquyendiep@gmail.com",CommissionRate = 2.0, GrossSales = 1.4, BasicSalary = 1.7});
        employees.Add(new SalariedEmployee(){SSN = "006",FirstName = "Van",LastName = "Tran",BirthDate = ConvertToDateTime("12/12/2002"),Phone = "0971715520",Email = "trinhquyendiep@gmail.com", CommissionRate = 2.0, GrossSales = 1.4, BasicSalary = 1.7});
        salariedEmployees.Add(new SalariedEmployee(){SSN = "004",FirstName = "Lan",LastName = "Nguyen",BirthDate = ConvertToDateTime("12/12/2002"),Phone = "0971715520",Email = "trinhquyendiep@gmail.com",CommissionRate = 2.0, GrossSales = 1.4, BasicSalary = 1.7});
        salariedEmployees.Add(new SalariedEmployee(){SSN = "005",FirstName = "Ngoc",LastName = "Vu",BirthDate = ConvertToDateTime("12/12/2002"),Phone = "0971715520",Email = "trinhquyendiep@gmail.com",CommissionRate = 2.0, GrossSales = 1.4, BasicSalary = 1.7});
        salariedEmployees.Add(new SalariedEmployee(){SSN = "006",FirstName = "Van",LastName = "Tran",BirthDate = ConvertToDateTime("12/12/2002"),Phone = "0971715520",Email = "trinhquyendiep@gmail.com", CommissionRate = 2.0, GrossSales = 1.4, BasicSalary = 1.7});
        
        Menu();
    }

}