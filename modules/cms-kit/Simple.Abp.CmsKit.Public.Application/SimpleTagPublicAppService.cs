using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.CmsKit.Tags;

namespace Simple.Abp.CmsKit.Public
{
    public class SimpleTagPublicAppService : SimpleCmsKitPublicAppServiceBase, ISimpleTagPublicAppService
    {
        protected ITagRepository TagRepository { get; }
        public SimpleTagPublicAppService(ITagRepository tagRepository)
        {
            TagRepository = tagRepository;
        }


        public async Task<List<TagDto>> GetAllAsync()
        {
            var tags = await TagRepository.GetListAsync();
            var modelList = ObjectMapper.Map<List<Tag>, List<TagDto>>(tags);
            return modelList;
        }
    }
}
