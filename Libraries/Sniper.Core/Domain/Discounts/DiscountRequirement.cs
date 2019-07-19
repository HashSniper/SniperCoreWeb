using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Discounts
{
    public partial class DiscountRequirement : BaseEntity
    {
        private ICollection<DiscountRequirement> _childRequirements;

        /// <summary>
        /// 账号标识符
        /// </summary>
        public int DiscountId { get; set; }

        /// <summary>
        /// 折扣要求规则系统名称
        /// </summary>
        public string DiscountRequirementRuleSystemName { get; set; }

        /// <summary>
        /// ParentId
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        /// 交互类型标识符（具有组的值，子请求为null）
        /// </summary>
        public int? InteractionTypeId { get; set; }

        /// <summary>
        /// 是否具有任何子要求的值
        /// </summary>
        public bool IsGroup { get; set; }

        /// <summary>
        /// 交互类型
        /// </summary>
        public RequirementGroupInteractionType? InteractionType
        {
            get => (RequirementGroupInteractionType?)InteractionTypeId;
            set => InteractionTypeId = (int?)value;
        }

        /// <summary>
        /// 账号
        /// </summary>
        public virtual Discount Discount { get; set; }

        /// <summary>
        /// 儿童折扣要求
        /// </summary>
        public virtual ICollection<DiscountRequirement> ChildRequirements
        {
            get => _childRequirements ?? (_childRequirements = new List<DiscountRequirement>());
            protected set => _childRequirements = value;
        }

    }
}
