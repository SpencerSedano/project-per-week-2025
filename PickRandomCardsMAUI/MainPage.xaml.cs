using PickRandomCards;

namespace PickRandomCardsMAUI;
public partial class MainPage : ContentPage
{
    
    public MainPage()
    {
        InitializeComponent();
    }


    private void PickCardsButton_OnClicked(object? sender, EventArgs e)
    {
        if (int.TryParse(NumberOfCards.Text, out var numberOfCards))
        {
            string[] cards = CardPicker.PickSomeCards(numberOfCards);
            PickedCards.Text = String.Empty;
            foreach (var card in cards)
            {
                PickedCards.Text += card + Environment.NewLine;
            }
            PickedCards.Text += Environment.NewLine + "You picked " + numberOfCards + " cards.";
        }
        else
        {
            PickedCards.Text = "Please enter a valid number";
            Random.Shared.
        }
    }
}