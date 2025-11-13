using Grpc.Core;
using MediatR;
using Students.GroupsGrpc;
using StudentsBot.Students.Application.Groups.Commands;
using StudentsBot.Students.Application.Groups.Queries;
using StudentsBot.Students.Domain.Exceptions;
using StudentsBot.Students.Mappers;

namespace StudentsBot.Students.Services;

public class GroupsService(IMediator mediator) : Groups.GroupsBase
{
    public override async Task<GetGroupByIdResponse> GetGroupById(GetGroupByIdRequest request, ServerCallContext context)
    {
        try
        {
            var group = await mediator.Send(new GetGroupByIdQuery(request.Id));
            return new GetGroupByIdResponse()
            {
                Value = group.Map()
            };
        }
        catch (EntityNotFoundException e)
        {
            return null;
        }
    }

    public override async Task<GetGroupsResponse> GetGroups(GetGroupsRequest request, ServerCallContext context)
    {
        var groups = await mediator.Send(new GetGroupsQuery());
        var response = new GetGroupsResponse();
        response.Value.Add(groups.Map());
        return response;
    }

    public override async Task<CreateGroupResponse> CreateGroup(CreateGroupRequest request, ServerCallContext context)
    {
        var groupId = await mediator.Send(new CreateGroupCommand(request.Name));
        return new CreateGroupResponse() { Id = groupId };
    }

    public override async Task<UpdateGroupResponse> UpdateGroup(UpdateGroupRequest request, ServerCallContext context)
    {
        await mediator.Send(new UpdateGroupCommand(request.Id, request.Name));
        return new UpdateGroupResponse();
    }

    public override async Task<DeleteGroupResponse> DeleteGroup(DeleteGroupRequest request, ServerCallContext context)
    {
        await mediator.Send(new DeleteGroupCommand(request.Id));
        return new DeleteGroupResponse();
    }
}