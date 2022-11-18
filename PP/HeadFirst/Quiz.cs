namespace HeadFirst;

public class Quiz
{
    public string Topic { get; set; }
    
    public int Page { get; set; }
    
    public List<string> Questions { get; set; }
    public List<string> Answers { get; set; }
}