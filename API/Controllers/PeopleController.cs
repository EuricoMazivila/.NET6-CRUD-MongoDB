using Application.Features.Peoples;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class PeopleController : BaseController
{
    [HttpGet]
    public async Task<IReadOnlyList<People>> GetAll()
    {
        return await Mediator.Send(new GetAllPeople.GetAllPeopleQuery());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<People>> GetById(string id)
    {
        return await Mediator.Send(new GetPeopleById.GetPeopleByIdQuery { Id = id });
    }

    [HttpPost]
    public async Task<ActionResult<People>> CreatePeople(CreatePeople.CreatePeopleCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<People>> UpdatePeople(string id, UpdatePeople.UpdatePeopleCommand command)
    {
        command.Id = id;
        return await Mediator.Send(command);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<People>> DeletePeople(string id)
    {
        return await Mediator.Send(new DeletePeople.DeletePeopleCommand { Id = id });
    }
}