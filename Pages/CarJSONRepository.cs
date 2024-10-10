// class to store the list of all cars as a JSON array into a file and act as a common repository to add and retrieve cars.
using System.Text.Json;

public static class CarJSONRepository
{

    private static readonly string CARS_JSON = "cars.json";
    public static void AddCar(Car car)
    {
        if (File.Exists(CARS_JSON) && new FileInfo(CARS_JSON).Length > 0)
{
    try
    {
        // read existing cars.
        List<Car> carJsonContent = JsonSerializer.Deserialize<List<Car>>(File.ReadAllText(CARS_JSON))!;
        
        car.CarId = getCars().Count + 1;
        // add new car to list.
        carJsonContent.Add(car);
        // write new list of cars to file.
        string carsJson = JsonSerializer.Serialize(carJsonContent, new JsonSerializerOptions { WriteIndented = true });
        // write string back to file.
        File.WriteAllText(CARS_JSON, carsJson);
    }
    catch (JsonException)
    {
        // Handle invalid JSON data by initializing a new list
        List<Car> cars = new List<Car>();
        car.CarId = getCars().Count + 1;
        cars.Add(car);
        string carsJson = JsonSerializer.Serialize(cars, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(CARS_JSON, carsJson);
    }
}
else
{
    List<Car> cars = new List<Car>();
    car.CarId = getCars().Count + 1;
    cars.Add(car);
    string carsJson = JsonSerializer.Serialize(cars, new JsonSerializerOptions { WriteIndented = true });
    File.WriteAllText(CARS_JSON, carsJson);
}


    }

    public static List<Car> getCars()
    {
        if (File.Exists(CARS_JSON) && new FileInfo(CARS_JSON).Length > 0)
{
    try
    {
        List<Car> carsJsonContent = JsonSerializer.Deserialize<List<Car>>(File.ReadAllText(CARS_JSON))!;
        carsJsonContent = carsJsonContent.OrderByDescending(car => car.reservationCount).ToList();
        return carsJsonContent;
    }
    catch (JsonException)
    {
        // Handle invalid JSON data by returning an empty list
        return new List<Car>();
    }
}
else
{
    return new List<Car>();
}



    }

    public static Car getCar(int carID){
        Car car = getCars().Where(c => c.CarId == carID).FirstOrDefault()!;
        if(car != null){
            return car;
        }else{
            throw new Exception("Car not found");
        }
    }

    public static void UpdateCarStatusAndCount(int carId)
{
    if (File.Exists(CARS_JSON))
    {
        // read existing cars
        List<Car> carJsonContent = JsonSerializer.Deserialize<List<Car>>(File.ReadAllText(CARS_JSON))!;

        // find the car with the specified CarId and update its status and reservation count.
        carJsonContent = carJsonContent.Select(car =>
        {
            if (car.CarId == carId)
            {
                car.AvailableStatus = false;
                car.reservationCount += 1;
            }
            return car;
        }).ToList();

        // write updated list of cars to file
        string carsJson = JsonSerializer.Serialize(carJsonContent, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(CARS_JSON, carsJson);
    }
    else
    {
        throw new FileNotFoundException("The car does not exist.");
    }
}

}
