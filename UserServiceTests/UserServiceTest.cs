namespace UserServiceTests;

using Xunit;
using UserServiceApp;

public class UserServiceTest
{


    //registeruser tests

    [Fact]
    public void RegisterUser_Successful()
    {
        // arrange
        UserService userService = new UserService();

        string username = "finn";
        string password = "passwordExample#1";
        string role = "admin";

        // act
        userService.RegisterUser(username, password, role);

        // assert
        Assert.True(userService.users.ContainsKey("finn"));

    }

    [Fact]
    public void RegisterUser_Duplicate_Username_Throws_Exception()
    {
        // arrange
        UserService userService = new UserService();

        string username = "finn";
        string password = "passwordExample#1";
        string role = "admin";

        string username2 = "finn";
        string password2 = "passwordExample#2";
        string role2 = "trainer";

        // act
        userService.RegisterUser(username, password, role);

        // assert
        Assert.Throws<ArgumentException>(() =>
        {
            userService.RegisterUser(username2, password2, role2);
        });

    }

    [Fact]
    public void RegisterUser_Short_Password_Throws_Exception()
    {
        // arrange
        UserService userService = new UserService();

        string username = "finn";
        string password = "passwor";
        string role = "admin";

        // act
        //act and assert are a single step

        // assert
        Assert.Throws<ArgumentException>(() =>
        {
            userService.RegisterUser(username, password, role);
        });

    }

    [Fact]
    public void RegisterUser_Password_Without_Number_Or_Special_Throws_Exception()
    {
        // arrange
        UserService userService = new UserService();

        string username = "finn";
        string password = "password";
        string role = "admin";

        // act
        //act and assert are a single step

        // assert
        Assert.Throws<ArgumentException>(() =>
        {
            userService.RegisterUser(username, password, role);
        });

    }

    [Fact]
    public void RegisterUser_Invalid_Role_Throws_Exception()
    {
        // arrange
        UserService userService = new UserService();

        string username = "finn";
        string password = "passwordExample#1";
        string role = "technician";

        // act
        //act and assert are a single step

        // assert
        Assert.Throws<ArgumentException>(() =>
        {
            userService.RegisterUser(username, password, role);
        });

    }

    //loginuser tests

    [Fact]
    public void LoginUser_Valid_Password_Returns_True()
    {
        // arrange
        UserService userService = new UserService();

        string username = "finn";
        string password = "passwordExample#1";
        string role = "admin";

        userService.RegisterUser(username, password, role);


        // act
        //act and assert are a single step

        bool canLogin = userService.LoginUser(username, password);

        // assert
        Assert.True(canLogin);

    }

    [Fact]
    public void LoginUser_Invalid_Password_Returns_False()
    {
        // arrange
        UserService userService = new UserService();

        string username = "finn";
        string password = "passwordExample#1";
        string role = "admin";

        string invalid_password = "passwordExample#2";

        userService.RegisterUser(username, password, role);


        // act
        //act and assert are a single step

        bool canLogin = userService.LoginUser(username, invalid_password);

        // assert
        Assert.False(canLogin);

    }

    [Fact]
    public void LoginUser_Invalid_Username_Throws_Exception()
    {
        // arrange
        UserService userService = new UserService();

        string username = "finn";
        string password = "passwordExample#1";
        string role = "admin";

        userService.RegisterUser(username, password, role);

        string loginUsername = "";

        // act
        //act and assert are a single step

        // assert
        Assert.Throws<ArgumentException>(() =>
        {
            userService.LoginUser(loginUsername, password);
        });

    }

    [Fact]
    public void LoginUser_Unregistered_User_Throws_Exception()
    {
        // arrange
        UserService userService = new UserService();

        string username = "finn";
        string password = "passwordExample#1";
        string role = "admin";

        userService.RegisterUser(username, password, role);

        string loginUsername = "bob";

        // act
        //act and assert are a single step

        // assert
        Assert.Throws<ArgumentException>(() =>
        {
            userService.LoginUser(loginUsername, password);
        });

    }


    //hasaccess tests

    [Fact]
    public void HasAccess_Valid_Role_Returns_True()
    {
        // arrange
        UserService userService = new UserService();

        string username = "finn";
        string password = "passwordExample#1";
        string role = "admin";

        userService.RegisterUser(username, password, role);


        // act


        bool canAccess = userService.HasAccess(username, "admin");

        // assert
        Assert.True(canAccess);

    }

    [Fact]
    public void HasAccess_Invalid_Role_Returns_False()
    {
        // arrange
        UserService userService = new UserService();

        string username = "finn";
        string password = "passwordExample#1";
        string role = "support";

        userService.RegisterUser(username, password, role);


        // act


        bool canAccess = userService.HasAccess(username, "admin");

        // assert
        Assert.False(canAccess);

    }

    [Fact]
    public void HasAccess_Invalid_Username_Throws_Exception()
    {
        // arrange+
        UserService userService = new UserService();

        string username = "finn";
        string password = "passwordExample#1";
        string role = "support";

        userService.RegisterUser(username, password, role);

        string invalid_username = "";


        // act
        //act and assert are a single step



        // assert
        Assert.Throws<ArgumentException>(() =>
        {
            userService.HasAccess(invalid_username, "support");
        }); ;

    }



}