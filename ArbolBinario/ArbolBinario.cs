using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolBinario
{
    public class ArbolBinario
    {
        public Nodo Raiz;
        public static int ContadorNodos = 0;
        //public int Count => throw new NotImplementedException();
        //public bool IsReadOnly => throw new NotImplementedException();

        public static void Main ()
        {
            throw new NotImplementedException();
        }
        //AGREGA UN NUEVO ELEMENTO
        public void AgregarElemento(Medicamento item)
        {
            Nodo nuevo= new Nodo(item);
            nuevo.izquierdo = null;
            nuevo.Derecho = null;
            if (Raiz == null)
            {
                Raiz = nuevo;
            }
            else
            {
                Nodo anterior = null;
                Nodo recorre = null;
                recorre = Raiz;
                while (recorre != null)
                {
                    anterior = recorre;
                    int comparison = String.Compare(item.Nombre, recorre.Medicamento.Nombre, comparisonType: StringComparison.OrdinalIgnoreCase);

                    if (comparison<1)
                        recorre = recorre.izquierdo;
                    else
                        recorre = recorre.Derecho;
                }
                int comparison2 = String.Compare(item.Nombre, anterior.Medicamento.Nombre, comparisonType: StringComparison.OrdinalIgnoreCase);
                if (comparison2 < 1)
                    anterior.izquierdo = nuevo;
                else
                    anterior.Derecho = nuevo;
            }
        }
    

        public void EliminarElemento(Medicamento item)
        {
            Nodo anterior = null;
            Nodo recorre = null;
            Nodo AUX = null;
            recorre = Raiz;
            while (recorre != null && recorre.Medicamento !=null && recorre.Medicamento.Nombre != item.Nombre)
            {
                anterior = recorre;
                int comparison = String.Compare(item.Nombre, recorre.Medicamento.Nombre, comparisonType: StringComparison.OrdinalIgnoreCase);

                if (comparison < 1)
                    recorre = recorre.izquierdo;
                else
                    recorre = recorre.Derecho;
            }
            Nodo guarda = null;
            if (recorre != null && recorre.izquierdo ==null && recorre.Derecho == null)
                recorre.Medicamento = null;

            if (recorre != null && recorre.izquierdo == null && recorre.Derecho != null)
            {
                guarda = recorre.Derecho;
                recorre.Derecho.Medicamento = null;
                recorre.Medicamento = guarda.Medicamento;
            }
            

            if (recorre != null && recorre.izquierdo != null && recorre.Derecho == null)
            {
                guarda = recorre.izquierdo;
                recorre.izquierdo.Medicamento = null;
                recorre.Medicamento = guarda.Medicamento;
            }

            if (recorre != null && recorre.izquierdo != null && recorre.Derecho != null)
            {                
                Nodo recorre2 = null;
                Nodo ant2 = null;
                recorre2 = recorre.Derecho;
                while (recorre2 != null)
                {
                    ant2 = recorre2;
                    recorre2 = recorre2.izquierdo;
                }
                AUX = ant2;
                if (ant2.Derecho != null)
                {
                    guarda = ant2.Derecho;
                    ant2.Derecho = null;
                    recorre.Derecho = guarda;
                    recorre.Medicamento = AUX.Medicamento;
                }
                else
                {
                    recorre.Medicamento = AUX.Medicamento;
                    ant2.Medicamento = null;
                }
            }
        }

        //BUSCAR UN ELEMENTO, REGRESA UN NODO
        Nodo AuxBusqueda; // VARIABLE PARA GUARDAR EL ELEMENTO ENCONTRADO
        public Nodo BuscaRegresa(Medicamento data)
        {
            AuxBusqueda = null;
            Busca(Raiz, data);
            return AuxBusqueda;
        }
        void Busca(Nodo nNodo, Medicamento item)
        { 
            Nodo recorre = null;
            recorre = Raiz;
            while (recorre.Medicamento.Nombre != item.Nombre && recorre!= null)
            {
                int comparison = String.Compare(item.Nombre, recorre.Medicamento.Nombre, comparisonType: StringComparison.OrdinalIgnoreCase);

                if (comparison < 1)
                    recorre = recorre.izquierdo;
                else
                    recorre = recorre.Derecho;
            }
            AuxBusqueda = recorre;
        }
        

        //BUSCA UN ELEMENTO PARA ACTUALIZAR SUS DATOS 
        public void ActualizaDatos(Medicamento data)
        {
            BuscaActualiza(Raiz, data);
        }
        void BuscaActualiza(Nodo nNodo, Medicamento item)
        {
            Nodo recorre = null;
            recorre = Raiz;
            while (recorre.Medicamento.Nombre != item.Nombre && recorre != null)
            {
                int comparison = String.Compare(item.Nombre, recorre.Medicamento.Nombre, comparisonType: StringComparison.OrdinalIgnoreCase);

                if (comparison < 1)
                    recorre = recorre.izquierdo;
                else
                    recorre = recorre.Derecho;
            }
            if (recorre.Medicamento.Nombre == item.Nombre && recorre != null)
                recorre.Medicamento.Cantidad = item.Cantidad;
        }

        //REGRESA UN VECTOR DE MEDICAMENTOS SEGUN PRE(0), POST(1), INORDEN(2) PARA MOSTRAR AL USUARIO
        Medicamento[] medicamentos; //VAR universal para guardar medicamentos
        int AA;
        public Medicamento[] Mostrar(int opcion, int cant)
        {
            medicamentos = new Medicamento[cant];
            AA = 0;
            switch (opcion)
            {
                case 1: postOrden(Raiz); break;
                case 2: preOrden(Raiz); break;
                case 3: enOrden(Raiz); break;
            }
            return medicamentos;
        }
        
        void postOrden(Nodo nNodo)
        {
            if (nNodo != null)
            {
                postOrden(nNodo.izquierdo);
                postOrden(nNodo.Derecho);
                medicamentos[AA] = nNodo.Medicamento;
                AA++;
            }
            
        }
        void preOrden(Nodo nNodo)
        {
            if (nNodo != null)
            {
                medicamentos[AA] = nNodo.Medicamento;
                AA++;
                preOrden(nNodo.izquierdo);
                preOrden(nNodo.Derecho);
            }
        }
        void enOrden(Nodo nNodo)
        {
            if (nNodo != null)
            {
                enOrden(nNodo.izquierdo);
                medicamentos[AA] = nNodo.Medicamento;
                AA++;
                enOrden(nNodo.Derecho);
            }
        }
    }
}
