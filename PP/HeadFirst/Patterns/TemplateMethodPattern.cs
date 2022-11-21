namespace HeadFirst.Patterns;

public class TemplateMethodPattern : BasePattern
{
    public override void Run()
    {
        var coffee = new Coffee();
        coffee.PrepareRecipe();

        var tea = new Tea();
        tea.PrepareRecipe();
    }

    public override string Name => "TemplateMethod";
    public override string Definition { get; }
}

public abstract class CaffeineBeverage
{
    public void PrepareRecipe()
    {
        BoilWater();
        Brew();
        PourInCup();
    }

    void BoilWater() => Console.WriteLine("Boiling water");
    
    protected abstract void Brew();

    void PourInCup() => Console.WriteLine("Pouring in cup");
}

class Tea : CaffeineBeverage
{
    protected override void Brew() => Console.WriteLine("Brewing the tea");
}

class Coffee : CaffeineBeverage
{
    protected override void Brew() => Console.WriteLine("Brewing the coffee");
}