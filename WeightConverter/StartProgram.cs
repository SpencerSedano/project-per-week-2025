namespace WeightConverter;

public static class StartProgram
{
    private static string name;
    private static string lastName;
    private static double weight;
    private static double height;
    public static void AskInfo()
    {
        Console.WriteLine("Welcome to the BMI Calculator");
        Console.Write("Enter your name: ");
        name = Console.ReadLine();
        Console.Write("Enter your last name: ");
        lastName = Console.ReadLine();
        Console.Write("Enter your weight in kg: ");
        weight = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter your height in meters: ");
        height = Convert.ToDouble(Console.ReadLine());
    }

    public static void Result()
    {
        Person newPerson = new Person(name, lastName, weight, height);
        Console.Write($"Hello {name} {lastName}. ");
        Console.Write($"Your BMI is: {newPerson.GetBmi():F2}");
    }
}