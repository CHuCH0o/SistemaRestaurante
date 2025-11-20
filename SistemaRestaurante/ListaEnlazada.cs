namespace SistemaRestaurante
{
    // esta es una lista enlazada simple
    // no usa list de dotnet
    // aqui guardamos muchos elementos en nodos

    public class ListaEnlazada<T>
    {
        public Nodo<T> Cabeza;

        public ListaEnlazada()
        {
            Cabeza = null;
        }

        // agrega al final de la lista
        public void Agregar(T valor)
        {
            // creamos un nodo nuevo
            Nodo<T> nuevo = new Nodo<T>(valor);

            // si la lista esta vacia
            if (Cabeza == null)
            {
                Cabeza = nuevo;
                return;
            }

            // si ya hay nodos buscamos el ultimo
            Nodo<T> actual = Cabeza;
            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }

            // aqui conectamos el nuevo al final
            actual.Siguiente = nuevo;
        }

        // devuelve la cantidad de elementos
        public int Longitud()
        {
            int contador = 0;
            Nodo<T> actual = Cabeza;
            while (actual != null)
            {
                contador++;
                actual = actual.Siguiente;
            }
            return contador;
        }

        // devuelve el elemento en una posicion
        public T ObtenerPorIndice(int indice)
        {
            int i = 0;
            Nodo<T> actual = Cabeza;
            while (actual != null)
            {
                if (i == indice)
                {
                    return actual.Valor;
                }
                i++;
                actual = actual.Siguiente;
            }

            return default(T);
        }

        // elimina el elemento en una posicion
        public void EliminarPorIndice(int indice)
        {
            if (indice < 0)
            {
                return;
            }

            if (Cabeza == null)
            {
                return;
            }

            if (indice == 0)
            {
                // si es el primero movemos la cabeza
                Cabeza = Cabeza.Siguiente;
                return;
            }

            int i = 0;
            Nodo<T> actual = Cabeza;
            Nodo<T> anterior = null;

            while (actual != null)
            {
                if (i == indice)
                {
                    // aqui quitamos el nodo saltandolo
                    if (anterior != null)
                    {
                        anterior.Siguiente = actual.Siguiente;
                    }
                    return;
                }
                i++;
                anterior = actual;
                actual = actual.Siguiente;
            }
        }

        // recorre toda la lista y ejecuta una accion
        public void Recorrer(Action<T> accion)
        {
            Nodo<T> actual = Cabeza;
            while (actual != null)
            {
                accion(actual.Valor);
                actual = actual.Siguiente;
            }
        }
    }
}
