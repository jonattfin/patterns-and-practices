using System.Text;

namespace HeadFirst;

public class Quiz
{
    public string Topic { get; set; }
    
    public int Page { get; set; }

    public List<string> Questions { get; set; } = new();
    public List<string> Answers { get; set; } = new();

    public override string ToString()
    {
        var stringBuilder = new StringBuilder();

        stringBuilder.Append($"{Topic}, {Page}");
        stringBuilder.Append(string.Join(',', Questions));
        stringBuilder.Append(string.Join(',', Answers));

        return stringBuilder.ToString();
    }
}