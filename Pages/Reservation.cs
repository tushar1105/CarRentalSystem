using System.ComponentModel.DataAnnotations;

// class to store the customer reservation details.
public class Reservation {

    [Required (ErrorMessage = "Please enter a customer name.")]
    [RegularExpression (@"^[A-Za-z\s]+$", ErrorMessage = "Only alphabets and spaces allowed.")]
    [MaxLength(200, ErrorMessage = "Name cannot exceed 200 characters.")]
    public string CustomerName {get; set;}  = string.Empty;
    [Required (ErrorMessage = "Please enter a 10 digit phone number")]        
    [RegularExpression (@"^\d{3}-\d{3}-\d{4}$", ErrorMessage = "Phone number is not in valid format - NNN-NNN-NNNN")]
    public string CustomerPhone {get; set;}  = string.Empty;
    [Required (ErrorMessage = "Please enter a customer address.")]
    [MaxLength(500, ErrorMessage = "Address cannot exceed 500 characters.")]
    public string CustomerAddress {get; set;}  = string.Empty;
    [Required (ErrorMessage = "Please select a reservation Date and Time.")]
    public DateTime ReservationDateTime {get; set;} = DateTime.Now;

    [Required (ErrorMessage = "Please select a car.")]
    [Range(1, int.MaxValue, ErrorMessage = "Please select a car.")]
    public int ReservedCarId {get; set;}  = 0;// used to identify the car that is reserved by the customer.
    
    
    public Reservation (){
        
    }

    public Reservation(string customerName, string customerPhone, string customerAddress, DateTime
    reservationDateTime, int ReservedCarId){
        this.CustomerName = customerName;
        this.CustomerPhone = customerPhone;
        this.CustomerAddress = customerAddress;
        this.ReservationDateTime = reservationDateTime;
        this.ReservedCarId = ReservedCarId;
    }

}