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
    
    public partial class Mezun_Gonderileri
    {
        public int MezunGonderi_Id { get; set; }
        public int Mezun_Id { get; set; }
        public string Gonderi_Basligi { get; set; }
        public string Gonderi_Icerigi { get; set; }
        public Nullable<int> Ilan_Id { get; set; }
        public System.DateTime Tarih { get; set; }
    
        public virtual Mezunlar Mezunlar { get; set; }
    }
}
