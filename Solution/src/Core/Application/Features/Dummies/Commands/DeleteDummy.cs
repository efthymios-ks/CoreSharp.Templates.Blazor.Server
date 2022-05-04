using CoreSharp.Templates.Blazor.Server.Application.Repositories;
using CoreSharp.Templates.Blazor.Server.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CoreSharp.Templates.Blazor.Server.Application.Features.Dummies.Commands
{
    /// <summary>
    /// Delete single <see cref="Dummy"/> by id.
    /// </summary>
    public class DeleteDummy : IRequest
    {
        //Constructors
        public DeleteDummy(Guid dummyId)
            => DummyId = dummyId;

        //Properties
        public Guid DummyId { get; }
    }

    internal class DeleteDummyHandler : IRequestHandler<DeleteDummy>
    {
        //Fields
        private readonly IAppUnitOfWork _unitOfWork;

        //Constructors
        public DeleteDummyHandler(IAppUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;

        //Methods 
        async Task<Unit> IRequestHandler<DeleteDummy, Unit>.Handle(DeleteDummy request, CancellationToken cancellationToken)
        {
            var repository = _unitOfWork.DummyRepository;
            await repository.RemoveByAsync(request.DummyId, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
