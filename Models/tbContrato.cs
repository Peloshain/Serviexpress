//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiExpress.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbContrato
    {
        public tbContrato()
        {
            this.tbPagos = new HashSet<tbPagos>();
        }
    
        public int IdContrato { get; set; }
        public Nullable<int> idCliente { get; set; }
        public string NombreCliente { get; set; }
        public Nullable<int> Monto { get; set; }
        public Nullable<System.DateTime> FechaInicio { get; set; }
        public Nullable<System.DateTime> FechaFin { get; set; }
        public Nullable<int> tipo { get; set; }
    
        public virtual tbClientes tbClientes { get; set; }
        public virtual tbTipoContrato tbTipoContrato { get; set; }
        public virtual ICollection<tbPagos> tbPagos { get; set; }
    }
}
