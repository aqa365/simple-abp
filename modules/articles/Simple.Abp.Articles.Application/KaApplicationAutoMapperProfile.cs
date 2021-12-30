using AutoMapper;
using Simple.Abp.Articles.Dtos;

namespace Simple.Abp.Articles
{
    public class KaApplicationAutoMapperProfile : Profile
    {
        public KaApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            ConfigBlog();
        }

        private void ConfigBlog()
        {
            CreateMap<Article, ArticleDto>();
            CreateMap<CreateUpdateArticleDto, Article>(MemberList.Source);

            CreateMap<ArticleCatalog, ArticleCatalogDto>();
            CreateMap<CreateUpdateArticleCatalogDto, ArticleCatalog>(MemberList.Source);

            CreateMap<ArticleTag, ArticleTagDto>();
            CreateMap<CreateUpdateArticleTagDto, ArticleTag>(MemberList.Source);
        }
    }
}