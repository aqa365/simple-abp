using Microsoft.AspNetCore.Authorization;
using Simple.Abp.Articles.Dtos;
using Simple.Abp.Articles.Manager;
using Simple.Abp.Articles.Repositories;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Uow;

namespace Simple.Abp.Articles
{
    public class ArticleAppService : CrudAppService<
        Article,
        ArticleDto,
        Guid,
        ArticlePagedRequestDto,
        CreateUpdateArticleDto,
        CreateUpdateArticleDto>,
        IArticleAppService
    {
        private readonly IArticleRepository _repository;
        private readonly IArticleTagManager _articleTagManager;

        public ArticleAppService(IArticleRepository repository,
             IArticleTagManager articleTagManager) : base(repository)
        {
            _repository = repository;
            _articleTagManager = articleTagManager;

            GetPolicyName = ArticlesPermissions.Articles.Default;
            GetListPolicyName = ArticlesPermissions.Articles.Default;
            CreatePolicyName = ArticlesPermissions.Articles.Create;
            UpdatePolicyName = ArticlesPermissions.Articles.Update;
            DeletePolicyName = ArticlesPermissions.Articles.Delete;
        }

        private async Task<ArticleDto> BuildArticleDto(IQueryable<Article> query, Article entity)
        {
            if (entity == null)
                return null;

            // 上一篇
            var previousQuery = query.Where(c => c.CreationTime > entity.CreationTime)
                .OrderBy(c => c.CreationTime);
            var previousEntity = await AsyncExecuter.FirstOrDefaultAsync(previousQuery);

            // 下一篇
            var nextQuery = query.Where(c => c.CreationTime < entity.CreationTime)
                .OrderByDescending(c => c.CreationTime);
            var nextEntity = await AsyncExecuter.FirstOrDefaultAsync(nextQuery);

            var model = ObjectMapper.Map<Article, ArticleDto>(entity);
            model.Previous = ObjectMapper.Map<Article, ArticleDto>(previousEntity);
            model.Next = ObjectMapper.Map<Article, ArticleDto>(nextEntity);

            return model;
        }
        protected override async Task<IQueryable<Article>> CreateFilteredQueryAsync(ArticlePagedRequestDto input)
        {
            var query = await _repository.WithDetailsAsync();
            if (!input.Filter.IsNullOrWhiteSpace())
                query = query.Where(c => c.Title.Contains(input.Filter));

            if (!input.CatalogTitle.IsNullOrWhiteSpace())
                query = query.Where(c => c.Catalog.Title == input.CatalogTitle);

            if (!input.TagName.IsNullOrWhiteSpace())
                query = query.Where(c => c.Tag == input.TagName);

            return query;
        }

        protected override IQueryable<Article> ApplyDefaultSorting(IQueryable<Article> query)
        {
            query = query.OrderByDescending(c => c.IsTop)
                .ThenBy(c => c.Order)
                .ThenByDescending(c => c.CreationTime);

            return query;
        }

        public async Task<ArticleDto> GetDefaultAsync(Guid id)
        {
            var query = _repository.WithDefaultFilterDetails();

            var entityQuery = query.Where(c => c.Id == id);
            var entity = await AsyncExecuter.FirstOrDefaultAsync(entityQuery);

            return await BuildArticleDto(query, entity);
        }

        public async Task<ArticleDto> GetDefaultBySeoAsync(string seoPath)
        {
            var query = _repository.WithDefaultFilterDetails();

            var entityQuery = query.Where(c => c.SEOPath == seoPath);
            var entity = await AsyncExecuter.FirstOrDefaultAsync(entityQuery);

            return await BuildArticleDto(query, entity);
        }

        public async Task<PagedResultDto<ArticleDto>> GetDefaultListAsync(ArticlePagedRequestDto request)
        {
            var query = await CreateFilteredQueryAsync(request);
            query = _repository.WithDefaultFilter(query);

            var totalCount = await AsyncExecuter.CountAsync(query);

            query = ApplyDefaultSorting(query);
            query = query.Skip(request.SkipCount).Take(request.MaxResultCount);

            var entities = await AsyncExecuter.ToListAsync(query);
            var modelList = ObjectMapper.Map<List<Article>, List<ArticleDto>>(entities);
            return new PagedResultDto<ArticleDto>(totalCount, modelList);
        }

        [UnitOfWork]
        [Authorize(ArticlesPermissions.Articles.Create)]
        public override async Task<ArticleDto> CreateAsync(CreateUpdateArticleDto input)
        {
            var entity = ObjectMapper.Map<CreateUpdateArticleDto, Article>(input);
    
            await _articleTagManager.CreateAsync(input.Tag);
            await _repository.InsertAsync(entity);

            return ObjectMapper.Map<Article, ArticleDto>(entity);
        }

        [UnitOfWork]
        [Authorize(ArticlesPermissions.Articles.Update)]
        public override async Task<ArticleDto> UpdateAsync(Guid id, CreateUpdateArticleDto input)
        {
            var entity = await _repository.GetAsync(id, false);
            ObjectMapper.Map(input, entity);

            await _articleTagManager.CreateAsync(input.Tag);
            await _repository.UpdateAsync(entity);

            return ObjectMapper.Map<Article, ArticleDto>(entity);
        }
    }
}
