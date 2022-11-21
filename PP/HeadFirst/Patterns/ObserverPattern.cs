namespace HeadFirst.Patterns;

public class ObserverPattern : BasePattern
{
    public override void Run()
    {
        var subject = new WeatherData();
        var conditionsDisplay = new CurrentConditionsDisplay();
        var forecastDisplay = new ForecastDisplay();

        subject.AddObserver(conditionsDisplay);
        subject.AddObserver(forecastDisplay);
        
        subject.SetMeasurements(10, 20, 30);
    }

    public override string Name => "Observer";
    public override string Definition { get; }
    
}

public interface ISubject
{
    void AddObserver(IObserver observer);
    void RemoveObserver(IObserver observer);

    void NotifyObservers();
}

public interface IObserver
{
    void Update(double temperature, double humidity, double pressure);
}

public interface IDisplay
{
    void Display();
}

public class WeatherData : ISubject
{
    private readonly List<IObserver> _observers = new();

    private double Temperature { get; set; }
    private double Humidity { get; set; }
    private double Pressure { get; set; }

    public void AddObserver(IObserver observer) => _observers.Add(observer);

    public void RemoveObserver(IObserver observer) => _observers.Remove(observer);

    public void NotifyObservers() => _observers.ForEach(observer => 
        observer.Update(Temperature, Humidity, Pressure));

    void MeasurementsChanged() => NotifyObservers();

    public void SetMeasurements(double temperature, double humidity, double pressure)
    {
        Temperature = temperature;
        Humidity = humidity;
        Pressure = pressure;
        
        MeasurementsChanged();
    }
}

public class CurrentConditionsDisplay : IObserver, IDisplay
{
    private double _temperature;
    private double _humidity;
    
    public void Update(double temperature, double humidity, double pressure)
    {
        _temperature = temperature;
        _humidity = humidity;
        
        Display();
    }

    public void Display()
    {
        Console.WriteLine($"Temp: {_temperature}, Humidity: {_humidity}");
    }
}

public class ForecastDisplay : IObserver, IDisplay
{
    private double _temperature;
    private double _humidity;
    
    public void Update(double temperature, double humidity, double pressure)
    {
        _temperature = temperature;
        _humidity = humidity;
        
        Display();
    }

    public void Display()
    {
        Console.WriteLine($"Temp: {_temperature}, Humidity: {_humidity}");
    }
}

