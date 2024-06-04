using MatchCards.Models;
using MatchCards.Services;

namespace MatchCards;

public class GameSimulator
{
    private Player _player1;
    private Player _player2;
    private int _noOfPack = 0;
    private string _matchingCondition = "";

    public GameSimulator(int noOfPack, string matchingCondition)
    {
        _noOfPack = noOfPack;
        _matchingCondition = matchingCondition;
        _player1 = new Player("player1");
        _player2 = new Player("player2");
    }

    public void ProcessGame()
    {
        // Create a deck of card (e.g. cardDeck will contain a total of 52 x _noOfPack cards )
        List<Card> cardDeck = CardsService.CreateDeckOfCards(_noOfPack);

        // Shuffle the deck of card
        var shuffledCards = CardsService.ShuffleCards(cardDeck);

        // Play the game
        GameService.PlayGame(shuffledCards, _matchingCondition, _player1, _player2);
    }
}