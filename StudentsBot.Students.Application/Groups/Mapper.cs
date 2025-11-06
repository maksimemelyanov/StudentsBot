using Group = StudentsBot.Students.Domain.Groups.Group;

namespace StudentsBot.Students.Application.Groups;

public static class Mapper
{
    public static GroupDto Map(this Group group)
    {
        return new GroupDto() { Name = group.Name, Id = group.Id };
    }
}