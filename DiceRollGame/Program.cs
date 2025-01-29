using DiceRollGame;

var attempts = 1;
var randomNumber = RandomNumber.GetRandomNumber();
while (attempts <= 3)
{
    GameMenu.Show();
    var userAnswer = Console.ReadLine();
    if(Convert.ToInt32(userAnswer) != randomNumber)
    {
        Console.WriteLine("Wrong number!");
        attempts++;
    }
    else
    {
        Console.WriteLine("CONGRATULATIONS!");
    }
}
