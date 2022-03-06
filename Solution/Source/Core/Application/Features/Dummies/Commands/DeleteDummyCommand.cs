using CoreSharp.CleanStructure.Blazor.Application.Repositories;
using CoreSharp.CleanStructure.Blazor.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CoreSharp.CleanStructure.Blazor.Application.Features.Dummies.Queries
{
    /// <summary>
    /// Delete single <see cref="Dummy"/> by id.
    /// </summary>
    public class DeleteDummyCommand : IRequest
    {
        //Constructors
        public DeleteDummyCommand(Guid dummyId)
            => DummyId = dummyId;

        //Properties
        public Guid DummyId { get; }
    }

    internal class DeleteDummyCommandHandler : IRequestHandler<DeleteDummyCommand>
    {
        //Fields
        private readonly IAppUnitOfWork _unitOfWork;

        //Constructors
        public DeleteDummyCommandHandler(IAppUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;

        //Methods 
        async Task<Unit> IRequestHandler<DeleteDummyCommand, Unit>.Handle(DeleteDummyCommand request, CancellationToken cancellationToken)
        {
            var repository = _unitOfWork.DummyRepository;
            await repository.RemoveAsync(request.DummyId, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
