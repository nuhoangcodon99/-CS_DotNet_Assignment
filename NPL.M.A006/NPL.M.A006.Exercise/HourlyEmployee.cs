namespace NPL.M.A006.Exercise;

public class HourlyEmployee : Employee
{
    public double Wage { get; set; }
    public double WorkingHour { get; set; }



    public override string ToString()
    {
        return $"{Wage} {WorkingHour}";
    }
}