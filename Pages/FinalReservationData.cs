// class to store the final customer reservation details and the reserved car information.
public class FinalReservationData{

    // Reservation and Class exist as an IN-A relationship.
    public int reservationID {get; set;} = 0;
    public Reservation reservationInfo { get; set; } = new Reservation();
    public Car carInfo { get; set; } = new Car();
}