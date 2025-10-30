namespace StudentsBot.Students.Domain.Groups;

public interface IGroupRepository
{
    Task<Group?> GetById(int id, CancellationToken cancellationToken);
    Task<IEnumerable<Group>> GetAll(CancellationToken cancellationToken);
    Task<int> Add(Group group, CancellationToken cancellationToken);
    Task Update(Group group, CancellationToken cancellationToken);
    Task Delete(int id, CancellationToken cancellationToken);
}