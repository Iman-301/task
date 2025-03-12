using MediatR;
// using Infrastructure.Persistence;
using Domain.Repositories;

namespace Application.Tasks.Commands;

public class DeleteTaskCommand : IRequest<bool>
{
    public Guid Id { get; set; }
    public DeleteTaskCommand(Guid id) => Id = id;
}

public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, bool>
{
    private readonly ITaskRepository _repository;

    public DeleteTaskCommandHandler(ITaskRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        var task = await _repository.GetTaskByIdAsync(request.Id);
        if (task == null) return false;

        await _repository.DeleteTaskAsync(request.Id);
        return true;
    }
}
