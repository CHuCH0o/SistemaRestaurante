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
    }
}