//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace zadatak1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class Studenti
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Studenti()
        {
            this.Ispitis = new HashSet<Ispiti>();
        }

        [DisplayName("Indeks:")]
        public int indeks { get; set; }

        [DisplayName("Ime:")]
        public string ime { get; set; }

        [DisplayName("Prezime:")]
        public string prezime { get; set; }

        [DisplayName("Smer:")]
        public string smer { get; set; }

        [DisplayName("E-mail:")]
        public string email { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ispiti> Ispitis { get; set; }
    }
}