namespace CRA.classes;

public class Taller
{
    public List<Cliente> clientes;
    public List<Vehiculo> vehiculos;
    public List<Empleado> empleados;
    public List<OrdenServicio> ordenesDeServicio;
    public List<Factura> facturas;
    public int numeroOrdenActual;
    public int numeroFacturaActual;
 
    public Taller()
    {
        clientes = new List<Cliente>();
        vehiculos = new List<Vehiculo>();
        empleados = new List<Empleado>();
        ordenesDeServicio = new List<OrdenServicio>();
        facturas = new List<Factura>();
        numeroOrdenActual = 1;
        numeroFacturaActual = 1;
    }

    public void RegistrarCliente(Cliente cliente)
    {
        this.clientes.Add(cliente);
    }

    public void RegistrarVehiculo(Vehiculo vehiculo)
    {
        this.vehiculos.Add(vehiculo);
    }

    public void RegistrarEmpleado(Empleado empleado)
    {
        this.empleados.Add(empleado);
    }
    public Empleado BuscarEmpleado(string id)
    {
        return empleados.Find(e => e.id.Equals(id));
    }
    public Cliente BuscarCliente(string id)
    {
        return clientes.Find(c => c.Id.Equals(id));
    }
    public Vehiculo BuscarVehiculo(string placa)
    {
        return vehiculos.Find(v => v.Placa.Equals(placa));
    }

    public OrdenServicio BuscarOrden(int NroOrden)
    {
        return ordenesDeServicio.Find(o => o.NroOrden == NroOrden);
    }
    public void GenerarOrdenDeServicio()
    {
        Console.WriteLine("Ingrese el Id del cliente que solicita el servicio");
        string clienteId = Console.ReadLine();
        Console.WriteLine("Ingrese la placa del vehículo al cual se le va a hacer el servicio");
        string vehiculoPlaca = Console.ReadLine();
        Console.WriteLine("Ingrese el diagnostico del cliente");
        string diagnosticoCliente = Console.ReadLine();
        Console.WriteLine("Ingrese el id del empleado que va a atender la orden de servicio");
        string empleadoId = Console.ReadLine();

        Empleado empleado = BuscarEmpleado(empleadoId);
        Cliente cliente = BuscarCliente(clienteId);
        Vehiculo vehiculo = BuscarVehiculo(vehiculoPlaca);
        if (cliente == null || vehiculo == null)
        {
            Console.WriteLine("Cliente o vehículo no encontrado. No se pudo generar la orden de servicio.");
            return;
        }

        OrdenServicio orden = new OrdenServicio(numeroOrdenActual, DateTime.Now, cliente, vehiculo, diagnosticoCliente);
        orden.AgregarEmpleado(empleado);
        orden.AgregarDiagnosticoExperto();
        orden.GenerarOrdenDeAprobacion(empleadoId);
        ordenesDeServicio.Add(orden);
        numeroOrdenActual++;
    }

    public List<OrdenServicio> ObtenerOrdenesDeServicioPorCliente(string idCliente)
    {
        return ordenesDeServicio.FindAll(orden => orden.Cliente.Id == idCliente);
    }

    public void MostrarOrdenes()
    {
        Console.WriteLine("\n----------------- Mostrar Órdenes de Servicio de un Cliente -----------------");
        Console.Write("Ingrese el ID del cliente: ");
        string idCliente = Console.ReadLine();
        List<OrdenServicio> ordenesCliente = ObtenerOrdenesDeServicioPorCliente(idCliente);

        if (ordenesCliente.Count > 0)
        {
            Console.WriteLine($"Órdenes de servicio para el cliente con ID {idCliente}:");
            foreach (var orden in ordenesCliente)
            {
                Console.WriteLine("\n\n**-------Datos de la orden-------\n");
                Console.WriteLine($"Nro de orden: {orden.NroOrden}\t Fecha: {orden.FechaOrden}\nId cliente: {orden.Cliente.Id}\tNombre CLiente: {orden.Cliente.Nombre}");

                Console.WriteLine("\n-----Datos Vehiculo-------\n");
                Console.WriteLine($"Placa: {orden.Vehiculo.Placa}\tKM: {orden.Vehiculo.Km}\n");

                Console.WriteLine("\n-----Diagnostico Cliente-------\n");
                Console.WriteLine($"Diagnostico: {orden.DiagnosticoCliente}\n");
                Console.WriteLine("\n-----Personal a cargo-------\n");
                foreach (var empleado in orden.PersonalACargo)
                {
                    Console.WriteLine($"Id: {empleado.id}\tEmpleado: {empleado.nombre}\tEspecialidad: {empleado.especialidad}\n");

                    foreach (var diagnostico in orden.DiagnosticoExperto)
                    {
                        Console.WriteLine("\n-----Diagnostico Experto-------\n");
                        Console.WriteLine($"Nro cc:{empleado.id}\t Nombre: {empleado.nombre}\n Diagnostico: {diagnostico}\n");
                    }
                }

            }
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine($"No se encontraron órdenes de servicio para el cliente con ID {idCliente}.");
        }
    }


    public void MostrarEmpleados()
    {
        Console.WriteLine("--------- Empleados ---------");
        Console.WriteLine("#\tNombre\tCelular\tEspecialidad");
        foreach (Empleado empleado in empleados)
        {
            Console.WriteLine($"{empleado.id}\t{empleado.nombre}\t{empleado.celular}\t{empleado.especialidad}");
        }
        Console.WriteLine("\n\nPresione una tecla para continuar...");
        Console.ReadKey();
    }




}
