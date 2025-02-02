ProcessAll(["Spencer", "John", "Sherry", "Inigo"]);

List<string> ProcessAll(List<string> words)
{
    var stringsProcessors = new List<StringsProcessor>
    {
        new StringsTrimmingProcessor(),
        new StringsUppercaseProcessor()
    };
    
    List<string> result = words;
    foreach (var stringsProcessor in stringsProcessors)
    {
        result = stringsProcessor.Process(result);
    }

    foreach (var i in result)
    {
        Console.WriteLine(i);
    }
    
    return result;
}

public class StringsProcessor
{
    public virtual List<string> Process(List<string> result)
    {
        return result;
    }
}
public class StringsTrimmingProcessor : StringsProcessor
{
    public override List<string> Process(List<string> input)
    {
        var result = new List<string>();
        foreach(string trimmedString in input)
        {
            int stringLength = trimmedString.Length / 2;
            var resultString = trimmedString.Substring(0, stringLength);
            result.Add(resultString);
        }
        return result;
    }
}
public class StringsUppercaseProcessor : StringsProcessor
{
    public override List<string> Process(List<string> input)
    {
        var result = new List<string>();
        
        foreach(string upperString in input)
        {
            result.Add(upperString.ToUpper());
        }
        return result;
    }
}