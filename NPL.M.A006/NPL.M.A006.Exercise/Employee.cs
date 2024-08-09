namespace NPL.M.A006.Exercise;

public abstract class Employee
{
    public string SSN { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }

    public abstract override string ToString();

    public Employee(){}

    public Employee(string ssn, string firstName, string lastName, DateTime birthDate, string phone, string email)
    {
        this.SSN = ssn;
        this.FirstName = firstName;
        this.LastName = lastName;
        this.BirthDate = birthDate;
        this.Phone = phone;
        this.Email = email;
    }

    public void Display()
    {
        Console.WriteLine($"{SSN}   {FirstName}    {LastName}   {BirthDate.ToString("dd/MM/yyyy")}   {Phone}    {Email}");
    }
}