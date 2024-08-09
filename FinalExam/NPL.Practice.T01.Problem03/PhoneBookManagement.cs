namespace NPL.Practice.T01.Problem03;

public class PhoneBookManagement
{
    public List<PhoneBook> listPhoneBook  { get; set; }

    public PhoneBookManagement()
    {
        listPhoneBook = new List<PhoneBook>();
    }

    public void Add(PhoneBook phoneBook)
    {
        listPhoneBook.Add(phoneBook);
        Console.WriteLine("Successfully");
    }

    public void Remove(string name)
    {
        listPhoneBook.RemoveAll(item => item.Name == name);
        Console.WriteLine("Successfully");
    }

    public  void Sort()
    {
        listPhoneBook = listPhoneBook.OrderBy(item => item.Name).ToList(); // sort by name
    }
    public  PhoneBook Find(string name)
    {
        PhoneBook result = listPhoneBook.FirstOrDefault(item => item.Name == name); // find by name
        if (result != null)
        {
            return result;
        }
        Console.WriteLine("PhoneNumber not exist!");
        return null;
    }
}