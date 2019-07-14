using System;
using System.Collections.Generic;
using System.Text;
using Sniper.Core.Domain.Customers;
using Sniper.Core.Domain.Security;

namespace Sniper.Services.Security
{
    public partial class PermissionService : IPermissionService
    {
        public bool Authorize(PermissionRecord permission)
        {
            throw new NotImplementedException();
        }

        public bool Authorize(PermissionRecord permission, Customer customer)
        {
            throw new NotImplementedException();
        }

        public bool Authorize(string permissionRecordSystemName)
        {
            throw new NotImplementedException();
        }

        public bool Authorize(string permissionRecordSystemName, Customer customer)
        {
            throw new NotImplementedException();
        }

        public void DeletePermissionRecord(PermissionRecord permission)
        {
            throw new NotImplementedException();
        }

        public IList<PermissionRecord> GetAllPermissionRecords()
        {
            throw new NotImplementedException();
        }

        public PermissionRecord GetPermissionRecordById(int permissionId)
        {
            throw new NotImplementedException();
        }

        public PermissionRecord GetPermissionRecordBySystemName(string systemName)
        {
            throw new NotImplementedException();
        }

        public void InsertPermissionRecord(PermissionRecord permission)
        {
            throw new NotImplementedException();
        }

        public void InstallPermissions(IPermissionProvider permissionProvider)
        {
            throw new NotImplementedException();
        }

        public void UninstallPermissions(IPermissionProvider permissionProvider)
        {
            throw new NotImplementedException();
        }

        public void UpdatePermissionRecord(PermissionRecord permission)
        {
            throw new NotImplementedException();
        }
    }
}
