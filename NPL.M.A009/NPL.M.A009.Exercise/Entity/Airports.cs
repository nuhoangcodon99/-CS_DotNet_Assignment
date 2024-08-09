namespace NPL.M.A009.Exercise;

public class Airports
{
    public string idAirport { get; set; }
    public string NameAirport { get; set; }
    public double RunwaySize { get; set; }
    public int MaxFixedWingParkingPlace { get; set; }
    public List<Fixedwing> FixedWingAirplaneIDs { get; set; }
    public int MaxRotatedWingParkingPlace { get; set; }
    public List<Helicopter> HelicopterIDs  { get; set; }

    public override string ToString()
    {
        return $"ID AIRPORT: {idAirport}        AIRPORT NAME: {NameAirport}   ";
    }
}