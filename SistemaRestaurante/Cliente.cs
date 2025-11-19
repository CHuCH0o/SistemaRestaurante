using System;


namespace SistemaRestaurante
{
    // esta clase guarda los datos del cliente

    public class Cliente
    {
        public string Cedula;
        public string NombreCompleto;
        public string Celular;
        public string Email;
       
        // aqui reviso que el email tenga arroba y un punto
        public static bool EsEmailValido(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            if (!email.Contains("@"))
            {
                return false;
            }

            if (!email.Contains("."))
            {
                return false;
            }

            return true;
        }
         // verifica si cedula ya existe en todo el sistema
        public static bool ExisteCedulaEnTodos(ListaEnlazada<Restaurante> restaurantes, string cedula)
        {
            Nodo<Restaurante> r = restaurantes.Cabeza;
            while (r != null)
            {
                Nodo<Cliente> c = r.Valor.Clientes.Cabeza;
                while (c != null)
                {
                    if (c.Valor.Cedula == cedula)
                    {
                        return true;
                    }
                    c = c.Siguiente;
                }
                r = r.Siguiente;
            }
            return false;
        }

        // menu clientes
        public static void MenuClientes(ListaEnlazada<Restaurante> restaurantes)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== CLIENTES ===");
                Console.WriteLine("1. Agregar cliente");
                Console.WriteLine("2. Editar cliente");
                Console.WriteLine("3. Listar clientes");
                Console.WriteLine("0. Volver al menu principal");
                Console.Write("Seleccione una opcion: ");
                string op = Console.ReadLine();

                if (op == "0")
                {
                    return;
                }

                Restaurante rest = Restaurante.SeleccionarRestaurante(restaurantes);
                if (rest == null)
                {
                    continue;
                }

                if (op == "1")
                {
                    AgregarCliente(restaurantes, rest);
                }
                else if (op == "2")
                {
                    EditarCliente(restaurantes, rest);
                }
                else if (op == "3")
                {
                    ListarClientes(rest, true);
                }
                else
                {
                    Console.WriteLine("opcion invalida");
                    Console.ReadLine();
                }
            }
        }

        // seleccionar cliente
        public static Cliente SeleccionarCliente(Restaurante r)
        {
            while (true)
            {
                ListarClientes(r, false);
                Console.WriteLine("0. Volver");
                Console.Write("Seleccione un numero: ");
                string t = Console.ReadLine();

                int op;
                if (!int.TryParse(t, out op))
                {
                    Console.WriteLine("opcion invalida");
                    Console.ReadLine();
                    return null;
                }

                if (op == 0)
                {
                    return null;
                }

                int idx = op - 1;
                int total = r.Clientes.Longitud();

                if (idx < 0 || idx >= total)
                {
                    Console.WriteLine("opcion invalida");
                    Console.ReadLine();
                    return null;
                }

                return r.Clientes.ObtenerPorIndice(idx);
            }
        }

        // agregar cliente
        public static void AgregarCliente(ListaEnlazada<Restaurante> restaurantes, Restaurante r)
        {
            Console.Clear();
            Console.WriteLine("=== AGREGAR CLIENTE ===");

            Cliente c = new Cliente();

            Console.Write("cedula: ");
            c.Cedula = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(c.Cedula))
            {
                Console.WriteLine("cedula invalida");
                Console.ReadLine();
                return;
            }

            if (ExisteCedulaEnTodos(restaurantes, c.Cedula))
            {
                Console.WriteLine("ya existe un cliente con esa cedula");
                Console.ReadLine();
                return;
            }

            Console.Write("nombre completo: ");
            c.NombreCompleto = Console.ReadLine();

            Console.Write("celular 10 digitos: ");
            c.Celular = Console.ReadLine();
            if (!Restaurante.EsCelularValido(c.Celular))
            {
                Console.WriteLine("celular invalido");
                Console.ReadLine();
                return;
            }

            Console.Write("email: ");
            c.Email = Console.ReadLine();
            if (!EsEmailValido(c.Email))
            {
                Console.WriteLine("email invalido");
                Console.ReadLine();
                return;
            }

            r.Clientes.Agregar(c);

            Console.WriteLine("cliente agregado");
            Console.ReadLine();
        }

        // listar clientes
        public static void ListarClientes(Restaurante r, bool esperar)
        {
            Console.Clear();
            Console.WriteLine("=== LISTA DE CLIENTES ===");

            Nodo<Cliente> act = r.Clientes.Cabeza;
            int i = 0;

            if (act == null)
            {
                Console.WriteLine("no hay clientes");
            }

            while (act != null)
            {
                Cliente c = act.Valor;
                Console.WriteLine((i + 1) + ". " + c.Cedula + " - " + c.NombreCompleto + " - " + c.Celular);
                i++;
                act = act.Siguiente;
            }

            if (esperar)
            {
                Console.WriteLine("presione enter para seguir");
                Console.ReadLine();
            }
        }

        // editar cliente
        public static void EditarCliente(ListaEnlazada<Restaurante> restaurantes, Restaurante r)
        {
            Console.Clear();
            Console.WriteLine("=== EDITAR CLIENTE ===");

            Cliente c = SeleccionarCliente(r);
            if (c == null)
            {
                return;
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine("cliente seleccionado");
                Console.WriteLine(c.Cedula + " - " + c.NombreCompleto + " - " + c.Celular + " - " + c.Email);
                Console.WriteLine();
                Console.WriteLine("1. cambiar nombre");
                Console.WriteLine("2. cambiar celular");
                Console.WriteLine("3. cambiar email");
                Console.WriteLine("0. volver");
                Console.Write("Seleccione una opcion: ");
                string op = Console.ReadLine();

                if (op == "1")
                {
                    Console.Write("nuevo nombre: ");
                    c.NombreCompleto = Console.ReadLine();
                }
                else if (op == "2")
                {
                    Console.Write("nuevo celular: ");
                    string cel = Console.ReadLine();
                    if (Restaurante.EsCelularValido(cel))
                    {
                        c.Celular = cel;
                    }
                    else
                    {
                        Console.WriteLine("celular invalido");
                        Console.ReadLine();
                    }
                }
                else if (op == "3")
                {
                    Console.Write("nuevo email: ");
                    string mail = Console.ReadLine();
                    if (EsEmailValido(mail))
                    {
                        c.Email = mail;
                    }
                    else
                    {
                        Console.WriteLine("email invalido");
                        Console.ReadLine();
                    }
                }
                else if (op == "0")
                {
                    return;
                }
                else
                {
                    Console.WriteLine("opcion invalida");
                    Console.ReadLine();
                }
            }
        }
    }
}