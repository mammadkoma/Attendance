namespace Tests;

public class UsersControllerTest : IClassFixture<AppDbContextFixture>
{
    public AppDbContextFixture appDbContextFixture { get; }

    public UsersControllerTest(AppDbContextFixture fixture) => appDbContextFixture = fixture;

    [Fact]
    public void GetAll_OkResult()
    {
        using var db = appDbContextFixture.CreateContext();
        var service = new UserService(db);
        var users = service.GetAll().Result;
        Assert.Equal(1, users[0]?.Id);
    }
}