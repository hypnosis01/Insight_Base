//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Insight.WS.Base.Common.Entity
{
    using System;
    
    public partial class RoleAction
    {
        public Nullable<System.Guid> ID { get; set; }
        public Nullable<System.Guid> ParentId { get; set; }
        public System.Guid ActionId { get; set; }
        public Nullable<int> Index { get; set; }
        public int Type { get; set; }
        public string Action { get; set; }
        public Nullable<int> Permit { get; set; }
        public string Description { get; set; }
        public Nullable<int> state { get; set; }
    }
}
