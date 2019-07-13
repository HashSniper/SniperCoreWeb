using Sniper.Core.Domain.Customers;
using Sniper.Core.Domain.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Services.Security
{
    public partial interface IPermissionService
    {
        /// <summary>
        /// 删除权限
        /// </summary>
        /// <param name="permission"></param>
        void DeletePermissionRecord(PermissionRecord permission);

        /// <summary>
        /// 通过id获取权限
        /// </summary>
        /// <param name="permissionId"></param>
        /// <returns></returns>
        PermissionRecord GetPermissionRecordById(int permissionId);

        /// <summary>
        /// 通过系统名称获取权限
        /// </summary>
        /// <param name="systemName"></param>
        /// <returns></returns>
        PermissionRecord GetPermissionRecordBySystemName(string systemName);

        /// <summary>
        /// 获取权限列表
        /// </summary>
        /// <returns></returns>
        IList<PermissionRecord> GetAllPermissionRecords();

        /// <summary>
        /// 插入权限
        /// </summary>
        /// <param name="permission"></param>
        void InsertPermissionRecord(PermissionRecord permission);

        /// <summary>
        /// 更新权限
        /// </summary>
        /// <param name="permission"></param>
        void UpdatePermissionRecord(PermissionRecord permission);

        /// <summary>
        /// 安装权限
        /// </summary>
        /// <param name="permissionProvider"></param>
        void InstallPermissions(IPermissionProvider permissionProvider);

        /// <summary>
        /// 卸载权限
        /// </summary>
        /// <param name="permissionProvider"></param>
        void UninstallPermissions(IPermissionProvider permissionProvider);

        /// <summary>
        /// 授权许可
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        bool Authorize(PermissionRecord permission);

        /// <summary>
        /// 授权许可
        /// </summary>
        /// <param name="permission"></param>
        /// <param name="customer"></param>
        /// <returns></returns>
        bool Authorize(PermissionRecord permission, Customer customer);

        /// <summary>
        /// 授权许可
        /// </summary>
        /// <param name="permissionRecordSystemName"></param>
        /// <returns></returns>
        bool Authorize(string permissionRecordSystemName);

        /// <summary>
        /// 授权许可
        /// </summary>
        /// <param name="permissionRecordSystemName"></param>
        /// <param name="customer"></param>
        /// <returns></returns>
        bool Authorize(string permissionRecordSystemName, Customer customer);


    }
}
