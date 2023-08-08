namespace CRA.view;

public class MenuRegistrar
{
    public MenuRegistrar() { }

    public int MostrarMenuRegistrar()
    {
        Console.Clear();
        Console.WriteLine("\n--------------- Registro ----------------");
        Console.WriteLine($"1. Registrar Cliente");
        Console.WriteLine($"2. Registrar Vehículo");
        Console.WriteLine($"3. Registrar Empleado");
        Console.WriteLine($"4. Volver al menú principal");
        return Convert.ToInt32(Console.ReadLine());


    }
}
