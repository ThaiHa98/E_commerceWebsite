using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Common.Constants
{
    public static class SystemConstants
    {
        public const string DatabaseSettings = "DatabaseSettings:ConnectionString";
        public static class Claims
        {
            public const string Permissions = "permissions";
            public const string Roles = ClaimTypes.Role;
            public const string Id = ClaimTypes.NameIdentifier;
            public const string UserName = ClaimTypes.Name;
        }

        public class Roles
        {
            public const string Customer = "Customer";
            public const string Employee = "Employee";
        }

        public static class AppSettings
        {
            public const string BaseAddressWebPortal = "BaseAddressWebPortal";
            public const string UserApiAddress = "UserApiAddress";
            //public const string NotifyApiAddress = "NotifyApiAddress";
            //public const string LanguageId = "vi";
            public const string ClientId = "ClientId";
            public const string ApiGateWay = "AppSettings:ApiGateWay";
            //public const string BaseAddressGateWay = "BaseAddressGateWay";
            public const string BaseAddress = "BaseAddress";
        }

        public class CacheConstants
        {
            public const string ResClientId = "ResClientId";
            public const string GetApiPermissions = "GetApiPermissions";
            public const string PermissionRoleItems = "PermissionRoleItems";
            public const string ReportTotal = "ReportTotal";
            public const string ConfigServiceApp = "ConfigServiceApp";
        }

        public class KeyAppRouteSettings
        {
            public const string GetServiceKeyId = "/keyapp?serviceKeyId=";
        }

        public static class PermissionsRouteSettings
        {
            public const string GetPermissions = "/useritems/get-permissions-role?userId=";
        }
    }
}
