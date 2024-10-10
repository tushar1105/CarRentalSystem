using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Assignment4_Tushar_Sharma_8869110.Pages;

public class Reserve : PageModel
{
    private readonly ILogger<Reserve> _logger;

    public Reserve(ILogger<Reserve> logger)
    {
        _logger = logger;
    }
    public Car car = new Car(); // list object to hold the available cars.
    public Reservation reservation { get; set; } = new Reservation();

    FinalReservationData successfulReservation { get; set; } = new FinalReservationData();
    public void OnGet(int carId)
    {
        reservation = new Reservation();
        car = CarJSONRepository.getCar(carId);
        successfulReservation = new FinalReservationData();
        if (carId != 0)
        {
            reservation.ReservedCarId = carId;
        }
        //    System.Console.WriteLine(reservation.Cars.Count);
        // returns all cars.
        //cars = CarRepository.getCars();
    }

    public IActionResult OnPost(Reservation reservation,int carId)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                System.Console.WriteLine(carId);
                reservation.ReservedCarId = carId;
                car = CarJSONRepository.getCar(carId);
                return Page();
            }
            // System.Console.WriteLine("here");
            // Final Reservation Info object to hold user reservation details and car details.
            FinalReservationData finalReservationData = new FinalReservationData();
            // reserved carId received from form.
            int reservedCarId = reservation.ReservedCarId;
            // System.Console.WriteLine(reservedCarId);
            // set the reserved car's available status to false.
            CarJSONRepository.UpdateCarStatusAndCount(reservedCarId);
            // fetching car by ID.
            finalReservationData.carInfo = CarJSONRepository.getCar(reservedCarId);
            // adding the user reservation info to the final reservatoin data object.
            finalReservationData.reservationInfo = reservation;
            // adding each new reservation to the Final reservation repository.
            FinalReservationJSONRepository.addNewReservation(finalReservationData);
            // redirect to the success page to display final receipt.
            successfulReservation = finalReservationData;
            return RedirectToPage("Success", successfulReservation);
        }
        catch (Exception)
        {
            return RedirectToPage("Error");
        }
    }
}

