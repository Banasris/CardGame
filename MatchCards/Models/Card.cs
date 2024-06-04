namespace MatchCards.Models;

public class Card
{
    public string Suit { get; }
    public string Value { get; }
    
    public Card(string suit, string value)
    {
        Suit = suit;
        Value = value;
    }

    public override string ToString()
    {
        return $"{Value} of {Suit}";
    }
}