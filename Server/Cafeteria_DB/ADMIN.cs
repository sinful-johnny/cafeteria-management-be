//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cafeteria_DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class ADMIN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ADMIN()
        {
            this.CANVA_ADMIN = new HashSet<CANVA_ADMIN>();
        }
    
        public string ID_ADMIN { get; set; }
        public string EMAIL { get; set; }
        public byte[] PASSWORDHASH { get; set; }
        public byte[] SALT { get; set; }
        public Nullable<System.DateTime> CREATED_AT { get; set; }
        public Nullable<System.DateTime> UPDATE_AT { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CANVA_ADMIN> CANVA_ADMIN { get; set; }
    }
}
