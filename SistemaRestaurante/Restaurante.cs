using System;

namespace SistemaRestaurante
{
    // esta clase guarda los datos del restaurante

    public class Restaurante
    {
        public string Nit;
        public string Nombre;
        public string Dueno;
        public string Celular;
        public string Direccion;
        
        // estas son las listas relacionadas con el restaurante
        public ListaEnlazada<Cliente> Clientes;
        public ListaEnlazada<Plato> Platos;
        public Cola<Pedido> ColaPedidos;
        public Pila<Pedido> HistorialPedidos;
        public decimal GananciasDia;

        // constructor para dejar todo listo
        public Restaurante()
        {
            Clientes = new ListaEnlazada<Cliente>();
            Platos = new ListaEnlazada<Plato>();
            ColaPedidos = new Cola<Pedido>();
            HistorialPedidos = new Pila<Pedido>();
            GananciasDia = 0;
            
        }

        // aqui reviso que el celular tenga diez numeros
        public static bool EsCelularValido(string celular)
        {
            if (string.IsNullOrWhiteSpace(celular))
            {
                return false;
            }

            if (celular.Length != 10)
            {
                return false;
            }

            foreach (char c in celular)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }

            return true;
        }

        // aqui busco un restaurante por nit en la lista
        public static Restaurante BuscarPorNit(ListaEnlazada<Restaurante> restaurantes, string nit)
        {
            Nodo<Restaurante> actual = restaurantes.Cabeza;
            while (actual != null)
            {
                if (actual.Valor.Nit == nit)
                {
                    return actual.Valor;
                }
                actual = actual.Siguiente;
            }
            return null;
        }
    }
}