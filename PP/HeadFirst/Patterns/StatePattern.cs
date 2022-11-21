namespace HeadFirst.Patterns;

public class StatePattern : BasePattern
{
    public override void Run()
    {
        var gumballMachine = new GumballMachine(10);
        gumballMachine.InsertQuarter();
        gumballMachine.TurnCrank();
        gumballMachine.Dispense();

        Console.WriteLine(gumballMachine.ToString());
    }

    public override string Name => "State";
    public override string Definition { get; }
}

public class GumballMachine : BaseState
{
    private readonly BaseState _hasQuarterState;
    private readonly BaseState _noQuarterState;
    private readonly BaseState _soldState;
    private readonly BaseState _soldOutState;

    private BaseState _currentState;
    
    public int Count { get; private set; }

    public GumballMachine(int numberOfGumballs)
    {
        _noQuarterState = new NoQuarterState(this);
        _hasQuarterState = new HasQuarterState(this);
        _soldState = new SoldState(this);
        _soldOutState = new SoldOutState(this);

        Count = numberOfGumballs;
        if (Count > 0)
        {
            _currentState = _noQuarterState;
        }
    }

    public void SetState(BaseState state)
    {
        _currentState = state;
    }

    public BaseState GetHasQuarterState()
    {
        return _hasQuarterState;
    }

    public BaseState GetNoQuarterState()
    {
        return _noQuarterState;
    }
    
     public BaseState GetGumballSoldState()
    {
        return _soldState;
    }

    public BaseState GetGumballSoldOutState()
    {
        return _soldOutState;
    }

    public void InsertQuarter()
    {
        _currentState.InsertQuarter();
    }

    public void EjectQuarter()
    {
        _currentState.EjectQuarter();
    }

    public void TurnCrank()
    {
        _currentState.TurnCrank();
    }

    public void Dispense()
    {
        _currentState.Dispense();
    }

    public void ReleaseBall()
    {
        if (_currentState == _soldState)
        {
            Count--;
        }
    }

    public override string ToString()
    {
        return $"{Count}, {_currentState}";
    }
}

public class BaseState
{
    protected GumballMachine Machine { get; }
    
    protected string Name { get; }

    protected BaseState(GumballMachine machine, string name)
    {
        Machine = machine;
        Name = name;
    }
    
    protected BaseState() {}

    public virtual void InsertQuarter()
    {
        Console.WriteLine("InsertQuarter");
    }

    public virtual void EjectQuarter()
    {
        Console.WriteLine("EjectQuarter");
    }

    public virtual void TurnCrank()
    {
        Console.WriteLine("TurnCrank");
    }

    public virtual void Dispense()
    {
        Console.WriteLine("Dispense");
    }
}

public class NoQuarterState : BaseState
{
    public NoQuarterState(GumballMachine machine) : base(machine, "NoQuarter")
    {
    }

    public override void InsertQuarter()
    {
        base.InsertQuarter();
        Machine.SetState(Machine.GetHasQuarterState());
    }
}

public class HasQuarterState : BaseState
{
    public HasQuarterState(GumballMachine machine) : base(machine, "HasQuarter")
    {
    }

    public override void EjectQuarter()
    {
        base.EjectQuarter();
        Machine.SetState(Machine.GetNoQuarterState());
    }

    public override void TurnCrank()
    {
        base.TurnCrank();
        Machine.SetState(Machine.GetGumballSoldState());
    }
}

public class SoldOutState : BaseState
{
    public SoldOutState(GumballMachine machine) : base(machine, "SoldOut")
    {
    }
}

public class SoldState : BaseState
{
    public SoldState(GumballMachine machine) : base(machine, "Sold")
    {
    }

    public override void Dispense()
    {
        base.Dispense();
        
        Machine.ReleaseBall();
        Machine.SetState(Machine.Count > 0 ? Machine.GetNoQuarterState() : Machine.GetGumballSoldOutState());
    }
}