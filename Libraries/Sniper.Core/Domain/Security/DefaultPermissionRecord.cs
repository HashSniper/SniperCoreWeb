using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Security
{
    public class DefaultPermissionRecord
    {
        public DefaultPermissionRecord()
        {
            PermissionRecords = new List<PermissionRecord>();

        }

        public string CustomerRoleSystemName { get; set; }

        public IEnumerable<PermissionRecord> PermissionRecords { get; set; }

    }
}
