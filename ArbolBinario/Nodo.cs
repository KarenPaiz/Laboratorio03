using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolBinario
{
    public class Nodo
    {
        public Medicamento Medicamento;
        public Nodo Padre;
        public Nodo izquierdo;
        public Nodo Derecho;
        public Nodo()
        { }
        public Nodo(Medicamento Medicamento)
        {
            this.Medicamento = Medicamento;
        }
        //public Nodo(Medicamento medicamento, Nodo izquierdo, Nodo derecho, Nodo padre)
        //{
        //    this.Medicamento = medicamento;
        //    this.izquierdo = izquierdo;
        //    this.Derecho = derecho;
        //    this.Padre = padre;
        //}
        public bool EsRaiz()
        {
            if (Padre != null)
                return false;

            return true;
        }
        public bool ExisteIzquiero()
        {
            if (izquierdo != null)
                return true;

            return false;
        }
        public bool ExisteDerecho()
        {
            if (Derecho != null)
                return true;

            return false;
        }
        public bool TieneMedicamento()
        {
            if (Medicamento != null)
                return true;

            return false;
        }
    }
    

}
