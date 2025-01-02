namespace calculator;

public static class Operation {
    public static void Start() {
        var operation = Console.ReadLine()?.ToLower();
        Console.Write("Choose your first number: ");
        var firstNumber = Convert.ToDouble(Console.ReadLine());
        Console.Write("Choose your second number: ");
        var secondNumber = Convert.ToDouble(Console.ReadLine());

        switch (operation) {
            case "1":
            case "addition":
                Console.Write("Your answer is: ");
                Addition.SumMethod(firstNumber, secondNumber);
                break;
            case "2":
            case "subtraction":
                Console.Write("Your answer is: ");
                Subtraction.Subtract(firstNumber, secondNumber);
                break;
            case "3":
            case "multiplication":
                Console.Write("Your answer is: ");
                Multiplication.Multiply(firstNumber, secondNumber);
                break;
            case "4":
            case "division":
                Console.Write("Your answer is: ");
                Division.Divide(firstNumber, secondNumber);
                break;
            default:
                Console.WriteLine("Invalid Operation");
                break;
        }
    }

    //49-52, it's 1-4
    public static void GetAscii(char character) {
        if(character >= 49 && character <= 52) { 
            Console.WriteLine($"You chose {character - '0'}");
        }
        else {
            Console.WriteLine("Choose a number between 1 and 4");
        }
    }   
}