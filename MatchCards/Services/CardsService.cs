using MatchCards.Models;

namespace MatchCards.Services;
public class CardsService
{
    /// <summary>
    /// valid suits: spades, hearts, clubs, diamonds
    /// </summary>
    /// <returns>List of valid suits</returns>
    public static List<string> GetValidSuits()
    {
        List<string> validSuits = new List<string>();

        validSuits.Add(nameof(ENUMS.Suit.Clubs));
        validSuits.Add(nameof(ENUMS.Suit.Diamonds));
        validSuits.Add(nameof(ENUMS.Suit.Hearts));
        validSuits.Add(nameof(ENUMS.Suit.Spades));

        return validSuits;
    }
    /// <summary>
    /// Valid values: ace, king, queen, two, three, four, five, six, seven, eight, nine, ten
    /// </summary>
    /// <returns>List of values </returns>
    public static List<string> GetValidValues()
    {
        List<string> validValues = new List<string>();

        validValues.Add(nameof(ENUMS.Value.Ace));
        validValues.Add(nameof(ENUMS.Value.King));
        validValues.Add(nameof(ENUMS.Value.Queen));
        validValues.Add(nameof(ENUMS.Value.Jack));
        validValues.Add(nameof(ENUMS.Value.Two));
        validValues.Add(nameof(ENUMS.Value.Three));
        validValues.Add(nameof(ENUMS.Value.Four));
        validValues.Add(nameof(ENUMS.Value.Five));
        validValues.Add(nameof(ENUMS.Value.Six));
        validValues.Add(nameof(ENUMS.Value.Seven));
        validValues.Add(nameof(ENUMS.Value.Eight));
        validValues.Add(nameof(ENUMS.Value.Nine));
        validValues.Add(nameof(ENUMS.Value.Ten));

        return validValues;
    }
    public static List<Card> CreatePackOfCards() //52 cards in a pack
    {
        var packOfCards = new List<Card>();
        List<string> validsuits = GetValidSuits();
        int totalRows = validsuits.Count;

        for (int row = 0; row < totalRows; row++) //4 suit card
        {
            List<Card> listofCardsPerRow = new List<Card>();
            List<string> validvalues = GetValidValues();
            foreach (var t in validvalues) //13 value cards in each row
            {
                Card card = new Card(validsuits[row], t);
                listofCardsPerRow.Add(card);
            }
            packOfCards.AddRange(listofCardsPerRow);
        }

        return packOfCards;
    }
    public static List<Card> CreateDeckOfCards(int pack) //enter number of pack (52 cards in a pack)
    {
        var deckCards = new List<Card>();
        var packOfCards = CreatePackOfCards();
        for (int i = 0; i < pack; i++)
        {
            deckCards.AddRange(packOfCards);
        }

        return deckCards;
    }
   
    public static List<Card> ShuffleCards(List<Card> cards)
    {
        var rnd = new Random();
        var result = cards.OrderBy(_ => rnd.Next()).ToList();
        return result;
    }
    public static bool CardMatched(Card card1, Card card2, string matchingCondition)
    {
        switch (matchingCondition)
        {
            case nameof(ENUMS.MatchCondition.MatchValues):
                return card1.Value == card2.Value;
            case nameof(ENUMS.MatchCondition.MatchSuits):
                return card1.Suit == card2.Suit;
            case nameof(ENUMS.MatchCondition.MatchSuitsAndValues):
                return card1.Suit == card2.Suit && card1.Value == card2.Value;
            default:
                return false;
        }

    }

    public static Stack<Card> CreateStackOfShuffledCards(List<Card> cardList)
    {
        Stack<Card> cardStack = new Stack<Card>();
        foreach (var card in cardList)
        {
            cardStack.Push(card);
        }
        return cardStack;
    }
}