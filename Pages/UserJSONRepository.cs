// class to store the list of all users as a JSON array into a file and act as a common repository to add and retrieve cars.
using System.Text.Json;

public static class UserJSONRepository
{

    private static readonly string USERS_JSON = "users.json";
    public static void AddUser(User user)
    {
        if (File.Exists(USERS_JSON) && new FileInfo(USERS_JSON).Length > 0)
{
    try
    {
        List<User> userJsonContent = JsonSerializer.Deserialize<List<User>>(File.ReadAllText(USERS_JSON))!;
        
        user.userId = getUsers().Count + 1;
        userJsonContent.Add(user);
        string usersJson = JsonSerializer.Serialize(userJsonContent, new JsonSerializerOptions { WriteIndented = true });
        // write string back to file.
        File.WriteAllText(USERS_JSON, usersJson);
    }
    catch (JsonException)
    {
        // Handle invalid JSON data by initializing a new list
        List<User> users = new List<User>();
        user.userId = getUsers().Count + 1;
        users.Add(user);
        string usersJson = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(USERS_JSON, usersJson);
    }
}
else
{
    List<User> users = new List<User>();
    user.userId = getUsers().Count + 1;
    users.Add(user);
    string usersJson = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
    File.WriteAllText(USERS_JSON, usersJson);
}


    }

    public static List<User> getUsers()
    {
        if (File.Exists(USERS_JSON) && new FileInfo(USERS_JSON).Length > 0)
{
    try
    {
        List<User> usersJsonContent = JsonSerializer.Deserialize<List<User>>(File.ReadAllText(USERS_JSON))!;
        return usersJsonContent;
    }
    catch (JsonException)
    {
        // Handle invalid JSON data by returning an empty list
        return new List<User>();
    }
}
else
{
    return new List<User>();
}



    }

    public static User login(string username, string password){
        User user = getUsers().Where(u => u.Username.Equals(username) && u.Password.Equals(password)).FirstOrDefault()!;
        if(user != null){
            return user;
        }else{
            return new User();
        }
    }


}
