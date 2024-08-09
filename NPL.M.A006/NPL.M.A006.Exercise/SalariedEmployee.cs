namespace NPL.M.A006.Exercise;

public class SalariedEmployee : Employee
{
    public double CommissionRate { get; set; }
    public double GrossSales { get; set; }
    public double BasicSalary { get; set; }
    public override string ToString()
    {
        return $"{BasicSalary}";
    }
}