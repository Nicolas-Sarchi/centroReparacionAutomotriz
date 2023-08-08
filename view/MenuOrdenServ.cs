namespace CRA.view;

public class MenuOrdenServ
{
    public MenuOrdenServ(){}

    public int MostrarMenu()
    {
        Console.Clear();
        Console.WriteLine("\n--------------- Orden de servicio ----------------");
        Console.WriteLine($"1. Registrar orden de servicio");
        Console.WriteLine($"2. Consultar Órdenes de Servicio por Cliente");
        Console.WriteLine($"3. Añadir personal a una orden de servicio");
        Console.WriteLine($"4. Ver ordenes de aprobación");
        Console.WriteLine("5. Volver al menú principal");
        return Convert.ToInt32(Console.ReadLine());
    }
}
