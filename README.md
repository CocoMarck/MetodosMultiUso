# Modulos utilies para C#

Funciones para uso general creadas en c#.
Tienen intención de solo tener funciones para uso general, como "obtenerSistemaOperativo", "crearAccesoDirecto", ese tipo de cosas.

La estructura de las funciones, tiene la intención de ser modular y que se pueda compilar a .dll de manera sencilla.


### Ejemplos de uso
```csharp
string sistema_operativo = SystemUtil.getSystem();
Console.WriteLine( $"Estás usando: {sistema_operativo}" );
```


# Ejecutar programa con `dotnet`
```bash
dotnet run
```