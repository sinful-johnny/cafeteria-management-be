//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IdentityCafeteriaModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class AspNetMenu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AspNetMenu()
        {
            this.AspNetMenu1 = new HashSet<AspNetMenu>();
            this.AspNetRoleMenus = new HashSet<AspNetRoleMenu>();
            this.AspNetRoleMenus1 = new HashSet<AspNetRoleMenu>();
        }
    
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Nullable<int> ParentId { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AspNetMenu> AspNetMenu1 { get; set; }
        public virtual AspNetMenu AspNetMenu2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AspNetRoleMenu> AspNetRoleMenus { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AspNetRoleMenu> AspNetRoleMenus1 { get; set; }
    }
}
