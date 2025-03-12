using Domain;
using MediatR;
// using Infrastructure.Persistence;
using Domain.Repositories;

namespace Application.Tasks.Queries;

public class GetTaskByIdQuery : IRequest<TaskEntity?>
{
    public Guid Id { get; }
    public GetTaskByIdQuery(Guid id) {Id = id;}
}

public class GetTaskByIdQueryHandler : IRequestHandler<GetTaskByIdQuery, TaskEntity?>
{
    private readonly ITaskRepository _repository;

    public GetTaskByIdQueryHandler(ITaskRepository repository)
    {
        _repository = repository;
    }

    public async Task<TaskEntity?> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetTaskByIdAsync(request.Id);
    }
}
