//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CafeteriaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class FOOD_TYPE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FOOD_TYPE()
        {
            this.FOOD_TABLE = new HashSet<FOOD_TABLE>();
        }

        [Key]
        public string ID_FOOD { get; set; }
        public string FOOD_NAME { get; set; }
        public Nullable<int> AMOUNT_LEFT { get; set; }
        public Nullable<decimal> PRICE { get; set; }
        public string FOOD_TYPE_STATUS { get; set; }
        public string FOOD_TYPENAME { get; set; }
        public Nullable<System.DateTime> CREATED_AT { get; set; }
        public Nullable<System.DateTime> UPDATE_AT { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FOOD_TABLE> FOOD_TABLE { get; set; }
    }
}
