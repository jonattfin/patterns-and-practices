namespace HeadFirst.Patterns;

public class SingletonPattern : BasePattern
{
    public override void Run()
    {
        var singleton = Singleton.Instance;
        singleton.Work();
    }

    public override string Name => "Singleton";
    public override string Definition { get; }
}

public class Singleton
{
    private static readonly Lazy<Singleton> _Lazy = new(() => new Singleton());
    
    private Singleton() {}

    public static Singleton Instance { get; } = _Lazy.Value;

    public void Work() => Console.WriteLine("Working...");
}