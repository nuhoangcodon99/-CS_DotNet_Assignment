using System.Runtime.InteropServices.JavaScript;
using System.Text.RegularExpressions;
using System.Text.Json;

namespace NPL.M.A009.Exercise;

public class Program{
    private static void MainMenu()
    {
        Console.WriteLine("========= Assignment 09 - Management =========");
        Console.WriteLine("Please select the admin area you require:");
        Console.WriteLine("1. Import Data.");
        Console.WriteLine("2. Airport Management.");
        Console.WriteLine("3. Fixed wing airplane management.");
        Console.WriteLine("4. Helicopter management group.");
        Console.WriteLine("5. Exit.");
        Console.Write("Enter Menu Option Number: ");
        int inp = int.Parse(Console.ReadLine() ?? string.Empty);
        Console.WriteLine(inp);
        switch (inp)
        {
            case 1:
                ImportData();
                break;
            case 2:
                AirportManagement();
                break;
            case 3:
                FixedWingAirplaneManagement();
                break;
            case 4:
                HelicopterManagementGroup();
                break;
            case 5:
                break;
        }

    }

    public static void ImportData()
    {
        Console.WriteLine("========= Import Data =========");
        Console.WriteLine("1. Airport.");
        Console.WriteLine("2. Add Fixed wing airplane.");
        Console.WriteLine("3. Add Helicopter.");
        Console.WriteLine("4. Back.");
        Console.Write("Enter Menu Option Number: ");
        int inp = int.Parse(Console.ReadLine() ?? string.Empty);

        switch (inp)
        {
            case 1:
                AirportCrud();
                break;
            case 2:
                Console.WriteLine("========= Add Fixed Wing Airplane =========");
                

                // public double CruiseSpeed { get; set; }
               
                
                
                // public double MinNeededRunwaySize { get; set; }
                Fixedwing fixedwing = new Fixedwing();
                Console.Write("1.Input ID Aiport (5 digit): ");
                string? idAirport = Console.ReadLine();
                while (!IsValidID(idAirport))
                {
                    Console.WriteLine("Invalid ID !!!");
                    Console.Write("1.Input ID Aiport (5 digit): ");
                    idAirport = Console.ReadLine();
                }

                fixedwing.IdAirplane= $"FW{idAirport}";
                
                Console.Write("2. Model (maximum 40 characters): ");
                string? model = Console.ReadLine();
                while (!IsValidModel(model))
                {
                    Console.WriteLine("Invalid model !!!");
                    Console.Write("2. Model (maximum 40 characters): ");
                    model = Console.ReadLine();
                }
                fixedwing.Model = model;
                
                Console.Write("3. PlaneType (CAG (Cargo), LGR (Long range), PRV (Private)): ");
                string? planeType = Console.ReadLine();
                while (!IsValidPlaneType(planeType))
                {
                    Console.Write("Invalid plane type !!!");
                    Console.Write("3. PlaneType (CAG (Cargo), LGR (Long range), PRV (Private)): ");
                    planeType = Console.ReadLine();
                }
                fixedwing.PlaneType = planeType;
                Console.Write("4. EmptyWeight: ");
                double emptyWeight = double.Parse(Console.ReadLine());
                fixedwing.EmptyWeight = emptyWeight;
                
                Console.Write("5. MaxTakeoffWeight : ");
                double maxTakeoffWeight = double.Parse(Console.ReadLine());
                // while (!IsValidMaxTakeoffWeight(emptyWeight,maxTakeoffWeight))
                // {
                //     Console.WriteLine("Invaild  MaxTakeoffWeight !!! ");
                //     Console.Write("5. MaxTakeoffWeight (Max = 1.5xEmptyWeight): ");
                //     maxTakeoffWeight = double.Parse(Console.ReadLine());
                // }

                fixedwing.MaxTakeoffWeight = maxTakeoffWeight;
                Console.Write("6. CruiseSpeed: ");
                double cruiseSpeed = double.Parse(Console.ReadLine());
                fixedwing.CruiseSpeed = cruiseSpeed;
                
                Console.Write("7. MinNeededRunwaySize: ");
                double minNeededRunwaySize = double.Parse(Console.ReadLine());
                fixedwing.MinNeededRunwaySize = minNeededRunwaySize;
                Console.WriteLine("Successfully created new fixedwing airplane!!!");
                string directoryPath = @"../../../Data/Fixedwings.json";
                List<Fixedwing>? fixedwings = new List<Fixedwing>();
                try
                {
                    // Đọc file JSON và deserialize thành mảng Airport
                    using FileStream fs = new FileStream(directoryPath, FileMode.OpenOrCreate);
       
                    fixedwings = JsonSerializer.Deserialize<List<Fixedwing>>(fs) ;
                
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                fixedwings?.Add(fixedwing);
                using (FileStream fs = new FileStream(directoryPath, FileMode.Create)) 
                {
                    JsonSerializer.Serialize(fs, fixedwings);
                }
                ImportData();
                break;
            case 3:
                Console.WriteLine("========= Add Helicopter =========");
                
                
                Helicopter helicopter = new Helicopter();
                Console.Write("1.Input ID Aiport (5 digit): ");
                string? idAirportHeli = Console.ReadLine();
                while (!IsValidID(idAirportHeli))
                {
                    Console.WriteLine("Invalid ID !!!");
                    Console.Write("1.Input ID Aiport (5 digit): ");
                    idAirport = Console.ReadLine();
                }

                helicopter.IdAirplane= $"FW{idAirportHeli}";
                
                Console.Write("2. Model (maximum 40 characters): ");
                string? modelHeli = Console.ReadLine();
                while (!IsValidModel(modelHeli))
                {
                    Console.WriteLine("Invalid model !!!");
                    Console.Write("2. Model (maximum 40 characters): ");
                    model = Console.ReadLine();
                }
                helicopter.Model = modelHeli;
                
                Console.Write("3. Range: ");
                helicopter.Range = double.Parse(Console.ReadLine());
                Console.Write("4. EmptyWeight: ");
                double emptyWeightHeli = double.Parse(Console.ReadLine());
                helicopter.EmptyWeight = emptyWeightHeli;
                
                Console.Write("5. MaxTakeoffWeight (Max = 1.5xEmptyWeight): ");
                double maxTakeoffWeightHeli = double.Parse(Console.ReadLine());
                while (!IsValidMaxTakeoffWeight(emptyWeightHeli,maxTakeoffWeightHeli))
                {
                    Console.WriteLine("Invaild  MaxTakeoffWeight !!! ");
                    Console.Write("5. MaxTakeoffWeight (Max = 1.5xEmptyWeight): ");
                    maxTakeoffWeightHeli = double.Parse(Console.ReadLine());
                }

                helicopter.MaxTakeoffWeight = maxTakeoffWeightHeli;
                Console.Write("6. CruiseSpeed: ");
                double cruiseSpeedHeli = double.Parse(Console.ReadLine());
                helicopter.CruiseSpeed = cruiseSpeedHeli;
                
                Console.WriteLine("Successfully created new helicopter !!!");
                string directoryPathHeli = @"../../../Data/Helicopters.json";
                List<Helicopter>? helicopters = new List<Helicopter>();
                try
                {
                    // Đọc file JSON và deserialize thành mảng Airport
                    using FileStream fs = new FileStream(directoryPathHeli, FileMode.OpenOrCreate);
       
                    helicopters = JsonSerializer.Deserialize<List<Helicopter>>(fs) ;
                
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                helicopters?.Add(helicopter);
                using (FileStream fs = new FileStream(directoryPathHeli, FileMode.Create)) 
                {
                    JsonSerializer.Serialize(fs, helicopters);
                }
                ImportData();
                break;
            case 4:
                MainMenu();
                break;
        }
    }

    public static bool IsValidMaxTakeoffWeight(double emptyWeight, double maxTakeoffWeight)
    {
        if(emptyWeight * 1.5 <= maxTakeoffWeight)
        {
            return true;
        }

        return false;
    }
    public static bool IsValidPlaneType(string planeType)
    {
        if (String.Compare(planeType, "CAG", StringComparison.Ordinal) == 0 ||
            String.Compare(planeType, "LGR", StringComparison.Ordinal) == 0 ||
            String.Compare(planeType, "PRV", StringComparison.Ordinal) == 0)
        {
            return true;
        }

        return false;
    }
    public static bool IsValidModel(string model)
    {
        if (model.Length <= 40 )
        {
            return true;
        }

        return false;
    }
    public static void AirportCrud()
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
                AddHelicopter(idAirportUpd);
            }

            if (inpItem == 2)
            {
                DelHelicopter(idAirportUpd);
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
                AddFixedWing(idAirportUpd);
            }

            if (inpItem == 2)
            {
                DelFixedWing(idAirportUpd);
            }
        }

