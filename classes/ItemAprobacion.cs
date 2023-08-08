namespace CRA.classes;


public class ItemAprobacion
{
    public string Item { get; set; }
    public string Repuesto { get; set; }
    public decimal ValorUnitario { get; set; }
    public int Cantidad { get; set; }
    public decimal ValorTotal { get; private set; }
    public string Estatus { get; set; }

    public ItemAprobacion(string item, string repuesto, decimal valorUnitario, int cantidad)
    {
        Item = item;
        Repuesto = repuesto;
        ValorUnitario = valorUnitario;
        Cantidad = cantidad;
        Estatus = "Rechazado";
        ValorTotal = ValorUnitario * Cantidad;
    }
}

