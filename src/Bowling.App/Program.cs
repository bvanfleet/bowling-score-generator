using Bowling.App;
using Bowling.App.Extensions;
using Newtonsoft.Json;

static async Task<string?> ReadFileAsync(string[] args)
{
    if (args.Length > 0)
    {
        string filename = args.First();
        using Stream stream = File.OpenRead(filename);
        using TextReader reader = new StreamReader(stream);

        return await reader.ReadToEndAsync();
    }

    return default;
}

string data = string.Empty;
try
{
    data = (await ReadFileAsync(args)).NotNullOrEmpty("Score file cannot be empty");
}
catch (ArgumentNullException exception)
{
    Console.Error.WriteLine(exception.Message);
    return;
}

Frame[] frames = JsonConvert.DeserializeObject<Frame[]>(data)!;
var parser = new ScoreParser();

try
{
    var frameIds = string.Join("\t ", frames.Select(f => f.Id));
    var frameInput = string.Join(" ", frames.Select(f => f.ToString()));
    var frameScores = string.Join("\t ", parser.ParseScores(frames));

    Console.WriteLine(frameIds);
    Console.WriteLine(frameInput);
    Console.WriteLine(frameScores);
}
catch (ArgumentNullException exception)
{
    Console.Error.WriteLine(exception.Message);
}
