
namespace MatchCards.Models;

public class ENUMS
{
    public enum MatchCondition
    {
        MatchSuits,
        MatchValues,
        MatchSuitsAndValues,
        MatchNotValid
    }

    public enum Suit
    {
        Clubs,
        Diamonds,
        Hearts,
        Spades
    }

    public enum Value
    {
        Ace,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        King,
        Queen,
        Jack
    }
}