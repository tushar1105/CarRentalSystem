using System.ComponentModel.DataAnnotations;

public class User
{

    public int userId { get; set; } = 0;

    [Required(ErrorMessage = "Please enter a username.")]
    public string Username { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please enter a password.")]
    public string Password { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public User()
    {

    }

    public User(int userId,string username, string password,string name)
    {   
        this.userId = userId;
        this.Username = username;
        this.Password = password;
        this.Name = name;
    }
}