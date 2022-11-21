// See https://aka.ms/new-console-template for more information

using HeadFirst.Patterns;

RunPatterns();

Console.WriteLine("Press any key...");
Console.ReadKey();

void RunPatterns()
{
    var patterns = GetKnownPatterns().Reverse();
    foreach (var pattern in patterns)
    {
        Console.WriteLine($"=== {pattern.Name} ===");
        Console.WriteLine($"=== {pattern.Definition} ===");
        
        pattern.GetDesignPrinciples().ToList().ForEach(Console.WriteLine);
        pattern.GetQuizzes().ToList().ForEach(Console.WriteLine);
        
        pattern.Run();
        
        Console.WriteLine("----Separator-----");
    }
}

static IEnumerable<BasePattern> GetKnownPatterns()
{
    yield return new StrategyPattern();
    yield return new ObserverPattern();
    yield return new DecoratorPattern();
    yield return new FactoryPattern();
    yield return new SingletonPattern();
    yield return new CommandPattern();
    yield return new AdapterPattern();
    yield return new FacadePattern();
    yield return new TemplateMethodPattern();
    yield return new IteratorPattern();
}