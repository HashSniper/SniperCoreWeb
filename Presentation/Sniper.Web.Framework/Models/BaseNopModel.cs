using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Sniper.Web.Framework.Models
{
    /// <summary>
    /// 代表基本的nopCommerce模型
    /// </summary>
    public class BaseNopModel
    {
        #region Ctor
        public BaseNopModel()
        {
            CustomProperties = new Dictionary<string, object>();
            PostInitialize();
        }
        #endregion

        #region Methods

        public virtual void BindModel(ModelBindingContext bindingContext)
        {
        }

        /// <summary>
        /// Perform additional actions for the model initialization
        /// </summary>
        /// <remarks>Developers can override this method in custom partial classes in order to add some custom initialization code to constructors</remarks>
        protected virtual void PostInitialize()
        {
        }

        #endregion

        #region Properties

        [XmlIgnore]
        public Dictionary<string, object> CustomProperties { get; set; }
        #endregion

    }
}
