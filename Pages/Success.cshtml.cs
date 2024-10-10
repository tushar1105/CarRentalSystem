using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace Assignment3_Tushar_Sharma_8869110.Pages;

public class SuccessModel : PageModel
{
    private readonly ILogger<SuccessModel> _logger;

    public SuccessModel(ILogger<SuccessModel> logger)
    {
        _logger = logger;
    }

    public List<FinalReservationData> reservations {get; set;} = new List<FinalReservationData>();

    public void OnGet()
    {
        reservations = FinalReservationJSONRepository.getReservations();
        var maxIdReservation = reservations.OrderByDescending(r => r.reservationID).FirstOrDefault()!;
        reservations.Clear();
        reservations.Add(maxIdReservation);
    }
}

