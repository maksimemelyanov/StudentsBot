using Microsoft.EntityFrameworkCore;
using StudentsBot.Students.Domain.Groups;

namespace StudentsBot.Students.Infrastructure.Groups;

public class GroupRepository : IGroupRepository
{
    private readonly AppDbContext _context;

    public GroupRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Group?> GetById(int id, CancellationToken cancellationToken)
    {
        return await _context.Groups.FindAsync([id], cancellationToken);
    }

    public async Task<IEnumerable<Group>> GetAll(CancellationToken cancellationToken)
    {
        return await _context.Groups.ToListAsync(cancellationToken);
    }

    public async Task<int> Add(Group group, CancellationToken cancellationToken)
    {
        var entity = await _context.Groups.AddAsync(group, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return entity.Entity.Id;
    }

    public async Task Update(Group group, CancellationToken cancellationToken)
    {
        _context.Groups.Update(group);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task Delete(int id, CancellationToken cancellationToken)
    {
        var entity = await GetById(id, cancellationToken);
        if (entity is not null)
        {
            _context.Groups.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}