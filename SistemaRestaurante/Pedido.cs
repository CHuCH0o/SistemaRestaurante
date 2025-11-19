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

 // constructor deja la lista lista
        public Pedido()
        {
            PlatosPedido = new ListaEnlazada<PlatoPedido>();
        }
        
        // tomar pedido

        public static void TomarPedido(Restaurante r)
        {
            Console.Clear();
            Console.WriteLine("=== TOMAR PEDIDO ===");

            // verifico que haya clientes
            if (r.Clientes.Cabeza == null)
            {
                Console.WriteLine("no hay clientes en este restaurante");
                Console.ReadLine();
                return;
            }

            // verifico que haya platos
            if (r.Platos.Cabeza == null)
            {
                Console.WriteLine("no hay platos en este restaurante");
                Console.ReadLine();
                return;
            }

            // escoger cliente
            Console.WriteLine("elija el cliente");
            Cliente cli = Cliente.SeleccionarCliente(r);
            if (cli == null)
            {
                return;
            }

            Pedido p = new Pedido();
            p.IdPedido = Guid.NewGuid().ToString();
            p.ClientePedido = cli;
            p.FechaHora = DateTime.Now;
            p.Estado = "PENDIENTE";

            // agregar platos
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== AGREGAR PLATO AL PEDIDO ===");

                Plato pla = Plato.SeleccionarPlato(r);
                if (pla == null)
                {
                    break;
                }

                Console.Write("cantidad: ");
                string txt = Console.ReadLine();
                int cantidad;
                if (!int.TryParse(txt, out cantidad) || cantidad <= 0)
                {
                    Console.WriteLine("cantidad invalida");
                    Console.ReadLine();
                    continue;
                }

                PlatoPedido pp = new PlatoPedido();
                pp.Plato = pla;
                pp.Cantidad = cantidad;
                pp.Subtotal = pla.Precio * cantidad;

                p.PlatosPedido.Agregar(pp);

                Console.Write("agregar otro plato s n: ");
                string mas = Console.ReadLine();
                if (mas == null || mas.ToLower() != "s")
                {
                    break;
                }
            }

            // total
            decimal total = 0;
            Nodo<PlatoPedido> act = p.PlatosPedido.Cabeza;
            while (act != null)
            {
                total += act.Valor.Subtotal;
                act = act.Siguiente;
            }
            p.Total = total;

            if (p.Total <= 0)
            {
                Console.WriteLine("pedido sin platos no se guarda");
                Console.ReadLine();
                return;
            }

            // resumen
            Console.Clear();
            Console.WriteLine("=== RESUMEN DEL PEDIDO ===");
            Console.WriteLine("cliente: " + cli.Cedula + " - " + cli.NombreCompleto);

            act = p.PlatosPedido.Cabeza;
            while (act != null)
            {
                Console.WriteLine("- " + act.Valor.Plato.Nombre + " x " + act.Valor.Cantidad + " = " + act.Valor.Subtotal);
                act = act.Siguiente;
            }

            Console.WriteLine("TOTAL: " + p.Total);
            Console.Write("confirmar s n: ");
            string conf = Console.ReadLine();

            if (conf == null || conf.ToLower() != "s")
            {
                Console.WriteLine("pedido cancelado");
                Console.ReadLine();
                return;
            }

            r.ColaPedidos.Agregar(p);

            Console.WriteLine("pedido guardado");
            Console.ReadLine();
        }
    }
}