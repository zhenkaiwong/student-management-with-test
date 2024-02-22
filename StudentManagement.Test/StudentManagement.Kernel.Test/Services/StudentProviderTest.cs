using StudentManagement.Kernel.Models;
using StudentManagement.Kernel.Services.DataProvider;
using Xunit;

namespace StudentManagement.Test.StudentManagement.Kernel.Test.Services;

public class StudentProviderTest
{
    IDataProvider? _studentProvider = null;

    public StudentProviderTest()
    {
        _studentProvider = MockStudentProvider.CreateInstance();
    }

    [Fact]
    public void DeleteStudent_StudentExist_ReturnTrue()
    {

    }

    [Fact]
    public void DeleteStudent_StudentNotExist_ReturnFalse()
    {

    }

    protected class MockStudentProvider : StudentProvider
    {
        protected MockStudentProvider() : base()
        {
            // insert dummy data
            for (int count = 1; count <= 10; count++)
            {
                var student = new Student()
                {
                    StudentId = $"STUD{count + 1000}",
                    Name = $"Student {count}",
                    Class = $"Class A"
                };

                _entries.Add(student.StudentId, student);
            }
        }
    }
}
