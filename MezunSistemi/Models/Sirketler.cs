//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MezunSistemi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sirketler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sirketler()
        {
            this.Ilanlar = new HashSet<Ilanlar>();
            this.Mezunlar = new HashSet<Mezunlar>();
            this.Mezunlar_Sirketler = new HashSet<Mezunlar_Sirketler>();
            this.Sirketin_Departmanlari = new HashSet<Sirketin_Departmanlari>();
        }
    
        public int Sirket_Id { get; set; }
        public string Sirket_Adi { get; set; }
        public string Adres { get; set; }
        public string Sirket_TelNo { get; set; }
        public string Sirket_Mail { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ilanlar> Ilanlar { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Mezunlar> Mezunlar { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Mezunlar_Sirketler> Mezunlar_Sirketler { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sirketin_Departmanlari> Sirketin_Departmanlari { get; set; }
    }
}
