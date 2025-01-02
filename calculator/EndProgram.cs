namespace calculator;

public static class EndProgram {

    public static void End() {
        Console.WriteLine("Do you want to exit? (y/n)");
        var userInput = Console.ReadLine();

        while (userInput?.ToLower() == "y") {
            StartProgram.Start();
            Operation.Start();
            End();
        }
        
        Environment.Exit(0);
    }
    
}