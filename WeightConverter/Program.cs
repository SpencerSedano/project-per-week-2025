namespace WeightConverter;

class Program {
    static void Main(string[] args) {
        Person spencer = new Person("Spencer", "Sedano", 87.5, 1.70);
        Person sherry = new Person("Sherry", "Wang", 61.1, 1.54);
        
        var spencerBmi = spencer.GetBmi();
        var sherryBmi = sherry.GetBmi();
        
        // Console.WriteLine($"Spencer's BMI {spencerBmi:F2}");
        // Console.WriteLine($"Sherry's BMI {sherryBmi:F2}");
        Console.WriteLine("Welcome to the BMI Calculator");
        Console.Write("Enter your name: ");
        var name = Console.ReadLine();
        Console.Write("Enter your last name: ");
        var lastName = Console.ReadLine();
        Console.Write("Enter your weight in kg: ");
        var weight = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter your height in meters: ");
        var height = Convert.ToDouble(Console.ReadLine());
        Person newPerson = new Person(name, lastName, weight, height);
        
        Console.Write($"Hello {name} {lastName}. ");
        Console.Write($"Your BMI is: {newPerson.GetBmi():F2}");

    }
}