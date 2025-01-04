namespace MemoryGame;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void PlayAgainButton_Clicked(object? sender, EventArgs e)
    {
        GuessingButtons.IsVisible = true;
        PlayAgainButton.IsVisible = false;

        List<string> faceEmojis =
        [
            "😀", "😀",
            "😊", "😊",
            "🤣", "🤣",
            "🥳", "🥳",
            "🤓", "🤓",
            "😎", "😎",
            "😖", "😖",
            "😡", "😡",
        ];

        foreach (var button in GuessingButtons.Children.OfType<Button>())
        {
            int index = Random.Shared.Next(faceEmojis.Count);
            string nextEmoji = faceEmojis[index];
            button.Text = nextEmoji;
            faceEmojis.RemoveAt(index);
        }
    }
    
    private void EmojiHandler(object? sender, EventArgs e)
    {
        throw new NotImplementedException();
    }
}