using Application.Features.Models.DTOs;
using Core.Persistence.Paging;

namespace Application.Features.Models.Models;

public class ModelListModel : BasePageableModel
{
    public ICollection<ModelListDTO> Items { get; set; }
}