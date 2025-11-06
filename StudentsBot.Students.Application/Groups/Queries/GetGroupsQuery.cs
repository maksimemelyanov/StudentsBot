using MediatR;
using StudentsBot.Students.Domain.Groups;

namespace StudentsBot.Students.Application.Groups.Queries;

public record GetGroupsQuery : IRequest<IEnumerable<GroupDto>>;

public class GetGroupsQueryHadler(IGroupRepository groupRepository) : IRequestHandler<GetGroupsQuery, IEnumerable<GroupDto>>
{
    public async Task<IEnumerable<GroupDto>> Handle(GetGroupsQuery request, CancellationToken cancellationToken)
    {
        return (await groupRepository.GetAll(cancellationToken)).Select(g => g.Map());
    }
}