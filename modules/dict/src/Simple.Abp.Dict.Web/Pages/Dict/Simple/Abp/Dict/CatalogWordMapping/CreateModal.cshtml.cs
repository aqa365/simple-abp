using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Simple.Abp.Dict;
using Simple.Abp.Dict.Dtos;
using Simple.Abp.Dict.Web.Pages.Dict.Simple.Abp.Dict.CatalogWordMapping.ViewModels;

namespace Simple.Abp.Dict.Web.Pages.Dict.Simple.Abp.Dict.CatalogWordMapping
{
    public class CreateModalModel : DictPageModel
    {
        [BindProperty]
        public CreateEditCatalogWordMappingViewModel ViewModel { get; set; }

        private readonly ICatalogWordMappingAppService _service;

        public CreateModalModel(ICatalogWordMappingAppService service)
        {
            _service = service;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditCatalogWordMappingViewModel, CreateUpdateCatalogWordMappingDto>(ViewModel);
            await _service.CreateAsync(dto);
            return NoContent();
        }
    }
}