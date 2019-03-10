using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolBinario
{
    public class Medicamento
    {
       public int Id { get; set; }
        public string  Nombre { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
        public string descripcion { get; set; }
        public string Productora { get; set; }
    }
}
