namespace CRA.classes
{
    public class Cliente
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Celular { get; set; }
        public string Correo { get; set; }
        public DateTime FechaRegistro { get; set; }
        public List<Vehiculo> Vehiculos { get; set; }

        public Cliente(string id, string nombre, string apellido, string celular, string correo, DateTime fechaRegistro)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Celular = celular;
            this.Correo = correo;
            this.FechaRegistro = fechaRegistro;
            this.Vehiculos = new List<Vehiculo>();
        }

        public Cliente() { }

        public Cliente agregarCliente()
        {
            Cliente cliente = new Cliente();
            Console.Write("Ingrese el número de identificación del cliente: ");
            cliente.Id = Console.ReadLine();
            Console.Write("Ingrese el nombre del cliente: ");
            cliente.Nombre = Console.ReadLine();
            Console.Write("Ingrese el apellido del cliente: ");
            cliente.Apellido = Console.ReadLine();
            Console.Write("Ingrese el número de celular del cliente: ");
            cliente.Celular = Console.ReadLine();
            Console.Write("Ingrese el correo electrónico del cliente: ");
            cliente.Correo = Console.ReadLine();
            cliente.FechaRegistro = DateTime.Now;
            cliente.Vehiculos = new List<Vehiculo>();
            return cliente;
        }
    }

}