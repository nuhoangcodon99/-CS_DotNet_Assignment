namespace NPL.M.A009.Exercise;

public class Helicopter : Airplane
{
    public double Range { get; set; }
    public override void Fly()
    {
        Console.WriteLine("rotated wing");
    }

    public override string ToString()
    {
        return $"ID: {IdAirplane}   MODEL: {Model}    RANGE: {Range}";
    }
}