using AutoMapper;
using CoreSharp.Models.Pages;
using CoreSharp.Templates.Blazor.Server.Application.Dto;
using CoreSharp.Templates.Blazor.Server.Application.Extensions;
using CoreSharp.Templates.Blazor.Server.Application.Features.Dummies.Queries.Abstracts;
using CoreSharp.Templates.Blazor.Server.Application.Repositories;
using CoreSharp.Templates.Blazor.Server.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CoreSharp.Templates.Blazor.Server.Application.Features.Dummies.Queries
{
    /// <summary>
    /// Get paged collection of <see cref="Dummy"/> from database.
    /// </summary>
    public class GetDummiesPage : RepositoryNavigationBase<Dummy>, IRequest<Page<DummyDto>>
    {
        //Constructors
        public GetDummiesPage(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        //Properties
        public int PageNumber { get; }
        public int PageSize { get; }
    }

    internal class GetDummiesPageHandler : IRequestHandler<GetDummiesPage, Page<DummyDto>>
    {
        //Fields
        private readonly IAppUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        //Constructors
        public GetDummiesPageHandler(IAppUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //Methods
        public async Task<Page<DummyDto>> Handle(GetDummiesPage request, CancellationToken cancellationToken)
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
