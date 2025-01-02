namespace BudgetTracker;

using System.IO;
public class User { 
    private string Name { get; set; }
    private double BankMoney { get; set; }

    public User(string name, double bankMoney) {
        this.Name = name;
        this.BankMoney = bankMoney;
    }

    public string GetName() => Name;
    public double GetBankMoney() => BankMoney;

    public void SavingFile() {
        string folder = @"/Users/spencersedano/Desktop/2025 Coding Resolution/BudgetTracker/savedFiles/";
        var userFileName = Console.ReadLine();
        string? fileName = userFileName;
        string fullPath = folder + fileName;

        try {
            using (StreamWriter writer = new StreamWriter(fullPath, true)) {
                writer.WriteLine($"{GetName()}: {GetBankMoney()}\n");
            }
        }
        catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
        
        
    }
}