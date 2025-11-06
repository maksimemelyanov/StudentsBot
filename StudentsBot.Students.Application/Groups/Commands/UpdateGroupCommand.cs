using MediatR;
using StudentsBot.Students.Domain.Exceptions;
using StudentsBot.Students.Domain.Groups;

namespace StudentsBot.Students.Application.Groups.Commands;

public record UpdateGroupCommand(int Id, string Name) : IRequest;

public class UpdateGroupCommandHandler(IGroupRepository groupRepository) : IRequestHandler<UpdateGroupCommand>
{
    public async Task Handle(UpdateGroupCommand request, CancellationToken cancellationToken)
    {
        var group = await groupRepository.GetById(request.Id, cancellationToken);
        if (group == null)
            throw new EntityNotFoundException();
        group.Name = request.Name;
        await groupRepository.Update(group, cancellationToken);
    }
}