using Sniper.Core.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Services.Catalog
{
    public partial interface ICategoryTemplateService
    {
        /// <summary>
        /// 删除类别模板
        /// </summary>
        /// <param name="categoryTemplate"></param>
        void DeleteCategoryTemplate(CategoryTemplate categoryTemplate);

        /// <summary>
        /// 获取类别模板
        /// </summary>
        /// <returns></returns>
        IList<CategoryTemplate> GetAllCategoryTemplates();

        /// <summary>
        /// 获取类别模板
        /// </summary>
        /// <param name="categoryTemplateId"></param>
        /// <returns></returns>
        CategoryTemplate GetCategoryTemplateById(int categoryTemplateId);

        /// <summary>
        /// 插入类别模板
        /// </summary>
        /// <param name="categoryTemplate"></param>
        void InsertCategoryTemplate(CategoryTemplate categoryTemplate);

        /// <summary>
        /// 更新类别模板
        /// </summary>
        /// <param name="categoryTemplate"></param>
        void UpdateCategoryTemplate(CategoryTemplate categoryTemplate);


    }
}
