namespace CRA.classes;
public class Factura
{

    public int NroOrden { get; set; }
    public int NroFactura { get; set; }
    public string IdCliente { get; set; }
    public double Subtotal { get; set; }
    public double ManoObra { get; set;}
    public double Total { get; set; }
    public double Iva { get; set; }
    public List<ItemAprobacion> ItemsAprobados { get; set; }
    public Factura(int nroOrden, int nroFactura, string idCliente, double subtotal, double iva, double manoObra, double total, List<ItemAprobacion> itemsAprobados)
    {
        NroOrden = nroOrden;
        NroFactura = nroFactura;
        IdCliente = idCliente;
        Subtotal = subtotal;
        Iva = iva;
        ManoObra = manoObra;
        Total = total;
        ItemsAprobados = itemsAprobados;
    }


}
