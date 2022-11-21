namespace HeadFirst.Patterns;

public class IteratorPattern : BasePattern
{
    public override void Run()
    {
        var waitress = new Waitress(new IMenuIterator[] { new PancakeHouseMenu(), new DinnerMenu() });
        waitress.PrintMenu();
    }

    public override string Name => "Iterator";
    public override string Definition { get; }
}

public class Waitress
{
    private readonly IMenuIterator[] _menus;

    public Waitress(IMenuIterator[] menus)
    {
        _menus = menus;
    }

    public void PrintMenu()
    {
        foreach (var menu in _menus)
        {
            PrintMenu(menu.CreateIterator());
        }
    }

    private static void PrintMenu(ICustomIterator iterator)
    {
        while (iterator.HasNext())
        {
            Console.WriteLine(iterator.Next());
        }
    }
}

public class MenuItem
{
    public string Name { get; set; }

    public override string ToString()
    {
        return $"{Name}";
    }
}

public class PancakeHouseMenu : IMenuIterator
{
    private readonly List<MenuItem> _menuItems = new();

    public PancakeHouseMenu()
    {
        _menuItems.Add(new MenuItem() { Name = "Pancakes with fried eggs" });
        _menuItems.Add(new MenuItem() { Name = "Pancakes with fresh blueberries" });
    }

    private void AddItem(MenuItem menuItem)
    {
        _menuItems.Add(menuItem);
    }

    public ICustomIterator CreateIterator()
    {
        return new PancakeHouseMenuIterator(_menuItems);
    }
}

public class PancakeHouseMenuIterator : ICustomIterator
{
    private readonly List<MenuItem> _menuItems;
    private int _index = 0;

    public PancakeHouseMenuIterator(List<MenuItem> menuItems)
    {
        _menuItems = menuItems;
    }

    public bool HasNext()
    {
        return _index < _menuItems.Count;
    }

    public MenuItem Next()
    {
        return _menuItems[_index++];
    }
}

public class DinnerMenu : IMenuIterator
{
    private readonly MenuItem[] _menuItems = new MenuItem[2];
    private int _index = 0;

    public DinnerMenu()
    {
        _menuItems[0] = new MenuItem() { Name = "Vegetarian BLT" };
        _menuItems[1] = new MenuItem() { Name = "Hot dog with sauerkraut, relish, onions" };
    }

    private void AddItem(MenuItem menuItem)
    {
        _menuItems[_index++] = menuItem;
    }

    public ICustomIterator CreateIterator()
    {
        return new DinnerMenuIterator(_menuItems);
    }
}

public class DinnerMenuIterator : ICustomIterator
{
    private readonly MenuItem[] _menuItems;
    private int _index;

    public DinnerMenuIterator(MenuItem[] menuItems)
    {
        _menuItems = menuItems;
    }

    public bool HasNext()
    {
        return _index < _menuItems.Length;
    }

    public MenuItem Next()
    {
        return _menuItems[_index++];
    }
}

public interface ICustomIterator
{
    bool HasNext();
    MenuItem Next();
}

public interface IMenuIterator
{
    ICustomIterator CreateIterator();
}