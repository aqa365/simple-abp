using Simple.Abp.Articles;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Simple.Abp.Articles
{
    public class ArticlesPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var blogGroup = context.AddGroup(ArticlesPermissions.GroupName, L("Permission:Articles"));

            var articlePermission = blogGroup.AddPermission(ArticlesPermissions.Articles.Default, L("Permission:Article"));
            articlePermission.AddChild(ArticlesPermissions.Articles.Create, L("Permission:Create"));
            articlePermission.AddChild(ArticlesPermissions.Articles.Update, L("Permission:Update"));
            articlePermission.AddChild(ArticlesPermissions.Articles.Delete, L("Permission:Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<ArticlesResource>(name);
        }
    }
}
