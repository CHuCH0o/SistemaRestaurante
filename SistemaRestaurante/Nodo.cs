namespace SistemaRestaurante
{
    // esta clase es un nodo generico
    // guarda un valor y el siguiente nodo

    public class Nodo<T>
    {
        public T Valor;
        public Nodo<T> Siguiente;

        // constructor simple
        public Nodo(T valor)
        {
            Valor = valor;
            Siguiente = null;
        }
    }
}