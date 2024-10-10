using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Assignment4_Tushar_Sharma_8869110.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public List<Car> cars {get; set;} = new List<Car>(); // list object to hold the available cars.
    public List<User> users {get; set;} = new List<User>(); // list object to hold the available users.
    public void OnGet()
    {   
        // populate the CarRepository with all cars at the rental company.
        // CarRepository.cars.Clear();
        // FinalReservationRepository.finalReservations.Clear();
        // add cars only if the list is empty to avoid duplication.
        if(CarJSONRepository.getCars().Count == 0){
            var bmwX6 = new Car(carId: 1,model: "X6",make: "BMW",imagePath: "/../images/BMWX6.png",description: "Luxurious and powerful, the BMW X6 offers a thrilling drive with cutting-edge technology.",rentPerDay: 20.30,availableStatus: true,reservationCount : 10);
            var dodgeJourney = new Car(carId: 2,model: "Journey",make: "Dodge",imagePath: "/../images/DodgeJourney.png",description: "A spacious and versatile SUV, perfect for family trips and adventures.",rentPerDay: 34.50,availableStatus: true,reservationCount : 2);
            var fordMustang = new Car(carId: 3,model: "Mustang",make: "Ford",imagePath: "/../images/FordMustang.png",description: "Experience the iconic American muscle car with its powerful performance and sleek design.",rentPerDay: 45.0,availableStatus: true,reservationCount : 13);
            var hyundaiElantra = new Car(carId: 4,model: "Elantra",make: "Hyundai",imagePath: "/../images/HyundaiElantra.png",description: "A reliable and fuel-efficient sedan, ideal for both city driving and long journeys.",rentPerDay: 25.75,availableStatus: true,reservationCount : 20);
            var jeepWrangler = new Car(carId: 5,model: "Wrangler",make: "Jeep",imagePath: "/../images/JeepWrangler.png",description: "Rugged and ready for any terrain, the Jeep Wrangler is your go-to for off-road adventures.",rentPerDay: 30.60,availableStatus: true,reservationCount : 4);
            var lexusNX = new Car(carId: 6,model: "NX300",make: "Lexus",imagePath: "/../images/LexusNX300.png",description: "Enjoy the luxury and comfort of the Lexus NX 300, featuring advanced safety and tech.",rentPerDay: 50.25,availableStatus: true,reservationCount : 3);
            var mercedesMaybach = new Car(carId: 7,model: "Maybach",make: "Mercedes",imagePath: "/../images/MercedesMAYBACH.png",description: "Indulge in top-tier elegance and performance with the luxurious Mercedes Maybach.",rentPerDay: 75.25,availableStatus: true,reservationCount : 22);
            var subaruForester = new Car(carId: 8,model: "Forester",make: "Subaru",imagePath: "/../images/SubaruForester.png",description: "The Subaru Forester is a versatile SUV with ample space, perfect for outdoor enthusiasts.",rentPerDay: 40.25,availableStatus: true,reservationCount : 1);
            var toyotaCamry = new Car(carId: 9,model: "Camry",make: "Toyota",imagePath: "/../images/ToyotaCamry.png",description: "A classic sedan known for its reliability and comfort, making every drive a pleasure.",rentPerDay: 30.25,availableStatus: true,2);
            // adding the car objects onto to the list inside the repository.
            CarJSONRepository.AddCar(bmwX6);
            CarJSONRepository.AddCar(dodgeJourney);
            CarJSONRepository.AddCar(fordMustang);
            CarJSONRepository.AddCar(hyundaiElantra);
            CarJSONRepository.AddCar(jeepWrangler);
            CarJSONRepository.AddCar(lexusNX);
            CarJSONRepository.AddCar(mercedesMaybach);
            CarJSONRepository.AddCar(subaruForester);
            CarJSONRepository.AddCar(toyotaCamry);
            // fetch all available cars.
            cars = CarJSONRepository.getCars();
        }else{
            cars = CarJSONRepository.getCars();
        }
        // add users only if the list is empty to avoid duplication.
        if(UserJSONRepository.getUsers().Count == 0){
            var admin = new User(userId: 1,username : "admin",password : "admin@123", name: "Tushar");
            var bob = new User(userId: 2,username : "bob",password : "bob@123", name: "Bob");
            var jack = new User(userId: 3,username : "jack",password : "jack@123", name: "Jack");
            var jim = new User(userId: 4,username : "jim",password : "jim@123", name: "Jim");
            
            // adding the user objects onto to the list inside the repository.
            UserJSONRepository.AddUser(admin);
            UserJSONRepository.AddUser(bob);
            UserJSONRepository.AddUser(jack);
            UserJSONRepository.AddUser(jim);
        }
    }
}
