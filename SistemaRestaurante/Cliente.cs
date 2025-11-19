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
    }
}