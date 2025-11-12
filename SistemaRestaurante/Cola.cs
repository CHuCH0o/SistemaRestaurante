using System;


namespace SistemaRestaurante

{
    // esta es una cola simple
    // primero entra primero sale

    public class Cola<T>
    {
        private Nodo<T> cabeza;
        private Nodo<T> cola;

        public Cola()
        {
            cabeza = null;
            cola = null;
        }

        // agrega un valor al final de la cola
        public void Agregar(T valor)
        {
            Nodo<T> nuevo = new Nodo<T>(valor);

            if (cabeza == null)
            {
                cabeza = nuevo;
                cola = nuevo;
            }
            else
            {
                cola.Siguiente = nuevo;
                cola = nuevo;
            }
        }

        // devuelve el primero sin quitarlo
        public T Primero()
        {
            if (cabeza == null)
            {
                return default(T);
            }
            return cabeza.Valor;
        }

        // quita el primero
        public void Eliminar()
        {
            if (cabeza == null)
            {
                return;
            }

            cabeza = cabeza.Siguiente;
            if (cabeza == null)
            {
                cola = null;
            }
        }

        // revisa si esta vacia
        public bool EstaVacia()
        {
            return cabeza == null;
        }

        // recorre la cola
        public void Recorrer(Action<T> accion)
        {
            Nodo<T> actual = cabeza;
            while (actual != null)
            {
                accion(actual.Valor);
                actual = actual.Siguiente;
            }
        }
    }
}
