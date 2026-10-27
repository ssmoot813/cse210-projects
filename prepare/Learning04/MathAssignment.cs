public class MathAssignment : Assignment
{
    private string _textbookSection;
    private string _problems;

    // Name and topic are passed up to the base class constructor
    public MathAssignment(string studentName, string topic, string textbookSection, string problems)
        : base(studentName, topic)
    {
        _textbookSection = textbookSection;
        _problems = problems;
    }

    public string GetHomeworkList()
    {
        return $"Section {_textbookSection} Problems {_problems}";
    }
}