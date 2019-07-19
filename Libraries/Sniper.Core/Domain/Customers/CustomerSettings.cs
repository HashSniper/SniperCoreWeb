using Sniper.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Customers
{
    public class CustomerSettings : ISettings
    {
        /// <summary>
        /// 是否使用用户名而不是电子邮件
        /// </summary>
        public bool UsernamesEnabled { get; set; }

        /// <summary>
        /// 是否可以检查用户名的可用性（在“我的帐户”页面上注册或更改时）
        /// </summary>
        public bool CheckUsernameAvailabilityEnabled { get; set; }

        /// <summary>
        /// 是否允许用户更改其用户名
        /// </summary>
        public bool AllowUsersToChangeUsernames { get; set; }

        /// <summary>
        /// 是否验证用户名（在“我的帐户”页面上注册或更改时）
        /// </summary>
        public bool UsernameValidationEnabled { get; set; }

        /// <summary>
        /// 是否使用正则表达式验证用户名（在“我的帐户”页面上注册或更改时）
        /// </summary>
        public bool UsernameValidationUseRegex { get; set; }

        /// <summary>
        /// 用户名验证规则
        /// </summary>
        public string UsernameValidationRule { get; set; }

        /// <summary>
        /// 默认密码格式
        /// </summary>
        public PasswordFormat DefaultPasswordFormat { get; set; }

        /// <summary>
        /// 哈希密码时的客户密码格式（SHA1，MD5）（不要在生产环境中编辑）
        /// </summary>
        public string HashedPasswordFormat { get; set; }

        /// <summary>
        /// 密码最小长度
        /// </summary>
        public int PasswordMinLength { get; set; }

        /// <summary>
        /// 密码是否至少有一个小写
        /// </summary>
        public bool PasswordRequireLowercase { get; set; }

        /// <summary>
        /// 密码是否需要大写
        /// </summary>
        public bool PasswordRequireUppercase { get; set; }

        /// <summary>
        /// 密码是否至少包含一个非字母数字字符
        /// </summary>
        public bool PasswordRequireNonAlphanumeric { get; set; }

        /// <summary>
        /// 密码是否至少有一位数
        /// </summary>
        public bool PasswordRequireDigit { get; set; }

        /// <summary>
        /// 许多密码不应与前一个密码相同; 如果客户可以一次使用相同的密码，则为0
        /// </summary>
        public int UnduplicatedPasswordsNumber { get; set; }

        /// <summary>
        /// 密码恢复链接的天数。 如果未过期，则设置为0。
        /// </summary>
        public int PasswordRecoveryLinkDaysValid { get; set; }

        /// <summary>
        /// 密码的有效期
        /// </summary>
        public int PasswordLifetime { get; set; }

        /// <summary>
        /// 锁定帐户的最大登录失败次数。 设置为0以禁用此功能
        /// </summary>
        public int FailedPasswordAllowedAttempts { get; set; }

        /// <summary>
        /// 锁定用户的几分钟（登录失败）。
        /// </summary>
        public int FailedPasswordLockoutMinutes { get; set; }

        /// <summary>
        /// 注册类型
        /// </summary>
        public UserRegistrationType UserRegistrationType { get; set; }

        /// <summary>
        /// 是否允许客户上传头像。
        /// </summary>
        public bool AllowCustomersToUploadAvatars { get; set; }

        /// <summary>
        /// 最大头像大小（以字节为单位）
        /// </summary>
        public int AvatarMaximumSizeBytes { get; set; }

        /// <summary>
        /// 是否显示默认用户头像。
        /// </summary>
        public bool DefaultAvatarEnabled { get; set; }


        /// <summary>
        /// 是否显示客户位置
        /// </summary>
        public bool ShowCustomersLocation { get; set; }

        /// <summary>
        /// 是否向客户显示加入日期
        /// </summary>
        public bool ShowCustomersJoinDate { get; set; }

        /// <summary>
        /// 是否允许客户查看其他客户的配置文件
        /// </summary>
        public bool AllowViewingProfiles { get; set; }

        /// <summary>
        /// 是否应将“新客户”通知消息发送给店主
        /// </summary>
        public bool NotifyNewCustomerRegistration { get; set; }

        /// <summary>
        /// 是否隐藏“我的帐户”页面上的“可下载产品”标签
        /// </summary>
        public bool HideDownloadableProductsTab { get; set; }

        /// <summary>
        /// 是否隐藏“我的帐户”页面上的“返回库存订阅”标签
        /// </summary>
        public bool HideBackInStockSubscriptionsTab { get; set; }

        /// <summary>
        /// 是否在下载产品时验证用户
        /// </summary>
        public bool DownloadableProductsValidateUser { get; set; }

        /// <summary>
        /// 客户名称格式
        /// </summary>
        public CustomerNameFormat CustomerNameFormat { get; set; }

        /// <summary>
        /// 是否启用“新闻稿”表单字段
        /// </summary>
        public bool NewsletterEnabled { get; set; }

        /// <summary>
        /// 默认情况下，在注册页面上勾选“时事通讯”复选框
        /// </summary>
        public bool NewsletterTickedByDefault { get; set; }

        /// <summary>
        /// 是否隐藏时事通讯箱
        /// </summary>
        public bool HideNewsletterBlock { get; set; }

        /// <summary>
        /// 是否通讯栏应允许取消订阅
        /// </summary>
        public bool NewsletterBlockAllowToUnsubscribe { get; set; }

        /// <summary>
        /// “在线客户”模块的分钟数
        /// </summary>
        public int OnlineCustomerMinutes { get; set; }

        /// <summary>
        /// 我们应该存储每个客户的最后访问页面URL
        /// </summary>
        public bool StoreLastVisitedPage { get; set; }

        /// <summary>
        /// 是否存储客户的IP地址
        /// </summary>
        public bool StoreIpAddresses { get; set; }

        /// <summary>
        /// 删除的客户记录是否应加上前缀“-DELETED”
        /// </summary>
        public bool SuffixDeletedCustomers { get; set; }

        /// <summary>
        /// 是否强制输入两次电子邮件
        /// </summary>
        public bool EnteringEmailTwice { get; set; }

        /// <summary>
        /// 是否需要注册可下载产品
        /// </summary>
        public bool RequireRegistrationForDownloadableProducts { get; set; }

        /// <summary>
        /// 是否检查礼品卡余额
        /// </summary>
        public bool AllowCustomersToCheckGiftCardBalance { get; set; }

        /// <summary>
        /// 删除来宾任务运行的间隔（以分钟为单位）
        /// </summary>
        public int DeleteGuestTaskOlderThanMinutes { get; set; }

        #region Form fields

        /// <summary>
        /// 是否启用“性别”
        /// </summary>
        public bool GenderEnabled { get; set; }

        /// <summary>
        /// 是否启用“出生日期”
        /// </summary>
        public bool DateOfBirthEnabled { get; set; }

        /// <summary>
        /// 是否需要“出生日期”
        /// </summary>
        public bool DateOfBirthRequired { get; set; }

        /// <summary>
        /// 最低年龄。 如果忽略则为空
        /// </summary>
        public int? DateOfBirthMinimumAge { get; set; }

        /// <summary>
        /// 是否启用“公司”
        /// </summary>
        public bool CompanyEnabled { get; set; }

        /// <summary>
        /// 是否需要公司
        /// </summary>
        public bool CompanyRequired { get; set; }

        /// <summary>
        /// 是否启用“街道地址”
        /// </summary>
        public bool StreetAddressEnabled { get; set; }

        /// <summary>
        /// 是否需要街道地址
        /// </summary>
        public bool StreetAddressRequired { get; set; }

        /// <summary>
        /// 是否启用“街道地址2”
        /// </summary>
        public bool StreetAddress2Enabled { get; set; }

        /// <summary>
        /// 是否需要街道地址2
        /// </summary>
        public bool StreetAddress2Required { get; set; }

        /// <summary>
        /// 是否启用了“Zip /邮政编码”
        /// </summary>
        public bool ZipPostalCodeEnabled { get; set; }

        /// <summary>
        /// Zip /邮政编码 是否必须
        /// </summary>
        public bool ZipPostalCodeRequired { get; set; }

        /// <summary>
        /// 是否启用城市
        /// </summary>
        public bool CityEnabled { get; set; }

        /// <summary>
        /// 城市是否需要
        /// </summary>
        public bool CityRequired { get; set; }

        /// <summary>
        /// 是否启用地区
        /// </summary>
        public bool CountyEnabled { get; set; }

        /// <summary>
        /// 地区是否需要
        /// </summary>
        public bool CountyRequired { get; set; }

        /// <summary>
        ///是否启用国家
        /// </summary>
        public bool CountryEnabled { get; set; }

        /// <summary>
        /// 国家是否需要
        /// </summary>
        public bool CountryRequired { get; set; }

        /// <summary>
        /// 是否启用“州/省”
        /// </summary>
        public bool StateProvinceEnabled { get; set; }

        /// <summary>
        /// 州/省是否需要
        /// </summary>
        public bool StateProvinceRequired { get; set; }

        /// <summary>
        /// 是否启用手机号
        /// </summary>
        public bool PhoneEnabled { get; set; }

        /// <summary>
        /// 手机号是否必须
        /// </summary>
        public bool PhoneRequired { get; set; }

        /// <summary>
        /// 是否启用传真
        /// </summary>
        public bool FaxEnabled { get; set; }

        /// <summary>
        /// 传真是否必须
        /// </summary>
        public bool FaxRequired { get; set; }

        /// <summary>
        /// 是否应在注册期间接受隐私政策
        /// </summary>
        public bool AcceptPrivacyPolicyEnabled { get; set; }

        #endregion

    }
}
