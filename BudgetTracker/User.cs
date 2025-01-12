namespace BudgetTracker;

using System.IO;

public class User
{
    private string? Name { get; set; }
    private double? BankMoney { get; set; }
    private int _firstTimeMenuTimes = 0;

    public string? GetName() => Name;
    public double? GetBankMoney() => BankMoney;

    public void SavingFile()
    {
        string folder = @"/Users/spencersedano/Desktop/2025 Coding Resolution/BudgetTracker/savedFiles/";
        Console.Write("Choose a name file: ");
        var userFileName = Console.ReadLine();
        string? fileName = userFileName;
        string fullPath = folder + fileName;

        try
        {
            using (StreamWriter writer = new StreamWriter(fullPath, true))
            {
                writer.WriteLine($"{GetName()}: {GetBankMoney()}\n");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void Menu()
    {
        if (_firstTimeMenuTimes == 0)
        {
            Console.WriteLine("What is your name? ");
            Name = Console.ReadLine();
            Console.WriteLine("Write the starting amount of money: ");
            BankMoney = Convert.ToDouble(Console.ReadLine());
        }
        else
        {
            Console.WriteLine("Options:");
            Console.WriteLine("1. Add Budget");
            Console.WriteLine("2. Add Expenses");
        }
        _firstTimeMenuTimes++;
    }
}