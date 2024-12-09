using System;

namespace Contactos
{
    public class Contacto
    {
        private string name;
        private string phone;

        // Constructor predeterminado
        public Contacto()
        {
            name = "";
            phone = "";
        }

        // Constructor con parámetros
        public Contacto(string nombre, string telefono)
        {
            name = nombre;
            phone = telefono;
        }

        // Propiedad para el nombre
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        // Propiedad para el teléfono
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        // Método para comparar si dos contactos son iguales
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Contacto c = (Contacto)obj;
            return Name == c.Name && Phone == c.Phone;
        }

        // Método para generar un código hash
        public override int GetHashCode()
        {
            return (name != null ? name.GetHashCode() : 0) ^ (phone != null ? phone.GetHashCode() : 0);
        }
    }
}
