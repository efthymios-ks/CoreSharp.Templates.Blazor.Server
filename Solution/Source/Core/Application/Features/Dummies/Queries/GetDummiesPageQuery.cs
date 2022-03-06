using AutoMapper;
using CoreSharp.CleanStructure.Blazor.Application.Dto;
using CoreSharp.CleanStructure.Blazor.Application.Extensions;
using CoreSharp.CleanStructure.Blazor.Application.Features.Dummies.Queries.Abstracts;
using CoreSharp.CleanStructure.Blazor.Application.Repositories;
using CoreSharp.CleanStructure.Blazor.Domain.Entities;
using CoreSharp.Models.Pages;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CoreSharp.CleanStructure.Blazor.Application.Features.Dummies.Queries
{
    /// <summary>
    /// Get paged collection of <see cref="Dummy"/> from database.
    /// </summary>
    public class GetDummiesPageQuery : RepositoryNavigationBase<Dummy>, IRequest<Page<DummyDto>>
    {
        //Constructors
        public GetDummiesPageQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        //Properties
        public int PageNumber { get; }
        public int PageSize { get; }
    }

    internal class GetDummiesPageQueryHandler : IRequestHandler<GetDummiesPageQuery, Page<DummyDto>>
    {
        //Fields
        private readonly IAppUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        //Constructors
        public GetDummiesPageQueryHandler(IAppUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //Methods
        public async Task<Page<DummyDto>> Handle(GetDummiesPageQuery request, CancellationToken cancellationToken)
        {
            var repository = _unitOfWork.DummyRepository;

            var page = await repository.GetPageAsync(
                request.PageNumber,
                request.PageSize,
                request.Navigation,
                cancellationToken);

            return _mapper.MapPage<Dummy, DummyDto>(page);
        }
    }
}
