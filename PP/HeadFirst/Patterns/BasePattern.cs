namespace HeadFirst.Patterns;

public abstract class BasePattern
{
    public virtual void Run() {}

    public virtual IEnumerable<string> GetDesignPrinciples()
    {
        return Enumerable.Empty<string>();
    }

    public virtual IEnumerable<Quiz> GetQuizzes()
    {
        return Enumerable.Empty<Quiz>();
    }
    
    public abstract string Name { get; }
    public abstract string Definition { get; }
}