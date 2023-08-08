namespace CRA.classes;

public class OrdenAprobacion
{

    public int NroOrden { get; set; }
    public DateTime Fecha { get; set; }
    public string IdEmpleado { get; set; }
    public List<ItemAprobacion> ItemsAprobacion { get; set; }

    public OrdenAprobacion(int nroOrden, DateTime fecha, string idEmpleado)
    {
        NroOrden = nroOrden;
        Fecha = fecha;
        IdEmpleado = idEmpleado;
        ItemsAprobacion = new List<ItemAprobacion>();
    }

    public void AgregarItemAprobacion(ItemAprobacion item)
    {
        ItemsAprobacion.Add(item);
    }

}

