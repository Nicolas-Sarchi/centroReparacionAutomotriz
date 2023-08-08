namespace CRA.classes;

public class Empleado
{
    public string id { get; set; }
    public string nombre { get; set; }
    public string celular { get; set; }
    public string especialidad { get; set; }

    public Empleado(string id, string nombre, string celular, string especialidad)
    {
        this.id = id;
        this.nombre = nombre;
        this.celular = celular;
        this.especialidad = especialidad;
    }
    public Empleado () {}

    public Empleado agregarEmpleado()
    {
        Empleado empleado = new Empleado();
        Console.Write("Ingrese el número de identificación del empleado: ");
        empleado.id = Console.ReadLine();
        Console.Write("Ingrese el nombre del empleado: ");
        empleado.nombre = Console.ReadLine();
        Console.Write("Ingrese el número de celular del empleado: ");
        empleado.celular = Console.ReadLine();
        Console.Write("Ingrese la especialidad del empleado: ");
        empleado.especialidad = Console.ReadLine();
        return empleado;
    }

    
}
