//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BitirmeProjesi.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class FromUserToVetMessages
    {
        public long Id { get; set; }
        public string ContentMessage { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<long> FromUserId { get; set; }
        public Nullable<long> ToVetId { get; set; }
        public Nullable<long> QuestionsId { get; set; }
        public Nullable<int> Status { get; set; }
    
        public virtual Questions Questions { get; set; }
    }
}
