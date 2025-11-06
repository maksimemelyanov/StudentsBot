using MediatR;
using Microsoft.AspNetCore.Mvc;
using StudentsBot.Students.Application.Groups;
using StudentsBot.Students.Application.Groups.Commands;
using StudentsBot.Students.Application.Groups.Queries;
using StudentsBot.Students.Domain.Exceptions;

namespace StudentsBot.Students.Controllers;

[ApiController]
[Route("[controller]")]
public class GroupController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<GroupDto?> GetById(int id)
    {
        try
        {
            return await mediator.Send(new GetGroupByIdQuery(id));
        }
        catch (EntityNotFoundException e)
        {
            return null;
        }
        
    }

    [HttpGet]
    public async Task<IEnumerable<GroupDto>> GetAll()
    {
        return await mediator.Send(new GetGroupsQuery());
    }

    [HttpPost]
    public async Task<int> Create(CreateGroupCommand command)
    {
        return await mediator.Send(command);
    }

    [HttpPut]
    public async Task Update(UpdateGroupCommand command)
    {
        await mediator.Send(command);
    }
    
    [HttpDelete("{id}")]
    public async Task Delete(int id)
    {
        await mediator.Send(new DeleteGroupCommand(id));
    }
}