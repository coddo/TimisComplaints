//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TimisComplaints.DataLayer
{
    using System;
    using System.Collections.Generic;
    using TimisComplaints.DataLayer.Interfaces;
    
    public partial class Problem : IEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Problem()
        {
            this.UserProblems = new HashSet<UserProblem>();
            this.Districts = new HashSet<District>();
        }
    
        public System.Guid Id { get; set; }
        public System.Guid UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserProblem> UserProblems { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<District> Districts { get; set; }
        public virtual User User { get; set; }
    }
}
