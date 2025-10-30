using Microsoft.EntityFrameworkCore;
using StudentsBot.Students.Domain.Students;

namespace StudentsBot.Students.Infrastructure.Students;

public class StudentRepository : IStudentRepository
{
    private readonly AppDbContext _context;

    public StudentRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Student?> GetById(int id, CancellationToken cancellationToken)
    {
        return await _context.Students.FindAsync([id], cancellationToken);
    }

    public async Task<IEnumerable<Student>> GetAll(CancellationToken cancellationToken)
    {
        return await _context.Students.ToListAsync(cancellationToken);
    }

    public async Task<int> Add(Student student, CancellationToken cancellationToken)
    {
        var entity = await _context.Students.AddAsync(student, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return entity.Entity.Id;
    }

    public async Task Update(Student student, CancellationToken cancellationToken)
    {
        _context.Students.Update(student);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task Delete(int id, CancellationToken cancellationToken)
    {
        var entity = await GetById(id, cancellationToken);
        if (entity is not null)
        {
            _context.Students.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}