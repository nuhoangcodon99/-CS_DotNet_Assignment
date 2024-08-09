namespace NPL.M.A009.Exercise;

public abstract class Airplane
{
    public string IdAirplane { get; set; }
    public string Model { get; set; }
    public double CruiseSpeed { get; set; }
    public double EmptyWeight { get; set; }
    public double MaxTakeoffWeight { get; set; }
    protected Airplane(string id, string model, double cruiseSpeed, double emptyWeight, double maxTakeoffWeight)
    {
        IdAirplane = id;
        Model = model;
        CruiseSpeed = cruiseSpeed;
        EmptyWeight = emptyWeight;
        MaxTakeoffWeight = maxTakeoffWeight;
    }

    protected Airplane()
    {
        
    }


    public abstract void Fly();
}