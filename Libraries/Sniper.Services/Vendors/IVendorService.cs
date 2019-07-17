using Sniper.Core;
using Sniper.Core.Domain.Vendors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Services.Vendors
{
    public partial interface IVendorService
    {
        /// <summary>
        /// 按供应商标识获取供应商
        /// </summary>
        /// <param name="vendorId"></param>
        /// <returns></returns>
        Vendor GetVendorById(int vendorId);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="vendor"></param>
        void DeleteVendor(Vendor vendor);

        /// <summary>
        /// 翻页获取
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="showHidden"></param>
        /// <returns></returns>
        IPagedList<Vendor> GetAllVendors(string name = "", int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false);

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="vendorIds"></param>
        /// <returns></returns>
        IList<Vendor> GetVendorsByIds(int[] vendorIds);

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="vendor"></param>
        void InsertVendor(Vendor vendor);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="vendor"></param>
        void UpdateVendor(Vendor vendor);

        /// <summary>
        /// 获取供应商备注
        /// </summary>
        /// <param name="vendorNoteId"></param>
        /// <returns></returns>
        VendorNote GetVendorNoteById(int vendorNoteId);

        /// <summary>
        /// 删除备注
        /// </summary>
        /// <param name="vendorNote"></param>
        void DeleteVendorNote(VendorNote vendorNote);

        /// <summary>
        /// 格式化备注
        /// </summary>
        /// <param name="vendorNote"></param>
        /// <returns></returns>
        string FormatVendorNoteText(VendorNote vendorNote);

    }
}
