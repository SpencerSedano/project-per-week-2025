namespace WeightConverter;

class Program {
    static void Main(string[] args) {
        Person spencer = new Person("Spencer", "Sedano", 87.5, 1.70);
        Person sherry = new Person("Sherry", "Wang", 61.1, 1.54);
        
        var spencerBmi = spencer.GetBmi();
        var sherryBmi = sherry.GetBmi();
        
        // Console.WriteLine($"Spencer's BMI {spencerBmi:F2}");
        // Console.WriteLine($"Sherry's BMI {sherryBmi:F2}");

        //Starting Program
        StartProgram.AskInfo();
        
        //Result
        StartProgram.Result();
        
    }
}