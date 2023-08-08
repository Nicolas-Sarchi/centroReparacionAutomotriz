namespace CRA.classes;
using CRA.classes;

public class OrdenServicio
{
    public int NroOrden { get; set; }
    public DateTime FechaOrden { get; set; }
    public Cliente Cliente { get; set; }
    public Vehiculo Vehiculo { get; set; }
    public string DiagnosticoCliente { get; set; }
    public List<Empleado> PersonalACargo { get; set; }  
    public List<string> DiagnosticoExperto { get; set; } 
    public List<OrdenAprobacion> OrdenesAprobacion { get; set; } 

    public OrdenServicio(int nroOrden, DateTime fechaOrden, Cliente cliente, Vehiculo vehiculo, string diagnosticoCliente)
    {
        NroOrden = nroOrden;
        FechaOrden = fechaOrden;
        Cliente = cliente;
        Vehiculo = vehiculo;
        DiagnosticoCliente = diagnosticoCliente;
        PersonalACargo = new List<Empleado>();
        DiagnosticoExperto = new List<string>();
        OrdenesAprobacion = new List<OrdenAprobacion>();

    }

    public void AgregarEmpleado(Empleado empleado)
    {
        this.PersonalACargo.Add(empleado);
    }

    public void AgregarDiagnosticoExperto()
    {
        List<string> diagnosticosPreestablecidos = new List<string>
    {
        "Falla en el motor",
        "Problema con la batería",
        "Fuga de líquido de frenos",
        "Problema en la transmisión",
        "Fallo en el sistema eléctrico",
        "Problema de suspensión",
        "Problema de frenos",
        "Ruedas Desalineadas"
    };
        Random random = new Random();
        int indexDiagnostico = random.Next(0, diagnosticosPreestablecidos.Count);
        string diagnostico = diagnosticosPreestablecidos[indexDiagnostico];
        this.DiagnosticoExperto.Add(diagnostico);
    }


    public void GenerarOrdenDeAprobacion(string empleadoId)
    {
        Empleado empleado = PersonalACargo.Find(empleado => empleado.id == empleadoId);
        OrdenAprobacion ordenAprobacion = new OrdenAprobacion(NroOrden, FechaOrden, empleado.id);
        OrdenesAprobacion.Add(ordenAprobacion);
    }


    public void MostrarOrdenesAprobacion()
    {
        Console.WriteLine("------- Ordenes de aprobación -------");
        foreach (var orden in OrdenesAprobacion)
        {
            Console.WriteLine($"Nro Orden: {orden.NroOrden}\tFecha: {orden.Fecha}\nId Empleado: {orden.IdEmpleado}");
            Console.WriteLine("\n-------- Detalle de Aprobación --------\n");
            Console.Write("Desea añadir un detalle de aprobaciòn? S/N: ");
            string opciondetalle = Console.ReadLine().ToUpper();
            while (opciondetalle != "N")
            {
                
                Console.Write("Ingrese el numero de item del repuesto:");
                string itemN = Console.ReadLine();
                Console.Write("Ingrese el nombre del repuesto:");
                string repuesto = Console.ReadLine();
                Console.Write("\nIngrese el valor unitario del repuesto:");
                double valorU = double.Parse(Console.ReadLine());
                Console.Write("\nIngrese la cantidad del repuesto:");
                int cantidad = int.Parse(Console.ReadLine());
                Console.Write("\nIngrese el estado del repuesto (A/R): ");
                string estado = Console.ReadLine();
                ItemAprobacion item = new ItemAprobacion(itemN, repuesto, valorU, cantidad);
                orden.AgregarItemAprobacion(item);   
                Console.Write("Desea añadir un detalle de aprobaciòn? S/N: ");
                opciondetalle = Console.ReadLine().ToUpper();
                if (estado.ToUpper() != "A" && estado.ToUpper() != "R")
                {
                    Console.WriteLine("estado no valido");
                    return;

                } else{
                    if(estado.ToUpper() == "A"){
                        item.Estatus = "Aprobado";
                    } else{
                        item.Estatus = "Rechazado";
                    }
                }
            } 
                
        }
    }



    


}


