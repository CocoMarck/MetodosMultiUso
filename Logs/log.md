#    Probando todos los modulos    #

Aca veremos como se usan los modulos locos, por ejemplo, ve como jala `ShowPrint.inputContinue`:
Continuamos...


--------------------------------------------------------------------------------------------------------------------------------


#    `SystemUtilConf`    #

Terminal a ejecutar: `x-terminal-emulator`


--------------------------------------------------------------------------------------------------------------------------------


#    `ResourceLoader`    #

Rutas locas:
```
/home/jean_abraham/Proyectos/Programacion/csharp/github-clones/MetodosMultiUso/
/home/jean_abraham/Proyectos/Programacion/csharp/github-clones/MetodosMultiUso/Config
/home/jean_abraham/Proyectos/Programacion/csharp/github-clones/MetodosMultiUso/Resources
```
- Obtener tipo de ruta: dir
- Combinación restrictiva: `/home/jean_abraham/Proyectos/Programacion/csharp/github-clones/MetodosMultiUso/Program.cs`
- Combinación normal: `/home/jean_abraham/Proyectos/Programacion/csharp/github-clones/MetodosMultiUso/Config/runCommand.conf`


--------------------------------------------------------------------------------------------------------------------------------


#    Como se muestra por defecto `ShowPrint.title`    #

Por defecto el metodo `title`, se muestra asi:
    #    text    #

Tambien se le pueden cambiar su diseño:
    @        Espacio        @


No te dites cuenta pero ya se esta usando otro metodo, se llama `ShowPrint.separator` este sirve para mostrar sparaciones visuales, mira esta sparación, usando el caracter `^`(con 100 de estos caracteres):


^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

Bueno, ahora veremos como funcan otras funciones/metodos.


--------------------------------------------------------------------------------------------------------------------------------


#    Usando ShowPrint.codeText    #


~~~
Nothing
~~~


```python
print('Hello world')
```


```csharp
ShowPrint.codeText( string text, string text_type, bool console );
```

#    Usando `SystemUtil`    #

El sistema operativo que estas usando es: `linux`.
El metodo que se uso para saber el OS, es `SystemUtil.getSystem`.



--------------------------------------------------------------------------------------------------------------------------------


#    Mostrar string de comando    #

`$HOME` es: /home/jean_abraham


#    Mostrar resolución de pantalla    #

La resolución de pantalla, indica como se mostraran las imagenes, la cantidad de pixeles que se podran mostrar.
La resolucion de pantalla es: 0x0

#    Mostrar servidor grafico    #

El servidor grafico, es el que dibuja todo en pantalla, muy bonito.
El servidor grafico es: `wayland`


--------------------------------------------------------------------------------------------------------------------------------


#    `TextUtil.readText`    #

text:
```
# Aca se determina que terminal por defecto abrir
linux_terminal=x-terminal-emulator
win_terminal=cmd.exe
```


array:
```
# Aca se determina que terminal por defecto abrir
linux_terminal=x-terminal-emulator
win_terminal=cmd.exe
```


list:
```
# Aca se determina que terminal por defecto abrir
linux_terminal=x-terminal-emulator
win_terminal=cmd.exe
```


dictionary:
```
0. # Aca se determina que terminal por defecto abrir
1. linux_terminal=x-terminal-emulator
2. win_terminal=cmd.exe
```


#    `TextUtil.ignoreComment`    #

```
Ejemplo 
Texto
linux_terminal=x-terminal-emulator
win_terminal=cmd.exe
```

#    TextUtil.matrixLineBreaks    #
Ejemplo
Chido


#    TextUtil.separeText    #
Key: variable. Value: Valor


#    TextUtil.onlyTheComment    #
ComentarioComentario


#    TextUtil.filteredTextDictionary    #
Key: 0. Value: (H, False)
Key: 1. Value: (o, False)
Key: 2. Value: (l, False)
Key: 3. Value: (a, False)
Key: 4. Value: ( , False)
Key: 5. Value: (2, True)


#    TextUtil.passTextFilter    #
True

#    TextUtil.ignoreTextFilter    #
Textochido

#    `TextUtil.arrayAlphabet`    #
- BMW
- Ford
- Mazda
- Volvo
- 1@


#    `TextUtil.arrayNotRepeatItem`    #
- hola
- adios


#    `TextUtil.textOrNone`    #
- Perro loco
- null
- null


--------------------------------------------------------------------------------------------------------------------------------

#    TimeUtil    #
**TIME_VALUES**
- millisecond: 1
- second: 1000
- minute: 60000
- hour: 3600000
- day: 86400000


**TIME_MULTIPLER**
- millisecond: 1
- second: 1000
- minute: 60
- hour: 60
- day: 24


**DATETIME_FORMAT:** `yyyy-MM-ddTHH:mm:ss`


##    getDecimalTime    ##
`60` minute a hour son: `1`


##    `getDateTime` FirstDay and LastDay OfTheMonth    ##
- La fecha actual es: `2025-09-04T01:05:16`
- Primer dia del mes: `2025-09-01T00:00:00`
- Ultimo dia del mes: `2025-09-30T23:59:59`
