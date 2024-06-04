namespace MatchCards.Models;
public class Player : IComparable<Player>
{
    private int _noOfTimesMatched;

    private List<Card> _cardList;
    private string _playerName { get; }

    public Player(string name)
    {
        _playerName = name;
        _cardList = new List<Card>();
    }

    public int HowManyCards()
    {
        return _cardList.Count; 
    }
    public string GetPlayerName()
    {
        return _playerName; 
    }
    public List<Card> AddPileToCards(List<Card> pile)
    {
        _cardList.AddRange(pile);
        pile.Clear();
        return _cardList;
    }

    public void IncrementNoOfTimesMatched()
    {
        _noOfTimesMatched++;
    }

    public int NoOfTimesMatched()
    {
        return _noOfTimesMatched;
    }

    //Compares this instance to a Player object and returns an integer that indicates whether the value
    //of this instance is less than, equal to, or greater than the value of the Player object.
    public int CompareTo(Player other)
    {
        if (other._cardList.Count == _cardList.Count)
        {
            return 0;
        }
        if (other._cardList.Count > _cardList.Count)
        {
            return -1;
        }
        if (other._cardList.Count < _cardList.Count)
        {
            return 1;
        }
        return 0;
    }
}