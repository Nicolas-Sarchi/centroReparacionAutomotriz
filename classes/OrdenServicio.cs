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
        List<ItemAprobacion> itemsAleatorios = GenerarItemsAleatorios();

        // Asociar los ítems aleatorios a la orden de aprobación
        Empleado empleado = PersonalACargo.Find(empleado => empleado.id == empleadoId);
        OrdenAprobacion ordenAprobacion = new OrdenAprobacion(NroOrden, FechaOrden, empleado.id);
        ordenAprobacion.ItemsAprobacion = itemsAleatorios;

        // Agregar la orden de aprobación a la lista de órdenes de aprobación de la orden de servicio
        OrdenesAprobacion.Add(ordenAprobacion);
    }

    public List<ItemAprobacion> GenerarItemsAleatorios()
    {
        List<ItemAprobacion> itemsAleatorios = new List<ItemAprobacion>();


        ItemAprobacion item1 = new ItemAprobacion("01", "Pastillas de frenos", 50000, 2);
        ItemAprobacion item2 = new ItemAprobacion("02", "Batería", 80000, 1);
        ItemAprobacion item3 = new ItemAprobacion("03", "Aceite de motor", 25000, 3);
        ItemAprobacion item4 = new ItemAprobacion("04", "Filtro de aire", 30000, 1);
        ItemAprobacion item5 = new ItemAprobacion("05", "Líquido de frenos", 40000, 1);

        itemsAleatorios.Add(item1);
        itemsAleatorios.Add(item2);
        itemsAleatorios.Add(item3);
        itemsAleatorios.Add(item4);
        itemsAleatorios.Add(item5);

        return itemsAleatorios;
    }

    public void MostrarOrdenesAprobacion()
    {
        Console.WriteLine("------- Ordenes de aprobación -------");
        foreach (var orden in OrdenesAprobacion)
        {
            Console.WriteLine($"Nro Orden: {orden.NroOrden}\tFecha: {orden.Fecha}\nId Empleado: {orden.IdEmpleado}");
            Console.WriteLine("\n-------- Detalle de Aprobación --------\n");
            foreach (var item in orden.ItemsAprobacion)
            {
                Console.Write($"Diagnostico: {item.Item}\tRepuesto: {item.Repuesto}\tValor Unitario: {item.ValorUnitario}\tCantidad: {item.Cantidad}\tValor Total: {item.ValorTotal}\tEstatus (A/R): ");
                string estatus = Console.ReadLine();
                if (estatus.ToUpper() != "A" && estatus.ToUpper() != "R")
                {
                    Console.WriteLine("Estatus no valido");
                    return;

                } else{
                    if(estatus.ToUpper() == "A"){
                        item.Estatus = "Aprobado";
                    } else{
                        item.Estatus = "Rechazado";
                    }
                }
                
            }
        }
    }

    public void FacturarServicio(int nroOrden)
    {
        OrdenAprobacion ordenAprobacion = BuscarOrden(nroOrden);

        if (ordenAprobacion == null)
        {
            Console.WriteLine("Orden de Aprobacion no encontrada.");
            return;
        }

        List<ItemAprobacion> repuestosAutorizados = ordenAprobacion.RepuestosAutorizados();

        decimal valorManoObra = CalcularValorManoObra(repuestosAutorizados);
        decimal subtotal = CalcularSubtotal(repuestosAutorizados, valorManoObra);
        decimal iva = CalcularIVA(subtotal);
        decimal total = CalcularTotal(subtotal, iva);

        MostrarFactura(nroOrden, repuestosAutorizados, valorManoObra, subtotal, iva, total);
    }

    private decimal CalcularValorManoObra(List<ItemAprobacion> repuestosAutorizados)
    {
        decimal valorManoObra = 0;
        foreach (var repuesto in repuestosAutorizados)
        {
            valorManoObra += repuesto.ValorTotal * 0.10m;
        }
        return valorManoObra;
    }

    private decimal CalcularSubtotal(List<ItemAprobacion> repuestosAutorizados, decimal valorManoObra)
    {
        decimal subtotal = repuestosAutorizados.Sum(repuesto => repuesto.ValorTotal) + valorManoObra;
        return subtotal;
    }

    private decimal CalcularIVA(decimal subtotal)
    {
        decimal iva = subtotal * 0.19m;
        return iva;
    }

    private decimal CalcularTotal(decimal subtotal, decimal iva)
    {
        decimal total = subtotal + iva;
        return total;
    }

    private void MostrarFactura(int nroOrden, List<ItemAprobacion> repuestosAutorizados, decimal valorManoObra, decimal subtotal, decimal iva, decimal total)
    {
        Console.WriteLine("\n--------- Factura ---------");
        Console.WriteLine($"Nro Orden: {nroOrden}");
        Console.WriteLine("\n--------- Detalle Factura ---------");
        foreach (var repuesto in repuestosAutorizados)
        {
            Console.WriteLine($"Repuesto: {repuesto.Repuesto}\tCantidad: {repuesto.Cantidad}\tValor Unitario: {repuesto.ValorUnitario}\tValor Total: {repuesto.ValorTotal}");
        }
        Console.WriteLine($"Valor Mano de Obra: {valorManoObra}\tSubtotal: {subtotal}\tIVA 19%: {iva}\tTotal: {total}\n");
    }

    public OrdenAprobacion BuscarOrden(int NroOrden)
    {
        return OrdenesAprobacion.Find(o => o.NroOrden == NroOrden);
    }

}


