namespace NPL.M.A009.Exercise;

public class Fixedwing : Airplane
{

    public string PlaneType { get; set; }
    public double MinNeededRunwaySize { get; set; }
    
    public override void Fly()
    {
        Console.WriteLine("fixed wing");
    }

    public override string ToString()
    {
        return $"ID: {IdAirplane}   MODEL: {Model}    PLANETYPE: {PlaneType}";
    }
}