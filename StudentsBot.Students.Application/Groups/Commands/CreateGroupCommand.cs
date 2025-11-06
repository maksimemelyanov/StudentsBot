using MediatR;
using StudentsBot.Students.Domain.Groups;

namespace StudentsBot.Students.Application.Groups.Commands;

public record CreateGroupCommand(string Name) : IRequest<int>;

public class CreateGroupCommandHandler(IGroupRepository groupRepository) : IRequestHandler<CreateGroupCommand, int>
{
    public async Task<int> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
    {
        var group = new Group() { Name = request.Name };
        return await groupRepository.Add(group, cancellationToken);
    }
}