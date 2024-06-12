using Travelers.Shared.Domain.Model.Exceptions;
using Travelers.Shared.Domain.Repositories;
using Travelers.Subscriptions.Domain.Model.Aggregate;
using Travelers.Subscriptions.Domain.Model.Commands;
using Travelers.Subscriptions.Domain.Repositories;
using Travelers.Subscriptions.Domain.Services;

namespace Travelers.Subscriptions.Application.Internal;

public class PlanCommandService(IPlanRepository planRepository, IUnitOfWork unitOfWork) : IPlanCommandService
{
   
    public async Task<Plan?> Handle(CreatePlanCommand command)
    {
        var plan = new Plan(command);
        var planNameExists = await planRepository.GetPlanByName(command.Name);
        var countDefaultPlants =  planRepository.CountDefaultPlans();
        if (planNameExists != null)
        {
            throw new PlanNameAlreadyExistsException(command.Name);
        }
        if (countDefaultPlants >= 1 && command.Default == 1)
        {
            throw new DefaultPlanLimitException();
        }

        if (command.MaxUsers <=0  || command.Default < 0 || command.Default > 1)
        {
            throw new NoValidPlanArgumentException();
        }
        await planRepository.AddAsync(plan);
        await unitOfWork.CompleteAsync();
        return plan;
    }

    public async Task<IEnumerable<Plan>> GetAllAsync()
    {
        return await planRepository.GetAllAsync();
    }

    public async Task<Plan?> Handle(UpdatePlanCommand command)
    {
        var plan = await planRepository.GetPlanById(command.Id);
        if (plan == null)
        {
            throw new PlanNotFoundException(command.Id);
        }

        plan.Name = command.Name;
        plan.MaxUsers = command.MaxUsers;
        plan.Default = command.Default;
        
        planRepository.Update(plan);
        await unitOfWork.CompleteAsync();
        return plan;
    }

    public async Task DeletePlanAsync(DeletePlanCommand command)
    {
        var plan = await planRepository.GetPlanById(command.Id);
        if (plan == null)
        {
            throw new PlanNotFoundException(command.Id);
        }

        planRepository.DeletePlanAsync(plan);
        await unitOfWork.CompleteAsync();
    }
}