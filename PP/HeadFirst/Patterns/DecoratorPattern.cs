namespace HeadFirst.Patterns;

public class DecoratorPattern : BasePattern
{
    public override void Run()
    {
        var beverage = new Espresso();
        Console.WriteLine(beverage.Description, beverage.Cost());

        var mocha = new Mocha(beverage);
        Console.WriteLine(mocha.Description, mocha.Cost());

        var streamReader = new StreamReader(new MemoryStream());
    }

    public override string Name => "Decorator";
    public override string Definition { get; }
    
    public override IEnumerable<string> GetDesignPrinciples()
    {
        yield return "Classes should be open for extension, but closed for modification";
    }

}

public abstract class Beverage
{
    public string Description { get; protected init; } = "Unknown beverage";

    public abstract double Cost();
}

public abstract class CondimentDecorator : Beverage
{
}

public class Espresso : Beverage
{
    public Espresso()
    {
        Description = "Espresso";
    }
    
    public override double Cost()
    {
        return 1.99;
    }
}

public class Mocha : CondimentDecorator
{
    private readonly Beverage _beverage;

    public Mocha(Beverage beverage)
    {
        _beverage = beverage;
        Description = _beverage.Description + ", Mocha";
    }
    
    public override double Cost()
    {
        return .20 + _beverage.Cost();
    }
}