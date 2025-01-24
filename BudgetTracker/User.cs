namespace BudgetTracker;

using System.IO;

public class User
{
    private string? Name { get; set; }
    private double? BankMoney { get; set; }
    private int _firstTimeMenuTimes = 0;
    private bool _menuControl = true;
    private double _userInput;
    

    public string? GetName() => Name;
    public double? GetBankMoney() => BankMoney;

    public void Menu()
    {
        while (_menuControl)
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
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Add To Budget");
                Console.WriteLine("2. Add Expense");
                Console.WriteLine("3. Save File");

                _userInput = Convert.ToDouble(Console.ReadLine());
                switch (_userInput)
                {
                    case 0:
                        _menuControl = false;
                        break;
                    case 1:
                        Console.Write("Money to add to budget:  ");
                        var budgetMoney = Convert.ToDouble(Console.ReadLine());
                        BankMoney += budgetMoney;
                        Console.WriteLine($"You added {budgetMoney} to {GetBankMoney()} and now it is {BankMoney}");
                        break;
                    case 2:
                        Console.Write("Money to add to your expense: ");
                        var expenseMoney = Convert.ToDouble(Console.ReadLine());
                        BankMoney -= expenseMoney;
                        Console.WriteLine($"You added {expenseMoney} to {GetBankMoney()} and now it is {BankMoney}");
                        break;
                    case 3:
                        Console.WriteLine("Save File? Yes/No");
                        var answer = Console.ReadLine();
                        if (answer?.ToUpper() == "YES")
                        {
                            FileSystem.SavingFile(GetName(), GetBankMoney());
                        }
                        if (answer?.ToUpper() == "NO")
                        {
                            return;
                        }
                        break;
                    default:
                        Console.WriteLine("Choose a valid number");
                        break;
                }
            }
            _firstTimeMenuTimes++;
        }

        
    }
}