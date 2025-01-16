namespace Guys;

public class Guy
{
    public string? Name;
    public int Cash;

    public void WriteMyInfo()
    {
        Console.WriteLine($"{Name} has {Cash} cash");
    }

    public int GiveCash(int amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Not a valid amount");
            return 0;
        }

        if (amount > Cash)
        {
            Console.WriteLine("Not enough cash");
            return 0;
        }
        Cash -= amount;
        return amount;
    }
    
    public void ReceiveCash(int amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine($"{Name} says: {amount} isn't an amount I'll take");
        }
        else
        {
            Cash += amount;
        }
    }
}