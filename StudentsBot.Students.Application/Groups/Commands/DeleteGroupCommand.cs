using MediatR;
using StudentsBot.Students.Domain.Groups;

namespace StudentsBot.Students.Application.Groups.Commands;

public record DeleteGroupCommand(int Id) : IRequest;

public class DeleteGroupCommandHandler(IGroupRepository groupRepository) : IRequestHandler<DeleteGroupCommand>
{
    public async Task Handle(DeleteGroupCommand request, CancellationToken cancellationToken)
    {
        await groupRepository.Delete(request.Id, cancellationToken);
    }
}