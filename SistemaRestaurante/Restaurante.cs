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
        
        
        // aqui se maneja el menu de restaurantes
        public static void MenuRestaurantes(ListaEnlazada<Restaurante> restaurantes)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== RESTAURANTES ===");
                Console.WriteLine("1. Crear restaurante");
                Console.WriteLine("2. Editar restaurante");
                Console.WriteLine("3. Listar restaurantes");
                Console.WriteLine("0. Volver al menu principal");
                Console.WriteLine("---------------------------");
                Console.Write("Seleccione una opcion: ");
                string opcion = Console.ReadLine();

                if (opcion == "1")
                {
                    CrearRestaurante(restaurantes);
                }
                else if (opcion == "2")
                {
                    Console.WriteLine("editar restaurante aun no implementado");
                    Console.ReadLine();
                }
                else if (opcion == "3")
                {
                    ListarRestaurantes(restaurantes, true);
                }
                else if (opcion == "0")
                {
                    return;
                }
                else
                {
                    Console.WriteLine("opcion invalida");
                    Console.WriteLine("presione enter para seguir");
                    Console.ReadLine();
                }
            }
        }

        // aqui creo un restaurante nuevo
        public static void CrearRestaurante(ListaEnlazada<Restaurante> restaurantes)
        {
            Console.Clear();
            Console.WriteLine("=== CREAR RESTAURANTE ===");

            Restaurante nuevo = new Restaurante();

            Console.Write("ingrese nit: ");
            nuevo.Nit = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nuevo.Nit))
            {
                Console.WriteLine("nit invalido");
                Console.ReadLine();
                return;
            }

            if (BuscarPorNit(restaurantes, nuevo.Nit) != null)
            {
                Console.WriteLine("ya existe un restaurante con ese nit");
                Console.ReadLine();
                return;
            }

            Console.Write("ingrese nombre: ");
            nuevo.Nombre = Console.ReadLine();

            Console.Write("ingrese dueño: ");
            nuevo.Dueno = Console.ReadLine();

            Console.Write("ingrese celular: ");
            nuevo.Celular = Console.ReadLine();

            if (!EsCelularValido(nuevo.Celular))
            {
                Console.WriteLine("celular invalido debe tener 10 numeros");
                Console.ReadLine();
                return;
            }

            Console.Write("ingrese direccion: ");
            nuevo.Direccion = Console.ReadLine();

            restaurantes.Agregar(nuevo);

            Console.WriteLine("restaurante creado");
            Console.ReadLine();
        }

        // aqui muestro la lista de restaurantes
        public static void ListarRestaurantes(ListaEnlazada<Restaurante> restaurantes, bool esperar)
        {
            Console.Clear();
            Console.WriteLine("=== LISTA DE RESTAURANTES ===");

            Nodo<Restaurante> actual = restaurantes.Cabeza;
            int indice = 0;

            if (actual == null)
            {
                Console.WriteLine("no hay restaurantes");
            }

            while (actual != null)
            {
                Restaurante r = actual.Valor;
                Console.WriteLine((indice + 1) + ". " + r.Nit + " - " + r.Nombre + " - " + r.Dueno + " - " + r.Celular);
                indice++;
                actual = actual.Siguiente;
            }

            Console.WriteLine("---------------------------");
            if (esperar)
            {
                Console.WriteLine("presione enter para seguir");
                Console.ReadLine();
            }
        }
    }
}