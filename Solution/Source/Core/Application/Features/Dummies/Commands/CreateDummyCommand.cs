using AutoMapper;
using CoreSharp.CleanStructure.Blazor.Application.Dto;
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
    /// Create new <see cref="Dummy"/>.
    /// </summary>
    public class CreateDummyCommand : IRequest<DummyDto>
    {
        //Constructors
        public CreateDummyCommand(DummyDto dummyDto)
            => DummyDto = dummyDto ?? throw new ArgumentNullException(nameof(dummyDto));

        //Properties
        public DummyDto DummyDto { get; }
    }

    internal class CreateDummyCommandHandler : IRequestHandler<CreateDummyCommand, DummyDto>
    {
        //Fields
        private readonly IAppUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        //Constructors
        public CreateDummyCommandHandler(IAppUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //Methods
        public async Task<DummyDto> Handle(CreateDummyCommand request, CancellationToken cancellationToken)
        {
            var repository = _unitOfWork.DummyRepository;
            var dummyDto = request.DummyDto;

            //Check if exists
            if (await repository.ExistsAsync(dummyDto.Id, cancellationToken))
                EntityExistsException.Throw<Dummy, Guid>(e => e.Id, dummyDto.Id);

            //Create 
            var dummyToCreate = _mapper.Map<Dummy>(request.DummyDto);
            var createdDummy = await repository.AddAsync(dummyToCreate, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);

            //Return 
            return _mapper.Map<DummyDto>(createdDummy);
        }
    }
}
