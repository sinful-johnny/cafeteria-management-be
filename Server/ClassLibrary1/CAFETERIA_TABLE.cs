//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClassLibrary1
{
    using System;
    using System.Collections.Generic;
    
    public partial class CAFETERIA_TABLE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CAFETERIA_TABLE()
        {
            this.FOOD_TABLE = new HashSet<FOOD_TABLE>();
        }
    
        public string ID_TABLE { get; set; }
        public Nullable<double> X_COORDINATE { get; set; }
        public Nullable<double> Y_COORDINATE { get; set; }
        public string ID_SHAPE { get; set; }
        public string ID_CANVA { get; set; }
        public string ID_ADMIN { get; set; }
        public string TABLE_STATUS { get; set; }
        public Nullable<System.DateTime> CREATED_AT { get; set; }
        public Nullable<System.DateTime> UPDATE_AT { get; set; }
    
        public virtual SHAPE_TYPE SHAPE_TYPE { get; set; }
        public virtual CANVA_ADMIN CANVA_ADMIN { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FOOD_TABLE> FOOD_TABLE { get; set; }
    }
}
