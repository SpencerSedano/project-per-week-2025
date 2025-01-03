﻿namespace BudgetTracker;

using System.IO;

//Requirements:
// 0. Have a starting amount of money
// 1. Input Savings
// 2. Input Expenses
// Be able to save it in a .txt file

class Program {
    static void Main(string[] args) {
        Console.WriteLine("What is your name? ");
        var name = Console.ReadLine();
        Console.WriteLine("Write the starting amount of money: ");
        var startAmount = Convert.ToDouble(Console.ReadLine());
        
        User spencer = new User(name, startAmount);
        
        Console.WriteLine($"Hello {spencer.GetName()}, your amount of money is: {spencer.GetBankMoney()}");
        
        
        Console.WriteLine("Save File? Yes/No");
        var answer = Console.ReadLine();
        if (answer?.ToUpper() == "YES") {
            spencer.SavingFile();
        }
        if (answer?.ToUpper() == "NO") {
            return;
        }

    }
}
