//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UPC.Paneando.DA
{
    using System;
    using System.Collections.Generic;
    
    public partial class pedido
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public pedido()
        {
            this.ordens = new HashSet<orden>();
            this.pedido_detalle = new HashSet<pedido_detalle>();
            this.pedido_fecha = new HashSet<pedido_fecha>();
        }
    
        public int id_pedido { get; set; }
        public Nullable<int> id_cliente { get; set; }
        public System.DateTime fecha { get; set; }
        public string direccion { get; set; }
        public string email { get; set; }
        public int estado { get; set; }
        public System.DateTime fecha_inicio { get; set; }
        public System.DateTime fecha_fin { get; set; }
        public Nullable<System.TimeSpan> hora_minuto { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<orden> ordens { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pedido_detalle> pedido_detalle { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pedido_fecha> pedido_fecha { get; set; }
    }
}
