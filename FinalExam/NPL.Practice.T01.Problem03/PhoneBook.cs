using System.Text.RegularExpressions;

namespace NPL.Practice.T01.Problem03;

public class PhoneBook
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string Group { get; set; }
    public void IsValidPhoneNumber(string phoneNumber)
    {
        string pattern = @"^0\d{2} \d{3} \d{4}$"; // The phone number is in format ### ### ####, must be start with 0 (zero), there are 2 spaces and accept digit only.
        Regex regex = new Regex(pattern);
        if (!regex.IsMatch(phoneNumber))
        {
            throw new PhoneBookException("Input value is not correct!");
        }
    }

    public void IsValidGroup(string group)
    {
        string[] arrayGroup = { "Family", "Colleague", "Friend", "Other" }; // The group field accepts one of the following values: "Family", "Colleague", "Friend", "Other"”
        if (Array.IndexOf(arrayGroup, group) == -1)
        {
            throw new PhoneBookException("Input value is not correct!");
        }

        
    }
   
}