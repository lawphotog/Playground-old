//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DurhamUniversity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Course
    {
        public Course()
        {
            this.Students = new HashSet<Student>();
            this.Modules = new HashSet<Module>();
        }
    
        public int Id { get; set; }
        public string Title { get; set; }
    
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Module> Modules { get; set; }
    }
}
