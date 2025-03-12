using Domain;
using MediatR;
// using Infrastructure.Persistence;
using Domain.Repositories;
namespace Application.Tasks.Commands;

public class CreateTaskCommand: IRequest<Guid>
{
    public string Title{get; set;}=string.Empty;
    public string Description {get; set;}=string.Empty;
    public bool IsCompleted {get; set;}
}

public class CreateTaskCommandHandler:IRequestHandler<CreateTaskCommand, Guid>
{
    private readonly ITaskRepository _repository;
    
    public CreateTaskCommandHandler(ITaskRepository repository)
    {
        _repository = repository;
    }


    public async Task<Guid> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        var task=new TaskEntity
        {
            Id=Guid.NewGuid(),
            Title=request.Title,
            Description=request.Description,
            IsCompleted=request.IsCompleted
        };

        await _repository.AddTaskAsync(task);
        return task.Id;
    }
}