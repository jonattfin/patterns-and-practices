namespace HeadFirst.Patterns;

public class StrategyPattern : BasePattern
{
    public override void Run()
    {
        var duck = new MallardDuck();
        duck.Display();
        duck.PerformFly();
        duck.PerformQuack();
    }

    public override string Name => "Strategy";

    public override string Definition =>
        $"The {Name} pattern defines a family of algorithms, encapsulates each one, and makes them interchangeable.";

    public override IEnumerable<string> GetDesignPrinciples()
    {
        yield return "Identify the aspects of your application that vary and separate them from what stays the same";
        yield return "Program to an interface, not an implementation";
        yield return "Favor composition over inheritance";
    }

    public override IEnumerable<Quiz> GetQuizzes()
    {
        yield return new Quiz()
        {
            Topic = "Which of the following are disadvantages of using inheritance to provide Duck behavior?",
            Questions = new List<string>()
            {
                "Code is duplicated across subclasses",
                "Runtime behavior changes are difficult",
                "We can't make ducks dance",
                "Hard to gain knowledge of all duck behaviors",
                "Ducks can't fly and quack at the same time",
                "Changes can unintentionally affect other ducks"
            },
            Answers = new[] { 0, 1, 3, 5 }.Select(x => x.ToString()).ToList(),
            Page = 5
        };

        yield return new Quiz()
        {
            Topic = "Lots of things can drive change. List some reasons you've had to change code in your application",
            Answers = new List<string>()
            {
                "New features",
                "Bug fixes",
                "Performance improvements",
                "Refactoring code"
            },
            Page = 8
        };
    }
}

public abstract class Duck : IFlyable, IQuackable
{
    protected IFlyBehavior FlyBehavior { get; init; }
    protected IQuackBehavior QuackBehavior { get; init; }

    public void PerformFly() => FlyBehavior.Fly();
    public void PerformQuack() => QuackBehavior.Quack();

    public void Swim() => Console.WriteLine("Swimming");

    public abstract void Display();
}

public interface IFlyable
{
    void PerformFly();
}

public interface IQuackable
{
    void PerformQuack();
}

public class MallardDuck : Duck
{
    public MallardDuck()
    {
        FlyBehavior = new FlyWithWings();
        QuackBehavior = new QuackBehavior();
    }

    public override void Display() => Console.WriteLine("I'm a mallard duck!");
}

public class RedheadDuck : Duck
{
    public override void Display() => Console.WriteLine("I'm a redhead duck!");
}

public class DecoyDuck : Duck
{
    public override void Display() => Console.WriteLine("I'm a decoy duck!");
}

public interface IFlyBehavior
{
    void Fly();
}

public interface IQuackBehavior
{
    void Quack();
}

public class FlyWithWings : IFlyBehavior
{
    public void Fly() => Console.WriteLine("I'm flying!");
}

public class FlyNoWay : IFlyBehavior
{
    public void Fly() => Console.WriteLine("I'm not flying!");
}

public class QuackBehavior : IQuackBehavior
{
    public void Quack() => Console.WriteLine("I'm quacking!");
}

public class DuckCall : IQuackable
{
    private readonly IQuackBehavior _quackBehavior;

    public DuckCall() => _quackBehavior = new QuackBehavior();

    public void PerformQuack() => _quackBehavior.Quack();
}