using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiExpress.Models
{
    public class Pago
    {
        public int Amount { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string SecurityCode { get; set; }
        public string Token { get; set; }
    }
}