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
    
    public partial class Semester
    {
        public Semester()
        {
            this.SemesterCourses = new HashSet<SemesterCourse>();
        }
    
        public int semester_id { get; set; }
        public string term { get; set; }
        public int semester_year { get; set; }
    
        public virtual ICollection<SemesterCourse> SemesterCourses { get; set; }
    }
}
