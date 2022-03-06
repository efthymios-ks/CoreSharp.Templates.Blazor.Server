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
    public class UpdateDummyCommand : IRequest<DummyDto>
    {
        //Constructors
        public UpdateDummyCommand(DummyDto dummyDto)
            => DummyDto = dummyDto ?? throw new ArgumentNullException(nameof(dummyDto));

        //Properties
        public DummyDto DummyDto { get; }
    }

    internal class UpdateDummyCommandHandler : IRequestHandler<UpdateDummyCommand, DummyDto>
    {
        //Fields
        private readonly IAppUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        //Constructors
        public UpdateDummyCommandHandler(IAppUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //Methods
        public async Task<DummyDto> Handle(UpdateDummyCommand request, CancellationToken cancellationToken)
        {
            var repository = _unitOfWork.DummyRepository;
            var dummyDto = request.DummyDto;

            //Get existing dummy 
            var dummyToUpdate = await repository.GetAsync(dummyDto.Id, cancellationToken: cancellationToken);
            _ = dummyToUpdate ?? throw EntityNotFoundException.Create<Dummy, Guid>(e => e.Id, dummyDto.Id);

            //Update 
            _mapper.Map(dummyDto, dummyToUpdate);
            var updatedDummy = await repository.UpdateAsync(dummyToUpdate, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);

            //Return
            return _mapper.Map<DummyDto>(updatedDummy);
        }
    }
}
