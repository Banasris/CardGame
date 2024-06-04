using MatchCards.Models;

namespace MatchCards.Services;
public class GameService
{
    public static void PlayGame(List<Card> shuffledCards, string matchingCondition, Player player1, Player player2)
    {
        if (shuffledCards == null) throw new ArgumentNullException();

        // Convert the list of cards into a stack to help play sequentially from the top of the deck
        var stackOfShuffledCards = CardsService.CreateStackOfShuffledCards(shuffledCards);
            
        var random = new Random();
        int noOfTimesMatched = 0;

        // Two players are added in the player list
        var playerList = new List<Player>() { player1, player2 };

        // Initialise an empty card pile at the start of the game
        var cardPile = new List<Card>();

        // Continue the game until cards left in the deck to play
        while (stackOfShuffledCards.Count > 0)
        {
            // Two cards played sequentially from the top of the deck
            var popCardOne = stackOfShuffledCards.Pop();
            var popCardTwo = stackOfShuffledCards.Pop();

            // Chosen a random player
            int index = random.Next(0, playerList.Count);

            // If cards matched based on the chosen matching condition
            if (CardsService.CardMatched(popCardOne, popCardTwo, matchingCondition))
            {
                // Increment the value of noOfTimesMatched by 1
                noOfTimesMatched++;
                playerList[index].IncrementNoOfTimesMatched();
                Console.WriteLine($"{playerList[index].GetPlayerName()} called Match!");

                // Matched cards are added into the pile
                cardPile.Add(popCardOne);
                cardPile.Add(popCardTwo);

                // A random player takes all the cards in the pile
                playerList[index].AddPileToCards(cardPile);
            }
            else
            {
                // Not matched cards are added into the pile
                cardPile.Add(popCardOne);
                cardPile.Add(popCardTwo);
            }
        }
        // Analyse the game result when no more cards left in the deck to play
        AnalyseGameResult(player1, player2);
    }

    public static int AnalyseGameResult(Player player1, Player player2)
    {
        var result = player1.CompareTo(player2);

        Console.WriteLine("");
        Console.WriteLine("The Game has completed and here are the results");
        Console.WriteLine($"{player1.GetPlayerName()} has matched {player1.NoOfTimesMatched()} times!");
        Console.WriteLine($"{player2.GetPlayerName()} has matched {player2.NoOfTimesMatched()} times!");
        Console.WriteLine("");
        Console.WriteLine($"{player1.GetPlayerName()} has {player1.HowManyCards()} cards!");
        Console.WriteLine($"{player2.GetPlayerName()} has {player2.HowManyCards()} cards!");
        Console.WriteLine("");

        switch (result)
        {
            case 0:
                Console.WriteLine("It's a Draw!");
                break;
            case 1:
                Console.WriteLine($"{player1.GetPlayerName()} is the Winner!");
                break;
            case -1:
                Console.WriteLine($"{player2.GetPlayerName()} is the Winner!");
                break;
        }

        return result;
    }
}