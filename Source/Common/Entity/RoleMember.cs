//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Insight.Base.Common.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class RoleMember
    {
        public System.Guid ID { get; set; }
        public Nullable<int> ParentId { get; set; }
        public System.Guid RoleId { get; set; }
        public System.Guid MemberId { get; set; }
        public long Index { get; set; }
        public int NodeType { get; set; }
        public string Name { get; set; }
    }
}
