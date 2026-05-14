namespace UserServiceTests;

using Xunit;
using Moq;
using UserServiceApp;

public class UserServiceTest
{


    [Fact]
    public void AddUser_With_Valid_Username_Successful()
    {
        // arrange
        String username = "finn";
        String password = "ExamplePassword#1";
        String role = "admin";



        var moqRepository = new Mock<UserServiceMoqRepository>();

        moqRepository.Setup(repository => repository.UserExists(username)).Returns(false);

        UserService userService = new UserService(moqRepository.Object);




        // act

        userService.RegisterUser(username, password, role);

        // assert
        moqRepository.Verify(repository => repository.AddUser(It.Is<User>(user => user.Username == username)), Times.Once);

    }

    [Fact]
    public void AddUser_With_Invalid_Username_Throws_Exception()
    {
        // arrange
        String username = "";
        String password = "ExamplePassword#1";
        String role = "admin";

        var moqRepository = new Mock<UserServiceMoqRepository>();

        UserService userService = new UserService(moqRepository.Object);

        // act

        Action action = () => userService.RegisterUser(username, password, role);

        // assert
        Assert.Throws<ArgumentException>(action);
    }





}