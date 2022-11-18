// See https://aka.ms/new-console-template for more information

using HeadFirst.Patterns;

RunPatterns();

Console.WriteLine("Press any key...");
Console.ReadKey();

void RunPatterns()
{
    var patterns = GetKnownPatterns();
    foreach (var pattern in patterns)
    {
        Console.WriteLine($"=== {pattern.Definition} ===");
        pattern.Run();
    }
}

static IEnumerable<IPattern> GetKnownPatterns()
{
    yield return new StrategyPattern();
}