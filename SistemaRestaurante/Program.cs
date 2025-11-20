namespace SistemaRestaurante
{
    // este es el programa principal
    // aqui por ahora solo muestro un mensaje

    internal class Program
    {
        static void Main(string[] args)
        {

            // aqui creo la lista de restaurantes
            ListaEnlazada<Restaurante> restaurantes = new ListaEnlazada<Restaurante>();

            // aqui empieza el ciclo del sistema
            while (true)
            {
                Console.Clear();
                Console.WriteLine("====================================");
                Console.WriteLine("         SISTEMA RESTAURANTE");
                Console.WriteLine("====================================");
                Console.WriteLine("1. Restaurantes");
                Console.WriteLine("2. Clientes");
                Console.WriteLine("3. Platos");
                Console.WriteLine("4. Pedidos");
                Console.WriteLine("5. Reportes");
                Console.WriteLine("------------------------------------");
                Console.Write("Seleccione una opcion: ");
                string opcion = Console.ReadLine();

                if (opcion == "1")
                {
                    Restaurante.MenuRestaurantes(restaurantes);
                }
                else if (opcion == "2")
                {
                    Cliente.MenuClientes(restaurantes);
                }
                else if (opcion == "3")
                {
                    Plato.MenuPlatos(restaurantes);
                }
                else if (opcion == "4")
                {
                    Pedido.MenuPedidos(restaurantes);
                }
                else if (opcion == "5")
                {
                    Pedido.MenuReportes(restaurantes);
                }
                else
                {
                    Console.WriteLine("opcion invalida");
                    Console.WriteLine("presione enter para seguir");
                    Console.ReadLine();
                }
            }
        }
    }
}