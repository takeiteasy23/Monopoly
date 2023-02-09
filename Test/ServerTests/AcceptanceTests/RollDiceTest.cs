using Application.Common;
using Microsoft.AspNetCore.SignalR.Client;

namespace ServerTests.AcceptanceTests;

[TestClass]
public class RollDiceTest
{
    private MonopolyTestServer server;
    private IRepository repository;
    
    [TestInitialize]
    public void Setup()
    {
        server = new MonopolyTestServer();
        repository = server.GetRequiredService<IRepository>();
    }
    
    [TestMethod]
    [Ignore]
    [Description(
        """
        Given:  目前玩家在F4
        When:   玩家擲骰得到7點
        Then:   A 移動到 A4
        """)]
    public void 玩家擲骰後移動棋子()
    {
        // Arrange
        var hub = server.CreateHubConnection();

        // Act
        // Assert
    }
}
