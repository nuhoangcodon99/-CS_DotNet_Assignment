using System.Text.Json;
using System.Text.RegularExpressions;

namespace NPL.M.A009.Exercise.Service;

public class AirportService
{
    public bool IsValidID(string? id)
    {
        string regex = @"^\d+$";
            
        if (Regex.IsMatch(id, regex) && id.Length == 5)
        {
            return true;
        }

        return false;
    }

    private HelicopterService heliService;
    private FixedWingService fixedwingService;
    public void AirportCrud()
    {
        Console.WriteLine("========= Airport =========");
        Console.WriteLine("1. Create airport.");
        Console.WriteLine("2. Delete Airport.");
        Console.WriteLine("3. Update helicopter(s) from an airport.");
        Console.WriteLine("4. Update fixed wing airplane.");
        Console.WriteLine("5. Back.");
        Console.Write("Enter Menu Option Number: ");
        int inp = int.Parse(Console.ReadLine() ?? string.Empty);
        if (inp == 1)
        {
            var airport = new Airports();
            Console.WriteLine("========= Create Airport =========");
            Console.Write("1.Input ID Aiport (5 digit): ");
            string? idAirport = Console.ReadLine();
            while (!IsValidID(idAirport))
            {
                Console.WriteLine("Invalid ID!!!");
                Console.Write("1.Input ID Aiport (5 digit): ");
                idAirport = Console.ReadLine();
            }

            airport.idAirport = $"AP{idAirport}";
            Console.Write("2. AirportName: ");
            airport.NameAirport = Console.ReadLine();
            Console.Write("3. RunwaySize: ");
            airport.RunwaySize = double.Parse(Console.ReadLine());
            Console.Write("4. Max Fixed Wing Parking Place: ");
            airport.MaxFixedWingParkingPlace = int.Parse(Console.ReadLine());
            Console.Write("5. Max Rotated Wing Parking Place: ");
            airport.MaxRotatedWingParkingPlace = int.Parse(Console.ReadLine());
            Console.WriteLine("Successfully created new airport!!!");
            string directoryPath = @"../../../Data/Airports.json";
            List<Airports>? airports = new List<Airports>();
            try
            {
                // Đọc file JSON và deserialize thành mảng Airport
                using FileStream fs = new FileStream(directoryPath, FileMode.OpenOrCreate);
       
                airports = JsonSerializer.Deserialize<List<Airports>>(fs) ;
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            airports?.Add(airport);
            using (FileStream fs = new FileStream(directoryPath, FileMode.Create)) 
            {
                JsonSerializer.Serialize(fs, airports);
            }
            AirportCrud();
        }
        if (inp == 2)
        {
            Console.WriteLine("========= Delete Airport =========");
            Console.WriteLine("========= List Airport =========");
            string directoryPath = @"../../../Data/Airports.json";
            List<Airports>? airports = new List<Airports>();
            try
            {
                // Đọc file JSON và deserialize thành mảng Airport
                using FileStream fs = new FileStream(directoryPath, FileMode.OpenOrCreate);
       
                airports = JsonSerializer.Deserialize<List<Airports>>(fs) ;
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            foreach (var airport in airports)
            {
                Console.WriteLine($"{airport.idAirport}     {airport.NameAirport}");
            }
            Console.Write("Please select IdAirport you want delete: ");
            string? idAirportDel = Console.ReadLine();
            foreach (var airport in airports.ToList())
            {
                if (String.Compare(idAirportDel, airport.idAirport, StringComparison.Ordinal) == 0)
                {
                    airports.Remove(airport);
                    Console.WriteLine("Successfully delete airport!!!");
                    break;
                }
            }
            using (FileStream fs = new FileStream(directoryPath, FileMode.Create)) 
            {
                JsonSerializer.Serialize(fs, airports);
            }
            AirportCrud();        
        }

        if (inp == 3)
        {
            Console.WriteLine("========= Update helicopter(s) from an airport =========");
            Console.Write("Please select IdAirport you want delete: ");
            string? idAirportUpd = Console.ReadLine();
            Console.WriteLine($"========= Update helicopter(s) from an airport by ID: {idAirportUpd} =========");
            Console.WriteLine("1. Add helicopter.");
            Console.WriteLine("2. Delete helicopter.");
            int inpItem = int.Parse(Console.ReadLine());
            if (inpItem == 1)
            {
                heliService.AddHelicopter(idAirportUpd);
            }

            if (inpItem == 2)
            {
                heliService.DelHelicopter(idAirportUpd);
            }
        }

        if (inp == 4)
        {
            Console.WriteLine("========= Update helicopter(s) from an airport =========");
            Console.Write("Please select IdAirport you want delete: ");
            string? idAirportUpd = Console.ReadLine();
            Console.WriteLine($"========= Update fixedwing airplane from an airport by ID: {idAirportUpd} =========");
            Console.WriteLine("1. Add fixedwing.");
            Console.WriteLine("2. Delete fixedwing.");
            int inpItem = int.Parse(Console.ReadLine());
            if (inpItem == 1)
            {
                fixedwingService.AddFixedWing(idAirportUpd);
            }

            if (inpItem == 2)
            {
                fixedwingService.DelFixedWing(idAirportUpd);
            }
        }
        
    }
}