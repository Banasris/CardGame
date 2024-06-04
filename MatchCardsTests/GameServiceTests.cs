using MatchCards.Models;
using MatchCards.Services;

namespace MatchCardsTests;

[TestFixture]
public class GameServiceTests
{
    [Test]
    public void AnalyseGameResult_TwoPlayersCardCountWhenEqual_ReturnScoreZero()
    {
        Player p1 = new Player("player1");
        Player p2 = new Player("player2");

        var pack1 = CardsService.CreatePackOfCards();
        var pack2 = CardsService.CreatePackOfCards();

        p1.AddPileToCards(pack1);
        p2.AddPileToCards(pack2);

        var result = GameService.AnalyseGameResult(p1, p2);

        Assert.That(result, Is.EqualTo(0));
    }

    [Test]
    public void AnalyseGameResult_Player2HasMoreCards_ReturnScoreMinusOne()
    {
        Player p1 = new Player("player1");
        Player p2 = new Player("player2");

        var pack1 = CardsService.CreateDeckOfCards(1);
        var pack2 = CardsService.CreateDeckOfCards(2);

        p1.AddPileToCards(pack1);
        p2.AddPileToCards(pack2);

        var result = GameService.AnalyseGameResult(p1, p2);

        Assert.That(result, Is.EqualTo(-1));
    }

    [Test]
    public void AnalyseGameResult_Player1HasMoreCards_ReturnScoreOne()
    {
        Player p1 = new Player("player1");
        Player p2 = new Player("player2");

        var pack1 = CardsService.CreateDeckOfCards(1);
        var pack2 = CardsService.CreateDeckOfCards(2);

        p1.AddPileToCards(pack2);
        p2.AddPileToCards(pack1);

        var result = GameService.AnalyseGameResult(p1, p2);

        Assert.That(result, Is.EqualTo(1));
    }

    [Test]
    public void PlayGame_ShuffledCardArgIsNull_ThrowArgumentNullException()
    {
        Player p1 = new Player("player1");
        Player p2 = new Player("player2");

        Assert.That(() => GameService.PlayGame(null,nameof(ENUMS.MatchCondition.MatchSuits), p1, p2), Throws.ArgumentNullException);
    }
}