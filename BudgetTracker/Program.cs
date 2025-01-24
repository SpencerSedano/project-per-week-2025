namespace BudgetTracker;

using System.IO;

//Requirements:
// 0. Have a starting amount of money
// 1. Input Savings
// 2. Input Expenses
// Be able to save it in a .txt file

class Program
{
    static void Main(string[] args)
    {
        User spencer = new User();
        spencer.Menu();

        Console.WriteLine($"Hello {spencer.GetName()}, your amount of money is: {spencer.GetBankMoney()}");


        
    }
}