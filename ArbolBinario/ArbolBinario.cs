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
    

        //ELIMINA Y REAJUSTA LOS NODOS 
        void Reajuste1(Nodo nNodo)
        {
            if (nNodo.izquierdo != null)
            {
                if (nNodo.Derecho == null)
                {
                    nNodo.Derecho = nNodo.izquierdo;
                    nNodo.izquierdo = null;
                }
                else
                {
                    Reajuste1(nNodo.Derecho);
                    nNodo.Derecho.izquierdo = nNodo.izquierdo;
                    nNodo.izquierdo = null;
                }
            }
        }
        void BuscaEliminar(Nodo nNodo, int data)
        {
            bool salir = false;
            if (nNodo != null && nNodo.Medicamento.Id != data && salir != true)
            {
                if (nNodo.Derecho != null)
                {
                    if (nNodo.Derecho.Medicamento.Id == data)
                    {
                        salir = true;
                    }
                    else
                    {
                        if (data > nNodo.Medicamento.Id)
                        {
                            BuscaEliminar(nNodo.Derecho, data);
                        }
                        if (nNodo.izquierdo != null && data < nNodo.Medicamento.Id)
                        {
                            BuscaEliminar(nNodo.izquierdo, data);
                        }
                    }
                }
                else if (nNodo.izquierdo != null)
                {
                    if (nNodo.izquierdo.Medicamento.Id == data)
                    {
                        salir = true;
                    }
                    else
                    {
                        if (data < nNodo.Medicamento.Id)
                        {
                            BuscaEliminar(nNodo.izquierdo, data);
                        }
                        else if (nNodo.Derecho != null && data > nNodo.Medicamento.Id)
                        {
                            BuscaEliminar(nNodo.Derecho, data);
                        }
                    }
                }

            }
            if (nNodo.izquierdo != null && nNodo.izquierdo.Medicamento.Id == data)
            {
                if (nNodo.izquierdo.izquierdo == null && nNodo.izquierdo.Derecho == null)
                {
                    nNodo.izquierdo = null;
                }
                else
                {
                    Reajuste1(nNodo.izquierdo);
                    if (nNodo.izquierdo.Derecho != null)
                    {
                        nNodo.izquierdo = nNodo.izquierdo.Derecho;
                    }
                }
                ContadorNodos--;
            }
            if (nNodo.Derecho != null && nNodo.Derecho.Medicamento.Id == data)
            {
                if (nNodo.Derecho.izquierdo == null && nNodo.Derecho.Derecho == null)
                {
                    nNodo.Derecho = null ;
                }
                else
                {
                    Reajuste1(nNodo.Derecho);
                    if (nNodo.Derecho.Derecho != null)
                    {
                        nNodo.Derecho = nNodo.Derecho.Derecho;
                    }
                }
                ContadorNodos--;
            }
        }
        public void EliminarElemento(int piCodigoElemento)
        {
            if (Raiz.Medicamento.Id == piCodigoElemento)
            {
                if (Raiz.Derecho!= null)
                {
                    Reajuste1(Raiz);
                    Raiz = Raiz.Derecho;
                    ContadorNodos--;
                }
                else if (Raiz.izquierdo != null)
                {
                    Reajuste1(Raiz);
                    Raiz = Raiz.Derecho;
                    ContadorNodos--;
                }
                else
                {
                    Raiz = null;
                    ContadorNodos--;
                }
            }
            else
            {
                BuscaEliminar(Raiz, piCodigoElemento);
            }
        }

        //BUSCAR UN ELEMENTO, REGRESA UN NODO
        public Nodo AuxBusqueda; // VARIABLE PARA GUARDAR EL ELEMENTO ENCONTRADO
        public Nodo BuscaRegresa(Medicamento data)
        {
            AuxBusqueda = null;
            Busca(Raiz, data.Id);
            return AuxBusqueda;
        }
        void Busca(Nodo nNodo, int data)
        {
            if (nNodo != null && nNodo.Medicamento.Id != data)
            {
                if (data < nNodo.Medicamento.Id)
                {
                    Busca(nNodo.izquierdo, data);
                }
                if (data > nNodo.Medicamento.Id)
                {
                    Busca(nNodo.Derecho, data);
                }
            }
            if (nNodo.Medicamento.Id == data)
            {
                AuxBusqueda = nNodo;
            }
        }
        

        //BUSCA UN ELEMENTO PARA ACTUALIZAR SUS DATOS 
        public void ActualizaDatos(Medicamento data)
        {
            BuscaActualiza(Raiz, data);
        }
        void BuscaActualiza(Nodo nNodo, Medicamento data)
        {
            if (nNodo != null && nNodo.Medicamento.Id != data.Id)
            {
                if (data.Id < nNodo.Medicamento.Id)
                {
                    BuscaActualiza(nNodo.izquierdo, data);
                }
                if (data.Id > nNodo.Medicamento.Id)
                {
                    BuscaActualiza(nNodo.Derecho, data);
                }
            }
            if (nNodo.Medicamento.Id == data.Id)
            {
                nNodo.Medicamento = data;
            }
        }

        //REGRESA UN VECTOR DE MEDICAMENTOS SEGUN PRE(0), POST(1), INORDEN(2) PARA MOSTRAR AL USUARIO
        public Medicamento[] medicamentos; //VAR universal para guardar medicamentos
        public int AA;
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
