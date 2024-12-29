namespace WeightConverter;

public class Person {
    private int Id { get; set; }
    private string Name { get; set; }
    private string LastName { get; set; }
    private double Weight { get; set; }
    private double Height { get; set; }

    public Person(string name, string lastName, double weight, double height) {
        this.Name = name;
        this.LastName = lastName;
        this.Weight = weight;
        this.Height = height;
    }

    public double GetBmi() {
        //Weight / Height. Ex: 87.5 / 1.70
        double bmi = (Weight / Height) / Height;
        return bmi;
    }
}