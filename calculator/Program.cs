// Calculator Functions
// Addition
// Subtraction
// Multiplication
// Division

using calculator;

StartProgram.Start();

var operation = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("Choose your first number: ");
var firstNumber = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("Choose your second number: ");
var secondNumber = Convert.ToDouble(Console.ReadLine());

switch (operation)
{
    case 1:
        Console.Write("Your answer is: ");
        Addition.SumMethod(firstNumber, secondNumber);
        break;
    case 2:
        Console.Write("Your answer is: ");
        Subtraction.Subtract(firstNumber, secondNumber);
        break;
    case 3:
        Console.Write("Your answer is: ");
        Multiplication.Multiply(firstNumber, secondNumber);
        break;
    case 4:
        Console.Write("Your answer is: ");
        Division.Divide(firstNumber, secondNumber);
        break;
    default:
        Console.WriteLine("Invalid Operation");
        break;
}