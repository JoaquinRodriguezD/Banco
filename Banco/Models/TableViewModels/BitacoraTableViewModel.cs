using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Banco.Models.TableViewModels
{
    public class BitacoraTableViewModel
    {
        public string Tipo { get; set; }
        public DateTime Fecha_hora { get; set; }
        public int Monto { get; set; }
        public string Estado { get; set; }
    }
}