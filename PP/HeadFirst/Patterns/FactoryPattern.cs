namespace HeadFirst.Patterns;

public class FactoryPattern : BasePattern
{
    public override void Run()
    {
        var newYorkStore = new NYStore();
        newYorkStore.OrderPizza(PizzaType.QuattroFormagi);

        var chicagoStore = new ChicagoStore();
        chicagoStore.OrderPizza(PizzaType.Cipola);
    }

    public override string Name => "Factory";
    
    public override string Definition { get; }
}

public abstract class Store
{
    protected readonly IPizzaFactory PizzaFactory;

    protected Store(IPizzaFactory pizzaFactory)
    {
        PizzaFactory = pizzaFactory;
    }
    
    public IPizza OrderPizza(PizzaType type)
    {
        var pizza = CreatePizza(type);
        
        pizza.Prepare();
        pizza.Bake();
        pizza.Cut();
        pizza.Box();

        return pizza;
    }

    protected abstract IPizza CreatePizza(PizzaType type);
}

public class NYStore : Store
{
    public NYStore() : base(new NYPizzaFactory())
    {
    }

    protected override IPizza CreatePizza(PizzaType type)
    {
        return PizzaFactory.CreatePizza(type);
    }
}

public class ChicagoStore : Store
{
    public ChicagoStore() : base(new ChicagoPizzaFactory())
    {
    }

    protected override IPizza CreatePizza(PizzaType type)
    {
        return PizzaFactory.CreatePizza(type);
    }
}

public interface IPizza
{
    public void Prepare() {}
    public void Bake() {}
    public void Cut() {}
    public void Box() {}
}

public enum PizzaType
{
    Cipola,
    QuattroFormagi
}

public class NYPizza : IPizza
{
    public void Prepare() => Console.WriteLine("Prepare NY");

    public void Bake() => Console.WriteLine("Bake NY");

    public void Cut() => Console.WriteLine("Cut NY");
}

public class ChicagoPizza : IPizza
{
    public void Prepare() => Console.WriteLine("Prepare Chicago");

    public void Bake() => Console.WriteLine("Bake Chicago");

    public void Cut() => Console.WriteLine("Cut Chicago");
}

public interface IPizzaFactory
{
    IPizza CreatePizza(PizzaType type);
}

public class NYPizzaFactory : IPizzaFactory
{
    public IPizza CreatePizza(PizzaType type)
    {
        return new NYPizza();
    }
}

public class ChicagoPizzaFactory : IPizzaFactory
{
    public IPizza CreatePizza(PizzaType type)
    {
        return new ChicagoPizza();
    }
}

