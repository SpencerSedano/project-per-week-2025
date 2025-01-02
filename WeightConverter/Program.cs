namespace WeightConverter;

class Program {
    static void Main(string[] args) {
        Person spencer = new Person("Spencer", "Sedano", 87.5, 1.70);
        Person sherry = new Person("Sherry", "Wang", 61.1, 1.54);
        
        var spencerBmi = spencer.GetBmi();
        var sherryBmi = sherry.GetBmi();
        Console.WriteLine($"Spencer's BMI {spencerBmi:F2}");
        Console.WriteLine($"Sherry's BMI {sherryBmi:F2}");
        Console.Write("");
        Console.WriteLine("Welcome to the BMI Calculator");
        Console.WriteLine("Enter your name: ");
        var name = Console.ReadLine();
        Console.WriteLine("Enter your last name: ");
        var lastName = Console.ReadLine();
        Console.WriteLine("Enter your weight in kg: ");
        var weight = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter your height in meters: ");
        var height = Convert.ToDouble(Console.ReadLine());
        Person newPerson = new Person(name, lastName, weight, height);
        
        Console.WriteLine($"Your BMI is: {newPerson.GetBmi():F2}");

    }
}