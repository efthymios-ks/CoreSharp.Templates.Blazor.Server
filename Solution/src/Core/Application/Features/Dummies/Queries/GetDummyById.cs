using AutoMapper;
using CoreSharp.Exceptions;
using CoreSharp.Templates.Blazor.Server.Application.Dto;
using CoreSharp.Templates.Blazor.Server.Application.Features.Dummies.Queries.Common;
using CoreSharp.Templates.Blazor.Server.Application.Repositories;
using CoreSharp.Templates.Blazor.Server.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CoreSharp.Templates.Blazor.Server.Application.Features.Dummies.Queries;

/// <summary>
/// Get single <see cref="Dummy"/> by id.
/// </summary>
public class GetDummyById : RepositoryNavigationBase<Dummy>, IRequest<DummyDto>
{
    //Constructors
    public GetDummyById(Guid dummyId)
        => DummyId = dummyId;

    //Properties
    public Guid DummyId { get; }
}

internal class GetDummyByIdHandler : IRequestHandler<GetDummyById, DummyDto>
{
    //Fields
    private readonly IAppUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    //Constructors
    public GetDummyByIdHandler(IAppUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    //Methods
    public async Task<DummyDto> Handle(GetDummyById request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.DummyRepository;
        var dummyId = request.DummyId;
        var dummy = await repository.GetAsync(dummyId, request.Navigation, cancellationToken);
        _ = dummy ?? throw EntityNotFoundException.Create<Dummy, Guid>(e => e.Id, dummyId);
        return _mapper.Map<DummyDto>(dummy);
    }
}
