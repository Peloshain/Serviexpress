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
    
    public partial class tbFacturas_Recibos
    {
        public int idFactura_Recibo { get; set; }
        public Nullable<int> idTransaccion { get; set; }
        public Nullable<int> idCliente { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string RFC { get; set; }
    
        public virtual tbPagos tbPagos { get; set; }
    }
}
