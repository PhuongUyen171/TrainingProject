//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class PERMISION
    {
        public int RoleID { get; set; }
        public string GroupID { get; set; }
        public Nullable<bool> PerID { get; set; }
    
        public virtual GROUPADMIN GROUPADMIN { get; set; }
        public virtual ROLE ROLE { get; set; }
    }
}
