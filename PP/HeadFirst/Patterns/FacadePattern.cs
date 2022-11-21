namespace HeadFirst.Patterns;

public class FacadePattern : BasePattern
{
    public override void Run()
    {
        var homeTheater = new HomeTheater();
        
        homeTheater.WatchMovie();
        homeTheater.EndMovie();
    }

    public override string Name => "Facade";
    public override string Definition { get; }
}

public class HomeTheater
{
    private readonly SoundPlayer _soundPlayer = new();
    private readonly Display _display = new();
    private readonly Lights _lights = new();

    public void WatchMovie()
    {
        Console.WriteLine("Starting to watch movie");
        _soundPlayer.TurnOn();
        _display.Up();
        _lights.On();
    }

    public void EndMovie()
    {
        Console.WriteLine("Ending to watch movie");
        _soundPlayer.TurnOff();
        _display.Down();
        _lights.Off();
    }
}

public class SoundPlayer
{
    public void TurnOn() => Console.WriteLine("SoundPlayer on");
    public void TurnOff() => Console.WriteLine("SoundPlayer off");
}

public class Display
{
    public void Up() => Console.WriteLine("Display up");
    public void Down() => Console.WriteLine("Display down");
}

public class Lights
{
    public void On() => Console.WriteLine("Lights on");
    public void Off() => Console.WriteLine("Lights off");
}