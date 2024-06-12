using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Travelers.Subscriptions.Domain.Model.Commands;
using Travelers.Subscriptions.Domain.Services;
using Travelers.Subscriptions.Interface.REST.Resources;
using Travelers.Subscriptions.Interface.REST.Transform;

namespace Travelers.Subscriptions.Interface.REST;

[ApiController]
[AllowAnonymous]
[Produces(MediaTypeNames.Application.Json)]
[Route("api/v1/[controller]")]
[ProducesResponseType(500)]
[ProducesResponseType(400)]
public class PlanController(IPlanCommandService commandService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var plans = await commandService.GetAllAsync();
        var resources = plans.Select(plan => PlanResourceFromEntityAssembler.ToResourceFromEntity(plan));
        return Ok(resources);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreatePlan([FromBody] CreatePlanResource createPlanResource)
    {
        var command = CreatePlanCommandFromResourceAssembler.ToCommandFromResource(createPlanResource);
        var plan = await commandService.Handle(command);
        var planResource = PlanResourceFromEntityAssembler.ToResourceFromEntity(plan);
        return StatusCode(201, planResource);

    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePlan(long id, [FromBody] UpdatePlanResource updatePlanResource)
    {
        var command = UpdatePlanCommandFromResourceAssembler.ToCommandFromResource(updatePlanResource);
        var plan = await commandService.Handle(command);
        var planResource = PlanResourceFromEntityAssembler.ToResourceFromEntity(plan);
        return Ok(planResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePlan(long id)
    {
        var command = new DeletePlanCommand(id);
        await commandService.DeletePlanAsync(command);
        return NoContent();
    }
}