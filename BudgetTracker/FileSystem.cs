namespace BudgetTracker;

public static class FileSystem
{
    public static void SavingFile(string? name, double? bankMoney)
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
                writer.WriteLine($"{name}: {bankMoney}\n");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}