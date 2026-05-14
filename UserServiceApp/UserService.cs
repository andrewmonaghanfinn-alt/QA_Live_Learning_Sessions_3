/* using System.Diagnostics;

namespace UserServiceApp;

public class UserService
{
    public Dictionary<String, User> users = new Dictionary<String, User>();

   
    public void RegisterUser(String username, String password, String role)
    {
        // throw IllegalArgumentException (or a custom exception)
        //  	if username exists
        // 	if password is invalid
        // 		password length must be 8 or more character
        // 		Must have one or more numbers
        // 		must contain one of these special characters !@#$%^&*
        //	if role is not a (manager, admin, support or trainer)

        String special_characters = "!@#$%^&*";
        String numbers = "0123456789";

        if (users.ContainsKey(username))
        {
            throw new ArgumentException("User is already registered");
        }
        if (String.IsNullOrWhiteSpace(username))
        {
            throw new ArgumentException("Invalid username");
        }
        if (password.Length < 8)
        {
            throw new ArgumentException("Password must be at least 8 characters");
        }
        if (!password.Any(s_character => special_characters.Contains(s_character)))
        {
            throw new ArgumentException("Password must contain a special character");
        }
        if (!password.Any(number => numbers.Contains(number)))
        {
            throw new ArgumentException("Password must contain at least 1 number");
        }
        if (role.ToLower() != "manager" && role.ToLower() != "admin" && role.ToLower() != "support" && role.ToLower() != "trainer")
        {
            throw new ArgumentException("Invalid role");
        }

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
        if (String.IsNullOrWhiteSpace(username))
        {
            throw new ArgumentException("Invalid username");
        }
        if (!users.ContainsKey(username))
        {
            throw new ArgumentException("User is not registered");
        }
        else if (users[username].Password != password)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public bool HasAccess(string username, string requiredRole)
    {
        // throw ArgumentException if username is null or empty
        // return true if the user’s role matches the requiredRole
        // else return false
        if (String.IsNullOrWhiteSpace(username))
        {
            throw new ArgumentException("Invalid username");
        }
        if (users.ContainsKey(username) && users[username].Role == requiredRole)
        {
            return true;
        }

        return false;
    }
}

*/

//remade the class using moq repository


namespace UserServiceApp;

public class UserService
{
    private readonly UserServiceMoqRepository repository;

    public UserService(UserServiceMoqRepository injectedRepository)
    {
        repository = injectedRepository;
    }



    public void RegisterUser(String username, String password, String role)
    {
        // throw IllegalArgumentException (or a custom exception)
        //  	if username exists
        // 	if password is invalid
        // 		password length must be 8 or more character
        // 		Must have one or more numbers
        // 		must contain one of these special characters !@#$%^&*
        //	if role is not a (manager, admin, support or trainer)

        String special_characters = "!@#$%^&*";
        String numbers = "0123456789";

        if (repository.UserExists(username))
        {
            throw new ArgumentException("User is already registered");
        }
        if (String.IsNullOrWhiteSpace(username))
        {
            throw new ArgumentException("Invalid username");
        }
        if (password.Length < 8)
        {
            throw new ArgumentException("Password must be at least 8 characters");
        }
        if (!password.Any(s_character => special_characters.Contains(s_character)))
        {
            throw new ArgumentException("Password must contain a special character");
        }
        if (!password.Any(number => numbers.Contains(number)))
        {
            throw new ArgumentException("Password must contain at least 1 number");
        }
        if (role.ToLower() != "manager" && role.ToLower() != "admin" && role.ToLower() != "support" && role.ToLower() != "trainer")
        {
            throw new ArgumentException("Invalid role");
        }

        // else do:
        repository.AddUser(new User(username, password, role));
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
        if (String.IsNullOrWhiteSpace(username))
        {
            throw new ArgumentException("Invalid username");
        }
        if (!repository.UserExists(username))
        {
            throw new ArgumentException("User is not registered");
        }
        else if (repository.GetUser(username).Password != password)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public bool HasAccess(string username, string requiredRole)
    {
        // throw ArgumentException if username is null or empty
        // return true if the user’s role matches the requiredRole
        // else return false
        if (String.IsNullOrWhiteSpace(username))
        {
            throw new ArgumentException("Invalid username");
        }
        if (repository.GetUser(username).Username == username && repository.GetUser(username).Role == requiredRole)
        {
            return true;
        }

        return false;
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

