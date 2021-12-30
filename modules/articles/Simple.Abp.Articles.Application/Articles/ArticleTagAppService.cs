using Simple.Abp.Articles.Dtos;
using Simple.Abp.Articles.Manager;
using Simple.Abp.Articles.Repositories;
using Volo.Abp.Application.Services;
using Volo.Abp.Linq;

namespace Simple.Abp.Articles
{
    public class ArticleTagAppService :
        CrudAppService<
            ArticleTag,
            ArticleTagDto,
            Guid,
            ArticlePagedTagRequestDto,
            CreateUpdateArticleTagDto,
            CreateUpdateArticleTagDto>,
        IArticleTagAppService
    {

        private readonly IArticleTagRepository _repository;
        private readonly IArticleRepository _articlerepository;
        private readonly IArticleTagManager _articleTagManager;

        private readonly IAsyncQueryableExecuter _asyncExecuter;

        public ArticleTagAppService(IArticleTagRepository repository,
            IArticleRepository articlerepository,
            IArticleTagManager articleTagManager,
            IAsyncQueryableExecuter asyncExecuter) : base(repository)
        {
            _repository = repository;
            _articlerepository = articlerepository;
            _articleTagManager = articleTagManager;
            _asyncExecuter = asyncExecuter;

            GetPolicyName = ArticlesPermissions.Articles.Default;
            GetListPolicyName = ArticlesPermissions.Articles.Default;
            CreatePolicyName = ArticlesPermissions.Articles.Create;
            UpdatePolicyName = ArticlesPermissions.Articles.Update;
            DeletePolicyName = ArticlesPermissions.Articles.Delete;
        }

        protected override async Task<IQueryable<ArticleTag>> CreateFilteredQueryAsync(ArticlePagedTagRequestDto input)
        {
            var query = await _repository.WithDetailsAsync();
            if (!input.Filter.IsNullOrWhiteSpace())
                query = query.Where(c => c.Name.Contains(input.Filter));

            return query;
        }

        public override async Task<ArticleTagDto> CreateAsync(CreateUpdateArticleTagDto input)
        {
            var tagEnity = await _articleTagManager.CreateAsync(input.Name);
            return ObjectMapper.Map<ArticleTag, ArticleTagDto>(tagEnity);
        }

        public async Task<List<ArticleTagDto>> GetAllAsync()
        {
            var entities = await _repository.GetListAsync();
            var modelList = ObjectMapper.Map<List<ArticleTag>, List<ArticleTagDto>>(entities);
            return modelList;
        }

        public async Task<List<ArticleTagDto>> GetExistArticleList()
        {
            var query = from c in await _repository.GetQueryableAsync()
                        join a in _articlerepository.WithDefaultFilter() on c.Name equals a.Tag
                        group c by new { c.Id, c.Name } into g
                        select new ArticleTagDto
                        {
                            Id = g.Key.Id,
                            Name = g.Key.Name,
                            ArticleCount = g.Count()
                        } into s
                        where s.ArticleCount > 0
                        select s;

            return await _asyncExecuter.ToListAsync(query);
        }
    }
}
