namespace PickRandomCards;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Pick a random number: ");
        string? userInput = Console.ReadLine();

        if (int.TryParse(userInput, out int numberOfCards))
        {
            string[] cards = CardPicker.PickSomeCards(numberOfCards);
            foreach (string card in cards)
            {
                Console.WriteLine(card);
            }
        }
        else
        {
            Console.WriteLine("Please enter a valid number");
        }
    }
}