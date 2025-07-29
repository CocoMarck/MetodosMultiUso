# TextUtil

Como remover el ultimo caracter:
```csharp
string text = "Hola\nAdios\n";
Console.WriteLine( text.Remove(text.Length -1) );
```

Determinar si un texto esta vacio:
```csharp
if ( string.IsNullOrEmpty(text) == false )
    Console.WriteLine("No esta vacio");
```

Establecer array vacio, sin index sin determinar:
```csharp
string[] array_text = {};
```

Detectar que un array esta vacio:
```csharp
int[] myArray = new int[0];
if (myArray.Length == 0) {
    // El array esta vacio
}

if (!myArray.Any()) {
    // El array esta vacio
}
```