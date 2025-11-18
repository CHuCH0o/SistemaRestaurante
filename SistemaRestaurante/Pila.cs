using System;

namespace SistemaRestaurante;

// esta es una pila simple
// ultimo en entrar primero en salir
public class Pila<T>

{
    private Nodo<T> superior;

    public Pila()
    {
        superior = null;
    }

    // agrega un elemento arriba
    public void AgregarElemento(T valor)
    {
        Nodo<T> nuevo = new Nodo<T>(valor);
        nuevo.Siguiente = superior;
        superior = nuevo;
    }

    // devuelve el superior sin quitar
    public T ObtenerSuperior()
    {
        if (superior == null)
        {
            return default(T);
        }
        return superior.Valor;
    }

    // quita el superior
    public void EliminarSuperior()
    {
        if (superior == null)
        {
            return;
        }
        superior = superior.Siguiente;
    }

    // revisa si esta vacia
    public bool EstaVacia()
    {
        return superior == null;
    }

    // recorre la pila
    public void Recorrer(Action<T> accion)
    {
        Nodo<T> actual = superior;
        while (actual != null)
        {
            accion(actual.Valor);
            actual = actual.Siguiente;
        }
    }
}
