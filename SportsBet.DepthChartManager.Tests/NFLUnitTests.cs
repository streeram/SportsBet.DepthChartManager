using SportsBet.DepthChartManager.Helpers;
using SportsBet.DepthChartManager.Interfaces;
using SportsBet.DepthChartManager.Models;

namespace SportsBet.DepthChartManager.Tests;

public class NFLUnitTests
{
    private readonly IDepthChartManager _manager;
    private Dictionary<int, Player> _players;
    public NFLUnitTests()
    {
        _manager = new NFLDepthChartManager();
        _players = new Dictionary<int, Player>();
        var player1 = new Player
        {
            Id = 1,
            Name = "Sriram"
        };

        var player2 = new Player
        {
            Id = 2,
            Name = "Divya"
        };

        var player3 = new Player
        {
            Id = 3,
            Name = "Samanvi"
        };

        var player4 = new Player
        {
            Id = 4,
            Name = "Aditi"
        };

        _players.Add(1, player1);
        _players.Add(2, player2);
        _players.Add(3, player3);
        _players.Add(4, player4);
    }

    [Fact]
    public void TestAddPlayersToDepthChartSuccessfully()
    {
        

        var isPlayerAddedSuccessfully = _manager?.AddPlayerToChart(_players[1], NFLPositionEnum.QB.GetDescription(), 0);
        Assert.True(isPlayerAddedSuccessfully);

        isPlayerAddedSuccessfully = _manager?.AddPlayerToChart(_players[2], NFLPositionEnum.QB.GetDescription(), 0);
        Assert.True(isPlayerAddedSuccessfully);
    }

    [Fact]
    public void TestRemovePlayerFromDepthChartSuccessfully()
    {
        var isPlayerAddedSuccessfully = _manager?.AddPlayerToChart(_players[1], NFLPositionEnum.QB.GetDescription(), 0);
        Assert.True(isPlayerAddedSuccessfully);

        _manager?.RemovePlayerFromChart(_players[1], NFLPositionEnum.QB.GetDescription());

        var players = _manager?.GetPlayersUnderPlayer(_players[1], NFLPositionEnum.QB.GetDescription());
        Assert.Null(players);
    }

    [Fact]
    public void TestRemovePlayerUnderExistingPlayersFromDepthChartSuccessfully()
    {
        var isPlayerAddedSuccessfully = _manager?.AddPlayerToChart(_players[1], NFLPositionEnum.QB.GetDescription(), 0);
        Assert.True(isPlayerAddedSuccessfully);

        isPlayerAddedSuccessfully = _manager?.AddPlayerToChart(_players[2], NFLPositionEnum.QB.GetDescription(), 0);
        Assert.True(isPlayerAddedSuccessfully);

        isPlayerAddedSuccessfully = _manager?.AddPlayerToChart(_players[3], NFLPositionEnum.QB.GetDescription(), 0);
        Assert.True(isPlayerAddedSuccessfully);

        _manager?.RemovePlayerFromChart(_players[1], NFLPositionEnum.QB.GetDescription());

        var players = _manager?.GetPlayersUnderPlayer(_players[3], NFLPositionEnum.QB.GetDescription());
        Assert.NotNull(players);
        Assert.Equal(1, players.Count);
    }
}