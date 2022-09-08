using Application.Features.Models.Queries.GetListModel;
using Application.Features.Models.Queries.GetListModelByDynamic;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

public class ModelsController: BaseController
{
    [HttpGet]
    public async Task<ActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListModelQuery getListModelQuery = new GetListModelQuery{PageRequest = pageRequest};
        var result = await Mediator.Send(getListModelQuery);
        return Ok(result);
    }
    
    [HttpPost("GetLis/tByDynamic")]
    public async Task<ActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
    {
        GetListModelByDynamicQuery getListModelByDynamicQuery = new GetListModelByDynamicQuery(){PageRequest = pageRequest, Dynamic = dynamic};
        var result = await Mediator.Send(getListModelByDynamicQuery);
        return Ok(result);
    }
}