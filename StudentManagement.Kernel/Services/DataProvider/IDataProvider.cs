using StudentManagement.Kernel.Models;

namespace StudentManagement.Kernel.Services.DataProvider;

public interface IDataProvider
{
    Student GetStudent(string studentId);
    List<Student> GetAllStudents();
    bool UpsertStudent(Student student);
    bool DeleteStudent(string studentId);
}
