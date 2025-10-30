namespace StudentsBot.Students.Domain.Students;

public interface IStudentRepository
{
    Task<Student?> GetById(int id, CancellationToken cancellationToken);
    Task<IEnumerable<Student>> GetAll(CancellationToken cancellationToken);
    Task<int> Add(Student student, CancellationToken cancellationToken);
    Task Update(Student student, CancellationToken cancellationToken);
    Task Delete(int id, CancellationToken cancellationToken);
}