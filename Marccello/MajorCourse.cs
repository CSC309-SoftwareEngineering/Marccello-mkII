//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Marccello
{
    using System;
    using System.Collections.Generic;
    
    public partial class MajorCourse
    {
        public Nullable<int> major_id { get; set; }
        public Nullable<int> course_id { get; set; }
        public int p_key { get; set; }
    
        public virtual Course Course { get; set; }
        public virtual Major Major { get; set; }
    }
}