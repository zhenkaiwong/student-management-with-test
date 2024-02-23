using StudentManagement.Kernel.Models;
using StudentManagement.Kernel.Services.DataProvider;
using Xunit;

namespace StudentManagement.Test.StudentManagement.Kernel.Test.Services;

public class StudentProviderTest
{
    MockStudentProvider? _studentProvider = null;

    public StudentProviderTest()
    {
        _studentProvider = MockStudentProvider.CreateInstance();
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

    [Fact]
    public void GetAllStudents_WithData_AnyReturnTrue()
    {
        _studentProvider.SeedData();
        var result = _studentProvider.GetAllStudents();

        Assert.True(result.Any());
    }

    [Fact]
    public void GetAllStudents_WithoutData_AnyReturnFalse()
    {
        _studentProvider.ClearData();
        var result = _studentProvider.GetAllStudents();

        Assert.False(result.Any());
    }

    protected class MockStudentProvider : StudentProvider
    {
        protected MockStudentProvider() : base()
        {
        }

        public void AddMockStudent(Student student)
        {
            _entries.Add(student.StudentId, student);
        }

        public static new MockStudentProvider CreateInstance()
        {
            return new MockStudentProvider();
        }

        public void SeedData()
        {
            ClearData();

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

        public void ClearData()
        {
            _entries.Clear();
        }
    }
}
