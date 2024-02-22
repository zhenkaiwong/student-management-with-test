using StudentManagement.Kernel.Models;

namespace StudentManagement.Kernel.Services.DataProvider;

public class StudentProvider : IDataProvider
{
    protected Dictionary<string, Student> _entries = new();
    private static IDataProvider? _provider = null;
    protected StudentProvider()
    {

    }

    public static IDataProvider CreateInstance()
    {
        if (_provider is null)
        {
            _provider = new StudentProvider();
        }

        return _provider;
    }

    public bool DeleteStudent(string studentId)
    {
        throw new NotImplementedException();
    }

    public List<Student> GetAllStudents()
    {
        throw new NotImplementedException();
    }

    public Student GetStudent(string studentId)
    {
        throw new NotImplementedException();
    }

    public bool UpsertStudent(Student student)
    {
        throw new NotImplementedException();
    }
}
