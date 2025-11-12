using System;

namespace SistemaRestaurante
{
    // esta clase guarda los datos del pedido

    public class Pedido
    {
        public string IdPedido;
        public Cliente ClientePedido;
        public ListaEnlazada<PlatoPedido> PlatosPedido;
        public decimal Total;
        public DateTime FechaHora;
        public string Estado; // pendiente o despachado

        // esta clase guarda un plato dentro del pedido
        public class PlatoPedido
        {
            public Plato Plato;
            public int Cantidad;
            public decimal Subtotal;
        }
    }
}