namespace CRA.classes;

public class Vehiculo
{
    public string Placa { get; set; }
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public string Color { get; set; }
    public string Km { get; set; }

    public Vehiculo(string placa, string marca, string modelo, string color, string km)
    {
        this.Placa = placa;
        this.Marca = marca;
        this.Modelo = modelo;
        this.Color = color;
        this.Km = km;
    }
    public Vehiculo() { }	

    public Vehiculo agregarVehiculo ()
    {
        Vehiculo vehiculo = new Vehiculo();
        Console.Write("Ingrese la placa del vehículo: ");
        vehiculo.Placa = Console.ReadLine();
        Console.Write("Ingrese la marca del vehículo: ");
        vehiculo.Marca = Console.ReadLine();
        Console.Write("Ingrese el modelo del vehículo: ");
        vehiculo.Modelo = Console.ReadLine();
        Console.Write("Ingrese el color del vehículo: ");
        vehiculo.Color = Console.ReadLine();
        Console.Write("Ingrese el kilometraje del vehículo: ");
        vehiculo.Km = Console.ReadLine();
        return vehiculo;
    }
}
