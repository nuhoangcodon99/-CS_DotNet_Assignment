// See https://aka.ms/new-console-template for more information

namespace NPL.Practice.T01.Problem02
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<string> listEmployee = new List<string>(); // Initialize
            listEmployee.Add("Nguyen Van Nam");
            listEmployee.Add("Dang Thanh Trung");
            listEmployee.Add("Le Van Nam");
            listEmployee.Add("Hoang Van Nam");
            listEmployee.Add("Hoang Van Trung");
            listEmployee.Add("Dang Van Hung");
            listEmployee.Add("Ngo Viet Hung");
            List<string> listEmailFpt = GenerateEmailAddress(listEmployee);
            foreach (var email in listEmailFpt)
            {
                Console.WriteLine(email);
            }
        }

        static private List<string> GenerateEmailAddress(List<string> listEmployees)
        {
            List<string> resultEmailFpt = new List<string>();
            Dictionary<string, int> countEmail = new Dictionary<string, int>(); // // Initialize dictionary contains count lastname with key: lastname
            foreach (string item in listEmployees)
            {
                string[] nameParts = item.Split(' '); // split name
                string lastName = nameParts[nameParts.Length - 1].ToLower(); // tolower lastname
                if (countEmail.ContainsKey(lastName)) // check lastname exist
                {
                    countEmail[lastName] = countEmail[lastName] + 1;
                }
                else
                {
                    countEmail.Add(lastName,0);
                }
                string emailFpt = "";
                for (int i = 0; i < nameParts.Length - 1; i++)
                {
                    emailFpt = emailFpt + nameParts[i][0]; // first char in nameparts
                }

                if (countEmail[lastName] > 0)
                {
                    emailFpt = $"{lastName}{emailFpt.ToLower()}{countEmail[lastName]}@fsoft.com.vn"; // Check the number of occurrences of the lastname 
                }
                else
                {
                    emailFpt = $"{lastName}{emailFpt.ToLower()}@fsoft.com.vn";
                }
                
                resultEmailFpt.Add(emailFpt);
            }
            return resultEmailFpt;
        }
    }
}