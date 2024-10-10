using Microsoft.AspNetCore.Routing.Constraints;

// class to store details for all cars available at the company.
public class Car {
    public int CarId {get; set;} = 0;
    public string Model {get; set;} = string.Empty;
    public string Make {get; set;} = string.Empty;
    public string ImagePath {get; set;} = string.Empty;
    public String Description {get; set;} = string.Empty;
    public double RentPerDay {get; set;}  = 0.0;
    public Boolean AvailableStatus {get; set;}  = true;// to check for if the car is reserved or available.
    public int reservationCount {get; set;} = 0;

    public Car(){
        
    }
    public Car(int carId, string model, string make, string imagePath, string
    description, double rentPerDay,bool availableStatus,int reservationCount){
        this.CarId = carId;
        this.Model = model;
        this.Make = make;
        this.ImagePath = imagePath;
        this.Description = description;
        this.RentPerDay = rentPerDay;
        this.AvailableStatus = availableStatus;
        this.reservationCount = reservationCount;
    }


}