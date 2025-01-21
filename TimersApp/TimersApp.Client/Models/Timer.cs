namespace TimersApp.Client.Models;

public class Timer
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Color { get; set; }

    public Timer(int id, string name, string color)
    {
        Id = id;
        Name = name;
        Color = color;
    }
}