using Sniper.Core.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Services.Catalog
{
    public partial interface IManufacturerTemplateService
    {
        /// <summary>
        /// 删除制造商模板
        /// </summary>
        /// <param name="manufacturerTemplate"></param>
        void DeleteManufacturerTemplate(ManufacturerTemplate manufacturerTemplate);

        /// <summary>
        /// 获取所有制造商模板
        /// </summary>
        /// <returns></returns>
        IList<ManufacturerTemplate> GetAllManufacturerTemplates();

        /// <summary>
        /// 获取制造商
        /// </summary>
        /// <param name="manufacturerTemplateId"></param>
        /// <returns></returns>
        ManufacturerTemplate GetManufacturerTemplateById(int manufacturerTemplateId);

        /// <summary>
        /// 插入制造商模板
        /// </summary>
        /// <param name="manufacturerTemplate"></param>
        void InsertManufacturerTemplate(ManufacturerTemplate manufacturerTemplate);

        /// <summary>
        /// 更新制造商模板
        /// </summary>
        /// <param name="manufacturerTemplate"></param>
        void UpdateManufacturerTemplate(ManufacturerTemplate manufacturerTemplate);

    }
}
