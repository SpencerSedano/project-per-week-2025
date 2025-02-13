using System.Text;
using System.Text.Json;

class CcCedictParser
{
    // Initialize List of Dictionaries
    private static readonly List<Dictionary<string, object>> ListOfDicts = [];

    static void Main()
    {
        string filePath = @"/Users/spencersedano/Desktop/2025 Coding Resolution/CcCedictParser/dictionary/cedict_ts.u8";
        
        string outputJsonPath = @"/Users/spencersedano/Desktop/2025 Coding Resolution/CcCedictParser/dictionary/cedict.json";

        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not found: " + filePath);
            return;
        }

        Console.WriteLine("Parsing dictionary . . .");
        string[] lines = File.ReadAllLines(filePath);
        
        foreach (string line in lines)
        {
            ParseLine(line);
        }

        Console.WriteLine("Saving as JSON . . .");
        SaveAsJson(outputJsonPath);

        Console.WriteLine("Done!");
    }

    static void ParseLine(string line)
    {
        if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#"))
            return;

        line = line.TrimEnd('/');
        string[] parts = line.Split('/');
        if (parts.Length < 2)
            return;

        string[] charAndPinyin = parts[0].Split('[');
        if (charAndPinyin.Length < 2)
            return;

        string[] characters = charAndPinyin[0].Trim().Split(' ');
        if (characters.Length < 2)
            return;

        string traditional = characters[0];
        string simplified = characters[1];
        string pinyin = charAndPinyin[1].Trim().TrimEnd(']');
        
        var entry = new Dictionary<string, object>
        {
            {"traditional", traditional},
            {"simplified", simplified},
            {"pinyin", pinyin},
            {"english", parts.Length > 2 ? parts.Skip(1).Take(parts.Length - 1).ToList() : parts[1]}
        };

        ListOfDicts.Add(entry);
    }

    static void SaveAsJson(string outputPath)
    {
        var options = new JsonSerializerOptions 
        { 
            WriteIndented = true, 
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping 
        };

        string json = JsonSerializer.Serialize(ListOfDicts, options);

        // Ensure UTF-8 encoding
        File.WriteAllText(outputPath, json, Encoding.UTF8);

        Console.WriteLine($"JSON saved to {outputPath}");
    }
}
