using MediatR;
using StudentsBot.Students.Domain.Exceptions;
using StudentsBot.Students.Domain.Groups;

namespace StudentsBot.Students.Application.Groups.Queries;

public record GetGroupByIdQuery(int Id) : IRequest<GroupDto>;

public class GetGroupByIdQueryHandler(IGroupRepository groupRepository) : IRequestHandler<GetGroupByIdQuery, GroupDto>
{
    public async Task<GroupDto> Handle(GetGroupByIdQuery request, CancellationToken cancellationToken)
    {
        var group = await groupRepository.GetById(request.Id, cancellationToken);
        if (group != null)
            return group.Map();
        throw new EntityNotFoundException();
    }
}