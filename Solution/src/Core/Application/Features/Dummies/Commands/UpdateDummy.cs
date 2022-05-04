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
    public class UpdateDummy : IRequest<DummyDto>
    {
        //Constructors
        public UpdateDummy(DummyDto dummyDto)
            => DummyDto = dummyDto ?? throw new ArgumentNullException(nameof(dummyDto));

        //Properties
        public DummyDto DummyDto { get; }
    }

    internal class UpdateDummyHandler : IRequestHandler<UpdateDummy, DummyDto>
    {
        //Fields
        private readonly IAppUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        //Constructors
        public UpdateDummyHandler(IAppUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //Methods
        public async Task<DummyDto> Handle(UpdateDummy request, CancellationToken cancellationToken)
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
