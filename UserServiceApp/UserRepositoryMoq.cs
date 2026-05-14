namespace UserServiceApp;

public interface UserServiceMoqRepository
{
    void AddUser(User user);

    User GetUser(String username);

    Boolean UserExists(String username);

}