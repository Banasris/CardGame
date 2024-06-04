using MatchCards.Models;
using MatchCards.Services;

namespace MatchCardsTests
{
    [TestFixture]
    public class CardsServiceTests
    {
        [Test]
        public void CreateNewCard_GivenASuitAndValue_ReturnCardWithGivenSuitAndValue()
        {
            Card card = new Card(nameof(ENUMS.Suit.Clubs), nameof(ENUMS.Value.Ace));

            Assert.That(card.ToString(), Does.Contain("ace of clubs").IgnoreCase);
        }

        [Test]
        public void GetValidSuits_CreatesListOfSuits_ReturnListOfValidSuits()
        {
            var allValidSuits = CardsService.GetValidSuits();

            Assert.That(allValidSuits.Count, Is.EqualTo(4));
        }

        [Test]
        public void GetValidSuits_CreatesListOfValues_ReturnListOfValidValues()
        {
            var allValidValues = CardsService.GetValidValues();

            Assert.That(allValidValues.Count, Is.EqualTo(13));
        }

        [Test]
        public void CreatePackOfCards_CompleteSetOfPlayingCards_Return52Cards()
        {
            var pack = CardsService.CreatePackOfCards();
           
            Assert.That(pack.Count, Is.EqualTo(52));
        }

        [Test]
        [TestCase(1, 52)]
        [TestCase(2, 104)]
        [TestCase(3, 156)]
        [TestCase(4, 208)]
        [TestCase(5, 260)]
        [TestCase(6, 312)]
        public void CreateDeckOfCards_UsingMultiplePacks_Return52TimesSizeOfPack(int packSize, int expectedTotalCards)
        {
            var deck = CardsService.CreateDeckOfCards(packSize);

            Assert.That(deck.Count, Is.EqualTo(expectedTotalCards));
        }

        [Test]
        public void ShuffleCards_AfterCardShuffled_ReturnSameNoOfCardsInDifferentOrder()
        {
            var packOfCards = CardsService.CreatePackOfCards();
            var shuffledCards = CardsService.ShuffleCards(packOfCards);

            Assert.That(shuffledCards.Count, Is.EqualTo(52));
            CollectionAssert.AreNotEqual(shuffledCards, packOfCards);
        }

        [Test]
        public void CreateStackOfShuffledCards_GivenListOfCards_ReturnCardsInStack()
        {
            var packOfCards = CardsService.CreatePackOfCards();
            Stack<Card> stackedCards = CardsService.CreateStackOfShuffledCards(packOfCards);

            Assert.That(stackedCards.Count, Is.EqualTo(52));
            Assert.That(stackedCards, Is.TypeOf<Stack<Card>>());
           
        }
        [Test]
        public void CardMatched_CardWithMatchingSuits_ReturnTrue()
        {
            Card card1 = new Card(nameof(ENUMS.Suit.Clubs), nameof(ENUMS.Value.Ace));
            Card card2 = new Card(nameof(ENUMS.Suit.Clubs), nameof(ENUMS.Value.Eight));
            string matchingCondition_match_suits = nameof(ENUMS.MatchCondition.MatchSuits);
            bool result_match_suits = CardsService.CardMatched(card1, card2, matchingCondition_match_suits);

            Assert.That(result_match_suits,Is.True);
        }

        [Test]
        public void CardMatched_CardWithMatchingValues_ReturnTrue()
        {
            Card card1 = new Card(nameof(ENUMS.Suit.Clubs), nameof(ENUMS.Value.Ace));
            Card card2 = new Card(nameof(ENUMS.Suit.Spades), nameof(ENUMS.Value.Ace));
            string matchingCondition_match_values = nameof(ENUMS.MatchCondition.MatchValues);
            bool result_match_values = CardsService.CardMatched(card1, card2, matchingCondition_match_values);

            Assert.That(result_match_values, Is.True);
        }
    }
}