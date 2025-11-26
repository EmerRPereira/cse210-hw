public class Assignment
{
    private string _studentName;
    private string _topic;

    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }

    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }

    // Getter opcional para acessar o nome do estudante na classe WritingAssignment
    public string GetStudentName()
    {
        return _studentName;
    }
}
