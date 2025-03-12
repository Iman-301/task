using Domain;
using MediatR;
// using Infrastructure.Persistence;
using Domain.Repositories;

namespace Application.Tasks.Queries;

public class GetAllTasksQuery : IRequest<List<TaskEntity>> { }

public class GetAllTasksQueryHandler : IRequestHandler<GetAllTasksQuery, List<TaskEntity>>
{
    private readonly ITaskRepository _repository;

    public GetAllTasksQueryHandler(ITaskRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<TaskEntity>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAllTasksAsync();
    }
}
