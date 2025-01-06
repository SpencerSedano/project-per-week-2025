namespace MemoryGame;

public partial class MainPage : ContentPage
{
    private int randomEmoji;

    public MainPage()
    {
        InitializeComponent();
    }

    public void PlayAgainEmojiHandler(object? sender, EventArgs e)
    {
        GuessingButtons.IsVisible = true;
        PlayAgainButton.IsVisible = false;
        
        List<List<string>> emojis = new List<List<string>>
        {
            new List<string>
            {
                "😀", "😀",
                "😊", "😊",
                "🤣", "🤣",
                "🥳", "🥳",
                "🤓", "🤓",
                "😎", "😎",
                "😖", "😖",
                "😡", "😡"
            },
            new List<string>
            {
                "🌙", "🌙",
                "🌎", "🌎",
                "🪐", "🪐",
                "🌟", "🌟",
                "⚡️", "⚡️",
                "✨", "✨",
                "💫", "💫",
                "🌔", "🌔"
            },
            new List<string>
            {
                "🍟", "🍟",
                "🍌", "🍌",
                "🍐", "🍐",
                "🍞", "🍞",
                "🍔", "🍔",
                "🍕", "🍕",
                "🍗", "🍗",
                "🧀", "🧀"
            }
        };
        
        
        randomEmoji = Random.Shared.Next(0, 3);
        
        foreach (var button in GuessingButtons.Children.OfType<Button>())
        {
            int index = Random.Shared.Next(emojis[randomEmoji].Count);
            string nextEmoji = emojis[randomEmoji][index];
            button.Text = nextEmoji;
            emojis[randomEmoji].RemoveAt(index);
        }
        
        Dispatcher.StartTimer(TimeSpan.FromSeconds(0.1), TimerTick);
    }
    int tenthsOfSecondsElapsed = 0;
    private bool TimerTick()
    {
        if (!IsLoaded) return false;
        tenthsOfSecondsElapsed++;

        TimeElapsed.Text = "Time Elapsed: " + (tenthsOfSecondsElapsed / 10F).ToString("0.0s");

        if (PlayAgainButton.IsVisible)
        {
            tenthsOfSecondsElapsed = 0;
            return false;
        }

        return true;
    }

    private Button lastClicked;
    private bool findingMatch = false;
    private int matchesFound;
    
    public void EmojiHandler(object? sender, EventArgs e)
    {
        if (sender is Button buttonClicked)
        {
            if (!string.IsNullOrWhiteSpace(buttonClicked.Text) && (findingMatch == false))
            {
                buttonClicked.BackgroundColor = Colors.Red;
                lastClicked = buttonClicked;
                findingMatch = true;
            }
            else
            {
                if(buttonClicked != lastClicked && buttonClicked.Text == lastClicked.Text && !string.IsNullOrWhiteSpace(buttonClicked.Text))
                {
                    matchesFound++;
                    lastClicked.Text = " ";
                    buttonClicked.Text = " ";
                }

                lastClicked.BackgroundColor = Colors.LightBlue;
                buttonClicked.BackgroundColor = Colors.LightBlue;
                findingMatch = false;
            }
        }

        if (matchesFound == 8)
        {
            randomEmoji = Random.Shared.Next(0, 3);
            matchesFound = 0;
            GuessingButtons.IsVisible = false;
            PlayAgainButton.IsVisible = true;
        }
    }
}