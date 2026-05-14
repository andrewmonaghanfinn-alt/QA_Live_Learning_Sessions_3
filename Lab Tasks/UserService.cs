public class UserService
{
    private Dictionary<String, User> users = new Dictionary<String, User>();

    public void RegisterUser(String username, String password, String role)
    {
        // throw IllegalArgumentException (or a custom exception)
        //  	if username exists
        // 	if password is invalid
        // 		password length must be 8 or more character
        // 		Must have one or more numbers
        // 		must contain one of these special characters !@#$%^&*
        //	if role is not a (manager, admin, support or trainer)

        // else do:
        users.Add(username, new User(username, password, role));
        // 	Then test username is added
    }

    public bool LoginUser(string username, string password)
    {
        // throw ArgumentException (or a custom exception)
        //  	if username is null
        //  	if username is empty (spaces/tabs)
        //  	if user is not registered
        //	return true if username and password of an existing user match
        //     else return false
    }

    public bool HasAccess(string username, string requiredRole)
    {
        // throw ArgumentException if username is null or empty
        // return true if the user’s role matches the requiredRole
        // else return false
    }
}


public class User
{
    public string Username { get; private set; }
    public string Password { get; private set; }
    public string Role { get; private set; }

    public User(String username, String password, String role)
    {
        this.Username = username;
        this.Password = password;
        this.Role = role;
    }
}
