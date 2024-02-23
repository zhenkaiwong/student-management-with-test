using System.Dynamic;
using StudentManagement.Kernel.Models;
using StudentManagement.Kernel.Services.DataProvider;
using Xunit;

namespace StudentManagement.Test.StudentManagement.Kernel.Test.Services;

public class StudentProviderTest
{
    MockStudentProvider? _studentProvider = null;

    public StudentProviderTest()
    {
        _studentProvider = (MockStudentProvider)MockStudentProvider.CreateMockInstance();
    }

    [Fact]
    public void DeleteStudent_StudentExist_ReturnTrue()
    {
        var student = new Student()
        {
            StudentId = "TestStudentID",
            Name = "Test student",
            Class = "Test calss"
        };

        _studentProvider.AddMockStudent(student);

        var result = _studentProvider.DeleteStudent(student.StudentId);

        Assert.True(result);
    }

    [Fact]
    public void DeleteStudent_StudentNotExist_ReturnFalse()
    {
        var result = _studentProvider.DeleteStudent("Fake student ID");

        Assert.False(result);
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

        public void AddMockStudent(Student student)
        {
            _entries.Add(student.StudentId, student);
        }

        public static MockStudentProvider CreateMockInstance()
        {
            return new MockStudentProvider();
        }
    }
}