        if (inp == 5)
        {
            ImportData();
        }
    }

    public static void AddHelicopter(string idAirport)
    {
        Console.WriteLine("Feature under development.");
    }
    public static void DelHelicopter(string idAirport )
    {
        Console.WriteLine("Feature under development.");
    }
    public static void AddFixedWing(string idAirport)
    {
        Console.WriteLine("Feature under development.");
    }
    public static void DelFixedWing(string idAirport )
    {
        Console.WriteLine("Feature under development.");
    }
    public static bool IsValidID(string? id)
    {
        string regex = @"^\d+$";
            
        if (Regex.IsMatch(id, regex) && id.Length == 5)
        {
            return true;
        }

        return false;
    }

    static void AirportManagement()
    {
        Console.WriteLine("========= Airport Management =========");
        Console.WriteLine("1. Display list of airport information.");
        Console.WriteLine("2. Display status of one airport.");
        Console.WriteLine("3. Main menu.");
        Console.Write("Enter Menu Option Number: ");
        int inp = int.Parse(Console.ReadLine());
        if (inp == 1)
        {
            string directoryPath = @"../../../Data/Airports.json";
            List<Airports>? airports = new List<Airports>();
            try
            {
                // Đọc file JSON và deserialize thành mảng Airport
                using FileStream fs = new FileStream(directoryPath, FileMode.OpenOrCreate);
       
                airports = JsonSerializer.Deserialize<List<Airports>>(fs) ;
                var sortedAirports = airports.OrderBy(a => a.idAirport).ToList();
                foreach (var airport in sortedAirports)
                {
                    Console.WriteLine(airport.ToString());
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            AirportManagement();
        }

        if (inp == 2)
        {
            Console.WriteLine("========= Display status of one airport =========");
            Console.Write("Input Id Airport: ");
            string idAirport = Console.ReadLine();
            string directoryPath = @"../../../Data/Airports.json";
            List<Airports>? airports = new List<Airports>();
            try
            {
                // Đọc file JSON và deserialize thành mảng Airport
                using FileStream fs = new FileStream(directoryPath, FileMode.OpenOrCreate);
       
                airports = JsonSerializer.Deserialize<List<Airports>>(fs) ;
                foreach (var airport in airports)
                {
                    if (String.Compare(airport.idAirport, idAirport, StringComparison.Ordinal) == 0)
                    {
                        Console.WriteLine($"ID AIRPORT: {airport.idAirport}");
                        Console.WriteLine($"AIRPORT NAME: {airport.NameAirport}");
                        Console.WriteLine($"RUNWAY SIZE: {airport.RunwaySize}");
                        Console.WriteLine($"MAX FIXEDWING PARKING PLACE: {airport.MaxFixedWingParkingPlace}");
                        Console.WriteLine("LIST FIXEDWING AIRPLANE:");
                        // var fixedwings = airport.FixedWingAirplaneIDs;
                        // Console.WriteLine(typeof(Fixedwing));
                        if (airport.FixedWingAirplaneIDs != null)
                        {
                            foreach (var fixedwing in airport.FixedWingAirplaneIDs)
                            {
                                Console.WriteLine(fixedwing.ToString());
                            }
                        }
                        else
                        {
                            Console.WriteLine("========= NULL =========");
                        }
                        
                        Console.WriteLine($"MAX ROTATED WING PARKING PLACE: {airport.MaxRotatedWingParkingPlace}");
                        Console.WriteLine("LIST HELICOPTERS: ");
                        if (airport.HelicopterIDs != null)
                        {
                            foreach (var helicopter in airport.HelicopterIDs)
                            {
                                Console.WriteLine(helicopter.ToString());
                            }
                        }
                        else
                        {
                            Console.WriteLine("========= NULL =========");
                        }
                        
                        
                        break;
                    }
                    
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            AirportManagement();
        }

        if (inp == 3)
        {
            MainMenu();
        }
    }

    public static void FixedWingAirplaneManagement()
    {
        Console.WriteLine("========= Fixed Wing Airplane Management =========");
        string directoryPath = @"../../../Data/Airports.json";
        List<Airports>? airports = new List<Airports>();
        try
        {
            // Đọc file JSON và deserialize thành mảng Airport
            using FileStream fs = new FileStream(directoryPath, FileMode.OpenOrCreate);
       
            airports = JsonSerializer.Deserialize<List<Airports>>(fs) ;
            foreach (var airport in airports)
            {
                foreach (var fixedwing in airport.FixedWingAirplaneIDs)
                {
                    Console.WriteLine(fixedwing.ToString() + $"ID AIRPORT PARKING: {airport.idAirport}      AIRPORT NAME PARKING: {airport.NameAirport}");
                }
            }
                
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        MainMenu();
        
        
    }

    public static void HelicopterManagementGroup()
    {
        Console.WriteLine("========= Helicopter Management Group =========");
        string directoryPath = @"../../../Data/Airports.json";
        List<Airports>? airports = new List<Airports>();
        try
        {
            // Đọc file JSON và deserialize thành mảng Airport
            using FileStream fs = new FileStream(directoryPath, FileMode.OpenOrCreate);
       
            airports = JsonSerializer.Deserialize<List<Airports>>(fs) ;
            foreach (var airport in airports)
            {
                foreach (var helicopter in airport.HelicopterIDs)
                {
                    Console.WriteLine(helicopter.ToString() + $"ID AIRPORT PARKING: {airport.idAirport}      AIRPORT NAME PARKING: {airport.NameAirport}");
                }
            }
                
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        MainMenu();
    }


    public static void Main(string[] args)
    {
        MainMenu();
    }
}


