#    Probando todos los modulos    #
Aca veremos como se usan los modulos locos, por ejemplo, ve como jala `ShowPrint.inputContinue`:
Continuamos...


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
La resolucion de pantalla es: 1920x1080

#    Mostrar servidor grafico    #
El servidor grafico, es el que dibuja todo en pantalla, muy bonito.
El servidor grafico es: `x11`


--------------------------------------------------------------------------------------------------------------------------------


#    `TextUtil.readText`    #
array:
# Aca se determina que terminal por defecto abrir
linux_terminal=x-terminal-emulator
win_terminal=cmd.exe


list:
# Aca se determina que terminal por defecto abrir
linux_terminal=x-terminal-emulator
win_terminal=cmd.exe


dictionary:
0. # Aca se determina que terminal por defecto abrir
1. linux_terminal=x-terminal-emulator
2. win_terminal=cmd.exe


#    `TextUtil.ignoreComment`    #
Ejemplo 
Ejemplo Texto
