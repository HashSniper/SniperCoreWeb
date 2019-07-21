using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Topics
{
    public partial class TopicTemplate : BaseEntity
    {
        public string Name { get; set; }

        public string ViewPath { get; set; }

        public int DisplayOrder { get; set; }

    }
}
