using Application.Features.Brands.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using MediatR;

namespace Application.Features.Brands.Queries;

public class GetListBrandQuery: IRequest<BrandListModel>
{
    public PageRequest PageRequest { get; set; }
    
    public class GetListBrandQueryHandler : IRequestHandler<GetListBrandQuery, BrandListModel>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;
        
        public GetListBrandQueryHandler(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }
        
        public async Task<BrandListModel> Handle(GetListBrandQuery request, CancellationToken cancellationToken)
        {
            var brands = await _brandRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);
            var mappedBrandListModel = _mapper.Map<BrandListModel>(brands);
            return mappedBrandListModel;
        }
    }
}