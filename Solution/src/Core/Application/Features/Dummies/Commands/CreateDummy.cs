using AutoMapper;
using CoreSharp.Exceptions;
using CoreSharp.Templates.Blazor.Server.Application.Dto;
using CoreSharp.Templates.Blazor.Server.Application.Repositories;
using CoreSharp.Templates.Blazor.Server.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CoreSharp.Templates.Blazor.Server.Application.Features.Dummies.Commands
{
    /// <summary>
    /// Create new <see cref="Dummy"/>.
    /// </summary>
    public class CreateDummy : IRequest<DummyDto>
    {
        //Constructors
        public CreateDummy(DummyDto dummyDto)
            => DummyDto = dummyDto ?? throw new ArgumentNullException(nameof(dummyDto));

        //Properties
        public DummyDto DummyDto { get; }
    }

    internal class CreateDummyHandler : IRequestHandler<CreateDummy, DummyDto>
    {
        //Fields
        private readonly IAppUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        //Constructors
        public CreateDummyHandler(IAppUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //Methods
        public async Task<DummyDto> Handle(CreateDummy request, CancellationToken cancellationToken)
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
