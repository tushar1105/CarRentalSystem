using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace Assignment4_Tushar_Sharma_8869110.Pages;

public class AllReservationsModel : PageModel
{
    private readonly ILogger<AllReservationsModel> _logger;

    public AllReservationsModel(ILogger<AllReservationsModel> logger)
    {
        _logger = logger;
    }

    public List<FinalReservationData> reservations { get; set; } = new List<FinalReservationData>();
    public User user { get; set; } = new User();

    public void OnGet(User loginUser)
    {
        user = loginUser;
        reservations = FinalReservationJSONRepository.getReservations();
    }
}

