using Sniper.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Security
{
    public class CaptchaSettings:ISettings
    {
        /// <summary>
        /// 是否启用验证码
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// 在登陆页是否启用验证码
        /// </summary>
        public bool ShowOnLoginPage { get; set; }

        /// <summary>
        /// 注册页是否使用验证码
        /// </summary>
        public bool ShowOnRegistrationPage { get; set; }

        /// <summary>
        /// 联系页面是否启用验证码
        /// </summary>
        public bool ShowOnContactUsPage { get; set; }

        /// <summary>
        /// 邮件页是否启用验证码
        /// </summary>
        public bool ShowOnEmailWishlistToFriendPage { get; set; }

        /// <summary>
        /// 是否显示在产品邮件上
        /// </summary>
        public bool ShowOnEmailProductToFriendPage { get; set; }

        /// <summary>
        /// 是否显示在博客页面上
        /// </summary>
        public bool ShowOnBlogCommentPage { get; set; }

        /// <summary>
        /// 是否显示在新闻页上
        /// </summary>
        public bool ShowOnNewsCommentPage { get; set; }

        /// <summary>
        /// 是否显示在产品预览上
        /// </summary>
        public bool ShowOnProductReviewPage { get; set; }

        /// <summary>
        /// 是否显示在供应商页上
        /// </summary>
        public bool ShowOnApplyVendorPage { get; set; }

        /// <summary>
        /// 是否显示在忘记密码页面上
        /// </summary>
        public bool ShowOnForgotPasswordPage { get; set; }

        /// <summary>
        /// 验证码
        /// </summary>
        public string ReCaptchaPublicKey { get; set; }

        /// <summary>
        ///私有
        /// </summary>
        public string ReCaptchaPrivateKey { get; set; }

        /// <summary>
        /// 主题
        /// </summary>
        public string ReCaptchaTheme { get; set; }

        /// <summary>
        /// 是否自动选择验证码语言
        /// </summary>
        public bool AutomaticallyChooseLanguage { get; set; }
    }
}
