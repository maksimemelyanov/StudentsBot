using Students.GroupsGrpc;
using StudentsBot.Students.Application.Groups;

namespace StudentsBot.Students.Mappers;

public static class GroupMapper
{
    public static Group Map(this GroupDto source)
    {
        return new Group()
        {
            Id = source.Id,
            Name = source.Name
        };
    }
    
    public static IEnumerable<Group> Map(this IEnumerable<GroupDto> source)
    {
        return source.Select(g => g.Map());
    }
}