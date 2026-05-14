namespace UserServiceApp;


public class UserRepositoryStub
{
    private Dictionary<String, User> users;

    public UserRepositoryStub()
    {
        users = new Dictionary<string, User>();
    }

    public void AddUser(User user)
    {
        if (String.IsNullOrWhiteSpace(user.Username))
        {
            throw new ArgumentException("Invalid username");
        }
        else if (users.ContainsKey(user.Username))
        {
            throw new ArgumentException("User already exists");
        }

        users.Add(user.Username, user);
    
    }

    public Boolean UserExists(User user)
    {
        return users.ContainsKey(user.Username);
    }

    public User GetUser(String username)
    {
        if (!users.ContainsKey(username))
        {
            throw new ArgumentException("User does not exist");
        }

        return users[username];
    }

}