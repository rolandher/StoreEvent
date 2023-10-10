using Moq;
using UseCases.Gateway.Repositories.UserRepository;

namespace TestStore.TestUserUseCase
{
    public class TestUser
    {
        private readonly Mock<IUserRepository> _mockUserRepository;

        //public TestUser()
        //{
        //    _mockUserRepository = new();
        //}

        //[Fact]
        //public async Task RegisterUserAsync()
        //{

        //    // Arrange
        //    var userEntity = new UserEntity("Name", "Email", "Password");

        //    var userResponse = new UserResponse();

        //    userResponse.Name = "Name";
        //    userResponse.Email = "Email";
        //    userResponse.Password = "Password";
        //    userResponse.UserId = Guid.NewGuid();

        //    _mockUserRepository.Setup(x => x.RegisterUserAsync(userEntity).ReturnsAsync(userResponse);

        //    var userUseCase = new UserUseCase(_mockUserRepository.Object);

        //     //Act

        //    var result = await userUseCase.RegisterUserAsync(new RegisterUserCommand("Name", "Email", "Password"));

        //    // Assert

        //    Assert.NotNull(result);

        //    Assert.Equal(userResponse.Name, result.Name);

        //    Assert.Equal(userResponse.Email, result.Email);

        //    Assert.Equal(userResponse.UserId, result.UserId);


    }
}
