using Application.Features.Models.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Models.Queries.GetListModelByDynamic;

public class GetListModelByDynamicQuery : IRequest<ModelListModel>
{
    public PageRequest PageRequest { get; set; }
    public Dynamic Dynamic { get; set; }
    
    public class GetListModelByDynamicQueryHandler : IRequestHandler<GetListModelByDynamicQuery, ModelListModel>
    {
        private readonly IModelRepository _modelRepository;
        private readonly IMapper _mapper;
        
        public GetListModelByDynamicQueryHandler(IModelRepository modelRepository, IMapper mapper)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
        }
        
        public async Task<ModelListModel> Handle(GetListModelByDynamicQuery request, CancellationToken cancellationToken)
        {
            var modelList = await _modelRepository.GetListByDynamicAsync(request.Dynamic,
                include: m=> m.Include(c=>c.Brand),
                index: request.PageRequest.Page, size: request.PageRequest.PageSize);
            return _mapper.Map<ModelListModel>(modelList);
        }
    }
}