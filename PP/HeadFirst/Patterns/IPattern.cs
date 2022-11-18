namespace HeadFirst.Patterns;

public interface IPattern
{
    void Run();
    
    string Name { get; }
    string Definition { get; }
    
    IEnumerable<string> GetDesignPrinciples();
    IEnumerable<Quiz> GetQuizzes();
}