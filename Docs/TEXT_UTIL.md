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



# `char` a minusculas o a mayusculas
```csharp
char c = 'a';

Console.WriteLine( char.ToLower(c) );
Console.WriteLine( char.ToUpper(c) );
```


# `char` a `string`
[Enlace de tutorial](https://www.techiedelight.com/es/convert-a-char-to-a-string-in-csharp/)
```csharp
char c = 'a';
string c_to_s = c.ToString();
```




```csharp
/// 
for( int index=0; index < text.Length; index++ ) {
    char character = text[index];
    
    // Determinar si el string pasa el filtro o no | Bucle dos
    // Establecer en if, el char en minusculas
    bool pass = false;
    for(int index_filter=0; index_filter < filter.Length; index_filter++){
        char character_filter = filter[index_filter];
        if ( char.ToLower(character) == character_filter) { pass = true; }
    }
    dict_text.Add( index, (character, pass) );
}
```



Separar texto
```csharp
string str == "Hello Vato"
string[] split = str.Split(' ');

foreach (string item in split ) {
    Console.Writeline( item] );
}
// Hello
// Vato
```


