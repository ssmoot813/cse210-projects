public class Assignment
{
    private string _studentName;
    private string _topic;

    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }

    // Getter so derived classes can read the name without making it protected
    public string GetStudentName()
    {
        return _studentName;
    }

    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }
}