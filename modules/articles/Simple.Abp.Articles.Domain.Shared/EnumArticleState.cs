using System;
using System.Collections.Generic;
using System.Text;

namespace Simple.Abp.Articles
{
    public enum EnumArticleState
    {
        /// <summary>
        /// 默认
        /// </summary>
        Default = 0,

        /// <summary>
        /// 草稿
        /// </summary>
        Draft = 1,

        /// <summary>
        /// 私有
        /// </summary>
        Private = 2
    }
}
