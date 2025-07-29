# SystemUtilConfg

`2025-07-22`: Este modulo actualmetne tiene warnings, hay que lograr quitarlos (mejorando el código).

# Leer texto, ignorando comentarios:
```csharp
string text_file = TextUtil.ignoreComment(
    text: (string)TextUtil.readTextFile( file: PATH_RUN_COMMAND, return_type: "text" )
);
```

# Obtener valor de variables puesta en texto:
```csharp
string[] var_value = line.Split("=");
```

# Obtener cantidad de items en una array:
```csharp
if (var_value.Length >= 2){}
```

# Diccionario para obtener valores:
```csharp
using System.Collections.Generic;
Dictionary<string, string> terminal_variables = new Dictionary<string, string>();
terminal_variables.Add( var_value[0], var_value[1]);
```


# Eliminar espacios en string
```csharp
texto = "   linux  "
texto.Trim() // "linux"
```
[Como usar trim by microsoft](https://learn.microsoft.com/en-us/dotnet/api/system.string.trim?view=net-9.0)

Tambien se puede forzar ponerlo en minusculas:
```csharp
texto.ToLower()
```

# Obtener key
```csharp
foreach (var variable in terminal_variables){
    Console.WriteLine(variable.Key, variable.Value);
}
Console.WriteLine( terminal_variables["linux_terminal"] );
```


# Referencias
- (String replace)[https://stackoverflow.com/questions/6945255/c-sharp-replace-string-in-string]
- (String sin espacios)[https://www.geeksforgeeks.org/c-sharp/c-sharp-tolower-method/]