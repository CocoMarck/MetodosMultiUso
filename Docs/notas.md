# Notas
Aca solo notas de todo tipo. Información relacionada con el desarrollo de los modulos, seguir un orden con el fin de mantener el programa bien estructurado.




## Recordatorios sin ordenar (Relacionados con las funciones/metodos)  
- **Usar Console.ForegroundColor:**  
Esta permite agregar color a los textos en consola.




## Recordatorios SystemUtil
- **Hacer runCommand:**  
Esta función permitira hacer el cleanScreen. Process lo hace en segundo plano y no es lo inidcado, no limpia bien la pantalla.

- Hacer función para obtener la salida de un comando. Lo obtendra en string.



## Recordatorios ShowPrint
- Por logica, el nombre ShowPrint, indica que todos los metodos por defecto se mostraran en consola.  
Declarar consante `private const bool DEFAULT_CONSOLE = true;` para mantener dicha lógica.

- La estructura de formación del texto, sera siguiendo la funcionalidad de MarkDown.

- Hacer `boxText( string text="echo", string text_type="bash", bool console=true )`  
Esa función sirve para mostrar texto metido en una cajita. Generalmente código, pero pos no siempre sara así.  
` f"\n\n```{text_type}\n{text}\n```\n\n" `


**Ejemplo de boxText:**  
```
boxText( );
```

Resultado:
````

```bash
echo
```

````




## Recordatorios estructura  
- **Seguir filosofia UNIX**  
Cada cosa tiene que hacer solo lo suyo, no cosas demas.


- **Archivos de configuración**  
Evitar hacer archivos.txt, mejor puros JSON y XML. Con estos se puede estructurar la info de una.




## Como importar los modulos
Has de cuenta que este es el main: `Program.cs`, esta en `/`

Ejemplo de importar `ShowPrint.cs` que esta en `/Core`.  
`/Program.cs`:  
```csharp
using MetodosMultiUso.Core;

MetodosMultiUso.ShowPrint.Title(console: True);
```




## Como nombrar todo vato
- Las clases se escriben asi (PascalCase): ```NombreDeClase```
- Los metodos/funciones de las clases seran asi (camelCase): ```metodoChido```
- Las variables preferiblemente asi (snake_case): ```variable_chida```
- Evitar estas locuras: ```HlACss99AlJalo, nombre_excesitvamente_largo_y_dificil_de_mantener_porQue_esta_feo```




## Hacer clase TestRunner

En esta clase abra funciones para testear los modulos. Estas funciones devolveran un boleano.
true si pasa el test, false si no.

El archivo de este sera `TestRunner.cs` y estara en la ruta `Tests`  

**Algo asi:**
```
MetodosMultiUso/
    ...
    Tests/
        TestRunner.cs
```

**Como:**
```
testShowPrint()
testSystemUtil()
...

Abra una funcion final que se llamara testAll().
Esta hara todos los test disponibles en esta clase.
testAll()
    testShowPrint()
    testSystemUtil()
    ...
```

Ya tu sabe vato.