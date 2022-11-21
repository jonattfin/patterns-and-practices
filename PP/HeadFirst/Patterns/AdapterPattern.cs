namespace HeadFirst.Patterns;

public class AdapterPattern : BasePattern
{
    public override void Run()
    {
        var turkey = new WildTurkey();
        var turkeyAdapter = new TurkeyAdapter(turkey);
        
        TestTurkey(turkey);
        TestDuck(turkeyAdapter);
        
        var duck = new SpecialMallardDuck();
        var duckAdapter = new DuckAdapter(duck);
        
        TestDuck(duck);
        TestTurkey(duckAdapter);
    }

    private void TestTurkey(Turkey turkey)
    {
        turkey.Gobble();
        turkey.Fly();
    }
    
    private void TestDuck(SpecialDuck duck)
    {
        duck.Quack();
        duck.Fly();
    }

    public override string Name => "Adapter";
    public override string Definition { get; }
}

public class DuckAdapter : Turkey
{
    private readonly SpecialDuck _duck;

    public DuckAdapter(SpecialDuck duck)
    {
        _duck = duck;
    }

    public void Gobble()
    {
        _duck.Quack();
    }

    public void Fly()
    {
        _duck.Fly();
    }
}

public interface SpecialDuck
{
    public void Quack();
    public void Fly();
}

public class SpecialMallardDuck : SpecialDuck
{
    public void Quack()
    {
        Console.WriteLine("Quack");
    }

    public void Fly()
    {
        Console.WriteLine("Fly");
    }
}

public interface Turkey
{
    public void Gobble();
    public void Fly();
}

public class WildTurkey : Turkey
{
    public void Gobble()
    {
        Console.WriteLine("Gobble");
    }

    public void Fly()
    {
        Console.WriteLine("Fly");
    }
}

public class TurkeyAdapter : SpecialDuck
{
    private readonly Turkey _turkey;

    public TurkeyAdapter(Turkey turkey)
    {
        _turkey = turkey;
    }
    
    public void Quack()
    {
        _turkey.Gobble();
    }

    public void Fly()
    {
        _turkey.Fly();
    }
}