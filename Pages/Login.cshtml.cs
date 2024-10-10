using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Assignment4_Tushar_Sharma_8869110.Pages;

public class Login : PageModel
{
    private readonly ILogger<Login> _logger;

    public Login(ILogger<Login> logger)
    {
        _logger = logger;
    }

    public User user {get; set;} = new User();
    public void OnGet()
    {
        user = new User();
    }



    public IActionResult OnPost(User user)
    {
        //database insertion here.
         if(!ModelState.IsValid){
            return Page();
        }
        User loginUser = UserJSONRepository.login(user.Username,user.Password);
        if(loginUser.Username != ""){
            return RedirectToPage("AllReservations",loginUser);
        }else{
            return RedirectToPage("Error");
        }
    }
}

