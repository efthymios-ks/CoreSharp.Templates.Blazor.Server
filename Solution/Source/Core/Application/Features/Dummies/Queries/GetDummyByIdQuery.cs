using AutoMapper;
using CoreSharp.CleanStructure.Blazor.Application.Dto;
using CoreSharp.CleanStructure.Blazor.Application.Features.Dummies.Queries.Abstracts;
using CoreSharp.CleanStructure.Blazor.Application.Repositories;
using CoreSharp.CleanStructure.Blazor.Domain.Entities;
using CoreSharp.Exceptions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CoreSharp.CleanStructure.Blazor.Application.Features.Dummies.Queries
{
    /// <summary>
    /// Get single <see cref="Dummy"/> by id.
    /// </summary>
    public class GetDummyByIdQuery : RepositoryNavigationBase<Dummy>, IRequest<DummyDto>
    {
        //Constructors
        public GetDummyByIdQuery(Guid dummyId)
            => DummyId = dummyId;

        //Properties
        public Guid DummyId { get; }
    }

    internal class GetDummyByIdQueryHandler : IRequestHandler<GetDummyByIdQuery, DummyDto>
    {
        //Fields
        private readonly IAppUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        //Constructors
        public GetDummyByIdQueryHandler(IAppUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //Methods
        public async Task<DummyDto> Handle(GetDummyByIdQuery request, CancellationToken cancellationToken)
        {
            var repository = _unitOfWork.DummyRepository;
            var dummyId = request.DummyId;
            var dummy = await repository.GetAsync(dummyId, request.Navigation, cancellationToken);
            _ = dummy ?? throw EntityNotFoundException.Create<Dummy, Guid>(e => e.Id, dummyId);
            return _mapper.Map<DummyDto>(dummy);
        }
    }
}
