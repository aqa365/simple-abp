using Simple.Abp.Articles.Dtos;
using Simple.Abp.Articles.Repositories;
using Volo.Abp.Application.Services;
using Volo.Abp.Linq;

namespace Simple.Abp.Articles
{
    public class ArticleCatalogAppService :
        CrudAppService<
            ArticleCatalog,
            ArticleCatalogDto,
            Guid,
            ArticlePagedCatalogRequestDto,
            CreateUpdateArticleCatalogDto,
            CreateUpdateArticleCatalogDto>,
            IArticleCatalogAppService
    {

        private readonly IArticleCatalogRepository _repository;
        private readonly IArticleRepository _articleRepository;
        private readonly IAsyncQueryableExecuter _asyncExecuter;

        public ArticleCatalogAppService(IArticleCatalogRepository repository,
            IArticleRepository articleRepository,
            IAsyncQueryableExecuter asyncExecuter) : base(repository)
        {
            _repository = repository;
            _articleRepository = articleRepository;
            _asyncExecuter = asyncExecuter;

            GetPolicyName = ArticlesPermissions.Articles.Default;
            GetListPolicyName = ArticlesPermissions.Articles.Default;
            CreatePolicyName = ArticlesPermissions.Articles.Create;
            UpdatePolicyName = ArticlesPermissions.Articles.Update;
            DeletePolicyName = ArticlesPermissions.Articles.Delete;
        }

        protected override async Task<IQueryable<ArticleCatalog>> CreateFilteredQueryAsync(ArticlePagedCatalogRequestDto input)
        {
            var query = await _repository.WithDetailsAsync();
            if (!input.Filter.IsNullOrWhiteSpace())
                query = query.Where(c => c.Title.Contains(input.Filter));

            return query;
        }

        public async Task<List<ArticleCatalogDto>> GetAllAsync()
        {
            var catalogEntities = await _repository.GetListAsync();
            var catalogs = ObjectMapper.Map<List<ArticleCatalog>, List<ArticleCatalogDto>>(catalogEntities);
            return catalogs;
        }

        public async Task<List<ArticleCatalogDto>> GetExistArticleList()
        {
            var query = from c in await _repository.GetQueryableAsync()
                        join a in _articleRepository.WithDefaultFilter() on c.Id equals a.CatalogId
                        group c by new { c.Id, c.ParentId, c.Title, c.Description } into g
                        select new ArticleCatalogDto
                        {
                            Id = g.Key.Id,
                            ParentId = g.Key.ParentId,
                            Title = g.Key.Title,
                            Description = g.Key.Description,
                            ArticleCount = g.Count()

                        } into s
                        where s.ArticleCount > 0
                        select s;

            return await _asyncExecuter.ToListAsync(query);
        }
    }
}
