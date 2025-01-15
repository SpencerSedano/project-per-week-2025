namespace PickRandomCards;

public class CardPicker
{
    public static string[] PickSomeCards(int numberOfCards)
    {
        string[] pickedCards = new string[numberOfCards];
        for (int i = 0; i < numberOfCards; i++)
        {
            pickedCards[i] = RandomValue() + " of " + RandomSuit();
        }
        return pickedCards;
    }

    public static string RandomSuit()
    {
        var randomSuit = Random.Shared.Next(1, 5);
        if (randomSuit == 1) return "Spades";
        if (randomSuit == 2) return "Hearts";
        if (randomSuit == 3) return "Diamonds";
        return "Clubs";
    }

    public static string RandomValue()
    {
        var randomValue = Random.Shared.Next(1, 15);
        if (randomValue == 1) return "Ace";
        if (randomValue == 11) return "Jack";
        if (randomValue == 12) return "Queen";
        if (randomValue == 13) return "King";
        return randomValue.ToString();
    }
}