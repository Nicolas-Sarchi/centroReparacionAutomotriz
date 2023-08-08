namespace CRA.classes;
public class Factura
{

    public int NroOrden { get; set; }
    public int NroFactura { get; set; }
    public string IdCliente { get; set; }
    public List<ItemAprobacion> RepuestosAutorizados { get; set; }

    public Factura(int nroOrden, int nroFactura, string idCliente, List<ItemAprobacion> repuestosAutorizados)
    {
        NroOrden = nroOrden;
        NroFactura = nroFactura;
        IdCliente = idCliente;
        RepuestosAutorizados = repuestosAutorizados;
    }

    private decimal CalcularValorManoObra()
    {
        decimal valorManoObra = 0;
        foreach (var item in RepuestosAutorizados)
        {
            valorManoObra += item.ValorTotal * 10 / 100;
        }
        return valorManoObra;
    }

    private decimal CalcularSubtotal()
    {
        decimal subtotal = 0;
        foreach (var item in RepuestosAutorizados)
        {
            subtotal += item.ValorTotal;
        }
        return subtotal + CalcularValorManoObra();
    }

    private decimal CalcularTotal()
    {
        decimal total = CalcularSubtotal() + (CalcularSubtotal() * 19 / 100);
        return total;
    }

    // public void MostrarFactura()
    // {
    //     decimal valorManoObra = CalcularValorManoObra();
    //     decimal subtotal = CalcularSubtotal();
    //     decimal total = CalcularTotal();

    //     Console.WriteLine("\n--------- Factura ---------");
    //     Console.WriteLine($"\nNro Orden: {NroOrden}\t\tNro Factura: {NroFactura}\n\nId Cliente: {IdCliente}\n");
    //     Console.WriteLine("\n--------- Detalle Factura ---------");
    //     foreach (var item in RepuestosAutorizados)
    //     {
    //         Console.WriteLine($"Item: {item.Item}\t\tCantidad: {item.Cantidad}\t\tValor Unitario: {item.ValorUnitario}\t\tValor Total: {item.ValorTotal}");
    //     }
    //     Console.WriteLine($"Valor Mano de Obra: {valorManoObra}\t\tSubtotal: {subtotal}\t\tIVA 19%: {subtotal * 19 / 100}\t\tTotal: {total}\n");
    // }

}
