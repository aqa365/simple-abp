using Simple.Abp.Articles.Repositories;
using System.Collections.Concurrent;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Guids;

namespace Simple.Abp.Articles.Manager
{
    public class ArticleTagManager : DomainService, IArticleTagManager
    {
        private static ConcurrentDictionary<string, string> _keys = new ConcurrentDictionary<string, string>();

        private readonly IArticleTagRepository _articleTagRepository;
        private readonly IGuidGenerator _guidGenerator;
        public ArticleTagManager(IArticleTagRepository articleTagRepository,
            IGuidGenerator guidGenerator)
        {
            _articleTagRepository = articleTagRepository;
            _guidGenerator = guidGenerator;
        }

        public async Task<ArticleTag> CreateAsync(string name)
        {
            var articleTag =  await _articleTagRepository.FirstOrDefaultAsync(c => c.Name == name);
            if (articleTag != null)
                return articleTag;

            if(_keys.TryAdd(name, name))
            {
                articleTag = new ArticleTag(
                    _guidGenerator.Create(),
                    name
                );

                await _articleTagRepository.InsertAsync(articleTag);
                string value = string.Empty;
                _keys.Remove(name, out value);
                return articleTag;
            }

            return null;
        }
    }
}
